using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualPrograming_experiment3_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label lab = new Label();
            this.Controls.Add(lab);
            lab.Width = 300;
            lab.Height = 50;
            lab.BackColor = Color.Aqua;
            lab.Text = "这是第一个窗口！";
            lab.AutoSize = true;
            lab.Font = new Font("宋体", 30);
            lab.ForeColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm = new Form2();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();           
        }
    }
}
