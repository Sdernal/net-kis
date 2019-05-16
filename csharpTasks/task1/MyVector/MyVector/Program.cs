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
            Vector v1 = new Vector(1, 2);
            Vector v2 = new Vector(4, -3);
            double k = 5;
            double k0 = 0;
            try
            {
                Console.WriteLine(v1 / k0);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("exception");
            }
            Console.WriteLine($"{v1}");
            Console.WriteLine($"{v1}.Length() = {v1.Length()}");
            Console.WriteLine($"{v1}.Add({v2}) = {v1.Add(v2)}");
            Console.WriteLine($"{v1}.Scale({5}) = {v1.Scale(k)}");
            Console.WriteLine($"{v1}.DotProduct({v2}) = {v1.DotProduct(v2)}");
            Console.WriteLine($"{v1}.CrossProduct({v2}) = {v1.CrossProduct(v2)}");
            Console.WriteLine($"{v1} + {v2} = {v1 + v2}");
            Console.WriteLine($"{v1} - {v2} = {v1 - v2}");
            Console.WriteLine($"{v1} * {k} = {v1 * k}");
            Console.WriteLine($"{k} * {v1} = {k * v1}");
            Console.WriteLine($"{v1} / {k} = {v1 / k}");
            Console.WriteLine($"-{v1} = {-v1}");
            Console.WriteLine($"v1: {v1}.Normolize = {v1.Normalize()}");
            Console.WriteLine($"getAngle((5; 0) and (-5, 0)): {new Vector(5, 0).GetAngleBetween(new Vector(-5, 0))}");
            Console.WriteLine($"GetRelation (1, 1) (5, 5): {new Vector(1, 1).GetRelation(new Vector(5, 5))}");
            Console.WriteLine($"GetRelation (1, 1) (4, 5): {new Vector(1, 1).GetRelation(new Vector(4, 5))}");
            Console.WriteLine($"GetRelation (1, 0) (0, 1): {new Vector(1, 0).GetRelation(new Vector(0, 1))}");
            Console.WriteLine($"GetOrhtogonal (5, 0) {new Vector(5, 0).GetOrthogonal()}");
            Console.WriteLine($"Rotate 180deg (1, 0): {new Vector(1, 0).Rotate(Math.PI)}");
        }     
        
    }
}
