using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsCollections
{
    class MyGeneric<T>
    {
        public T SomeProperty { get; set; }
        public T SomeMethod<U>(U value)
        {
            Console.WriteLine(value.GetType().ToString());
            return SomeProperty;
        }
    }

    interface IPrintable
    {
        void Print();
    }
    class GenericWithConstraint<T> where T : IPrintable
    {
        public void Print(T a, T b)
        {
            a.Print();
            b.Print();
        }
    }


    class Parent
    {
        public virtual void DoSmth()
        {
            Console.WriteLine("Parent");
        }
    }

    #region Covariance&Contrvariance
    class Child : Parent
    {
        public override void DoSmth()
        {
            Console.WriteLine("Child");
        }
    }

    interface ICovariance<out T> where T : Parent
    {
        T DoSmth();
    }

    class Covariance : ICovariance<Child>
    {
        public Child DoSmth()
        {
            Child child = new Child();
            return child;
        }
    }

    interface IContravariance<in T> where T : Parent
    {
        void DoSmth(T obj);
    }

    class Contravariance<T> : IContravariance<T> where T : Parent
    {
        public void DoSmth(T obj)
        {
            obj.DoSmth();
        }
    }
    #endregion
}
