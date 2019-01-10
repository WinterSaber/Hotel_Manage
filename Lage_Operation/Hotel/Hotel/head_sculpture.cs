using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace Hotel
{
    public partial class head_sculpture : Skin_VS
    {
        public register form = null;
        public head_sculpture()
        {
            InitializeComponent();
        }

        public void GetForm(register theform)
        {
            form = theform;
        }

        public void picture_click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;                
            form.pictureBox1.Image = pic.Image;
            form.pictureBox1.Name = pic.Name;
            this.Close();
        }
    }
}
