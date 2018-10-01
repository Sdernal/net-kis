using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVector
{   
    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }
    
    // Для создания методов расширения нужен статический класс, в котором в статических методах у первого аргумента 
    // добавляется ключевое слово this, далее можно вызывать данный метод у объектов класса такого аргумента 
    // Ниже нужно реализовать методы-расширения для нашего вектора
    // И не забыть про документацию и тесты
    public static class VectorExtensions
    {
        /// <summary>
        /// Нормализовать вектор
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector Normalize(this Vector v)
        {
            Vector result = new Vector(0, 0);
            try {
                result = new Vector(v.X_ / v.Length(), v.Y_ / v.Length());
            } 
            catch (DivideByZeroException){
                Console.WriteLine("Division by zero.", v.Length());
            }
            return result;
        }

        /// <summary>
        /// Получить угол между векторами в радианах
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <param name="eps"></param>
        /// <returns></returns>
        public static double GetAngleBetween(this Vector v, Vector u, double eps = 1e-6)
        {
            if (Math.Abs(v.Length()) < eps  || Math.Abs(u.Length()) < eps )
            {
                throw new DivideByZeroException();
            }
            return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
        }

        /// <summary>
        /// Получить отношение векторов: параллельны, перпендикулярны, остальное
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <param name="eps"></param>
        /// <returns></returns>
        public static VectorRelation GetRelation(this Vector v, Vector u, double eps = 1e-6)
        {
            if (Math.Abs(v.Length()) < eps  || Math.Abs(u.Length()) < eps )
            {
                throw new ArgumentException("Can't get relation when argument is zero-vector");
            }

            if (Math.Abs(v.DotProduct(u)) < eps)
            {
                return VectorRelation.Orthogonal;
            }

            if (Math.Abs(v.CrossProduct(u)) < eps)
            {
                return VectorRelation.Parallel;
            } else {
                return VectorRelation.General;
            }
        }

        /// <summary>
        /// Единичный ортогональный данному вектор
        /// </summary>
        /// <param name="v"></param>
        /// <param name="orientation"></param>
        /// <param name="eps"></param>
        /// <returns></returns>
        public static Vector GetOrthogonal(this Vector v, bool orientation = true, double eps = 1e-6)
        {
            if (Math.Abs(v.Length()) < eps)
            {
                throw new ArgumentException("Can't find orthogonal for zero-vector");
            }
            if (orientation)
            {
                double result_X = -v.Y_ / v.Length();
                double result_Y = v.X_ / v.Length();
                return new Vector(result_X, result_Y);
            } else 
            {
                double result_X = v.Y_ / v.Length();
                double result_Y = -v.X_ / v.Length();
                return new Vector(result_X, result_Y);   
            }
        }
        
        /// <summary>
        /// Повернуть вектор на заданный угол
        /// </summary>
        /// <param name="v"></param>
        /// <param name="angle"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public static Vector Rotate(this Vector v, double angle, bool orientation = true)
        {

            if (orientation)
            {
                double result_X = v.X_ * Math.Cos(angle) - v.Y_ * Math.Sin(angle);
                double result_Y = v.X_ * Math.Sin(angle) + v.Y_ * Math.Cos(angle);
                return new Vector(result_X, result_Y);
            } else 
            {
                double result_X = v.X_ * Math.Cos(angle) + v.Y_ * Math.Sin(angle);
                double result_Y = -v.X_ * Math.Sin(angle) + v.Y_ * Math.Cos(angle);
                return new Vector(result_X, result_Y);

            }
        }
    }
}
