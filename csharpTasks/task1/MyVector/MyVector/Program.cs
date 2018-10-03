using System;

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

            Console.WriteLine();

            #endregion

            #region ToString

            Console.WriteLine(x.ToString());
            Console.WriteLine();

            #endregion

            #region operatorPlus

            x = new Vector(4, 9);
            y = new Vector(5, -1);
            Console.WriteLine($"{x} + {y} = {x + y}");

            Console.WriteLine();

            #endregion

            #region operatorMinus

            Console.WriteLine($"{x} - {y} = {x - y}");
            Console.WriteLine();

            #endregion

            #region operatorStar

            k = 2.5;
            x = new Vector(-7, 3);
            Console.WriteLine($"{x} * {k} = {x * k}");
            Console.WriteLine($"{k} * {x} = {k * x}");

            Console.WriteLine();

            #endregion

            #region operatorSlash

            k = 3;
            Console.WriteLine($"{x} / {k} = {x / k}");

            k = 0;
            Console.WriteLine($"{x} / {k} = {x / k}");

            Console.WriteLine();

            #endregion

            #region operatorUnaryPlus

            Console.WriteLine($"+{x} = {+x}");
            Console.WriteLine();

            #endregion

            #region operatorUnaryMinus

            Console.WriteLine($"-{x} = {-x}");
            Console.WriteLine();

            #endregion

            #region Normalize

            x = new Vector(3, 0);
            Console.WriteLine($"{x} normalized: {x.Normalize()}");

            x = new Vector(-3, 4);
            Console.WriteLine($"{x} normalized: {x.Normalize()}");

            x = new Vector(-0.5, -0.5);
            Console.WriteLine($"{x} normalized: {x.Normalize()}");

            try
            {
                x = new Vector(0, 0);
                y = x.Normalize();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"{x} normalization...");
                Console.WriteLine("DivideByZeroException has been caught. " +
                                  $"Message: {e}");
            }

            Console.WriteLine();

            #endregion

            #region GetAngleBetween

            x = new Vector(3e5, 1);
            y = new Vector(-3e5, -1);
            Console.WriteLine($"angle({x}, {y}) = {x.GetAngleBetween(y)}");
            Console.WriteLine($"angle({y}, {x}) = {y.GetAngleBetween(x)}");
            Console.WriteLine($"angle({x}, {x}) = {x.GetAngleBetween(x)}");

            x = new Vector(4, -7);
            y = new Vector(-7.5, -5);
            Console.WriteLine($"angle({x}, {y}) = {x.GetAngleBetween(y)}");
            Console.WriteLine($"angle({y}, {x}) = {y.GetAngleBetween(x)}");

            y = new Vector(0, 0);
            try
            {
                Console.WriteLine($"angle({y}, {x}) = {y.GetAngleBetween(x)}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"angle({y}, {x}) = ...");
                Console.WriteLine("DivisionByZero has been caught. " +
                                  $"Message: {e}");
            }

            Console.WriteLine();

            #endregion

            #region VectorRelation

            x = new Vector(3, 5);
            y = x * -4.5;
            Console.WriteLine($"{x} and {y} are {x.GetRelation(y)}");

            y = x.GetOrthogonal() * 0.3;
            Console.WriteLine($"{x} and {y} are {x.GetRelation(y)}");

            y = new Vector(0, 0);
            Console.WriteLine($"{x} and {y} are {x.GetRelation(y)}");

            y = new Vector(4, 8);
            Console.WriteLine($"{x} and {y} are {x.GetRelation(y)}");

            Console.WriteLine();

            #endregion

            #region GetOrthogonal

            Console.WriteLine($"Orthogonal to {x} is {x.GetOrthogonal()}");

            x = new Vector(0, 0);
            try
            {
                Console.WriteLine($"Orthogonal to {x} is {x.GetOrthogonal()}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Orthogonal to {x} is...");
                Console.WriteLine("DivisionByZero has been caught. " +
                                  $"Message: {e}");
            }

            Console.WriteLine();

            #endregion

            #region Rotate

            x = new Vector(1, 0);
            k = Math.PI / 2;
            Console.WriteLine($"{x} rotated in {k} radians is {x.Rotate(k)}");

            k = Math.PI / 6;
            Console.WriteLine($"{x} rotated in {k} radians is {x.Rotate(k)}");

            #endregion
        }
    }
}