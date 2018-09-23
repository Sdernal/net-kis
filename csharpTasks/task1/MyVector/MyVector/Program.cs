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
            const string delimeter = "\n=================================\n";

            Vector x = new Vector(1, 2);
            Vector y = new Vector(-4, 2);
            Vector z = new Vector(-2, -4);
            Vector t = new Vector(5, 5);

            Console.WriteLine($"x: {x}\ny: {y}\nz: {z}\nt: {t}");
            Console.WriteLine(delimeter);

            t.Add(-x);
            Console.WriteLine($"t = t + (-x);\nt: {t};\nt.Length(): {t.Length()}\nnorm(t): {t.Normalize()}");
            Console.WriteLine(delimeter);

            Console.WriteLine($"x and y relation: {x.GetRelation(y)}");
            Console.WriteLine($"x and z relation: {x.GetRelation(z)}");
            Console.WriteLine($"y and z relation: {y.GetRelation(z)}");
            Console.WriteLine($"x and t relation: {x.GetRelation(t)}");
            Console.WriteLine(delimeter);

            Console.WriteLine("// suppose we are calculating an absolute angle between vectors");
            Console.WriteLine($"angle between x and y: {x.GetAngleBetween(y)}");
            Console.WriteLine($"angle between y and x: {y.GetAngleBetween(x)}");
            Console.WriteLine($"angle between x and z: {x.GetAngleBetween(z)}");
            Console.WriteLine($"angle between x and t: {x.GetAngleBetween(t)}");
            Console.WriteLine(delimeter);

            Console.WriteLine($"x.rotate(pi / 2): {x.Rotate(Math.PI / 2)}\ny / 2: {y / 2}");

            Console.ReadKey();
        }     
    }
}
