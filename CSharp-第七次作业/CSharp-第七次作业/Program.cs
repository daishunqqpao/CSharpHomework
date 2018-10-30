using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Data;


namespace CSharp_第七次作业
{


    public class Order
    {

    }
    [Serializable]

    public class OrderDetails : OrderService
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
        public string ordervalue
        {
            get;
            set;
        }
        public OrderDetails()
        {


        }
        public OrderDetails(string ordernum, string goodname, string customername, string ordervalue)
        {
            this.ordernum = ordernum;
            this.goodname = goodname;
            this.customername = customername;
            this.ordervalue = ordervalue;

        }

    }


    [Serializable]
    [XmlInclude(typeof(OrderDetails))]//没这句话就会失败哦
    public class OrderService
    {

        public bool OrderFoundation(string a, string b, string c, string d)
        {

            OrderDetails p1 = new OrderDetails("1", "饺子", "张三", "10000");
            OrderDetails p2 = new OrderDetails("2", "包子", "李四", "20000");
            OrderDetails p3 = new OrderDetails("3", "馒头", "王五", "1000");
            List<OrderService> order = new List<OrderService>();
            order.Add(p1);
            order.Add(p2);
            order.Add(p3);
            OrderDetails pnew = new OrderDetails(a, b, c, d);
            order.Add(pnew);
            return true;
        }
        public bool OrderRenew(string a, string b,string c, string d)
        {
            OrderDetails p1 = new OrderDetails("1", "饺子", "张三", "10000");
            OrderDetails p2 = new OrderDetails("2", "包子", "李四", "20000");
            OrderDetails p3 = new OrderDetails("3", "馒头", "王五", "1000");
            List<OrderService> order = new List<OrderService>();
            order.Add(p1);
            order.Add(p2);
            order.Add(p3);
            p2.ordernum = a;
            p2.goodname = b;
            p2.customername = c;
            p2.ordervalue = d;
            return true;

        }
        public bool Orderdelete(string a)
        {
            OrderDetails p1 = new OrderDetails("1", "饺子", "张三", "10000");
            OrderDetails p2 = new OrderDetails("2", "包子", "李四", "20000");
            OrderDetails p3 = new OrderDetails("3", "馒头", "王五", "1000");
            List<OrderService> order = new List<OrderService>();
            order.Add(p1);
            order.Add(p2);
            order.Add(p3);
            if (p1.ordernum == a )
            {
                    order.Remove(p1);
                    return true;
            }
            else
            {
               if(p2.ordernum == a)
                {
                    order.Remove(p2);
                    return true;
                }else
                {
                    if(p3.ordernum == a)
                    {
                        order.Remove(p3);
                        return true;
                    }
                    else { return false; }
                }
            }
        }






        static void XmlSerialize(XmlSerializer ser, string filename, object obj)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }

        public bool Export(List<OrderService> m)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<OrderService>));
            string xmlFileName = "s.xml";
            FileStream fs = new FileStream(xmlFileName, FileMode.Create);
            xmlser.Serialize(fs, m);
            fs.Close();
            return true;
        }

        public bool Import(string filename)
        {
            FileStream fs = new FileStream("s.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<OrderService>));
            List<OrderService> p = (List<OrderService>)xs.Deserialize(fs);
            p.ForEach(m => Console.WriteLine(m.ToString()));
            fs.Close();
            return true;

        }
        //抽取部分代码作为测试函数
        public bool SearchByGName(List<OrderService> order, string mm)
        {//按照商品名称查询(linq)

            var n = from OrderDetails god in order
                    where god.goodname == mm
                    select god;

            foreach (var m in n)
            {
                Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);
 

            }
            return true;

        }
        public bool SearchByCName(List<OrderService> order, string nn)
        {
            //按照客户名字查询（linq）

            var sb = from OrderDetails god in order
                     where god.customername == nn
                     select god;

            foreach (var m in sb)
            {
                Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);
            }

            //将orderdetails对象放入该类集合
            return true;
        }
        public OrderService()
        {

        }


    }
    public class Program
    {
        static void Main(string[] args)
        {

            /*   string a = "", b = "", c = "", e = "", f = "";
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
                   Console.WriteLine("请输入新的订单价格：");
                   string monn = Console.ReadLine();
                   p2.ordervalue = double.Parse(monn);
               }
               catch
               {
                   Console.WriteLine("修改订单失败");
               }
               */
            //   try
            // {
            //按照商品名称查询(linq)----将其作为一个代表方法转移到类中
            // Console.WriteLine("请输入查询的商品名称:");
            //string mm = Console.ReadLine();
            //  var n = from OrderDetails god in order
            // where god.goodname == mm
            // select god;

            // foreach (var m in n)
            // {
            // Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);


            // }
            //按照客户名字查询（linq）
            //   Console.WriteLine("请输入查询的客户姓名:");
            // string nn = Console.ReadLine();
            /*var sb = from OrderDetails god in order
                     where god.customername == nn
                     select god;
            foreach (var m in sb)
            {
                Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);
            }*/
            //按照订单号查询
            // Console.WriteLine("请输入查询的订单号:");
            //string pp = Console.ReadLine();
            //var bs = from OrderDetails god in order
            //  where god.ordernum == pp
            //select god;

            //  foreach (var m in bs)
            //{
            // Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);
            // }
            //查询订单金额大于1万元的订单
            //   var money = from OrderDetails god in order
            // where god.ordervalue >= 10000
            //  select god;
            //   foreach (var m in money)
            //  {
            //Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);
            //  }
            //catch { }
            //调用XML的相关函数
            //  OrderService per = new OrderService();
            // per.Export(order);
            // per.Import("s.xml");
        }

    }
}
