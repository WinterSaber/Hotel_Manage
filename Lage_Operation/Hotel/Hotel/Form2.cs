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
using System.Runtime.InteropServices;
using CCWin;

namespace Hotel
{
    public partial class entry : Skin_VS
    {
        string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=User.accdb";
        SecurityCode securitycode;
        public entry()
        {
            InitializeComponent();
            securitycode = new SecurityCode(4);
        }

        public class Win32
        {
            public const Int32 AW_HOR_POSITIVE = 0x00000001; // 从左到右打开窗口
            public const Int32 AW_HOR_NEGATIVE = 0x00000002; // 从右到左打开窗口
            public const Int32 AW_VER_POSITIVE = 0x00000004; // 从上到下打开窗口
            public const Int32 AW_VER_NEGATIVE = 0x00000008; // 从下到上打开窗口
            public const Int32 AW_CENTER = 0x00000010; //若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展。
            public const Int32 AW_HIDE = 0x00010000; //隐藏窗口，缺省则显示窗口。
            public const Int32 AW_ACTIVATE = 0x00020000; //激活窗口。在使用了AW_HIDE标志后不要使用这个标志。
            public const Int32 AW_SLIDE = 0x00040000; //使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略。
            public const Int32 AW_BLEND = 0x00080000; //使用淡出效果。只有当hWnd为顶层窗口的时候才可以使用此标志。
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern bool AnimateWindow(
          IntPtr hwnd, // handle to window
              int dwTime, // duration of animation
              int dwFlags // animation type
              );
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            Win32.AnimateWindow(this.Handle, 2000, Win32.AW_BLEND);
            securitycode.UpdateVerifyCode();
            SecCodePic.Image = securitycode.getImage();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Click(object sender, EventArgs e)
        {

            if (username.Text == "" || passw.Text == "")
                MessageBox.Show("用户名或密码不能为空！");
            else if (textBox1.Text == "")
            {
                MessageBox.Show("验证码不能为空！");
            }
            else
            {
                OleDbConnection conn = new OleDbConnection(connstr);
                conn.Open();
                string selectcmd = "";

                if (employee.Checked)
                {
                    selectcmd = "Select * from [employee] where [UserName]='" + username.Text + "'";

                }
                if (manager.Checked)
                {
                    selectcmd = "Select * from [manager] where [UserName]='" + username.Text + "'";

                }
                OleDbCommand command = new OleDbCommand(selectcmd, conn);
                OleDbDataReader myreader = command.ExecuteReader();

                if (myreader.Read())
                {
                    if (this.passw.Text.Equals(myreader["Password"].ToString()) && securitycode.Check(textBox1.Text) == true)
                    {
                        this.Visible = false;
                        if (employee.Checked)
                        {
                            string selectcmd1 = "Select * from [employee] where [UserName]='" + username.Text + "'";
                            OleDbCommand command1 = new OleDbCommand(selectcmd1, conn);
                            OleDbDataReader myreader1 = command1.ExecuteReader();
                            myreader1.Read();
                            string bianhao = myreader1["UserName"].ToString();
                            string selectcmd2 = "Select * from [employee] where [UserName]='" + username.Text + "'";
                            OleDbCommand command2 = new OleDbCommand(selectcmd2, conn);
                            OleDbDataReader myreader2 = command2.ExecuteReader();
                            myreader2.Read();
                            int num = Convert.ToInt32(myreader2["number"].ToString());
                            MessageBox.Show("登陆成功，欢迎您使用！");
                            main t = new main(0, bianhao, num);
                            t.Show();
                            notifyIcon1.Visible = false;
                        }
                        if (manager.Checked)
                        {
                            string selectcmd1 = "Select * from [manager] where [UserName]='" + username.Text + "'";
                            OleDbCommand command1 = new OleDbCommand(selectcmd1, conn);
                            OleDbDataReader myreader1 = command1.ExecuteReader();
                            myreader1.Read();
                            string bianhao = myreader1["UserName"].ToString();
                            string selectcmd2 = "Select * from [manager] where [UserName]='" + username.Text + "'";
                            OleDbCommand command2 = new OleDbCommand(selectcmd2, conn);
                            OleDbDataReader myreader2 = command2.ExecuteReader();
                            myreader2.Read();
                            int num = Convert.ToInt32(myreader2["number"].ToString());
                            MessageBox.Show("登陆成功，欢迎您使用！");
                            main s = new main(1, bianhao, num);
                            s.Show();

                            notifyIcon1.Visible = false;
                        }
                    }
                    else if (securitycode.Check(textBox1.Text) == false)
                    {
                        MessageBox.Show("验证码错误！请重新输入");
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("密码错误！请重新输入");
                        this.passw.Text = "";
                    }
                }
                else
                {
                    this.username.Text = "";
                    this.passw.Text = "";
                    MessageBox.Show("该用户不存在，请注册！");
                }
                myreader.Close();
                conn.Close();
            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            register r = new register();
            r.ShowDialog();
            //在C#中窗口的显示有两种方式：模态显示（showdialog）和非模态显示（show）。
            //模态与非模态窗体的主要区别是窗体显示的时候是否可以操作其他窗体。模态窗体不允许操作其他窗体，非模态窗体可以操作其他窗体。
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon1.Visible = false;
            }
        }
        private void FormSizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Visible = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                Application.Exit();
            }
        }



        private void entry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Win32.AnimateWindow(this.Handle, 2000, Win32.AW_SLIDE | Win32.AW_HIDE | Win32.AW_BLEND);
        }

        private void SecCodePic_Click(object sender, EventArgs e)
        {
            securitycode.UpdateVerifyCode();
            SecCodePic.Image = securitycode.getImage();
        }

        private void entry_Load(object sender, EventArgs e)
        {

        }

        private void entry_Load_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("HOTEL");//获取指定的进程名   
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                MessageBox.Show("程序已启动！");
                Application.Exit();              //关闭系统
            }
            Win32.AnimateWindow(this.Handle, 2000, Win32.AW_BLEND);
            securitycode.UpdateVerifyCode();
            SecCodePic.Image = securitycode.getImage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "Hotel.chm";
            process.Start();
        }
    }
}
