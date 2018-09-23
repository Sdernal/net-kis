using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            #region Работа с классами
            // Преобразование типов
            ExampleClass example = 5;
            int fromExample =(int)example;
            // в C# есть именнованные аргументы
            ExampleStaticClass.MultipleArguments(0, dt: new DateTime(2018, 10, 10), y: 3);
            // Использование операторов
            ExampleClass sum = example + new ExampleClass(65);
            sum.PrintField();
            // Partial класс
            PatrialClass partialClass = new PatrialClass();
            partialClass.MethodB();
            partialClass.MethodA();
            #endregion

            #region Наследование: виртуальные и невиртуальные методы
            A clearA = new A();
            A fromB = new B();
            B clearB = new B();

            clearA.VirtualMethod();
            clearA.Method();

            fromB.VirtualMethod();
            fromB.Method();

            clearB.VirtualMethod();
            clearB.Method();
            #endregion
        }
    }
}
