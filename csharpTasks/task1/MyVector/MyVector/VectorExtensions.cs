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
            // throw new NotImplementedException();
            if (Math.Abs(v.Length()) < 0.00001) {
                return new Vector(0.0, 0.0);
            }
            return (v / v.Length());
        }

        // Получить угол между векторами в радианах
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            // throw new NotImplementedException();
            if (Math.Abs(v.Length() * u.Length()) < 0.0000000001)
            {
                return 0.0;
            }
            return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
        }

        // Получить отношение векторов: параллельны, перпендикулярны, остальное
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            // throw new NotImplementedException();
            double product = v.DotProduct(u);
            if (Math.Abs(product) < 0.00001) {
                return VectorRelation.Orthogonal;
            }
            if (Math.Abs(Math.Abs(product) - v.Length() * u.Length()) < 0.000000001) {
                return VectorRelation.Parallel;
            }
            return VectorRelation.General;
        }

        // Единичный ортогональный вектор данному
        public static Vector GetOrthogonal(this Vector v)
        {
            // throw new NotImplementedException();
            Vector orthonogal = new Vector(-v.y, v.x);
            orthonogal /= Math.Sqrt(v.x * v.x + v.y * v.y);
            return orthonogal;
        }

        // Повернуть вектор на заданный угол
        public static Vector Rotate(this Vector v, double angle)
        {
            // throw new NotImplementedException();
            return new Vector(v.x * Math.Cos(angle) - v.y * Math.Sin(angle), 
            v.x * Math.Sin(angle) + v.y * Math.Cos(angle));
        }
    }
}
