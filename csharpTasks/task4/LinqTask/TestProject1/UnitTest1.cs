using System;
using Xunit;
using LinqTask;
using System.Linq;
using System.Collections.Generic;

namespace TestProject1
{
    public class UnitTest1
    {    
        [Fact]
        public void IsUser1ReviewsCountMatchesTest()
        {
            var reviewContext = new ReviewContext(_reviewsList);
            var user1ReviewsCount = reviewContext.GetUserReviews(1).Count();
            Assert.Equal(2, user1ReviewsCount);
        }

        [Theory]
        [InlineData("Gluhar", false)]
        [InlineData("GameOfThrones", true)]
        public void IsMovieReviewedTest(string movie, bool reviewed) {
            var reviewContext = new ReviewContext(_reviewsList);
            var isMovieReviewed = reviewContext.IsMovieReviewed(movie);
            Assert.Equal(isMovieReviewed, reviewed);
        }

        [Theory]
        [InlineData(3, 6, "GameOfThrones", false)]
        [InlineData(1, 5, "Avengers", true)]
        public void IsFavouriteResourcesContainsMovieTest(int id1, int id2, string movie, bool contains) {
            var reviewContext = new ReviewContext(_reviewsList);
            var favouriteResources = reviewContext.GetFavouritesResources(id1, id2);
            Assert.Equal(favouriteResources.Contains(movie), contains);
        }
        
        private readonly List<Review> _reviewsList = new List<Review> {
            new Review { UserId = 1, Mark = 4, Movie = "GameOfThrones" },
            new Review { UserId = 1, Mark = 6, Movie = "Avengers" },
            new Review { UserId = 2, Mark = 7, Movie = "GameOfThrones" },
            new Review { UserId = 2, Mark = 7, Movie = "House of Cards" },
            new Review { UserId = 3, Mark = 5, Movie = "GameOfThrones" },
            new Review { UserId = 3, Mark = 8, Movie = "Avengers" }
        };
    }
}