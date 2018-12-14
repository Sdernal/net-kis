using System;
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
    }
}
