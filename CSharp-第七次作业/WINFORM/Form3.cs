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
           bool bol= os.OrderRenew(a, b, c, d);
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
}
