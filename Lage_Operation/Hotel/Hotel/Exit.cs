using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class exit : Skin_VS
    {
        public main form = null;
        public exit()
        {
            InitializeComponent();
        }
        string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Passenger.accdb";
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            number.Items.Clear();
            if (type.Text == "标准单人间")
            {
                number.Items.Add("101");
                number.Items.Add("102");
                number.Items.Add("103");
                number.Items.Add("104");
                number.Items.Add("105");
                number.Items.Add("106");
                number.Items.Add("107");
                number.Items.Add("108");
            }
            if (type.Text == "标准双人间")
            {
                number.Items.Add("201");
                number.Items.Add("202");
                number.Items.Add("203");
                number.Items.Add("204");
                number.Items.Add("205");
                number.Items.Add("206");
                number.Items.Add("207");
                number.Items.Add("208");
            }
            if (type.Text == "商务客房")
            {
                number.Items.Add("301");
                number.Items.Add("302");
                number.Items.Add("303");
                number.Items.Add("304");
                number.Items.Add("305");
                number.Items.Add("306");
                number.Items.Add("307");
                number.Items.Add("308");
            }
        }
        public void GetForm(main theform)
        {
            form = theform;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (number.Text =="")
                MessageBox.Show("请选择房间号!");
            else
            {
                try
                {
                    string delcmd = "Delete From accommodation Where num='" + number.Text + "'";
                    string selectcmd = "Select * from [accommodation] where num='" + number.Text + "'";
                    OleDbConnection conn = new OleDbConnection(connstr);
                    conn.Open();
                    OleDbCommand mycmd = new OleDbCommand(delcmd, conn);
                    OleDbCommand command = new OleDbCommand(selectcmd, conn);
                    if (command.ExecuteScalar() == null)
                    {
                        MessageBox.Show("该房间并没有住宿！");
                    }
                    else
                    {
                        mycmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("退房成功！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("错误：" + ex.Message.ToString());
                }
            }
        }

        private void exit_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
