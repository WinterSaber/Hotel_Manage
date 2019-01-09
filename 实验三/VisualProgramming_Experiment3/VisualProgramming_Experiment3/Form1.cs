using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualProgramming_Experiment3
{
    public partial class Form1 : Form
    {
        Boolean flag = true;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 10;
            label1.Text = "41162202-肖鹏波";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelposition.Text = "跑马灯位置：" + labelrun.Left;
            if(flag==true)
            {
                labelrun.Left -= 1;
                labeldirect.Text = "跑马灯当前方向：向左移";
                if (labelrun.Left <= 0)
                    flag = false;
            }
            else
            {
                labelrun.Left += 1;
                labeldirect.Text = "跑马灯当前方向：向右移";
                if (labelrun.Right==this.Width)
                    flag = true;
            }
        }
    }
}
