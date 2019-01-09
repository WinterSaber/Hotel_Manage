using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualPrograming_Experiment4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Textbox中的文本改变后,SelectionStart会置为0
            int loc = txtId.SelectionStart;
            txtId.Text = txtId.Text.ToUpper();//转换为大写
            txtId.SelectionStart = loc;            
        }
        private void keypress(object sender, KeyPressEventArgs e)
        {
            if (txtId.Text.Length <6)
            {
                if (txtId.SelectionStart == 0)
                {
                    string s = e.KeyChar.ToString().ToUpper();
                    if (string.Compare(s, "A") < 0 || string.Compare(s, "Z") > 0)
                        e.Handled = true;
                }
                else
                {
                    if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
                        e.Handled = true;
                }
            }
            else
            {
                if (e.KeyChar != '\b')
                    e.Handled = true;
            }
        }
    }
}
