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
            double num1, num2;
            Console.WriteLine("请输入第1个数字：");
            num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入第2个数字：");
            num2 = double.Parse(Console.ReadLine());
            Console.WriteLine(num1 * num2);
        }
    }
}
