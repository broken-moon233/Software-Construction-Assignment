using System.Globalization;

/*
 用“埃氏筛法”求2~ 100以内的素数。2~ 100以内的数，
 先去掉2的倍数，再去掉3的倍数，再去掉4的倍数，
 以此类推...最后剩下的就是素数
 */

namespace project3
{
    public class IsPrime
    {
        public static void Main(string[] args)
        {
            int max = 100;
            int[] number = new int[max];
            for(int i = 2; i < max/2; i++)
            {
                for(int j = 2; j < max; j++)
                {
                    if (j % i == 0 && j / i > 1) number[j] = 1;
                }
            }
            for(int i = 2; i < max; i++)
            {
                if (number[i] == 0) System.Console.WriteLine(i);
            }
        }
    }
}