using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Form1 : Form
    {
        Boolean textboxHasText = false;
        string password;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            button3.Visible = false;
            if (textBox1.Text == "")
            {
                textBox1.Text = "请输入临时锁屏密码...";
                textBox1.ForeColor = Color.LightGray;
                textboxHasText = false;
            }
            else
            {
                textboxHasText = true;              
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "请输入临时锁屏密码...")
                MessageBox.Show("请输入临时密码！");
            else
            {
                password = textBox1.Text;
                textBox1.Text = "";
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                if (textBox1.Text != "")
                {
                    textBox1.Text = "请输入临时锁屏密码...";
                    textBox1.ForeColor = Color.LightGray;
                    textboxHasText = false;
                }
                else
                {
                    textboxHasText = true;
                }
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "请输入临时锁屏密码...";
                textBox1.ForeColor = Color.LightGray;
                textboxHasText = false;                
            }
            else
                textboxHasText = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (password == textBox1.Text)
                this.Close();           
            else
            {
                if (i >= 3)
                    MessageBox.Show("若您忘记临时密码，请重新启动系统！");
                else
                {
                    MessageBox.Show("密码错误，请重新输入！");                    
                    i++;
                }
            }
        }
    }
}
