using System;

namespace project4
{
    public class Toeplitz
    {
        public static void Main(string[] args)
        {
            int[,] matrix = null;
            matrix = new int[,] {
                { 1, 2, 3, 4 }, 
                { 5, 1, 2, 3},
                { 9, 5, 1, 2}
            };
            Console.WriteLine(IsToeplitz(matrix));

        }

        private static bool IsToeplitz(int[,] matrix) 
        {
            for(int i = 0; i < matrix.GetLength(0) - 1; i++) 
            {
                for(int j = 0; j < matrix.GetLength(1) - 1; j++) 
                {
                    if(matrix[i + 1, j + 1] != matrix[i, j]) 
                    {
                        return false;
                    }
                }
            }
            return true;

        }
    }
}