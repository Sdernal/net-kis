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
            Vector a = new Vector(1, 9);
            Vector b = new Vector(8, 4);
            double k = 0.5;

            Console.WriteLine("a + b = " + (a + b).ToString());
            Console.WriteLine("a - b = " + (a - b).ToString());
            Console.WriteLine("(a, b) = " + a.DotProduct(b).ToString());
            Console.WriteLine("[a, b] = " + a.CrossProduct(b).ToString());
            Console.WriteLine("k * a = " + (k * a).ToString());
            Console.WriteLine("a * k = " + (a * k).ToString());
            Console.WriteLine("a / k = " + (a / k).ToString());

            Console.WriteLine("a.Add(b) = " + a.Add(b).ToString());
            Console.WriteLine("b.Scale(k) = " + b.Scale(k).ToString());
            Console.WriteLine("a.Length() = " + a.Length());
            Console.WriteLine("b.Length() = " + b.Length());

            Console.WriteLine("a.Normalize() = " + a.Normalize().ToString());

            Vector c = new Vector(1, 0);
            Vector d = new Vector(0, 1);

            Console.WriteLine("c.GetAngleBetween(d) = " + c.GetAngleBetween(d).ToString());
            Console.WriteLine("c.GetRelation(d) = " + c.GetRelation(d).ToString());
            Console.WriteLine("a.GetRelation(d) = " + a.GetRelation(d).ToString());
            Console.WriteLine("d.GetRelation(d) = " + d.GetRelation(d).ToString());
            Console.WriteLine("d.GetOrthogonal() = " + d.GetOrthogonal().ToString());
            Console.WriteLine("a.Rotate(1.57) = " + a.Rotate(1.57).ToString());

            try
            {
                a = a / 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                a.GetAngleBetween(new Vector());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                a.GetRelation(new Vector());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Vector.ZeroVector().GetOrthogonal();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }     
        
    }
}
