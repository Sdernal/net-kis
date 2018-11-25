using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqTask
{
    // Контекст, который хранит список отзывов,
    // нужно реализовать методы-заглушки
    class ReviewContext
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
            return from rw in this.reviews
                   where rw.UserId == userId
                   select rw;
        }

        // Оценивал ли кто-нибудь фильм
        public bool IsMovieReviewed(string movieName)
        {
            return this.reviews.Any(rw => rw.Movie == movieName);
        }

        // Получить общие фильмы у двух пользователей
        public IEnumerable<string> CompareUsers(int user1, int user2)
        {
            return from rw1 in this.GetUserReviews(user1)
                   join rw2 in this.GetUserReviews(user2) on rw1.Movie equals rw2.Movie
                   select rw1.Movie;

        }

        // Получить "любимые" фильмы пользователя (оценка которых больше некоторого значения), упорядоченные по оценке
        public IEnumerable<string> GetFavouritesResources(int userId, int minimalMark = 5)
        {
            return from rw in this.reviews
                   where rw.UserId == userId && rw.Mark > minimalMark
                   orderby rw.Mark
                   select rw.Movie;
        }

        // Получить сумму четных оценок пользователя
        public int GetUserEvenSumMarks(int userId)
        {
            return (from rw in this.reviews
                    where rw.UserId == userId && rw.Mark % 2 == 0
                    select rw.Mark).Sum();
        }

        // Получить среднюю оценку для каждого фильма
        public IEnumerable<(string, double)> GetMoviesMeanMark()
        {
            return from rw in this.reviews
                   group rw by rw.Movie into g
                   select (g.Key, (from rw in g select rw.Mark).Average());
        }    
    }
}
