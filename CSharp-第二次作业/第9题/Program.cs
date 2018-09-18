using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第9题
{
    class Program
    {
        static void Main(string[] args)
        {
            
                int[] num = new int[99];
                for (int i = 0; i <= 98; i++)
                {
                    num[i] = i + 2;
                }//储存数据
                for (int i = 2; i <= 50; i++)
                {
                    for (int j = 0; j <= 98; j++)
                    {
                        if (num[j] / i > 1 && num[j] % i == 0)
                        {
                            num[j] = 0;
                        }
                    }
                }//让全部倍数都变成0
                Console.WriteLine("2-100中的素数有：");
                for (int i = 0; i <= 98; i++)
                {
                    if (num[i] != 0)
                        Console.WriteLine(num[i]);
                }//输出需要的素数

            
        }
    }
}
