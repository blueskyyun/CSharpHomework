using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        { 
            int[] arr = {7, 90, 12, 56, 11, 17, 13, 56, 93, 21};
            
            
            //求数组的最大值
            int indexMax = 0;
            int tmpMax = arr[0];
            for (int i = 0; i < (arr.Length-1); i++) {
                if (tmpMax < arr[i + 1]) {
                    indexMax = i + 1;
                    tmpMax = arr[i + 1];
                }
                
            }
            Console.WriteLine("此数组的最大值为arr[" + indexMax + "] = "+ arr[indexMax]);
            //求数组的最小值
            int indexMin = 0;
            int tmpMin = arr[0];
            for (int i = 0; i < (arr.Length - 1); i++)
            {
                if (tmpMin > arr[i + 1])
                {
                    indexMin = i + 1;
                    tmpMin = arr[i + 1];
                }

            }
            Console.WriteLine("此数组的最大值为arr[" + indexMin + "] = " + arr[indexMin]);
            //求数组所有元素的和
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine("此数组的所有元素之和为：" + sum);
            //求平均值
            double avr = sum / (arr.Length + 0.0);
            Console.WriteLine("此数组的平均数为：" + avr.ToString("F4"));



        }
    }
}
