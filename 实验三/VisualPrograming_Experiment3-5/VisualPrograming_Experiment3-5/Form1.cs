using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualPrograming_Experiment3_5
{
    public partial class Form1 : Form
    {
        int n = 0;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Location = new Point(this.Width, 133);
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (n % 4)
            {
                case 0:
                    pictureBox5.Image = pictureBox1.Image;
                    n++;
                    break;
                case 1:
                    pictureBox5.Image = pictureBox2.Image;
                    n++;
                    break;
                case 2:
                    pictureBox5.Image = pictureBox3.Image;
                    n++;
                    break;
                case 3:
                    pictureBox5.Image = pictureBox4.Image;
                    n = 0;
                    break;
            }
            if (pictureBox5.Location.X + pictureBox5.Width > 0)
                pictureBox5.Location = new Point(pictureBox5.Location.X - 10, 133);
            else
                pictureBox5.Location = new Point(this.Width, 133);
        }
    }
}
