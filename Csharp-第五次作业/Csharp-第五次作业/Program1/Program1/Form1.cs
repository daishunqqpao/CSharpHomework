using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (graphics == null) graphics = this.CreateGraphics();
                // string s = textBox1.Text;
                // double d = double.Parse(s);
                //double per2 = d;一直出错。。。无法强制转换获取文本值
                drawCayleyTree1(10, 200, 310, 100, -Math.PI / 2);
            }
            catch {  }
        }


        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        void drawCayleyTree1(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine1(x0, y0, x1, y1);
            drawCayleyTree1(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree1(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine1(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                Pens.Blue,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree2(10, 200, 310,100, -Math.PI / 2);

        }

        void drawCayleyTree2(int n, double x0, double y0,double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * 2 * Math.Cos(th);
            double y2 = y0 + leng * 2 * Math.Sin(th);
            drawLine2_1(x0, y0, x1, y1);
            drawCayleyTree2(n - 1, x1, y1, per1 * leng, th + th1);
           drawLine2_2(x0+10, y0+20, x2, y2);
            drawCayleyTree2(n - 1, x2, y2, per2 * leng, th-th2);
            
        }
    
        void drawLine2_1(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                Pens.Red,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }
        void drawLine2_2(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                Pens.Green,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

    }
}
