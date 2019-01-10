using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace Hotel
{
    public partial class login_manage : Skin_VS
    {
        string username;
        public login_manage(string x)
        {
            InitializeComponent();
            show();
            username = x;
        }
        public void show()
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=User.accdb";
            string selectCmd = "Select [UserName] AS 用户名,[Password] AS 密码  From employee Order By [id] DESC";
            OleDbConnection conn;
            OleDbDataAdapter myAdapter;
            DataSet myDataSet = new DataSet();
            conn = new OleDbConnection(connstr);
            conn.Open();
            myAdapter = new OleDbDataAdapter(selectCmd, conn);
            myAdapter.Fill(myDataSet, "employee");
            dataGridView1.DataSource = myDataSet.Tables["employee"];
            conn.Close();
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            string connStr, updateCmd;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=User.accdb";
            updateCmd = "UPDATE employee set [UserName]=@用户名, [Password]=@密码 Where [UserName]=@用户名";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(updateCmd, conn);
            cmd = new OleDbCommand(updateCmd, conn);
            cmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@密码", OleDbType.Char));
            cmd.Parameters["@用户名"].Value = textBox1.Text;
            cmd.Parameters["@密码"].Value = textBox2.Text;
            string selectcmd = "Select * from [employee] where Username='" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(selectcmd, conn);
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("请将信息填写完整！");
            else if (command.ExecuteScalar() == null)
                MessageBox.Show("该用户不存在！");
            else
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                show();
                textBox1.Text ="" ;
                textBox2.Text = "";
                MessageBox.Show("修改成功！");
            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                Application.Exit();
            }
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            string connstr;
            connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=User.accdb";
            string selectCmd = "Select * From main where empower='" + textBox3.Text + "'";
            OleDbConnection conn = new OleDbConnection(connstr);
            conn.Open();
            OleDbCommand command = new OleDbCommand(selectCmd, conn);
            if (textBox3.Text == "")
                MessageBox.Show("请输入密码！");
            else if (command.ExecuteScalar() != null)
            {
                skinButton3.Visible = false;
                textBox3.Text = "";
                label3.Text = "新的授权密码：";
                label3.ForeColor = Color.Red;
                conn.Close();
                skinCheckBox1.Visible = true;
            }
            else
            {
                MessageBox.Show("密码错误，请重新输入！");
                textBox3.Text = "";
            }
        }

        private void skinButton4_Click(object sender, EventArgs e)
        {
            if (skinButton3.Visible == true)
                MessageBox.Show("请先验证授权密码");
            else
            {
                string connstr;
                connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=User.accdb";
                string updateCmd = "UPDATE main set [empower]=@授权密码 Where [name]=@管理员";
                OleDbConnection conn = new OleDbConnection(connstr);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(updateCmd, conn);
                cmd = new OleDbCommand(updateCmd, conn);
                cmd.Parameters.Add(new OleDbParameter("@授权密码", OleDbType.Char));
                if (textBox3.Text == "")
                    MessageBox.Show("授权密码不能为空！");
                else if (MessageBox.Show("是否确认修改？", "确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cmd.Parameters["@授权密码"].Value = textBox3.Text;
                    MessageBox.Show("修改成功！");
                }
            }
        }

        private void skinCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBox1.Checked == true)
                textBox3.UseSystemPasswordChar = false;
            else
                textBox3.UseSystemPasswordChar = true;
        }

        private void skinButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void skinCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBox2.Checked == true)
                textBox4.UseSystemPasswordChar = false;
            else
                textBox4.UseSystemPasswordChar = true;
        }

        private void skinButton6_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=User.accdb";
            string updateCmd = "UPDATE manager set  [Password]=@密码 Where [UserName]='" + username + "'";
            OleDbConnection conn = new OleDbConnection(connstr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(updateCmd, conn);
            cmd = new OleDbCommand(updateCmd, conn);   
            cmd.Parameters.Add(new OleDbParameter("@密码", OleDbType.Char));
            if (textBox4.Text == "")
                MessageBox.Show("密码不能为空！");
            else
            {
                cmd.Parameters["@密码"].Value = textBox4.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("修改成功！");                
            }
        }
    }
}
