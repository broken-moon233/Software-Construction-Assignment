using System;

namespace project1
{
    public abstract class Rectangle
    {
        private int width;
        public int Width { get; set; }
        private int height;
        public int Height { get; set; }
        public int Area { get; set; }
        private string shapename;
        public string ShapeName { get; set; }

        public virtual double GetArea()
        {
            if (IsLegal())
            {
                return Width * Height;
            }
            return 0;
            
        }
        public virtual bool IsLegal()
        {
            return true;
        }
    }
    
    public class Square : Rectangle
    {
        public Square(int side) 
        {
            this.Width = side;
            this.Height = side;
            this.ShapeName = "Square";
        }

        public override bool IsLegal()
        {
            if(Height> 0 && Width > 0 && Height == Width)
            {
                return true;
            }

            return false;
        }
    }
    
    public class Oblong : Rectangle
    {

        public Oblong(int width, int height) 
        {
            this.Width = width;
            this.Height = height;
            this.ShapeName = "Oblong";
        }

        public override bool IsLegal()
        {
            if(Height> 0 && Width > 0 && Height != Width)
            {
                return true;
            }
            return false;
        }
    }
    
    public class Triangle : Rectangle
    {
        private int Sidea, Sideb, Sidec;

        public Triangle(int a, int b, int c) 
        {
            this.Sidea = a;
            this.Sideb = b;
            this.Sidec = c;
            this.ShapeName = "Triangle";
        }
        public override double GetArea()
        {
            int p;
            p = (Sidea + Sideb + Sidec) / 2;
            if (IsLegal())
            {
                return Math.Sqrt(p*(p-Sidea)*(p-Sideb)*(p-Sidec)); 
            }

            return 0;
        }

        public override bool IsLegal()
        {
            if(Sidea + Sideb > Sidec && Sidea + Sidec > Sideb && Sideb + Sidec > Sidea)
            {
                return true;
            }
            return false;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(10);
            Console.WriteLine(square.GetArea());
            Console.WriteLine(square.IsLegal());
            Oblong oblong = new Oblong(5, 8);
            Console.WriteLine(oblong.GetArea());
            Console.WriteLine(oblong.IsLegal());
            Triangle triangle = new Triangle(6, 10, 8);
            Console.WriteLine(triangle.GetArea());
            Console.WriteLine(triangle.IsLegal());
            
            Square wrongsquare = new Square(-10);
            Console.WriteLine(wrongsquare.GetArea());
            Console.WriteLine(wrongsquare.IsLegal());
            Oblong wrongoblong = new Oblong(5, 5);
            Console.WriteLine(wrongoblong.GetArea());
            Console.WriteLine(wrongoblong.IsLegal());
            Triangle wrongtriangle = new Triangle(6, 10, 20);
            Console.WriteLine(wrongtriangle.GetArea());
            Console.WriteLine(wrongtriangle.IsLegal());
            
        }
    }
}