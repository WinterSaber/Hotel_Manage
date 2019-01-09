using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualPrograming_Experiment3_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            colorshow.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            labeltext.Text = "当前设置:RGB(" + trackBar1.Value.ToString() + "," +
                trackBar2.Value.ToString() + "," + trackBar3.Value.ToString() + ")";
            labelred.Text = trackBar1.Value.ToString();
            labelgreen.Text = trackBar2.Value.ToString();
            labelblue.Text = trackBar3.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            colorshow.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            labeltext.Text = "当前设置:RGB(" + trackBar1.Value.ToString() + "," +
                trackBar2.Value.ToString() + "," + trackBar3.Value.ToString() + ")";
            labelred.Text = trackBar1.Value.ToString();
            labelgreen.Text = trackBar2.Value.ToString();
            labelblue.Text = trackBar3.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            colorshow.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            labeltext.Text = "当前设置:RGB(" + trackBar1.Value.ToString() + "," +
                trackBar2.Value.ToString() + "," + trackBar3.Value.ToString() + ")";
            labelred.Text = trackBar1.Value.ToString();
            labelgreen.Text = trackBar2.Value.ToString();
            labelblue.Text = trackBar3.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            colorshow.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            labeltext.Text = "当前设置:RGB(" + trackBar1.Value.ToString() + "," +
                trackBar2.Value.ToString() + "," + trackBar3.Value.ToString() + ")";
           
        }
    }
}
