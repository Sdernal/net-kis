using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            #endregion
        }
    }
}