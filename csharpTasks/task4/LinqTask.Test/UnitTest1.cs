using NUnit.Framework;
using LinqTask;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {

        private readonly ReviewContext _reviews;
        private readonly IEnumerable<Review> ListOfReviews;

        public Tests()
        {
            ListOfReviews = new[] {
                new Review {UserId = 1, Mark = 5, Movie="Game of thrones"},
                new Review {UserId = 1, Mark = 10, Movie="The Lord of the rings"},
                new Review {UserId = 1, Mark = 8, Movie="Avatar"},
                new Review {UserId = 2, Mark = 10, Movie="Titanic"},
                new Review {UserId = 2, Mark = 10, Movie="The quent Don"},
                new Review {UserId = 2, Mark = 9, Movie="Master and Margaret"},
                new Review {UserId = 3, Mark = 4, Movie="Avengers"},
                new Review {UserId = 3, Mark = 10, Movie = "The reader"}, //10!!!
                new Review {UserId = 3, Mark = 7, Movie = "Notre Dame de Paris"}
            };
            _reviews = new ReviewContext(ListOfReviews);
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsMovieReviewedTrue()
        {
            foreach (var review in ListOfReviews)
            {
                Assert.IsTrue(_reviews.IsMovieReviewed(review.Movie), $"The film {review.Movie} is in reviews");
            }
        }

        [TestCase("Inception")]
        [TestCase("The Lion King")]
        [TestCase("The Prestige")]
        public void IsMovieReviewedFalse(string FakeMovie)
        {
            Assert.IsFalse(_reviews.IsMovieReviewed(FakeMovie));
        }

        [Test]
        public void UsersReviews()
        {
            var users = ListOfReviews.Select(r => r.UserId);
            foreach (var user in users)
            {
                Assert.IsNotEmpty(_reviews.GetUserReviews(user));
            }
            Assert.IsEmpty(_reviews.GetUserReviews(ListOfReviews.Count() + 1));
            Assert.IsEmpty(_reviews.GetUserReviews(ListOfReviews.Count() + 10));
        }

        [TestCase(1, 6)]
        [TestCase(2, 4)]
        [TestCase(3, 7)]
        [TestCase(100, 10)]
        [TestCase(1, 20)]
        public void BestMovies(int userId, int minimalRate)
        {
            var bestMovies = ListOfReviews.Where(r => r.UserId == userId && r.Mark > minimalRate).OrderBy(x => x.Mark).Select(x => x.Movie);
            var MoviesFromReviews = _reviews.GetFavouritesResources(userId, minimalRate);
            Assert.AreEqual(MoviesFromReviews.Count(), bestMovies.Count());
            int i = 0;
            foreach (var movie in bestMovies)
            {
                Assert.IsTrue(MoviesFromReviews.ElementAt(i++) == movie);
            }
            
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(1000)]
        public void SumMarks(int userId)
        {
            var sum = ListOfReviews.Where(r => r.UserId == userId && r.Mark % 2 == 0).Select(r => r.Mark).Sum();
            Assert.AreEqual(_reviews.GetUserEvenSumMarks(userId), sum, 1e-3);
        }

        [Test]
        public void MoviesMeanMark()
        {
            var movies = ListOfReviews.GroupBy(r => r.Movie).Select(r => r.Key);
            foreach(var movie in movies)
            {
                var avg = ListOfReviews.Where(r => r.Movie == movie).Select(r => r.Mark).Average();
                Assert.AreEqual(_reviews.GetMoviesMeanMark().Where(r => r.Item1 == movie).First().Item2, avg, 1e-3);
            }
        }

        [TestCase (1, 2)]
        [TestCase(1, 1000)]
        public void UsersComparation(int user1, int user2)
        {
            var CommonMovies = ListOfReviews.Where(u => u.UserId == user1)
                .Select(u => u.Movie)
                .Intersect(ListOfReviews.Where(u => u.UserId == user2)
                .Select(u => u.Movie));
            Assert.AreEqual(CommonMovies, _reviews.CompareUsers(user1, user2));
            foreach(var film in CommonMovies)
            {
                Assert.IsTrue(_reviews.CompareUsers(user1, user2).Contains(film));
            }
        }

    }
}
