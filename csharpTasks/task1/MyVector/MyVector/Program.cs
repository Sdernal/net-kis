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
            Vector v1 = new Vector(1, 5);
            Vector v2 = new Vector(-1, 6);
            double k = 2;
            Console.WriteLine($"v1: {v1}.Scale({2}) = {v1.Scale(2)} and now v1 = {v1}");
            Console.WriteLine($"v1: {v1}.Add({v2}) = {v1.Add(v2)} and now v1 = {v1}");
            Console.WriteLine($"{v1}.DotProduct({v2}) = {v1.DotProduct(v2)}");
            Console.WriteLine($"{v1}.CrossProduct({v2}) = {v1.CrossProduct(v2)}");
            Console.WriteLine($"{v1} + {v2} = {v1 + v2}");
            Console.WriteLine($"{v1} - {v2} = {v1 - v2}");
            Console.WriteLine($"{v1} * {k} = {v1 * k}");
            Console.WriteLine($"{k} * {v1} = {k * v1}");
            Console.WriteLine($"{v1} / {k} = {v1 / k}");
            Console.WriteLine($"-{v1} = {-v1}");
            try
            {
                Console.WriteLine($"{v1} / {0} = {v1 / 0}");
            } catch(ArgumentException)
            {
                Console.WriteLine("Argument Exception");
            }
            Console.WriteLine($"v1: {v1}.Normolize = {v1.Normalize()}");
            Console.WriteLine($"getAngle((1; 0) and (0, 1)): {new Vector(1, 0).GetAngleBetween(new Vector(0, 1))}");
            Console.WriteLine($"GetRelation (1, 1) (3, 3): {new Vector(1, 1).GetRelation(new Vector(3, 3))}");
            Console.WriteLine($"GetOrhtogonal (5, 0) {new Vector(5, 0).GetOrthogonal()}");
            Console.WriteLine($"Rotate 90deg (1, 0): {new Vector(1, 0).Rotate(Math.PI / 2)}");
        }     
        
    }
}
