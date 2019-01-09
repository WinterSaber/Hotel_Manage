using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualPrograming_Experiment3_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            timer1.Interval = 100;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }
        int count = 0;
        double seconds = 0;
        Color oncolor = Color.Yellow;
        Color offcolor = Color.Red;
        int[,] changecells =
        {
            {-1,-1,-1,-1,-1 },
            {1,2,4,5,-1 },
            {2,1,3,-1,-1 },
            {3,2,3,-1,-1 },
            {4,1,7,-1,-1 },
            {5,2,4,6,8 },
            {6,3,9,-1,-1 },
            {7,4,5,8,-1 },
            {8,7,9,-1,-1 },
            {9,5,6,8,-1 },

        };
        Button[] Buttons = new Button[10];
private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width * 2 - 100;
            int y = Screen.PrimaryScreen.WorkingArea.Right - this.Height * 2;
            start.Enabled = true;
            button1.Click += new EventHandler(Button_Click);
            button2.Click += new EventHandler(Button_Click);
            button3.Click += new EventHandler(Button_Click);
            button4.Click += new EventHandler(Button_Click);
            button5.Click += new EventHandler(Button_Click);
            button6.Click += new EventHandler(Button_Click);
            button7.Click += new EventHandler(Button_Click);
            button8.Click += new EventHandler(Button_Click);
            button9.Click += new EventHandler(Button_Click);
            Buttons[1] = button1;
            Buttons[2] = button2;
            Buttons[3] = button3;
            Buttons[4] = button4;
            Buttons[5] = button5;
            Buttons[6] = button6;
            Buttons[7] = button7;
            Buttons[8] = button8;
            Buttons[9] = button9;
            for (int i = 1; i <= 9; i++)
                Buttons[i].Enabled = false;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button btnHit = (Button)sender;  //将所点击的按钮赋给btnHit
            int No = int.Parse(btnHit.Text);
            for (int i = 0; i < 5; i++)
            {
                int X = changecells[No, i];
                if (X != -1)
                {
                    if (Buttons[X].BackColor == offcolor)
                        Buttons[X].BackColor = oncolor;
                    else
                        Buttons[X].BackColor = offcolor;
                }
            }
            count += 1;
            label3.Text = "点击次数:" + count.ToString();
            int sum = 0;
            for (int i = 1; i <= 9; i++)
            {
                if (Buttons[i].BackColor == oncolor)
                    sum += 1;
            }
            if (sum == 8 && Buttons[5].BackColor == offcolor)
            {
                start.Enabled = true;
                timer1.Enabled = false;
                seconds = 0;
                MessageBox.Show("恭喜过关");
                label2.Text = "时间：" + seconds.ToString();
                for (int i = 1; i <= 9; i++)
                {
                    Buttons[i].Enabled = false;
                }

            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            count = 0;
            timer1.Enabled = true;
            label3.Text = "点击次数： " + count.ToString();
            Random r = new Random();
            for (int i = 1; i <= 9; i++)
            {
                Buttons[i].Enabled = true;
                if (r.Next(1, 10) > 5)
                    Buttons[i].BackColor = oncolor;
                else
                    Buttons[i].BackColor = offcolor;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds +=0.1;
            label2.Text = "秒数：" + seconds.ToString("0.0")+"秒";

        }
    }
}
