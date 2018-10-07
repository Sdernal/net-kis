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
            Vector a = new Vector(2, 3);
            Vector b = new Vector(4, 5);
            double k = 2.5;
            Console.WriteLine($"a.ToString() = {a.ToString()}");
            Console.WriteLine($"b.ToString() = {b.ToString()}");
            Console.WriteLine($"{a}.Length() = {a.Length()}");
            Console.WriteLine($"{b}.Length() = {b.Length()}");
            Console.WriteLine($"{a}.Add({b}) = {a.Add(b)}");
            Console.WriteLine($"{a}.Scale({k}) = {a.Scale(k)}");
            Console.WriteLine($"{b}.Scale({k}) = {b.Scale(k)}");
            Console.WriteLine($"{a}.DotProduct({b}) = {a.DotProduct(b)}");
            Console.WriteLine($"{a}.CrossProduct({b}) = {a.CrossProduct(b)}");
            Console.WriteLine($"{a} + {b} = {a + b}");
            Console.WriteLine($"{a} - {b} = {a - b}");
            Console.WriteLine($"{a} * {k} = {a * k}");
            Console.WriteLine($"{b} * {k} = {b * k}");
            Console.WriteLine($"{k} * {a} = {k * a}");
            Console.WriteLine($"{k} * {b} = {k * b}");
            Console.WriteLine($"{a} - {b} = {a - b}");
            Console.WriteLine($"{b} - {a} = {b - a}");
            Console.WriteLine($"{a} / {k} = {a / k}");
            Console.WriteLine($"{b} / {k} = {b / k}");
            try
            {
                Console.WriteLine($"{b} / 0 = {b / 0}");
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine($"Caught DivideByZeroException trying to divide {b} by 0");
            }
            Vector c = new Vector(4, 4);
            Vector d = new Vector(4, -4);
            Vector e = new Vector(-4, -4);
            Vector f = new Vector(0, 0);
            Vector n = new Vector(4, 0);
            Console.WriteLine($"{c}.Normalize() = {c.Normalize()}");
            Console.WriteLine($"{n}.Normalize() = {n.Normalize()}");
            try
            {
                Console.WriteLine($"{f}.Normalize() = {f.Normalize()}");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine($"Caught ArgumentException while calling Normalize on {f} vector");
            }
            Console.WriteLine($"{c}.GetAngleBetween({d}) = {c.GetAngleBetween(d)}");
            Console.WriteLine($"{c}.GetAngleBetween({e}) = {c.GetAngleBetween(e)}");
            Console.WriteLine($"{c}.GetAngleBetween({f}) = {c.GetAngleBetween(f)}");
            Console.WriteLine($"{c}.GetRelation({d}) = {c.GetRelation(d)}");
            Console.WriteLine($"{c}.GetRelation({e}) = {c.GetRelation(e)}");
            Console.WriteLine($"{c}.GetRelation({n}) = {c.GetRelation(n)}");
            Console.WriteLine($"{c}.GetOrthogonal() = {c.GetOrthogonal()}");
            Console.WriteLine($"{d}.GetOrthogonal() = {d.GetOrthogonal()}");
            Console.WriteLine($"{f}.GetOrthogonal() = {f.GetOrthogonal()}");
            Console.WriteLine($"{n}.GetOrthogonal() = {n.GetOrthogonal()}");
            Console.WriteLine($"{c}.Rotate(PI / 2) = {c.Rotate(Math.PI / 2)}");
            Console.WriteLine($"{c}.Rotate(PI) = {c.Rotate(Math.PI)}");
            Console.WriteLine($"{f}.Rotate(2.345) = {f.Rotate(2.345)}");
        }     
        
    }
}
