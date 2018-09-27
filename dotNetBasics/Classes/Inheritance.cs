using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class A
    {
        public int X {get;set;}

        public virtual void VirtualMethod()
        {
            Console.WriteLine("Called from A");
        }

        public void Method()
        {
            Console.WriteLine("Called from A");
        }
    }

    class B : A
    {
        public void PrintX()
        {
            Console.WriteLine($"{X}");
        }

        public override void VirtualMethod()
        {
            Console.WriteLine("Called from B");
        }

        public new void Method()
        {
            Console.WriteLine("Called from B");
        }
    }


    public interface IExample
    {
        void PrintSmth();
    }

    public class CExample : IExample
    {
        public void PrintSmth()
        {
            Console.WriteLine("PrintSmth method realization");
        }
    }

    public abstract class AbstractClass
    {
       public abstract void SomeMethod();
    }

    public class AbstractClassChild : AbstractClass
    {
        public override void SomeMethod()
        {
            Console.WriteLine("Abstract method realization");
        }
    }
}
