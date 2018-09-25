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
        public static Vector Normalize(this Vector v)
        {
            return v / v.Length();
        }

        // Получить угол между векторами в радианах
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
        }

        // Получить отношение векторов: параллельны, перпендикулярны, остальное
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (Math.Abs(v.CrossProduct(u)) < 1e-4) // TODO: think about it
            {
                return VectorRelation.Parallel;
            }

            return Math.Abs(v.DotProduct(u)) < 1e-4 // TODO: and here
                ? VectorRelation.Orthogonal
                : VectorRelation.General;
        }

        // Еденичный ортогональный вектор данному
        public static Vector GetOrthogonal(this Vector v)
        {
            return new Vector(v.Y, -v.X).Normalize();
        }

        // Повернуть вектор на заданный угол
        public static Vector Rotate(this Vector v, double angle)
        {
            return new Vector(v.X * Math.Cos(angle) - v.Y * Math.Sin(angle),
                v.X * Math.Sin(angle) + v.Y * Math.Cos(angle));
        }
    }
}