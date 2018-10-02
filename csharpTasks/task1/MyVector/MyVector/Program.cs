using System;

namespace MyVector
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            #region Length

            var v = new Vector(1.5, 2);
            Console.WriteLine($"|{v}| = {v.Length()}");
            v = new Vector(0, -1);
            Console.WriteLine($"|{v}| = {v.Length()}");

            Console.WriteLine();

            #endregion

            #region Add

            var x = new Vector(3.14, -6);
            var y = new Vector(7, 0);
            Console.WriteLine($"{x} + {y} = {x.Add(y)}");

            x = new Vector(23, -45);
            y = new Vector(3, 9);
            Console.WriteLine($"{x} + {y} = {x.Add(y)}");

            Console.WriteLine();

            #endregion

            #region Scale

            x = new Vector(3.14, -6);
            var k = 4.0;
            Console.WriteLine($"{x} * {k} = {x.Scale(k)}");

            x = new Vector(23, -45);
            k = 0.0;
            Console.WriteLine($"{x} * {k} = {x.Scale(k)}");

            Console.WriteLine();

            #endregion

            #region DotProduct

            x = new Vector(1, 1);
            y = new Vector(-5, 5);
            Console.WriteLine($"({x}; {y}) = {x.DotProduct(y)}");

            x = new Vector(0, 3.14);
            y = new Vector(0, -3.14);
            Console.WriteLine($"({x}; {y}) = {x.DotProduct(y)}");

            Console.WriteLine();

            #endregion

            #region CrossProduct

            x = new Vector(2, -1);
            y = new Vector(-1, 3);
            Console.WriteLine($"[{x}; {y}] = {x.CrossProduct(y)}");
            Console.WriteLine($"[{y}; {x}] = {y.CrossProduct(x)}");

            x = new Vector(-1, 3);
            y = new Vector(4, -12);
            Console.WriteLine($"[{x}; {y}] = {x.CrossProduct(y)}");

            x = new Vector(7, 4);
            y = new Vector(0, 0);
            Console.WriteLine($"[{x}; {y}] = {x.CrossProduct(y)}");
            
            Console.WriteLine();

            #endregion

            #region ToString

            Console.WriteLine(x.ToString());
            Console.WriteLine();

            #endregion

            #region operatorPlus

            x = new Vector(4, 9);
            y = new Vector(5, -1);
            Console.WriteLine($"{x} + {y} = {x + y}");
            
            Console.WriteLine();

            #endregion

            #region operatorMinus

            Console.WriteLine($"{x} - {y} = {x - y}");
            Console.WriteLine();

            #endregion

            #region operatorStar

            k = 2.5;
            x = new Vector(-7, 3);
            Console.WriteLine($"{x} * {k} = {x * k}");
            Console.WriteLine($"{k} * {x} = {k * x}");
            
            Console.WriteLine();

            #endregion
            
            #region operatorSlash

            k = 3;
            Console.WriteLine($"{x} / {k} = {x / k}");
            
            k = 0;
            Console.WriteLine($"{x} / {k} = {x / k}");
            
            Console.WriteLine();

            #endregion
        }
    }
}