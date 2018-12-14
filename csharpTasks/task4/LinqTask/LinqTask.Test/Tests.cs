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
            return new ReviewContext(new Review[]
            {
                new Review {UserId = 2, Movie = "Titanic", Mark = 2},
                new Review {UserId = 1, Movie = "Avatar", Mark = 10},
                new Review {UserId = 1, Movie = "Titanic", Mark = 7},
                new Review {UserId = 3, Movie = "The Shawshank Redemption", Mark = 9},
                new Review {UserId = 1, Movie = "The Lion King", Mark = 3},
                new Review {UserId = 2, Movie = "The Lion King", Mark = 10},
                new Review {UserId = 3, Movie = "The Lion King", Mark = 8}
            });
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 2)]
        [InlineData(3, 2)]
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
    }
}
