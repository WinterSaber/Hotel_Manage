using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualPrograming_Experiment3_6
{
    public partial class Form1 : Form
    {
        string fontstyle = "宋体";
        int fontsize = 18;
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            fontstyle = "宋体";
            label1.Font=new Font(fontstyle, fontsize);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            fontstyle = "楷书";
            label1.Font = new Font(fontstyle, fontsize);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.LightBlue;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Yellow;
        }

        private void 红色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;
        }

        private void 深蓝色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.DarkBlue;
        }

        private void 深绿色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.LightGreen;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            fontsize = 10;
            label1.Font = new Font(fontstyle, fontsize);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            fontsize = 24;
            label1.Font = new Font(fontstyle, fontsize);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            fontsize = 36;
            label1.Font = new Font(fontstyle, fontsize);
        }
    }
}
