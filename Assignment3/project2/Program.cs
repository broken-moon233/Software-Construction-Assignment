using System;
using project1;
namespace project2
{
    public class Factory
    {
        public static Rectangle MakeShape(string shapename, int width = 0, int hight = 0, int a = 0, int b = 0, int c = 0)
        {
            if(shapename == "Square")
            {
                return new Square(width);
            }
            else if(shapename == "Oblong")
            {
                return new Oblong(width, hight);
            }
            else if(shapename == "Triangle")
            {
                return new Triangle(a, b, c);
            }
            
            return null;
        }
    }

    public class Program
    { 
        public static void Main(string[] args)
        {
            Random op = new Random();
            Random a = new Random();
            Random b = new Random();
            Random c = new Random();
            double sumArea = 0;
            int sumLegal = 0;
            for(int i= 0; i < 10; i++)
            {
                switch (op.Next(1,4))
                {
                    case 1:
                        Rectangle square = Factory.MakeShape("Square", a.Next(0, 100));
                        Console.WriteLine("The " + square.ShapeName + " is " + square.IsLegal()
                            + " it's area is " + square.GetArea());
                        if (square.IsLegal())
                        {
                            sumLegal += 1;
                            sumArea += square.GetArea();
                        }
                        break;
                    case 2:
                        Rectangle oblong = Factory.MakeShape("Oblong", a.Next(0, 100), b.Next(0, 100));
                        Console.WriteLine("The " + oblong.ShapeName + " is " + oblong.IsLegal()
                            + " it's area is " + oblong.GetArea());
                        if (oblong.IsLegal())
                        {
                            sumLegal += 1;
                            sumArea += oblong.GetArea();
                        }
                        break;
                    case 3:
                        Rectangle triangle = Factory.MakeShape("Triangle", 0, 0, a.Next(0, 100), b.Next(0, 100), c.Next(0, 100));
                        Console.WriteLine("The " + triangle.ShapeName + " is " + triangle.IsLegal()
                            + " it's area is " + triangle.GetArea());
                        if (triangle.IsLegal())
                        {
                            sumLegal += 1;
                            sumArea += triangle.GetArea();
                        }
                        break;
                }
            }
            Console.WriteLine("There are " + sumLegal +" legal shapes. The sum of the areas is " + sumArea);
        }
    }
}