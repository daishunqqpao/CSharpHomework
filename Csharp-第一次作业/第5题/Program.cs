using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;


public class WinInOut : Form
{
    /// <summary>
    /// 应用程序的主入口点。
    /// </summary>

    TextBox txt1 = new TextBox();
    TextBox txt2 = new TextBox();
    Button btn = new Button();
    Label lbl = new Label();
    public void init()
    {
        this.Controls.Add(txt1);
        this.Controls.Add(txt2);
        this.Controls.Add(btn);
        this.Controls.Add(lbl);
        txt1.Dock = System.Windows.Forms.DockStyle.Left;
        txt2.Dock = System.Windows.Forms.DockStyle.Right;
        btn.Dock = System.Windows.Forms.DockStyle.Fill;
        lbl.Dock = System.Windows.Forms.DockStyle.Bottom;
        btn.Text = "求乘积";
        lbl.Text = "用于显示结果的标签";
        this.Size = new System.Drawing.Size(300, 120);
        btn.Click += new System.EventHandler(this.button1_Click);
    }
    public void button1_Click(object sender, EventArgs e)
    {
        string a = txt1.Text;
        string b = txt2.Text;
        double c = double.Parse(a);
        double d = double.Parse(b);
        double product = c * d;
        lbl.Text = c + "与" + d + "的乘积是" + product;


    }
    static void Main()
    {
        WinInOut f = new WinInOut();
        f.Text = "计算乘积";
        f.init();
        Application.Run(f);
    }
}

