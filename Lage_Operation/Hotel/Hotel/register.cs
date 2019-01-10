using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using CCWin;
using System.IO;

namespace Hotel
{
    
    public partial class register :Skin_VS
    {
        
        public int ensure;
        string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=User.accdb";
        public register()
        {
            InitializeComponent();
        }

        private void enroll_Click(object sender, EventArgs e)
        {
            string selectcmd = "";
            string selectcmd0 = "Select * from [main] where name='管理员'";
            if (employee.Checked)
                selectcmd = "Select * from [employee] where Username='" + username.Text + "'";
            if (manager.Checked)
                selectcmd = "Select * from [manager] where Username='" + username.Text + "'";
            OleDbConnection conn = new OleDbConnection(connstr);
            conn.Open();
            OleDbCommand command = new OleDbCommand(selectcmd, conn);

            OleDbCommand command0 = new OleDbCommand(selectcmd0, conn);
            OleDbDataReader myreader0 = command0.ExecuteReader();
            myreader0.Read();
            ensure = Convert.ToInt32 (myreader0["empower"]);
            if (this.username.Text.Trim() == null || this.passw.Text.Trim() == null)
                MessageBox.Show("用户名或密码不能为空！");
            else
            {
                if (command.ExecuteScalar() != null)
                {
                    MessageBox.Show("该用户已存在！");
                    this.username.Text = "";
                    this.passw.Text = "";
                    this.ensurepw.Text = "";
                }
                else
                {
                    string insertcmd = "";
                    if (employee.Checked)
                    {
                        insertcmd = "insert into employee([UserName],[Password]) values('" + username.Text + "','" + passw.Text + "')";
                        
                    }
                    if (manager.Checked)
                    {
                        insertcmd = "insert into manager([UserName],[Password]) values('" + username.Text + "','" + passw.Text + "')";
                        
                    }
                      
                    OleDbCommand command2 = new OleDbCommand(insertcmd, conn);

                    if (manager.Checked)
                    {
                        if (this.passw.Text.Trim() != this.ensurepw.Text.Trim())
                        {
                            MessageBox.Show("两次密码不一致，请重新输入！");
                            passw.Text = "";
                            ensurepw.Text = "";
                        }
                        else if(username.Text==""||passw.Text==""||ensurepw.Text==""||textempower.Text=="")
                        {
                            MessageBox.Show("请将信息补充完整！");
                        }
                        else if (ensure != Convert.ToInt32(textempower.Text))
                        {
                            MessageBox.Show("授权验证码错误！");
                            //this.passw.Text = "";
                            //this.ensurepw.Text = "";
                            this.textempower.Text = "";
                        }
                        else if (command2.ExecuteNonQuery() != -1 && ensure == Convert.ToInt32(textempower.Text))
                        {
                            MemoryStream stream = new MemoryStream();
                            byte[] photo = null;
                            Image img = this.pictureBox1.Image;
                            img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                            photo = stream.ToArray();
                            stream.Close();
                            string sql = "UPDATE manager set[touxiang] =@img where [username]='" + username.Text + "'";
                            OleDbCommand comm = new OleDbCommand(sql, conn);
                            comm.Parameters.Add("@img", OleDbType.VarBinary, photo.Length).Value = photo;
                            comm.ExecuteNonQuery();                            
                            MessageBox.Show("注册成功！");
                            this.Close();
                        }                       
                        else
                        {
                            MessageBox.Show("注册失败！");
                            this.passw.Text = "";
                            this.ensurepw.Text = "";
                        }
                    }
                    if (employee.Checked)
                    {
                        if (this.passw.Text.Trim() != this.ensurepw.Text.Trim())
                        {
                            MessageBox.Show("两次密码不一致，请重新输入！");
                            passw.Text = "";
                            ensurepw.Text = "";
                        }
                        else if (username.Text == "" || passw.Text == "" || ensurepw.Text == "" )
                        {
                            MessageBox.Show("请将信息补充完整！");
                        }
                        else if (command2.ExecuteNonQuery() != -1 )
                        {
                            MemoryStream stream = new MemoryStream();
                            byte[] photo = null;
                            Image img = this.pictureBox1.Image;
                            img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                            photo = stream.ToArray();
                            stream.Close();
                            string sql = "UPDATE employee set[touxiang] =@img where [username]='" + username.Text + "'";
                            OleDbCommand comm = new OleDbCommand(sql, conn);
                            comm.Parameters.Add("@img", OleDbType.VarBinary, photo.Length).Value = photo;
                            comm.ExecuteNonQuery();
                            MessageBox.Show("注册成功！");
                            this.Close();
                        }                   
                        else
                        {
                            MessageBox.Show("注册失败！");
                            this.passw.Text = "";
                            this.ensurepw.Text = "";
                        }
                    }
                }

            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manager_CheckedChanged(object sender, EventArgs e)
        {
            if(employee.Checked)
            {                
                empowerp.Visible = false;
                textempower.Visible = false;
            }
            else
            {
                MessageBox.Show("注册管理员，需要您提供授权密码！");
                empowerp.Visible = true;
                textempower.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            head_sculpture hea = new head_sculpture();
            hea.GetForm(this);
            hea.ShowDialog();

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = global::Hotel.Properties.Resources.管理员;
        }

        private void skinCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBox1.Checked == true)
                passw.UseSystemPasswordChar = false;
            else
                passw.UseSystemPasswordChar = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            DialogResult dr = open.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string imgpath = open.FileName;
                string s = imgpath.Substring(imgpath.IndexOf('.'));//截取图片后缀，例如.jpg
                if (s != ".jpg" && s != ".png" && s != ".gif"&& s != ".jpeg")
                {
                    MessageBox.Show("只能上传jpg,png,gif,jpeg格式的图片");
                    return;
                }
                Bitmap bmp = new Bitmap(open.FileName);
                int w = bmp.Width;//宽
                int h = bmp.Height;//高
                if(w==133&&h==133)
                {
                    MessageBox.Show("上传成功！");
                    string picName = Guid.NewGuid().ToString() + s;
                    this.pictureBox1.Image = Image.FromFile(imgpath);//显示图片           
                    File.Copy(open.FileName, Application.StartupPath + "\\image\\" + picName);
                }
                else
                {
                    MessageBox.Show("请将图片像素大小设置为133*133！");
                }
            }
        }
    }
}
