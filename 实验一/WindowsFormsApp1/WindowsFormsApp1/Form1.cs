using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Please Choose A Button", "Hello", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.WindowState = FormWindowState.Maximized;
                this.BackColor = Color.Black;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.BackColor = Color.Blue;
            }
        }
    }    
}
