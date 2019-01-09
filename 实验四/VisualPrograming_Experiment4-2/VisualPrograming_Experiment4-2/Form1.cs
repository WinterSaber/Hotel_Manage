using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualPrograming_Experiment4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "X坐标:"+pictureBox5.Left;
            label2.Text = "Y坐标:" + pictureBox5.Top;
            pictureBox5.Image = pictureBox1.Image;
            pictureBox1.Visible = false;       
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label3.Text = "按上下左右键以控制坦克的移动！";
        }
        private void keydown(object sender,KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    pictureBox5.Image = pictureBox1.Image;
                    if ((pictureBox5.Top + pictureBox5.Height) <= 0)
                        pictureBox5.Top = this.Height;
                    else
                        pictureBox5.Top -= 10;
                    break;
                case Keys.Down:
                    pictureBox5.Image = pictureBox2.Image;
                    if (pictureBox5.Top > this.Height)
                        pictureBox5.Top = 0-pictureBox5.Height;
                    else
                        pictureBox5.Top += 10;
                    break;
                case Keys.Left:
                    pictureBox5.Image = pictureBox3.Image;
                    if ((pictureBox5.Left + pictureBox5.Width) <= 0)
                        pictureBox5.Left = this.Width;
                    else
                        pictureBox5.Left -= 10;
                    break;
                case Keys.Right:
                    pictureBox5.Image = pictureBox4.Image;
                    if (pictureBox5.Left > this.Width) 
                        pictureBox5.Left =0- pictureBox5.Width;
                    else
                        pictureBox5.Left += 10;
                    break;
            }
            label1.Text = "X坐标：" + pictureBox5.Left;
            label2.Text = "Y坐标：" + pictureBox5.Top;
            label3.Text = "现在按下" + e.KeyCode.ToString() + "键，键值为" + Convert.ToInt32(e.KeyCode)+"。";
        }
        private void keyup(object sender, KeyEventArgs e)
        {
            label3.Text = "按上下左右键以控制坦克的移动！";
        }
    }
}
