using System;
using project1;
namespace project2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random op = new Random();
            Random a = new Random();
            Random b = new Random();
            Random c = new Random();
            for(int i= 0; i < 10; i++)
            {
                switch (op.Next(1,4))
                {
                    case 1:
                        Square square = new Square(a.Next(0, 100));
                        Console.WriteLine("The " + square.ShapeName + " is " + square.IsLegal()
                            + " it's area is " + square.GetArea());
                        break;
                    case 2:
                        Oblong oblong = new Oblong(a.Next(0, 100), b.Next(0, 100));
                        Console.WriteLine("The " + oblong.ShapeName + " is " + oblong.IsLegal()
                            + " it's area is " + oblong.GetArea());
                        break;
                    case 3:
                        Triangle triangle = new Triangle(a.Next(0,100), b.Next(0,100), c.Next(0,100));
                        Console.WriteLine("The " + triangle.ShapeName + " is " + triangle.IsLegal()
                            + " it's area is " + triangle.GetArea());
                        break;
                }
            }
        }
    }
}