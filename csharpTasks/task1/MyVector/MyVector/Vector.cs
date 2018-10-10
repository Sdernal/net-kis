using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("MyVector.test")]
namespace MyVector
{
    public struct Vector
    {

        public double x;
        public double y;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Vector(double X, double Y)
        {
            x = X;
            y = Y;
        }
        /* Нужно реализовать струкруру двумерный вектор (double X, double Y):
         - Добавить коструктор
         - Реализовать методы-заглушки:
            - Длина, сложение векторов, умножение на число
            - Скалярное и векторное произведение
            - Приведение к строке: выводить (X; Y)
         - Реализовать Операторы
         - В Main протестировать все методы, пока без использования фреймворков: просто зовем метод, сравниваем результат и пишем в консоль
         - К каждому полю структуры создать документацию: шаблон создается по "///" над тем, что документируем:
        /// <summary>
        /// Привмер использования Xml documentation comments
        /// </summary>
        private void Foo()
        {

        }        
        */

        /// <summary>
        /// Length of a vector
        /// </summary>
        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Adds v to this vector
        /// </summary>
        /// <param name="v"></param>
        public Vector Add(Vector v)
        {
            this.x += v.x;
            this.y += v.y;
            return this;
        }

        /// <summary>
        /// Scales this vector into k times
        /// </summary>
        /// <param name="k"></param>
        public Vector Scale(double k)
        {
            this.x *= k;
            this.y *= k;
            return this;
        }

        /// <summary>
        /// Scalar product of this vector and vector v 
        /// </summary>
        /// <param name="v"></param>
        public double DotProduct(Vector v)
        {
            return (this.x * v.x + this.y * v.y);
        }

        /// <summary>
        /// Cross product of this vector and vector v
        /// </summary>
        /// <param name="v"></param>
        public double CrossProduct(Vector v)
        {
            return (this.x * v.y - this.y * v.x);
        }

        /// <summary>
        /// Transforms vector to string
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            return (string)($"({Math.Round(x, 10)};{Math.Round(y, 10)})");
        }

        #region Operators        
        /* В этой секции нужно реализовать следующие опрераторы 
        - v + u, v - u (v,u - Vector)
        - v*k, k*v, v/k (k - double)
        - +v, -v 
        */
        // Такая семантика у операторов в C#
        public static Vector operator+ (Vector v, Vector u)
        {
            Vector res = new Vector(v.x + u.x, v.y + u.y);
            return res;
        }
        public static Vector operator -(Vector v, Vector u)
        {
            Vector res = new Vector(v.x - u.x, v.y - u.y);
            return res;
        }
        public static Vector operator *(Vector v, double k)
        {
            Vector res = new Vector(v.x * k, v.y * k);
            return res;
        }
        public static Vector operator *(double k, Vector v)
        {
            Vector res = new Vector(v.x * k, v.y * k);
            return res;
        }
        public static Vector operator /(Vector v, double k)
        {
            Vector res = new Vector(v.x / k, v.y / k);
            return res;
        }
        public static Vector operator +(Vector v)
        {
            return v;
        }
        public static Vector operator -(Vector v)
        {
            Vector res = new Vector(-v.x, -v.y);
            return res;
        }
        #endregion
    }
}
