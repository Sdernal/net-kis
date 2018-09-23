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
            // не хочется писать сложные проверки с EPS
            // здесь и далее полагаем, что данный класс не используется
            // в точных математических рассчетах; также полагаем, что
            // пользователь "умный" и знает основы геометрии
            if (v.Length() != 0)
            {
                return v / v.Length();
            }
            return new Vector();
        }

        /// <summary>
        /// Получить угол между векторами в радианах
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return Math.Atan2(v.CrossProduct(u), v.DotProduct(u));
        }

        // Получить отношение векторов: параллельны, перпендикулярны, остальное
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (Math.Abs(v.CrossProduct(u)) == 0)
            {
                return VectorRelation.Parallel;
            }
            else if (Math.Abs(v.DotProduct(u)) == 0)
            {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }

        // Еденичный ортогональный вектор данному
        public static Vector GetOrthogonal(this Vector v)
        {
            return new Vector(-v.y, v.x) / v.Length();
        }

        /// <summary>
        /// Rotates vector v by angle
        /// </summary>
        /// <param name="v">Vector v</param>
        /// <param name="angle">Angle in radians</param>
        /// <returns></returns>
        public static Vector Rotate(this Vector v, double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Vector(v.x * cos - v.y * sin, v.x * sin + v.y * cos);
        }
    }
}
