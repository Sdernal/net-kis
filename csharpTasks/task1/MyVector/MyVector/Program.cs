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
            double x1 = 0.5;
            double y1 = 1.5;
            double x2 = 2.5;
            double y2 = 3.5;
            double k = 3;
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            Console.WriteLine(v1.Length() == Math.Sqrt(x1 * x1 + y1 * y1));
            Console.WriteLine(v1.Add(v2));
            Console.WriteLine(v1.Scale(k));
            Console.WriteLine(v1.DotProduct(v2));
            Console.WriteLine(v1.CrossProduct(v2));
            Console.WriteLine(v1);
            Console.WriteLine(v1 + v2);
            Console.WriteLine(v1 - v2);
            Console.WriteLine(v1 * k);
            Console.WriteLine(k * v1);
            Console.WriteLine(v1 / k);
            Console.WriteLine(+v1);
            Console.WriteLine(-v1);


            var u1 = new Vector(1, 2);
            var u2 = new Vector(-4, 2);
            var u3 = new Vector(-5, -10);
            var u4 = new Vector(1, 1);
            Console.WriteLine(u1.Normalize());
            Console.WriteLine(u1.Normalize().Length());
            Console.WriteLine(u1.GetAngleBetween(u2));
            Console.WriteLine(u1.GetAngleBetween(u1));
            Console.WriteLine(u1.GetRelation(u2));
            Console.WriteLine(u1.GetRelation(u3));
            Console.WriteLine(u1.GetRelation(u4));
            Console.WriteLine(u1.GetOrthogonal());
            Console.WriteLine(u1.GetOrthogonal().Length());
            var angle = Math.PI;
            Console.WriteLine(u1.Rotate(angle));
        }     
        
    }
}
