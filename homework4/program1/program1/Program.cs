using System;
using System.Timers;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace program1
{
    //public class ClockEventArgs : EventArgs
    //{
    //    public char a;
    //}
    public delegate void RingEventHandler(object sender);

    public class Clock
    {
        public int hour, mini, sec;
        public void setCloTime()
        {
            Console.WriteLine("请设定时间（小时）：");
            if (int.TryParse(Console.ReadLine(), out hour))
            {
                if (hour < 0 || hour > 23) { Console.WriteLine("输入错误"); return; }
            }
            else { return; }
            Console.WriteLine("请设定时间（分）：");
            if (int.TryParse(Console.ReadLine(), out mini))
            {
                if (mini < 0 || mini > 59) { Console.WriteLine("输入错误"); return; }
            }
            else { return; }
            Console.WriteLine("请设定时间（秒）：");
            if (int.TryParse(Console.ReadLine(), out sec))
            {
                if (sec < 0 || sec > 59) { Console.WriteLine("输入错误"); return; }
            }
            else { return; }
        }
        DateTime timeCur = DateTime.Now;
        public void isRightTime()
        {
            if (timeCur.Hour == hour) {
                if (timeCur.Minute == mini) {
                    if (timeCur.Second > sec) {
                    }
                    else { Console.WriteLine("输入错误"); return; }
                }
                else if (timeCur.Minute > mini) {
                    Console.WriteLine("输入错误"); return;
                }
            }
            else if (timeCur.Hour > hour)
            {
                Console.WriteLine("输入错误"); return;
            }
        }
        
        public event RingEventHandler Ringing;
        public void DoRing()
        {
            while (true){
                DateTime timeCur = DateTime.Now;
                System.Threading.Thread.Sleep(500);
                if (timeCur.Hour == hour && timeCur.Minute == mini && timeCur.Second == sec)
                {
                    break;
                }
            }
            Console.WriteLine("您设定的时间到了！");

            //ClockEventArgs args = new ClockEventArgs();
            //args.a = ' ';
            Ringing(this);




            //Timer timer = new Timer(1000);
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(RecordTim);
            //timer.AutoReset = true;
            //timer.Enabled = true;

        }
        
        
        
    }
    //static void RecordTim(object source, System.Timers.ElapsedEventArgs e)
    //{
    //    if(e.SignalTime.Hour == hour && )
    //    Console.WriteLine("您设定的时间到了！"); }   





    class Program
    {
        static void Main(string[] args)
        {
            var clock = new Clock();
            clock.setCloTime();
            clock.isRightTime();
            clock.DoRing();
        }
    }
}
