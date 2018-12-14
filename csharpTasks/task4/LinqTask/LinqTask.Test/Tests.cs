using System.Linq;
using Xunit;

namespace LinqTask.Test
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyReviewsTest()
        {
            var rc = new ReviewContext(new Review[0]);
            Assert.Empty(rc.GetUserReviews(3));
            Assert.False(rc.IsMovieReviewed("Titanic"));
            Assert.Empty(rc.CompareUsers(0, 1));
            Assert.Empty(rc.GetFavouritesResources(2));
            Assert.Equal(0, rc.GetUserEvenSumMarks(1));
            Assert.Empty(rc.GetMoviesMeanMark());
        }

        private static ReviewContext GetTestSet()
        {
            return new ReviewContext(new[]
            {
                new Review {UserId = 2, Movie = "Titanic", Mark = 2},
                new Review {UserId = 1, Movie = "Avatar", Mark = 10},
                new Review {UserId = 1, Movie = "Titanic", Mark = 7},
                new Review {UserId = 3, Movie = "The Shawshank Redemption", Mark = 9},
                new Review {UserId = 1, Movie = "The Lion King", Mark = 3},
                new Review {UserId = 2, Movie = "The Lion King", Mark = 10},
                new Review {UserId = 3, Movie = "The Lion King", Mark = 8},
                new Review {UserId = 3, Movie = "Interstellar", Mark = 1},
                new Review {UserId = 4, Movie = "The Godfather", Mark = 8}
            });
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(5, 0)]
        public void UserReviewsTest(int id, int count)
        {
            var rc = GetTestSet();
            Assert.Equal(count, rc.GetUserReviews(id).Count());
            Assert.True(rc.GetUserReviews(id).All(r => r.UserId == id));
        }

        [Theory]
        [InlineData("1+1", false)]
        [InlineData("The Lion King", true)]
        [InlineData("Avatar", true)]
        [InlineData("Forrest Gump", false)]
        public void IsMovieReviewedTest(string name, bool answer)
        {
            var rc = GetTestSet();
            Assert.Equal(answer, rc.IsMovieReviewed(name));
        }

        [Theory]
        [InlineData(4, 4, 1, new[] {"The Godfather"})]
        [InlineData(2, 3, 1, new[] {"The Lion King"})]
        [InlineData(1, 4, 0, new string[] { })]
        [InlineData(2, 1, 2, new[] {"The Lion King", "Titanic"})]
        public void CompareUsersTest(int user1, int user2, int count,
            string[] common)
        {
            var rc = GetTestSet();
            var interception = rc.CompareUsers(user1, user2).ToList();
            Assert.Equal(count, interception.Count);
            foreach (var movie in common)
            {
                Assert.Contains(movie, interception);
            }
        }

        [Theory]
        [InlineData(1, 8, 1, new[] {"Avatar"})]
        [InlineData(3, 10, 0, new string[] { })]
        [InlineData(3, 4, 2, new[] {"The Lion King"})]
        public void GetFavouritesResourcesTest(int id, int minimalMark,
            int count, string[] content)
        {
            var favorites = GetTestSet().GetFavouritesResources(id, minimalMark)
                .ToList();
            Assert.Equal(count, favorites.Count);
            foreach (var movie in content)
            {
                Assert.Contains(movie, favorites);
            }
        }

        [Theory]
        [InlineData(5, 0)]
        [InlineData(1, 10)]
        [InlineData(3, 8)]
        [InlineData(2, 12)]
        public void GetUserEvenSumMarksTest(int id, int answer)
        {
            Assert.Equal(answer, GetTestSet().GetUserEvenSumMarks(id));
        }

        [Theory]
        [InlineData("The Lion King", 7.0)]
        [InlineData("Titanic", 4.5)]
        [InlineData("Avatar", 10.0)]
        public void GetMoviesMeanMarkTest(string movie, double mark)
        {
            var marks = GetTestSet().GetMoviesMeanMark();
            Assert.Equal(mark,
                marks.FirstOrDefault(p => p.Item1 == movie).Item2,
                1);
        }
    }
}
