using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//使用换行符，默认在windows下
namespace CSharp_第三次作业
{
    //抽象图表接口：抽象产品类  
    public interface Graph
    {
       void acreage();
    }

     
    public class Triangle : Graph
    {

    public  Triangle()
    {
        Console.Write("*\r\n");
        Console.Write("**\r\n");
        Console.Write("***\r\n");
    }

    public void acreage()

    {
        Console.Write("这个三角形的面积是1.5\r\n");
    }

    }//三角形构建



    public class Cicular : Graph
    {
        public Cicular()//这里圆的半径为8
        {
            for (int i = 0; i < 8; i++)
            {
                int temp = (int)(2 * Math.Sqrt(2 * i * 8 - i * i));
                int t = 2 * 8 - temp - 1;
                for (int j = 0; j < t; j++)
                {
                    Console.Write(' ');
                }
                Console.Write('*');
                for (int j = 0; j < 2 * temp; j++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine('*');
            }
            for (int i = 8 - 2; i >= 0; i--)
            {
                int temp = (int)(2 * Math.Sqrt(2 * i * 8 - i * i));
                int t = 2 * 8 - temp - 1;
                for (int j = 0; j < t; j++)
                {
                    Console.Write(' ');
                }
                Console.Write('*');
                for (int j = 0; j < 2 * temp; j++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine('*');
            }
        }

        public void acreage()

        {
            Console.Write("这个圆形的面积是64π\r\n");
        }

    }//圆形构建


    public class Rectangle:Graph
    {
        public Rectangle()
        {
            Console.Write("********\r\n");
            Console.Write("********\r\n");
            Console.Write("********\r\n");
        }

        public void acreage()

        {
            Console.Write("这个长方形的面积是24\r\n");
        }
    }//长方形构建



    public class Square:Graph
    {
        public Square()
        {
            Console.Write("****\r\n");
            Console.Write("****\r\n");
            Console.Write("****\r\n");
            Console.Write("****\r\n");
        }

        public void acreage()

        {
            Console.Write("这个正方形的面积是16\r\n");
        }
    }//正方形构建


    public class factorymethod
    {
        public Graph CreateShow(string show)
        {
            switch (show.Trim().ToLower())
            {
                case "三角形":
                    return new Triangle();
                case "圆形":
                    return new Cicular();
                case "长方形":
                    return new Rectangle();
                case "正方形":
                    return new Square();
                default:
                    throw new Exception("没有这个图形");
            }
        }
    }//工厂类的构建




    class Program
    {
        static void Main(string[] args)
        {
            Graph tri;
            factorymethod triF = new factorymethod();
            tri = triF.CreateShow("三角形");
            tri.acreage();
        
            Graph cir;
            factorymethod cirF = new factorymethod();
            cir = cirF.CreateShow("圆形");
            cir.acreage();
          
            Graph rec;
            factorymethod recF = new factorymethod();
            rec = recF.CreateShow("长方形");
            rec.acreage();
          
            Graph squ;
            factorymethod squF = new factorymethod();
            squ = squF.CreateShow("正方形");
            squ.acreage();
          
        }






    }






















}
