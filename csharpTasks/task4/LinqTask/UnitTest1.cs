using System;
using LinqTask;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace LinqTask.Test
{
    public class UnitTest
    {
        public ReviewContext reviewers;
        public IEnumerable<Review> data;
        public UnitTest() {
            data = new[] {
                new Review {UserId = 1, Mark = 8, Movie ="Four Rooms"},
                new Review {UserId = 1, Mark = 2, Movie ="Love, Rosie"},
                new Review {UserId = 2, Mark = 3, Movie ="Home by Spring"},
                new Review {UserId = 3, Mark = 4, Movie ="Home by Spring"},
                new Review {UserId = 3, Mark = 5, Movie ="The Oslo Diaries"},
                new Review {UserId = 4, Mark = 6, Movie ="Love, Rosie"},
                new Review {UserId = 4, Mark = 7, Movie ="The Yellow Handkerchief"},
                new Review {UserId = 4, Mark = 7, Movie ="The Boxer"},
                new Review {UserId = 5, Mark = 8, Movie ="Four Rooms"},
                new Review {UserId = 5, Mark = 9, Movie ="The Yellow Handkerchief"},
                new Review {UserId = 6, Mark = 10, Movie ="Snowden"},
                new Review {UserId = 6, Mark = 7, Movie ="The Oslo Diaries"},
                new Review {UserId = 6, Mark = 6, Movie ="Home by Spring"},
                new Review {UserId = 6, Mark = 3, Movie ="Miral"},
            };
            reviewers = new ReviewContext(data);
        }
        
        [Theory] 
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 2)]
        [InlineData(6, 4)]
        // Получение объектов отзывов у конкретного пользователя
        public void GetUserReviewCheck(int user_id, int ans)
        {
            var test_reviewers = reviewers.GetUserReviews(user_id).Count();
            Assert.Equal(test_reviewers, ans);
        }

        [Theory]
        [InlineData("Four Rooms", 1)]
        [InlineData("The Oslo Diaries", 1)]
        [InlineData("Snowden", 1)]
        [InlineData("Pollyanna", 0)]
        [InlineData("A Good Woman", 0)]
        [InlineData("Agatha and the Truth of Murder", 0)]
        // Оценивал ли кто-нибудь фильм
        public void IsMovieReviewedCheck(string film, int ans)
        {
            var film_to_test = reviewers.IsMovieReviewed(film);
            if (ans == 1)
            {
                Assert.True(film_to_test);
            }
            else
            {
                Assert.False(film_to_test);
            }
        }

        [Theory]
        [InlineData(1, 5, 1)]
        [InlineData(3, 6, 2)]
        [InlineData(2, 6, 1)]
        [InlineData(1, 3, 0)]
        [InlineData(2, 4, 0)]
        // Получить общие фильмы у двух пользователей
        public void CompareUsersCheck(int user1_id, int user2_id, int ans)
        {
            if (ans == 0)
            {
                Assert.Empty(reviewers.CompareUsers(user1_id, user2_id));
            }
            else
            {
                Assert.Equal(ans, reviewers.CompareUsers(user1_id, user2_id).Count());
            }
        }

        [Theory]
        [InlineData(4, 6, new[] { "The Yellow Handkerchief", "The Boxer"})]
        [InlineData(3, 4, new[] { "The Oslo Diaries" })]
        // Получить "любимые" фильмы пользователя (оценка которых больше некоторого значения), упорядоченные по оценке
        public void GetFavouritesResourcesCheck(int user_id, int min_mark, string[] ans_films)
        {
            var films_to_test = reviewers.GetFavouritesResources(user_id, min_mark);
            foreach (var film in ans_films)
            {
                Assert.Contains(film, films_to_test);
            }
        }

        [Theory]
        [InlineData(1, 10)]
        [InlineData(2, 0)]
        [InlineData(3, 4)]
        [InlineData(4, 6)]
        [InlineData(5, 8)]
        [InlineData(6, 16)]
        // Получить сумму четных оценок пользователя
        public void GetUserEvenSumMarksCheck(int user_id, int ans)
        {
            var sum_to_test = reviewers.GetUserEvenSumMarks(user_id);
            Assert.Equal(ans, sum_to_test);
        }

        [Theory]
        [InlineData("Four Rooms", 8.0)]
        [InlineData("The Oslo Diaries", 6.0)]
        [InlineData("Miral", 3)]
        [InlineData("Not exists", 0)]
        // Получить среднюю оценку для каждого фильма
        public void GetMoviesMeanMarkCheck(string movie, double ans_mark)
        {
            var movie_mark_to_test = reviewers.GetMoviesMeanMark(); 
            Assert.Equal(ans_mark, movie_mark_to_test.SingleOrDefault(p => p.Item1 == movie).Item2);
        }
    }
}