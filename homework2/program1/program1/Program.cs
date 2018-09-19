using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int num = 0;
            
            Console.WriteLine("请输入一个整数(不小于2)：");
            bool valid = int.TryParse(Console.ReadLine() , out num);
            bool isRange = (num >= 2);
            while (!(valid && isRange)) {
                Console.WriteLine("输入错误！请输入一个整数(不小于2)：");
                valid = int.TryParse(Console.ReadLine(), out num);
                isRange = (num >= 2);
            }
            Console.Write("该元素的所有素数因子为:");
            for (int i = 2; i <= num; i++)
                while (num % i == 0) {
                    Console.Write(i + "\t");
                    num /= i;
                }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
