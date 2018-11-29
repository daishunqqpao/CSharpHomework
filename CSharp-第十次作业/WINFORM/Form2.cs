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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new Orderdb())
            {
                OrderService os = new OrderService();
                string a = textBox1.Text;
                string b = textBox2.Text;
                string c = textBox3.Text;
                string d = textBox4.Text;
                List<OrderService> order = new List<OrderService>();
                db.Order.Add(order);
                db.SaveChanges();
                bool bol = os.OrderFoundation(order, a, b, c, d);

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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        class Orderdb : DbContext
        {
            public Orderdb() : base("orderdb")
            {
            }
            public DbSet<List<OrderService>> Order { get; set; }

        }
    }
}
