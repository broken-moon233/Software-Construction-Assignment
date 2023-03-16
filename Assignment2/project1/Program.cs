using System;

/*
 * 编写程序输出用户指定数据的所有素数因子
 */

namespace project1
{
    public class Prime
    {
        public static void Main()
        {
            Console.WriteLine("please input a number:");
            var y = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= y; i++)
            {
                if ((y % i == 0) && IsPrime(i)) Console.WriteLine(i);
            }
        }
        private static bool IsPrime(int x)
        {
            if (x < 3) return true;
            else
            {
                for (int i = 2; i < x; i++)
                {
                    if (x % i == 0) return false;
                }
            }
            return true;
        }
    }

}
