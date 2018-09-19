using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = 99;
            int[] arr = new int[len];
            //初始化
            for (int i = 0; i < len; i++) {
                arr[i] = 2 + i;
            }

            
            int remainder = 0;  //余数
            int divisor = 2;    //除数
            int quotient = 1;   //商
            while (divisor < 50) {
                for (int j = 0; j < len; j++) {
                    remainder = arr[j]%divisor;
                    quotient = arr[j] / divisor;
                    if (quotient != 1 && remainder == 0) {
                        for (int k = j; k < len - 1; k++)
                        {
                            arr[k] = arr[k + 1];

                        }
                        len--;
                    }

                        
                }
                divisor++;
               
            }
            
           

            for (int i = 0; i < len; i++) {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
