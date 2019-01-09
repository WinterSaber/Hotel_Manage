using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualPrograming_Experiment4_3
{
    public partial class Form1 : Form
    {
        private int oldX, oldY;
        Color pen_color;
        Bitmap bmp;    
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
            pen_color = new Color();
            pen_color = Color.Black;
            bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox2.Image = bmp;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            pen_color = pictureBox1.BackColor;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            pen_color = pictureBox1.BackColor;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            pen_color = pictureBox1.BackColor;
        }
        private void mousedown(object sender, MouseEventArgs e)
        {
            oldX = e.X;
            oldY = e.Y;           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox2.Image);
            g.Clear(Color.White);        
            g.Dispose();
            pictureBox2.Refresh();
        }

        private void mousemove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bmp);
                Pen pen = new Pen(pen_color, 3);
                g.DrawLine(pen, oldX, oldY, e.X, e.Y);
                pictureBox2.Image = bmp;
                oldX = e.X;
                oldY = e.Y;
                pictureBox2.Refresh();
            }
        }


    }
}
