using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOMEWORK4_2
{
    class Order
    {

    }
    class OrderDetails : OrderService
    {
        public string ordernum
        {
            get { return ordernum; }
            set { ordernum = value; }
        }
        public string goodname
        {
            get { return goodname; }
            set { goodname = value; }
        }
        public string customername
        {
            get { return customername; }
            set { customername = value; }
        }
        public OrderDetails(string ordernum,string goodname,string customername)
            {
            this.ordernum = ordernum;
            this.goodname = goodname;
            this.customername = customername;

             }

    }
    class OrderService
    {


  


        //将orderdetails对象放入该类集合




    }
    class Program
    {
        static void Main(string[] args)
        {
            string a = "", b = "", c = "",f="";
            OrderDetails p1 = new OrderDetails("1", "饺子", "张三");
            OrderDetails p2 = new OrderDetails("2", "包子", "李四");
            OrderDetails p3 = new OrderDetails("3", "馒头", "王五");
            List<OrderService> order = new List<OrderService>();
            order.Add(p1);
            order.Add(p2);
            order.Add(p3);
            //添加订单(如果不添加此订单则会在删除时产生异常）
            Console.WriteLine("请输入订单号：");
            a = Console.ReadLine();
            Console.WriteLine("请输入货物名称：");
            b = Console.ReadLine();
            Console.WriteLine("请输入客人姓名：");
            c = Console.ReadLine();
            OrderDetails pnew = new OrderDetails(a, b, c);
            order.Add(pnew);
            //删除订单
            try
            {

                order.Remove(p1);
                order.Remove(pnew);
            }
            catch
            {
                Console.WriteLine("删除订单出错啦！不存在新订单");
            }

            //查询订单
            Console.WriteLine("请输入你要查询的订单号:");
            f = Console.ReadLine();
            if (p1.ordernum == f || p2.ordernum == f || p3.ordernum == f || pnew.ordernum == f) 
            {
                Console.WriteLine("存在此订单");
            }
            else
            {
                Console.WriteLine("不存在此订单");
            }
            //修改订单
            try
            {
                Console.WriteLine("请输入新的订单号:");
                p2.ordernum = Console.ReadLine();
                Console.WriteLine("请输入新的货物名称：");
                p2.goodname = Console.ReadLine();
                Console.WriteLine("请输入新的客人名称：");
                p2.customername = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("修改订单失败");
            }

            







        }
    }
}
