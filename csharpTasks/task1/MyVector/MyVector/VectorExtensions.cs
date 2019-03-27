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
        // Нормализовать вектор
        /// <summary>
        /// нормализованный вектор
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector Normalize(this Vector v)
        {
            v /= v.Length();
            return v;
        }

        // Получить угол между векторами в радианах
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return Math.Acos(v.DotProduct(u) / v.Length() / u.Length());
        }

        // Получить отношение векторов: параллельны, перпендикулярны, остальное
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            switch (v.GetAngleBetween(u))
            {
                case 0:
                    return VectorRelation.Parallel;
                case Math.PI:
                    return VectorRelation.Parallel;
                case (Math.PI / 2):
                    return VectorRelation.Orthogonal;
                default:
                    return VectorRelation.General;
            }

        }

        // Единичный ортогональный вектор данному
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector GetOrthogonal(this Vector v)
        {
            return new Vector(-v.Y, v.X).Normalize();
        }

        // Повернуть вектор на заданный угол
        public static Vector Rotate(this Vector v, double angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            return new Vector(c * v.X - s * v.Y, c * v.Y + s * v.X);
        }
    }
}
