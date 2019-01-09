using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static ArrayList flag = new ArrayList();
        static void Main(string[] args)
        {
            string connStr;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Passenger.accdb";
            string selectcmd = "Select num from [accommodation] ";
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();



            OleDbCommand command = new OleDbCommand(selectcmd, conn);
            OleDbDataReader dr = command.ExecuteReader();  //查询获得所需的记录
            int i = 0;
            while (dr.Read())  //通过遍历读取
            {
                flag.Add(Convert.ToString(dr["num"]));
                i++;
            }

            Console.WriteLine(flag.Count);
            Console.WriteLine(i);
            

            int x;
                for ( x = 0; x <= flag.Count; x++)
                {
                    Console.WriteLine(x);
                    if (x == 2)
                         Console.WriteLine("hh");
                    
                   
                    
                }

            Console.ReadLine();
        }
        
    }

}
