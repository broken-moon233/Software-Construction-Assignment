using System;
using System.Diagnostics.CodeAnalysis;

namespace project2
{
    public class Array
    {
        public static void Main()
        {
            int[] balance = { 100, 10, 30, 48, 1 };
            int max, min, ave,sum;
            sum = 0;
            max = balance[0];
            min = balance[0];
            for (int i = 0; i < 5; i++)
            {
                if(max < balance[i]) max = balance[i];
                if(min > balance[i]) min = balance[i];
                sum = sum + balance[i];
                
            }
            ave = sum / 5;
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine(ave);
            Console.WriteLine(sum);

        }
 

    }
}
