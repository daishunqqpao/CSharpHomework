using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_第七次作业;
using MySql.Data.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;
namespace WINFORM
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderService os = new OrderService();
            string a = textBox1.Text;
            string b = textBox2.Text;
            string c = textBox3.Text;
            string d = textBox4.Text;
            OrderDetails p1 = new OrderDetails("1", "饺子", "张三", "10000");
            OrderDetails p2 = new OrderDetails("2", "包子", "李四", "20000");
            OrderDetails p3 = new OrderDetails("3", "馒头", "王五", "1000");
            List<OrderService> order = new List<OrderService>();
            order.Add(p1);
            order.Add(p2);
            order.Add(p3);
            using (var db = new Orderdb())
            {
                db.Order.Add(order);
                db.SaveChanges();
                bool bol = os.OrderRenew(p2, a, b, c, d);
                if (bol == true)
                {
                    Form4 f = new Form4();
                    f.ShowDialog();
                }
                else
                {
                    Form5 ff = new Form5();
                    ff.ShowDialog();
                }
            }
        }
        class Orderdb : DbContext
        {
            public Orderdb() : base("orderdb")
            {
            }
            public DbSet<List<OrderService>> Order { get; set; }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
