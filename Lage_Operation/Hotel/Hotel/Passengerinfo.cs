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
using CCWin;

namespace Hotel
{
    public partial class Passengerinfo : Skin_VS
    {
        Boolean textboxHasText = false;
        public Passengerinfo()
        {
            InitializeComponent();
            showperson();
            if (textBox1.Text == "")
            {
                textBox1.Text = "请输入要查询的房间号...";
                textBox1.ForeColor = Color.LightGray;
                textboxHasText = false;
            }
            else
                textboxHasText = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Passenger.accdb";
            string selectcmd = "Select [num] AS 房间号 ,[type] AS 房间类型,[name] AS 姓名,[peoplenum] AS 身份证号,[sex] AS 性别,[money] AS 缴纳金额,[deposit] AS 押金,[time] AS 入住时间 From accommodation where [num]='" + textBox1.Text + "'";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand command = new OleDbCommand(selectcmd, conn);
            string selectcmd1 = "Select *  From accommodation where [num]='" + textBox1.Text + "'";
            OleDbCommand command1 = new OleDbCommand(selectcmd1, conn);
            OleDbDataReader myreader2 = command1.ExecuteReader();
            myreader2.Read();
            if (command.ExecuteScalar() == null)
            {
                MessageBox.Show("请输入准确的查询信息！");
            }
            else
            {
                OleDbDataAdapter myadapter = new OleDbDataAdapter(selectcmd, conn);
                DataSet mydataset = new DataSet();
                myadapter.Fill(mydataset, "accommodation");
                dataGridView1.DataSource = mydataset.Tables["accommodation"].DefaultView;
                DataView mydataview = new DataView();
                textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add("Text", mydataset, "accommodation.房间号");
                textBox6.DataBindings.Clear();
                textBox6.DataBindings.Add("Text", mydataset, "accommodation.房间类型");
                textBox3.DataBindings.Clear();
                textBox3.DataBindings.Add("Text", mydataset, "accommodation.姓名");
                textBox7.DataBindings.Clear();
                textBox7.DataBindings.Add("Text", mydataset, "accommodation.身份证号");
                
                
                if (myreader2["sex"].ToString()=="女")
                    radioButton2.Checked = true;
                else
                    radioButton1.Checked = true;
                textBox5.DataBindings.Clear();
                textBox5.DataBindings.Add("Text", mydataset, "accommodation.缴纳金额");
                textBox4.DataBindings.Clear();
                textBox4.DataBindings.Add("Text", mydataset, "accommodation.押金");
                //textBox9.DataBindings.Clear();
                //textBox9.DataBindings.Add("Value", mydataset, "accommodation.时间");
            }
            conn.Close();
        }

        private void showperson()
        {
            string connStr, selectCmd;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Passenger.accdb";
            selectCmd = "Select [num] AS 房间号 ,[type] AS 房间类型,[name] AS 姓名,[peoplenum] AS 身份证号,[sex] AS 性别,[money] AS 缴纳金额,[deposit] AS 押金,[time] AS 入住时间 From accommodation  Order By num ASC";
            OleDbConnection conn;
            OleDbDataAdapter myAdapter;
            DataSet myDataSet = new DataSet();
            conn = new OleDbConnection(connStr);
            conn.Open();
            myAdapter = new OleDbDataAdapter(selectCmd, conn);
            myAdapter.Fill(myDataSet, "accommodation");
            dataGridView1.DataSource = myDataSet.Tables["accommodation"];
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "请输入要查询的房间号...";
                textBox1.ForeColor = Color.LightGray;
                textboxHasText = false;
                showperson();
            }
            else
                textboxHasText = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connStr, updateCmd;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Passenger.accdb";
            updateCmd = "UPDATE accommodation Set [num]=@房间号 ,[type]=@房间类型,[name]=@姓名,[peoplenum]=@身份证号,[sex]=@性别,[money]=@缴纳金额,[deposit]=@押金 Where [num]=@房间号";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(updateCmd, conn);
            cmd.Parameters.Add(new OleDbParameter("@房间号", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@房间类型", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@姓名", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@身份证号", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@性别", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@缴纳金额", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@押金", OleDbType.Char));
            //cmd.Parameters.Add(new OleDbParameter("@入住时间", OleDbType.Char));
            
            cmd.Parameters["@房间号"].Value = textBox2.Text;
            cmd.Parameters["@房间类型"].Value = textBox6.Text;
            if (radioButton1.Checked)
                cmd.Parameters["@性别"].Value = radioButton1.Text;
            else
                cmd.Parameters["@性别"].Value = radioButton2.Text;
            cmd.Parameters["@姓名"].Value = textBox3.Text;
            cmd.Parameters["@身份证号"].Value = textBox7.Text;
            cmd.Parameters["@缴纳金额"].Value = textBox5.Text;
            cmd.Parameters["@押金"].Value = textBox4.Text;
            
            string selectCmd = "Select [num]  From accommodation WHERE num= '" + textBox2.Text + "'";
            OleDbCommand command = new OleDbCommand(selectCmd, conn);
            if (textBox2.Text == "")
                MessageBox.Show("请务必输入房间号！");
            else if (command.ExecuteScalar() == null)
            {
                MessageBox.Show("该房间号不存在，请重新输入！");
                textBox2.Text = "";
            }
            else
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                showperson();
                MessageBox.Show("修改成功！");
            }
        }
    }
}
