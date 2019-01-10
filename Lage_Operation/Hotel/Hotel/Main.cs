using CCWin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Hotel
{
    public partial class main : Form
    {
        ArrayList flag = new ArrayList();
        
        public static string week;
        int position,new_number;
        string bianhao;
        Boolean flag1 = true;
        Button but = new Button();
        public main(int posit,string id,int num)
        {
            InitializeComponent();
            weather();
            func();
            transfer();
            status();
            read_note();
            position = posit;
            bianhao = id;
            new_number = num+1;
            update();
            timer2.Enabled = true;
            timer2.Interval = 10;

        }
        public void weather()
        {
            string server = "www.baidu.com";
            Ping p = new Ping();
            PingReply pr;
            try
            {
                pr = p.Send(server);

                if (pr.Status == IPStatus.Success)
                {
                    cn.com.webxml.www.WeatherWebService w = new cn.com.webxml.www.WeatherWebService();
                    //把webservice当做一个类来操作  
                    string[] s = new string[23];//声明string数组存放返回结果  
                    string city = comboBox2.Text.Trim();//获得文本框录入的查询城市  
                    s = w.getWeatherbyCityName(city);
                    //以文本框内容为变量实现方法getWeatherbyCityName  
                    if (s[8] == "")
                    {
                        MessageBox.Show("暂时不支持您查询的城市");
                    }
                    else
                    {
                        label9.Text = "今日天气概况:" + s[5] + " " + s[6];
                        wind.Text = "风    向：" + s[7];
                        second.Text = "明天天气：" + s[12] + " " + s[13];
                        richTextBox1.Text = s[10];
                        third.Text = "后天天气：" + s[17] + " " + s[18];
                    }
                }
            }
            catch
            {
                MessageBox.Show("当前网络状态不可用！");
            }
            
        } 
        public void func()
        {
            string connStr;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Passenger.accdb";
            string selectcmd = "Select num from [accommodation] ";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand command = new OleDbCommand(selectcmd, conn);
            OleDbDataReader dr = command.ExecuteReader();  //查询获得所需的记录
            
            while (dr.Read())  //通过遍历读取
            {
                flag.Add( Convert.ToString( dr["num"]));
                //i++;
            }

        }

        public void transfer()
        {            
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Passenger.accdb";
            for (int i = 0; i < flag.Count; i++)
            {
                string selectcmd = "Select * from [accommodation] where num='" + flag[i] + "'";
                OleDbConnection conn = new OleDbConnection(connstr);
                conn.Open();
                OleDbCommand command = new OleDbCommand(selectcmd, conn);
                if (command.ExecuteScalar() != null)
                {
                    string a = "r" + flag[i];
                    but = (Button)this.Controls.Find(a, true)[0];
                    but.BackColor = Color.Coral;
                    but.Enabled = false;
                }
                else
                {
                    string a = "r" + flag[i];
                    but = (Button)this.Controls.Find(a, true)[0];
                    but.BackColor = Color.DarkGray;
                    but.Enabled = true;
                }
                conn.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {                            
            timer1.Interval = 1000;
            label2.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            string dt= DateTime.Now.DayOfWeek.ToString();
            
            switch (dt)
            {
                case "Monday":
                    week = "星期一";
                    break;
                case "Tuesday":
                    week = "星期二";
                    break;
                case "Wednesday":
                    week = "星期三";
                    break;
                case "Thursday":
                    week = "星期四";
                    break;
                case "Friday":
                    week = "星期五";
                    break;
                case "Saturday":
                    week = "星期六";
                    break;
                case "Sunday":
                    week = "星期日";
                    break;
            }
            label5.Text = week;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //customer cus = new customer();
            //cus.Show();        
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

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                Application.Exit();
            }            
        }

        private void room_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            string Attributes;

            if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                Attributes = "标准单人间";
                customer cus = new customer(btn.Text, btn.Name, Attributes,btn);
                
                cus.ShowDialog();
                func();
                status();                
            }
            else if(tabControl1.SelectedTab.Name == "tabPage2")
            {
                Attributes = "标准双人间";
                customer cus = new customer(btn.Text, btn.Name, Attributes,btn);
                
                cus.ShowDialog();
                func();
                status();
            }
            else
            {
                Attributes = "商务客房";
                customer cus = new customer(btn.Text, btn.Name, Attributes,btn);
                
                cus.ShowDialog();
                func();
                status();
            }
        }

        private void main_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (position == 0)
                MessageBox.Show("员工无法使用该功能！");
            else
            {
                information inf = new information();
                inf.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Passengerinfo passenger = new Passengerinfo();
            passenger.ShowDialog();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            string server = "www.baidu.com";
            Ping p = new Ping();
            PingReply pr;
            try
            {
                pr = p.Send(server);

                if (pr.Status == IPStatus.Success)
                {
                    cn.com.webxml.www.WeatherWebService w = new cn.com.webxml.www.WeatherWebService();
                    //把webservice当做一个类来操作  
                    string[] s = new string[23];//声明string数组存放返回结果  
                    string city = comboBox2.Text.Trim();//获得文本框录入的查询城市  
                    s = w.getWeatherbyCityName(city);
                    //以文本框内容为变量实现方法getWeatherbyCityName  
                    if (s[8] == "")
                    {
                        MessageBox.Show("暂时不支持您查询的城市");
                    }
                    else
                    {
                        label9.Text = "今日天气概况:" + s[5] + " " + s[6];
                        wind.Text = "风    向：" + s[7];
                        second.Text = "明天天气：" + s[12] + " " + s[13];
                        richTextBox1.Text = s[10];
                        third.Text = "后天天气：" + s[17] + " " + s[18];
                    }
                }
            }
            catch
            {
                MessageBox.Show("当前网络状态不可用！");
            }
        }
        public void status()
        {
            string[] arr = { "标准单人间", "标准双人间", "商务客房" };
            int num;
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Passenger.accdb";
            for (int i = 0; i <= 2; i++)
            {
                string selectcmd = "Select count(*) from [accommodation] where type='" + arr[i] + "'";
                OleDbConnection conn = new OleDbConnection(connstr);
                conn.Open();
                OleDbCommand command = new OleDbCommand(selectcmd, conn);
                
                num =Convert.ToInt32(command.ExecuteScalar());
                if (i == 0)
                {
                    label13.Text = num + " /" + 8;
                    conn.Close();
                }
                else if (i == 1)
                {
                    label15.Text = num + " /" + 8;
                    conn.Close();
                }
                else
                {
                    label17.Text = num + " /" + 8;
                    conn.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            exit ex = new exit();
            if (ex.ShowDialog() == DialogResult.OK)
            {
                transfer();
                status();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            entry en = new entry();
            en.Show();
            this.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (position == 0)
                MessageBox.Show("员工无法使用该功能！");
            else
            {
                login_manage lo = new login_manage(bianhao);
                lo.ShowDialog();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (flag1 == true)
            {
                label24.Left -= 1;                
                if (label24.Left <= 0)
                    flag1 = false;
            }
            else
            {
                label24.Left += 1;                
                if (label24.Right == 1180)
                    flag1 = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            this.Opacity = 0.5;
            fr.ShowDialog();
            this.Opacity = 1;
        }

        



        private void button8_Click_1(object sender, EventArgs e)
        {
            richTextBox2.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = richTextBox2.SelectionFont.Style;
            richTextBox2.SelectionFont = new Font("新宋体", richTextBox2.SelectionFont.Size + 1, fontStyle);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = richTextBox2.SelectionFont.Style;
            richTextBox2.SelectionFont = new Font("新宋体", richTextBox2.SelectionFont.Size - 1, fontStyle);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = richTextBox2.SelectionFont.Style;
            richTextBox2.SelectionFont = new Font(richTextBox2.SelectionFont, fontStyle ^ FontStyle.Bold);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ColorDialog ColorForm = new ColorDialog();
            if (ColorForm.ShowDialog() == DialogResult.OK)
            {
                Color GetColor = ColorForm.Color;
                //GetColor就是用户选择的颜色，接下来就可以使用该颜色了
                richTextBox2.SelectionColor = GetColor;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = richTextBox2.SelectionFont.Style;
            richTextBox2.SelectionFont = new Font(richTextBox2.SelectionFont, fontStyle ^ FontStyle.Underline);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Informationdb.accdb";
            string updateCmd = "UPDATE notepad Set [note]=@便签 Where [ID]=1";
            OleDbConnection conn = new OleDbConnection(connstr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(updateCmd, conn);
            cmd.Parameters.Add(new OleDbParameter("@便签", OleDbType.Char));
            cmd.Parameters["@便签"].Value = richTextBox2.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            richTextBox2.Enabled = false;
        }

        private void read_note()
        {
            string connStr;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Informationdb.accdb";
            string selectcmd = "Select [note] AS 便签 From notepad where [ID]=1" ;
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbDataAdapter myadapter = new OleDbDataAdapter(selectcmd, conn);
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset, "notepad");
            OleDbCommand command = new OleDbCommand(selectcmd, conn);
            richTextBox2.DataBindings.Clear();
            richTextBox2.DataBindings.Add("Text", mydataset, "notepad.便签");
            
            conn.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        public void  update()
        {
            if(position==0)
            {
                ///this.pictureBox1.Image = global::Hotel.Properties.Resources.员工;
                string sql = "Select touxiang From employee Where[UserName]='" + bianhao + "'";
                
                label23.Text = "亲爱的员工" + bianhao + "，您好!";
                label24.Text = "亲爱的员工" + bianhao + "，这是您第" + new_number + "次登陆该系统，祝您工作愉快~";
                string connStr, updateCmd;
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=User.accdb";
                updateCmd = "UPDATE employee Set [number]=@次数 where [UserName]='" + bianhao+"'";
                OleDbConnection conn = new OleDbConnection(connStr);
                conn.Open();

                OleDbCommand comm = new OleDbCommand(sql, conn);
                OleDbDataReader sdr = comm.ExecuteReader();
                sdr.Read();
                MemoryStream ms = new MemoryStream((byte[])sdr[0]);
                Image image = Image.FromStream(ms);
                sdr.Close();
                pictureBox1.Image = image;

                OleDbCommand cmd = new OleDbCommand(updateCmd, conn);
                cmd.Parameters.Add(new OleDbParameter("@次数", OleDbType.Integer));
                cmd.Parameters["@次数"].Value = new_number;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                string sql = "Select touxiang From manager Where[UserName]='" + bianhao + "'";
                ///this.pictureBox1.Image = global::Hotel.Properties.Resources.管理员;
                label23.Text = "尊敬的管理员" + bianhao + "，您好!";
                label24.Text = "尊敬的管理员" + bianhao + "，这是您第" + new_number + "次登陆该系统,祝您工作愉快~";
                string connStr, updateCmd;
                connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=User.accdb";
                updateCmd = "UPDATE manager Set [number]=@次数 where [UserName]='" + bianhao + "'";
                OleDbConnection conn = new OleDbConnection(connStr);
                conn.Open();

                OleDbCommand comm = new OleDbCommand(sql, conn);
                OleDbDataReader sdr = comm.ExecuteReader();
                sdr.Read();
                MemoryStream ms = new MemoryStream((byte[])sdr[0]);
                Image image = Image.FromStream(ms);
                sdr.Close();
                pictureBox1.Image = image;

                OleDbCommand cmd = new OleDbCommand(updateCmd, conn);
                cmd.Parameters.Add(new OleDbParameter("@次数", OleDbType.Integer));
                cmd.Parameters["@次数"].Value = new_number;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

    }
}

