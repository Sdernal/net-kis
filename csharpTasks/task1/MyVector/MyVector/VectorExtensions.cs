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
        /// нормализованный вектор, исходный вектор не меняется
        /// </summary>
        public static Vector Normalize(this Vector v)
        {
            if (v.Length() == 0) throw new ArgumentException();
            return v / v.Length();
        }

        // Получить угол между векторами в радианах
        /// <summary>
        /// угол между векторами
        /// </summary>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.Length() == 0 || u.Length() == 0) throw new ArgumentException();
            return Math.Acos(v.DotProduct(u) / v.Length() / u.Length());
        }

        // Получить отношение векторов: параллельны, перпендикулярны, остальное
        /// <summary>
        /// отношение между векторами
        /// </summary>
        /// <returns>VectorRelation (Parallel, General, Orthogonal)</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            VectorRelation relation = VectorRelation.General;
            if (v.X * u.Y == v.Y * u.X) relation = VectorRelation.Parallel;
            if (v.DotProduct(u) == 0) relation = VectorRelation.Orthogonal;
            return relation;
        }

        // Еденичный ортогональный вектор данному
        /// <summary>
        /// вектор ортогональный данному
        /// </summary>
        public static Vector GetOrthogonal(this Vector v)
        {
            if (v.Length() == 0) throw new ArgumentException();
            return new Vector(-v.Y, v.X) / v.Length();
        }

        // Повернуть вектор на заданный угол
        /// <summary>
        /// поворот на заднный угол
        /// </summary>
        public static Vector Rotate(this Vector v, double angle)
        {
            double cs = Math.Cos(angle);
            double sn = Math.Sin(angle);
            return new Vector(cs * v.X - sn * v.Y, cs * v.Y + sn * v.X);
        }
    }
}
