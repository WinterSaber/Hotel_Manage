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
    public partial class information : Skin_VS
    {
        public information()
        {
            InitializeComponent();
            showperson();
            if (textBox1.Text == "")
            {
                textBox1.Text = "请输入要查询的员工姓名...";
                textBox1.ForeColor = Color.LightGray;
                textboxHasText = false;
            }
            else
                textboxHasText = true;
            
        }

        private void information_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }


        Boolean textboxHasText = false;
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
                textBox1.Text = "请输入要查询的员工姓名...";
                textBox1.ForeColor = Color.LightGray;
                textboxHasText = false;
                showperson();
            }
            else
                textboxHasText = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Informationdb.accdb";
            string selectcmd = "Select [id] AS 编号,[name] AS 姓名,[sex] AS 性别,[age] AS 年龄,[department] AS 部门,[position] AS 职位,[tel] AS 电话,[address] AS 地址 From PERSON where [name]='" + textBox1.Text + "'";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand command = new OleDbCommand(selectcmd, conn);
            string selectcmd1 = "Select *  From PERSON where [name]='" + textBox1.Text + "'";
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
                myadapter.Fill(mydataset, "PERSON");
                dataGridView1.DataSource = mydataset.Tables["PERSON"].DefaultView;
                DataView mydataview = new DataView();
                textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add("Text", mydataset, "PERSON.编号");
                textBox6.DataBindings.Clear();
                textBox6.DataBindings.Add("Text", mydataset, "PERSON.姓名");
                
                if (myreader2["sex"].ToString() == "女")
                    radioButton2.Checked = true;
                else
                    radioButton1.Checked = true;
               
                textBox7.DataBindings.Clear();
                textBox7.DataBindings.Add("Text", mydataset, "PERSON.年龄");
                textBox9.DataBindings.Clear();
                textBox9.DataBindings.Add("Text", mydataset, "PERSON.部门");
                textBox5.DataBindings.Clear();
                textBox5.DataBindings.Add("Text", mydataset, "PERSON.职位");
                textBox4.DataBindings.Clear();
                textBox4.DataBindings.Add("Text", mydataset, "PERSON.电话");
                textBox8.DataBindings.Clear();
                textBox8.DataBindings.Add("Text", mydataset, "PERSON.地址");
            }
            
            
        }
        private void showperson()
        {
            string connStr, selectCmd;          
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Informationdb.accdb";
            selectCmd = "Select [id] AS 编号,[name] AS 姓名,[sex] AS 性别,[age] AS 年龄,[department] AS 部门,[position] AS 职位,[tel] AS 电话,[address] AS 地址 From PERSON  Order By id ASC";
            OleDbConnection conn;
            OleDbDataAdapter myAdapter;
            DataSet myDataSet = new DataSet();
            conn = new OleDbConnection(connStr);
            conn.Open();
            myAdapter = new OleDbDataAdapter(selectCmd, conn);
            myAdapter.Fill(myDataSet,"PERSON");
            dataGridView1.DataSource = myDataSet.Tables["PERSON"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connStr, selectCmd,insertCmd;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Informationdb.accdb";
            
            insertCmd = "Insert Into PERSON([id],[name], [sex], [age], [department], [position], [tel], [address]) Values(@编号, @姓名, @性别, @年龄, @部门, @职位, @电话, @地址)";
            OleDbConnection conn = new OleDbConnection(connStr);
            
            conn.Open();
            
            OleDbCommand cmd = new OleDbCommand(insertCmd, conn);
            cmd.Parameters.Add(new OleDbParameter("@编号", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@姓名", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@性别", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@年龄", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@部门", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@职位", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@电话", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@地址", OleDbType.Char));
            cmd.Parameters["@编号"].Value = textBox2.Text;            
            cmd.Parameters["@姓名"].Value = textBox6.Text;
            if(radioButton1.Checked)
                cmd.Parameters["@性别"].Value = radioButton1.Text;
            else
                cmd.Parameters["@性别"].Value = radioButton2.Text;
            cmd.Parameters["@年龄"].Value = textBox7.Text;
            cmd.Parameters["@部门"].Value = textBox9.Text;
            cmd.Parameters["@职位"].Value = textBox5.Text;
            cmd.Parameters["@电话"].Value = textBox4.Text;
            cmd.Parameters["@地址"].Value = textBox8.Text;

            selectCmd = "Select [id]  From PERSON WHERE id= '" + textBox2.Text + "'";
            OleDbCommand command = new OleDbCommand(selectCmd, conn);

            if (textBox2.Text == ""  || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
                MessageBox.Show("请将信息补充完整！");
            else if (command.ExecuteScalar() != null)
            {
                MessageBox.Show("不能添加编号相同的员工，请重新输入！");
                textBox2.Text = "";
            }
            else
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                showperson();
                MessageBox.Show("添加成功！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connStr, updateCmd;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Informationdb.accdb";
            updateCmd = "UPDATE PERSON Set [id]=@编号, [name]=@姓名,[sex]=@性别,[age]=@年龄,[department]=@部门,[position]=@职位,[tel]=@电话, [address]=@地址 Where [id]=@编号";    
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(updateCmd, conn);
            cmd.Parameters.Add(new OleDbParameter("@编号", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@姓名", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@性别", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@年龄", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@部门", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@职位", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@电话", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@地址", OleDbType.Char));
            cmd.Parameters["@编号"].Value = textBox2.Text;
            cmd.Parameters["@姓名"].Value = textBox6.Text;
            if (radioButton1.Checked)
                cmd.Parameters["@性别"].Value = radioButton1.Text;
            else
                cmd.Parameters["@性别"].Value = radioButton2.Text;
            cmd.Parameters["@年龄"].Value = textBox7.Text;
            cmd.Parameters["@部门"].Value = textBox9.Text;
            cmd.Parameters["@职位"].Value = textBox5.Text;
            cmd.Parameters["@电话"].Value = textBox4.Text;
            cmd.Parameters["@地址"].Value = textBox8.Text;
            string selectCmd = "Select [id]  From PERSON WHERE id= '" + textBox2.Text + "'";
            OleDbCommand command = new OleDbCommand(selectCmd, conn);
            if (textBox2.Text == "" )
                MessageBox.Show("请务必输入编号！");
            else if (command.ExecuteScalar() == null)
            {
                MessageBox.Show("该编号不存在，请重新输入！");
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
        string GetSqlStr(string str)
        {
            return str.Replace("'", "''");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string connStr, delCmd;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Informationdb.accdb";
            delCmd = "Delete From PERSON Where id = '" + GetSqlStr(textBox2.Text) + "'";
            string selectCmd = "Select [id]  From PERSON WHERE id= '" + textBox2.Text + "'";
            
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand command = new OleDbCommand(selectCmd, conn);
            OleDbCommand cmd = new OleDbCommand(delCmd, conn);
            if (textBox2.Text == "")
                MessageBox.Show("请务必输入编号！");
            else if (command.ExecuteScalar() == null)
            {
                MessageBox.Show("该编号不存在，请重新输入！");
                textBox2.Text = "";
            }
            else
            {
                cmd.ExecuteNonQuery();
                conn.Close();
                showperson();
                MessageBox.Show("删除成功！");
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";            
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }


    }
}
