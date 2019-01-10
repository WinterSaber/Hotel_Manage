using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using CCWin;

namespace Hotel
{
    public partial class customer : Skin_VS
    {
        
        Button button = new Button();
        string room_num,room_name,room_arr;
        public customer(String text1,String text2,String text3,Button b)
        {
            InitializeComponent();
            this.room_num = text1;
            this.room_name = text2;
            room_arr = text3;
            button = b;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string connStr, insertCmd;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Passenger.accdb";
            insertCmd = "Insert Into accommodation([num], [type], [name], [peoplenum], [sex], [money], [deposit], [time]) Values(@房间号, @房间类型, @姓名, @身份证号, @性别, @缴纳金额, @押金, @入住时间)";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(insertCmd, conn);
            cmd.Parameters.Add(new OleDbParameter("@房间号", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@房间类型", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@姓名", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@身份证号", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@性别", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@缴纳金额", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@押金", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@时间", OleDbType.Char));
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                MessageBox.Show("请将住宿信息补充完整!");
            else
            {
                String sex;
                if (radioButton1.Checked)
                    sex = radioButton1.Text;
                else
                    sex = radioButton2.Text;
                cmd.Parameters["@房间号"].Value = textBox1.Text;
                cmd.Parameters["@房间类型"].Value = textBox6.Text;
                cmd.Parameters["@姓名"].Value = textBox2.Text;
                cmd.Parameters["@身份证号"].Value = textBox3.Text;
                cmd.Parameters["@性别"].Value = sex;
                cmd.Parameters["@缴纳金额"].Value = textBox5.Text;
                cmd.Parameters["@押金"].Value = textBox4.Text;
                cmd.Parameters["@时间"].Value = dateTimePicker1.Value;
                button.BackColor = Color.Coral;
                button.Enabled = false;
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();

            }
            
        }

        private void customer_Load(object sender, EventArgs e)
        {
            textBox1.Text = room_num;
            textBox6.Text = room_arr;
        }
    }
}
