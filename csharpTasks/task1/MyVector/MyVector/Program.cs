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
            Vector a = new Vector(1, 2);
            Vector b = new Vector(-2, 1);
            Console.WriteLine((a + b).ToString());
            Console.WriteLine((a * 0.5).ToString());
            Console.WriteLine((a / 0).ToString());
            Console.WriteLine(a.GetOrthogonal().ToString());
            Console.WriteLine(a.Normalize().ToString());

            Vector c = new Vector(1, 0);
            Console.WriteLine(c.Rotate(Math.PI / 4));
            Console.WriteLine(a.GetAngleBetween(b));
            Console.WriteLine(c.isZero());
            
        }     
        
    }
}
