using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVector
{
    public struct Vector
    {
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
        public double x, y;

        /// <summary>
        /// Construct vector with coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// return length of the vector in rectangular coordinate system
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            // throw new NotImplementedException();
            return Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Sum of two vectors
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Vector Add(Vector v)
        {
            // throw new NotImplementedException();
            this.x += v.x;
            this.y += v.y;
            return this;
        }

        /// <summary>
        /// Multiplication on the scalar k
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public Vector Scale(double k)
        {
            // throw new NotImplementedException();
            this.x *= k;
            this.y *= k;
            return this;
        }

        /// <summary>
        /// Dot product of two vectors
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double DotProduct(Vector v)
        {
            // throw new NotImplementedException();
            return this.x * v.x + this.y * v.y;
        }

        /// <summary>
        /// Cross product of two vectors
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double CrossProduct(Vector v)
        {
            // throw new NotImplementedException();
            return this.x * v.y - this.y * v.x;
        }


        /// <summary>
        /// return (x; y)
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            // throw new NotImplementedException();
            return $"Vector({this.x}, {this.y})";
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
            // throw new NotImplementedException();
            return new Vector(v.x + u.x, v.y + u.y);
        }    

        public static Vector operator- (Vector v, Vector u)
        {
            return new Vector(v.x - u.x, v.y - u.y);
        }  

        public static Vector operator* (Vector v, double k)
        {
            return new Vector(v.x * k, v.y * k);
        }

        public static Vector operator* (double k, Vector v)
        {
            return new Vector(v.x * k, v.y * k);
        }

        public static Vector operator/ (Vector v, double k)
        {
            if (k == 0.0) {
                throw new DivideByZeroException();
            }
            return new Vector(v.x / k, v.y / k);
        }

        public static Vector operator+ (Vector v)
        {
            return new Vector(+v.x, +v.y);
        }

        public static Vector operator- (Vector v)
        {
            return new Vector(-v.x, -v.y);
        }

        #endregion
    }
}
