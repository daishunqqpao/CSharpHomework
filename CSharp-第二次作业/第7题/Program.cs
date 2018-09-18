using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第7题
{
    class Program
    {
        static void Main(string[] args)
        {
            
                int[] f = new int[5] { 123, 4, 234, 53, 4 };
                int max = f[0];
                int min = f[0];
                int sum = 0;
                for (int i = 0; i <= 4; i++)
                {
                    if (max < f[i])
                        max = f[i];
                    if (min > f[i])
                        min = f[i];
                    sum += f[i];
                }
                Console.WriteLine("最大值是：" + max);
                Console.WriteLine("最小值是：" + min);
                Console.WriteLine("平均值是：" + (double)sum / 5);
                Console.WriteLine("所有数组元素的和是：" + sum);
            
        }
    }
}
