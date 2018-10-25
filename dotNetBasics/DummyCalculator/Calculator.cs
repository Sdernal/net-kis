using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DummyCalculator.Tests")]
namespace DummyCalculator
{    
    class Calculator
    {
        public double Sum(double a, double b)
        {
            return a + b;
        } 
    }
}
