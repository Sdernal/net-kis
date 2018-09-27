using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /// <summary>
    /// Пример класса в C#
    /// </summary>
    public class ExampleClass
    {
        /// <summary>
        /// Поле класса
        /// </summary>
        public int exampleField;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public ExampleClass()
        {
            exampleField = 42;
        }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="value"></param>
        public ExampleClass(int value)
        {
            exampleField = value;
        }

        /// <summary>
        /// Метод без параметров
        /// </summary>
        public void PrintField()
        {
            Console.WriteLine($"Example field: {exampleField}");
        }

        /// <summary>
        /// Метод с параметром
        /// </summary>
        /// <param name="otherValue">Параметр</param>
        /// <returns>Возвращает сумму аргумента и поля класса</returns>
        public int GetSumWithField(int otherValue)
        {
            return otherValue + exampleField;
        }        

        /// <summary>
        /// Пример опереатора
        /// </summary>
        /// <param name="ex1">Левый операнд</param>
        /// <param name="ex2">Правый операнд</param>
        /// <returns></returns>
        public static ExampleClass operator+(ExampleClass ex1, ExampleClass ex2)
        {
            return new ExampleClass() { exampleField = ex1.exampleField + ex2.exampleField };
        }     
        
        /// <summary>
        /// Пример implicit преобразования
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ExampleClass(int value)
        {
            return new ExampleClass(value);
        }

        /// <summary>
        /// Пример explicit преобразования
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator int(ExampleClass value)
        {
            return value.exampleField;
        }
    }

    /// <summary>
    /// Класс с свойствами
    /// </summary>
    public class ClassWithProperties
    {
        private int _x;
        /// <summary>
        /// Свойство над полем X
        /// </summary>
        public int PropertyX
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Автоматическое свойство
        /// </summary>
        public int AutoProperty { get; set; }

        /// <summary>
        /// Свойство с приватным сетом
        /// </summary>
        public int AutoPropertyWithoutSet { get; private set; }

        private string name;
        /// <summary>
        /// Реализация свойства с помощью Expression метода
        /// </summary>
        public string ExpressionProperty
        {
            get => name;
            set => name = value;
        }
    }

    /// <summary>
    /// Пример статического класса
    /// </summary>
    public static class ExampleStaticClass {
        /// <summary>
        /// Метод с одним выражением в краткой записи
        /// </summary>
        public static void ExpressionMethod() => Console.WriteLine("Expression method");

        /// <summary>
        /// Метод с несколькими параметрами по-умолчанию
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dt"></param>
        /// <param name="guid"></param>
        public static void MultipleArguments(int x, int y = 0, DateTime dt = default(DateTime), Guid guid = new Guid())
        {
            Console.WriteLine($"x: {x}; y: {y}; dt: {dt}; guid: {guid}");
        }
    }   
}
