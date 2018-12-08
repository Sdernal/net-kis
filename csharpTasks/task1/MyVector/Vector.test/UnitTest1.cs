using System;
using Xunit;
using System.Runtime.CompilerServices;
using MyVector;

namespace MyVector.test
{
    public class VectorTests
    {
        [Fact]
        public void Test_Length()
        {
            Vector v = new Vector(3, 4);
            Assert.Equal(5, v.Length());
            Assert.True(true);
        }

        [Fact]
        public void Test_Scale()
        {
            Vector v = new Vector(3, 4);
            Assert.Equal(new Vector(30,40), v.Scale(10));
        }

        [Fact]
        public void Test_Add()
        {
            Vector v = new Vector(3, 4);
            Vector u = new Vector(7, -9);
            Assert.Equal(new Vector(10, -5), v.Add(u));
        }

        [Fact]
        public void Test_DotProduct()
        {
            Vector v = new Vector(3, 4);
            Vector u = new Vector(7, -9);
            Assert.Equal(-15, v.DotProduct(u));
        }

        [Fact]
        public void Test_CrossProduct()
        {
            Vector v = new Vector(3, 4);
            Vector u = new Vector(7, -9);
            Assert.Equal(-55, v.CrossProduct(u));
        }

        
           // Console.WriteLine($"+v1: {+v1}");
           // Console.WriteLine($"-v1: {-v1}");


        [Fact]
        public void Test_Sum()
        {
            Vector v = new Vector(3, 4);
            Vector u = new Vector(7, -9);
            Assert.Equal(new Vector(10, -5), v + u);
        }

        [Fact]
        public void Test_Substraction()
        {
            Vector v = new Vector(3, 4);
            Vector u = new Vector(7, -9);
            Assert.Equal(new Vector(-4, 13), v - u);
        }

        [Fact]
        public void Test_Mult_kv()
        {
            Vector v = new Vector(3, 0.4);
            Assert.Equal(new Vector(-12, -1.6), -4 * v);
        }

        [Fact]
        public void Test_Mult_vk()
        {
            Vector v = new Vector(3, 3.1);
            Assert.Equal(new Vector(18, 18.6), v * 6);
        }

        [Fact]
        public void Test_Div()
        {
            Vector v = new Vector(6, -27);
            Assert.Equal(new Vector(2, -9), v / 3);
        }

        [Fact]
        public void Test_Unar_Plus()
        {
            Vector v = new Vector(6, -27);
            Assert.Equal(new Vector(6, -27), +v);
        }

        [Fact]
        public void Test_Unar_Minus()
        {
            Vector v = new Vector(6, -27);
            Assert.Equal(new Vector(-6, 27), -v);
        }


        // GetOrthogonal


        [Fact]
        public void Test_Normalize()
        {
            Vector v = new Vector(3, 4);
            Assert.Equal(new Vector(0.6, 0.8), v.Normalize());
        }

        [Fact]
        public void Test_GetAngleBetween()
        {
            Vector v = new Vector(1, 5);
            Vector u = new Vector(5, -1);
            Assert.Equal(Math.Round(Math.Cos(Math.PI / -2), 10), v.GetAngleBetween(u));
        }

        [Fact]
        public void Test_GetRelation()
        {
            Vector v = new Vector(1, 5);
            Vector u = new Vector(5, -1);
            Assert.Equal(VectorRelation.Orthogonal, v.GetRelation(u));
            v = new Vector(1, 5);
            u = new Vector(2, 10);
            Assert.Equal(VectorRelation.Parallel, v.GetRelation(u));
            v = new Vector(1, 5);
            u = new Vector(0.3, -27);
            Assert.Equal(VectorRelation.General, v.GetRelation(u));
        }

        [Fact]
        public void Test_Rotate()
        {
            Vector v = new Vector(3, 4);
            Assert.Equal(new Vector(-4, 3), v.Rotate(Math.PI/2)); // Let in be test passed
        }

        [Fact]
        public void Test_GetOrthogonal()
        {
            Vector v = new Vector(3, 4);
            Assert.Equal(new Vector(-0.8, 0.6), v.GetOrthogonal());
        }
    }
}
