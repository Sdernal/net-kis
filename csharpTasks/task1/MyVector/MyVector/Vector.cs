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

        public double X_ { get; private set; }
        public double Y_ { get; private set; }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Vector(double X, double Y)
        {
            this.X_ = X;
            this.Y_ = Y;

        }
       
        /// <summary>
        /// Длина вектора
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            return Math.Sqrt(Math.Pow(X_, 2) + Math.Pow(Y_, 2));
        }

        /// <summary>
        /// Сложение векторов.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Vector Add(Vector v)
        {
            Vector result = new Vector(X_ + v.X_,Y_ + v.Y_);
            return result;
        }

        /// <summary>
        /// Домножение вектора на скаляр
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public Vector Scale(double k)
        {
            Vector result = new Vector(X_ * k, Y_ * k);
            return result;
        }

        /// <summary>
        /// Скалярное произведение
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double DotProduct(Vector v)
        {
            return v.X_ * this.X_ + v.Y_ * this.Y_;
        }

        /// <summary>
        /// Векторное произведение
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double CrossProduct(Vector v)
        {
            return Math.Abs(this.X_ * v.Y_ - this.Y_ * v.X_);
        }

        /// <summary>
        /// Приведение к строке
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            String result = '(' + this.X_.ToString() + ", " + this.Y_.ToString() + ')';
            return result;
        }

        #region Operators        
        /* В этой секции нужно реализовать следующие опрераторы 
        - v + u, v - u (v,u - Vector)
        - v*k, k*v, v/k (k - double)
        - +v, -v 
        */
        // Такая семантика у операторов в C#

        /// <summary>
        /// Оператор сложения векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Vector operator+ (Vector v, Vector u)
        {
            double result_X = v.X_ + u.X_;
            double result_Y = v.Y_ + u.Y_;
            return new Vector(result_X, result_Y);
        } 
        
        /// <summary>
        /// Оператор разности векторов
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Vector operator- (Vector v, Vector u)
        {
            double result_X = v.X_ - u.X_;
            double result_Y = v.Y_ - u.Y_;
            return new Vector(result_X, result_Y);
        } 
        
        /// <summary>
        /// Оператор умножения вектора на скаляр
        /// </summary>
        /// <param name="v"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Vector operator* (Vector v, double k)
        {
            double result_X = v.X_ * k;
            double result_Y = v.Y_ * k;
            return new Vector(result_X, result_Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector operator* (double k, Vector v)
        {
            double result_X = v.X_ * k;
            double result_Y = v.Y_ * k;
            return new Vector(result_X, result_Y);
        }

        /// <summary>
        /// Деление на скаляр
        /// </summary>
        /// <param name="v"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Vector operator/ (Vector v, double k)
        {
            if (k == 0)
            {
                throw new DivideByZeroException();
            }
            double result_X = v.X_ / k;
            double result_Y = v.Y_ / k;
            return new Vector(result_X, result_Y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector operator+ (Vector v)
        {
            return v;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector operator- (Vector v)
        {
            double result_X = -v.X_;
            double result_Y = -v.Y_;
            return new Vector(result_X, result_Y);

        }
        #endregion
    }
}
