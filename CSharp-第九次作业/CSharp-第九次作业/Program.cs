using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
namespace CSharp_第九次作业
{
    public class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
   
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false); //加入初始页面
            new Thread(myCrawler.Crawl).Start(); //开始爬行

          new Thread(myCrawler.Crawl2).Start(); //开始爬行-优化


        }
        private void Crawl()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
         // Console.WriteLine("开始爬行了。。。。");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)   //找到一个还没有下载过的链接
                {
                    if ((bool)urls[url]) continue;  //已经下载过的，不再下载
                    current = url;
                }
                if (current == null || count > 10) break;
             // Console.WriteLine("爬行" + current + "页面！");
                string html = Download(current);//下载
                urls[current] = true;
                count++;
                Parse(html);
            }
        //   Console.WriteLine("爬行结束");
            stopWatch.Stop();
            Console.WriteLine("Normal run " + stopWatch.ElapsedMilliseconds + " ms.");//输出执行时间而已
        }
        private void Crawl2()//优化函数,嵌套循环就对外层循环进行并行处理，下载时候进行多线程
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            //Console.WriteLine("开始爬行了。。。。");
            Parallel.For(0, 11,(Ncount,ParallelLoopState)  =>
              {
                  string current = null;
                  foreach (string url in urls.Keys)   //找到一个还没有下载过的链接
                  {
                      if ((bool)urls[url]) continue;  //已经下载过的，不再下载
                      current = url;
                  }
                  if (current == null || Ncount > 10)
                  {
                      ParallelLoopState.Break();//这个线程达到停止要求了
                      return;
                  }
                  //Console.WriteLine("爬行" + current + "页面！");
                  string html = Download(current);//下载
                  urls[current] = true;

                  Parse(html);
    
              }

             );
           // Console.WriteLine("爬行结束");
            stopWatch.Stop();
            Console.WriteLine("ParallelFor run " + stopWatch.ElapsedMilliseconds + " ms.");//输出执行时间而已
        }
        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=')+1).Trim('"','\"','#',' ','>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
