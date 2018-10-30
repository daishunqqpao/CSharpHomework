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

namespace WINFORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderService os = new OrderService();
            string a = richTextBox2.Text;
            bool bol =os.Orderdelete(a);
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

        private void button4_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            OrderDetails p1 = new OrderDetails("1", "饺子", "张三", "10000");
            OrderDetails p2 = new OrderDetails("2", "包子", "李四", "20000");
            OrderDetails p3 = new OrderDetails("3", "馒头", "王五", "1000");
            List<OrderService> order = new List<OrderService>();
            order.Add(p1);
            order.Add(p2);
            order.Add(p3);
            if (p1.ordernum == a)
            {
           richTextBox1.Text = "订单号是：" + p1.ordernum + "   " + "货物名称是：" + p1.goodname + "      " + "客人名字是：" + p1.customername + "   " + "商品价格是：" + p1.ordervalue;
            }
            else
            {
                if (p2.ordernum == a)
                {
           richTextBox1.Text = "订单号是：" + p2.ordernum + "   " + "货物名称是：" + p2.goodname + "      " + "客人名字是：" + p2.customername +"   "+"商品价格是：" + p2.ordervalue;
                }
                else
                {
                    if (p3.ordernum == a)
                    {
           richTextBox1.Text = "订单号是：" + p3.ordernum + "   " + "货物名称是：" + p3.goodname + "      " + "客人名字是：" + p3.customername + "   " + "商品价格是：" + p3.ordervalue;
                    }
                    else {
                        richTextBox1.Text = "很遗憾，没有你的订单";
                    }
                }
            }
        }
    }
}
