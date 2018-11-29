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
using MySql.Data.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;


namespace CSharp_第七次作业
{
    class Orderdb : DbContext
    {
        public Orderdb() : base("orderdb")
        {
        }
        public DbSet<List<OrderService>> Order { get; set; }

    }

    public class Order
    {

    }
    
    public class OrderDetails : OrderService
    {
        [Key]
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



    public class OrderService
    {

        public bool OrderFoundation(List<OrderService> order, string a, string b, string c, string d)
        {
            using (var db = new Orderdb())
            { 
            try
            {
                    OrderDetails p1 = new OrderDetails("1", "饺子", "张三", "10000");
                    OrderDetails p2 = new OrderDetails("2", "包子", "李四", "20000");
                    OrderDetails p3 = new OrderDetails("3", "馒头", "王五", "1000");
                    order.Add(p1);
                    order.Add(p2);
                    order.Add(p3);
                    OrderDetails pnew = new OrderDetails(a, b, c, d);
                    order.Add(pnew);
                    db.Order.Add(order);
                    db.SaveChanges();
                    return true;
            }

            catch { return false; }
        }
        }
        public bool OrderRenew(OrderDetails p2,  string a, string b, string c, string d)
        {
            using (var db = new Orderdb())
            {
                try
                { 
   
                    p2.ordernum = a;
                    p2.goodname = b;
                    p2.customername = c;
                    p2.ordervalue = d;
                    db.Entry<OrderDetails>(p2).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;

                }
            catch { return false; }

            }
        }
        public bool Orderdelete(List<OrderService> order ,string a)
        {
            using (var db = new Orderdb())
            {
                try
                {
                    var n = from OrderDetails god in order
                            where god.ordernum == a
                            select god;

                    foreach (var m in n)
                    {
                        db.Entry<OrderDetails>(m).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                    }
                    return true;
                }
                catch { return false; }
            }
        }

        public bool SearchByONum(List<OrderService> order, string mm)
        {//按照商品名称查询(linq)

            var n = from OrderDetails god in order
                    where god.ordernum == mm
                    select god;

            foreach (var m in n)
            {
                Console.WriteLine(m.ordernum + m.goodname + m.customername + m.ordervalue);


            }
            return true;

        }




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
    class DbContext : System.Data.Entity.DbContext
    {
        private string v;

        public DbContext(string v)
        {
            this.v = v;
        }

        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {


        }

    }
}
