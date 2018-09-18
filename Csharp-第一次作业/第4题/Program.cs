using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第4题
{
    class Program
    {
        static void Main(string[] args)
        {
            string m = "";
            string n = "";
            double a = 0;
            double b = 0;
            Console.Write(value: "Please input a double:");
            m = Console.ReadLine();
            a = double.Parse(m);
            Console.Write("Please input another double:");
            n = Console.ReadLine();
            b = double.Parse(n);
            double c = a * b;
            Console.WriteLine("The product is:" + c);
        }
    }
}
