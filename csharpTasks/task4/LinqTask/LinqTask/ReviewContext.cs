using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqTask
{
    // Контекст, который хранит список отзывов,
    // нужно реализовать методы-заглушки
    public class ReviewContext
    {
        private IEnumerable<Review> reviews;

        // Инициализируется перечислением отзывов
        public ReviewContext(IEnumerable<Review> visitings)
        {
            this.reviews = visitings;
        }

        // Получение объектов отзывов у конкретного пользователя
        public IEnumerable<Review> GetUserReviews(int userId)
        {
            return reviews.Where(u => u.UserId == userId);
        }

        // Оценивал ли кто-нибудь фильм
        public bool IsMovieReviewed(string movieName)
        {
           return reviews.Where(u => u.Movie == movieName).Count() != 0;
        }

        // Получить общие фильмы у двух пользователей
        public IEnumerable<string> CompareUsers(int user1, int user2)
        {
            return reviews
                .Where(u => u.UserId == user1)
                .Select(u => u.Movie)
                .Intersect(reviews.Where(u => u.UserId == user2)
                .Select(u => u.Movie));
        }

        // Получить "любимые" фильмы пользователя (оценка которых больше некоторого значения), упорядоченные по оценке
        public IEnumerable<string> GetFavouritesResources(int userId, int minimalMark = 5)
        {
            return reviews.Where(u => u.UserId == userId && u.Mark > minimalMark).OrderBy(u => u.Mark).Select(u => u.Movie);
        } 

        // Получить сумму четных оценок пользователя
        public int GetUserEvenSumMarks(int userId)
        {
            return reviews.Where(u => u.UserId == userId && u.Mark % 2 == 0).Sum(u => u.Mark);
        }

        // Получить среднюю оценку для каждого фильма
        public IEnumerable<(string, double)> GetMoviesMeanMark()
        {
            return reviews.GroupBy(u => u.Movie).Select(u => (u.Key, u.Average(t => t.Mark)));
        }    
    }
}
