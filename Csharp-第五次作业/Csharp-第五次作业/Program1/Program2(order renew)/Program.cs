using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2_order_renew_
{
    class Order
    {

    }
    class OrderDetails : OrderService
    {
        public string ordernum
        {
            get;
            set;
        }
        public string goodname
        {
            get;
            set;
        }
        public string customername
        {
            get;
            set;
        }
        public double ordervalue
        {
            get;
            set;
        }
        public OrderDetails(string ordernum, string goodname, string customername, double ordervalue)
        {
            this.ordernum = ordernum;
            this.goodname = goodname;
            this.customername = customername;
            this.ordervalue = ordervalue;

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
            string a = "", b = "", c = "", e = "", f = "";
            OrderDetails p1 = new OrderDetails("1", "饺子", "张三", 10000);
            OrderDetails p2 = new OrderDetails("2", "包子", "李四", 20000);
            OrderDetails p3 = new OrderDetails("3", "馒头", "王五", 1000);
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
            Console.WriteLine("请输入订单价格：");
            e = Console.ReadLine();
            double d = double.Parse(e);
            OrderDetails pnew = new OrderDetails(a, b, c, d);
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
            try
            {
                //按照商品名称查询(linq)
                Console.WriteLine("请输入查询的商品名称:");
                string mm = Console.ReadLine();
                var n = from OrderDetails god in order
                        where god.goodname == mm
                        select god;

                foreach (var m in n)
                {
                    Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);


                }
                //按照客户名字查询（linq）
                Console.WriteLine("请输入查询的客户姓名:");
                string nn = Console.ReadLine();
                var sb = from OrderDetails god in order
                         where god.goodname == nn
                         select god;

                foreach (var m in sb)
                {
                    Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);
                }
                //按照订单号查询
                Console.WriteLine("请输入查询的订单号:");
                string pp = Console.ReadLine();                
                var bs = from OrderDetails god in order
                         where god.goodname == nn
                         select god;

                foreach (var m in bs)
                {
                    Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);
                }
                //查询订单金额大于1万元的订单
                var money = from OrderDetails god in order
                            where god.ordervalue >= 10000
                            select god;
                foreach(var m in money)
                {
                    Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);
                }
            }
            catch { }
        }
    }
}