using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_自定义闹钟
{
    

   
        public delegate void InformHandle(object sender);
        public class CurrentTimeSetandJudge
        {
            public event InformHandle Timenow;

            public void Time(int hour,int minute)
            {
                int wait = hour * 3600 + minute * 60;
                int systemswait = wait * 1000;
                int m = DateTime.Now.Hour;
                int n = DateTime.Now.Minute;
                 Console.WriteLine("约定时间还没有到，安心休息吧~");
            while (hour != m)
            {
                int a = DateTime.Now.Hour;
                m = a;
            }
            while(minute!=n)
            {
                int b = DateTime.Now.Minute;
                n = b;

            }
                Ontime();//这个相当于是一个信号，当运行这个函数的时候会发出一个信号。
            }
            public virtual void Ontime()
            {
                if (Timenow != null)
                {
                    Timenow(this);
                }
            }
        }
        public class AlarmLauch
        {
            public  void WakeYouUp(object sender)
            {
                Console.WriteLine("起来啦！！！！！！！！！！！！！！！！！！！！！！");
            }

        }
        class Program
        {
            static void Main(string[] args)
        {
            string hour = "";
            string minute = "";
            CurrentTimeSetandJudge a = new CurrentTimeSetandJudge();
            AlarmLauch b = new AlarmLauch();
            a.Timenow += new InformHandle(b.WakeYouUp);
            Console.WriteLine("请先输入你想几时起来：(输完后得到提示之后再输入分钟,24小时制）");   
            hour= Console.ReadLine();
            int n = int.Parse(hour);
            Console.WriteLine("知道啦！请再输入你几分钟起来：");
            minute = Console.ReadLine();
            int m = int.Parse(minute);
            a.Time(n, m);
            Console.ReadKey();

        }

         }
}
