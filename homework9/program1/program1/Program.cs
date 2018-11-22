using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();

            string startUrl = "https://github.com/mysqljs/mysql";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl,false);
           
            Stopwatch timer = new Stopwatch();
            timer.Start();

            Parallel.Invoke(new Action[] { () => myCrawler.Crawl(100), () => myCrawler.Crawl(100) });
            //Thread thread1 = new Thread(() => myCrawler.Crawl(10000));
            //thread1.Start();
            //thread1.Join();
            timer.Stop();
            Console.WriteLine(timer.Elapsed.TotalMilliseconds);

        }
    }

    public class Crawler
    {
        internal Hashtable urls = new Hashtable();
        private int count = 0;
        protected internal void Crawl(int cnt)
        {
            Console.WriteLine("开始爬行了......");
            while(true)
            {
                string current = null;
                foreach(string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if((current == null)|| count > cnt)break;

                Console.WriteLine("爬行"+current+"页面！");

                string html = DownLoad(current);

                urls[current] = true;
                count++;
                Parse(html);

            }
            Console.WriteLine("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string filename = count.ToString();
                File.WriteAllText(filename,html,Encoding.UTF8);
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
            string strRef = @"(href|HREF)[]* = []*[""'][^""']+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('＂', '\'', '#', ' ', '>');
                if(strRef.Length == 0) continue;

                if (urls[strRef] == null) urls[strRef] = false;

            }
        }

    }
}
