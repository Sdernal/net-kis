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
            // Console.WriteLine("Hello world!");   
            Vector one = new Vector(1, 3);
            Vector two = new Vector(-2, 4);
            Vector three = new Vector(2, -3);

            Console.WriteLine($"DotProduct: {one.DotProduct(two)}");  
            Console.WriteLine("Exact answer is 10");  
            Console.WriteLine($"CrossProduct: {one.CrossProduct(two)}");
            Console.WriteLine("Exact Answer is 10");
            Console.WriteLine($"Angle between two and three: {two.GetAngleBetween(three)}");
            Double angle = two.GetAngleBetween(three);
            Vector two_rotated = two.Rotate(-angle).Normalize();
            Console.WriteLine("Two rotated and normalized: ");
            Console.WriteLine(two_rotated.x.ToString() + " " + two_rotated.y.ToString());
            Console.WriteLine("Three normalized:");
            Console.WriteLine(three.Normalize().x.ToString() + " " + three.Normalize().y.ToString());
            Console.WriteLine("DotProduct of orthogonals: ");
            Console.WriteLine(one.DotProduct(one.GetOrthogonal()));
        }     
    }
}
