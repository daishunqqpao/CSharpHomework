using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_第二次作业
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("请输入一个大于或等于2的整数：");
            string a = Console.ReadLine();
            int n = Int32.Parse(a);
            //数据的输入
            int i = 2;
            Console.WriteLine("它的素数因子是：");
            for (i = 2; i <= n; i++)

                while (n % i == 0)
                {
                    Console.Write(i + "  ");

                    n /= i;

                }
        }
    }
}
