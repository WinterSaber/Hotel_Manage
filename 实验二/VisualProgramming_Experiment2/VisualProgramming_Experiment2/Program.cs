using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualProgramming_Experiment2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr=new int[5];
            for (int i = 0; i < 5; i++)
                arr[i]=Convert.ToInt32(Console.ReadLine());
            for (int j = 0; j < 5; j++)
                Console.Write(arr[j]);
            Console.Read();
        }
    }
}
