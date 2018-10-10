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
            Console.WriteLine("Hello world!");
            Vector v1 = new Vector(3.7, 8.9);
            Vector v2 = new Vector(2.5, 1.7);
            Console.WriteLine($"v1: {v1.ToString()}");
            Console.WriteLine($"v2: {v2.ToString()}");
            Console.WriteLine($"v1 length: {v1.Length()}");
            v1.Add(v2);
            Console.WriteLine($"v1 add v2: {v1}");
            v2.Scale(10);
            Console.WriteLine($"v2 Scale 10: {v2}");
            Console.WriteLine($"v1: {v1.ToString()}");
            Console.WriteLine($"v2: {v2.ToString()}");
            Console.WriteLine($"v1 dotproduct v2: {v1.DotProduct(v2)}");
            Console.WriteLine($"v1 crossproduct v2: {v1.CrossProduct(v2)}");

            Console.WriteLine($"v1 + v2: {v1 + v2}");
            Console.WriteLine($"v1 - v2: {v1 - v2}");
            Console.WriteLine($"v1 * 3: {v1 * 3}");
            Console.WriteLine($"3 * v1: {3 * v1}");
            Console.WriteLine($"v1 / 4: {v1 / 4}");
            Console.WriteLine($"+v1: {+v1}");
            Console.WriteLine($"-v1: {-v1}");



            Console.WriteLine($"normilize: {v1.Normalize()}");
            Console.WriteLine($"getAngleBetween: {v1.GetAngleBetween(v2)}");
            Console.WriteLine($"getRelation: {v1.GetRelation(v2)}");
            Console.WriteLine($"v1: {v1.ToString()}");
            Console.WriteLine($"rotate: {v1.Rotate(3.1415)}");


            Console.ReadLine();
        }     
        
    }
}
