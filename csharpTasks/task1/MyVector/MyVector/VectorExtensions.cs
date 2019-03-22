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
        /// Нормализация вектора
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector Normalize(this Vector v)
        {
            if (v.X == 0 && v.Y == 0) return v;
            return v.Scale(1 / v.Length());
        }

        // Получить угол между векторами в радианах
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return Math.Acos(v.DotProduct(u) / v.Length() / u.Length());
        }

        // Получить отношение векторов: параллельны, перпендикулярны, остальное
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.DotProduct(u) == 0) return VectorRelation.Orthogonal;
            if (v.DotProduct(u) == v.Length() * u.Length()) return VectorRelation.Parallel;
            return VectorRelation.General;
        }

        // Еденичный ортогональный вектор данному
        public static Vector GetOrthogonal(this Vector v)
        {
            return new Vector(v.Y, -v.X).Normalize();
        }

        // Повернуть вектор на заданный угол
        public static Vector Rotate(this Vector v, double angle)
        {
            double cs = Math.Cos(angle);
            double sn = Math.Sin(angle);
            return new Vector(cs * v.X - sn * v.Y, cs * v.Y + sn * v.X);
        }
    }
}
