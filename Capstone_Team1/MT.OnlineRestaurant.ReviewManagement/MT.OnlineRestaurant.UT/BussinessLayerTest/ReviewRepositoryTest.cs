using Microsoft.AspNetCore.Mvc;
using Moq;
using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.BusinessLayer;
using MT.OnlineRestaurant.DataLayer.Repository;
//using MT.OnlineRestaurant.SearchManagement.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MT.OnlineRestaurant.UT
{
    [TestFixture]
    public class RestaurantBusinessTest
    {
        Mock<IReviewRepository> _mockReviewRepository = new Mock<IReviewRepository>();
        public RestaurantBusinessTest()
        {
          
        }
       


        [Test]
        public void GetResturantReviews()
        {
            
            //GetResturantReviews
            ////Arrange
            //List<RestaurantRating> restaurantRatings = new List<RestaurantRating>();
            //restaurantRatings.Add(new RestaurantRating()
            //{
            //    RestaurantId = 1,
            //    customerId = 1,
            //    rating = "4",
            //    user_Comments = "",
            //});
            //var mockOrder = new Mock<IRestaurantBusiness>();
            //mockOrder.Setup(x => x.GetRestaurantRating(1)).Returns(restaurantRatings.AsQueryable());

            ////Act
            //var searchController = new SearchController(mockOrder.Object);
            //var data = searchController.GetResturantRating(1);
            //var okObjectResult = data as OkObjectResult;

            ///Arrange
            List<RestaurantReview> result = new List<RestaurantReview>();

            result.Add(new RestaurantReview
            {
                Id = 1,
                Rating = "5",
                Comments = "yoyo",
                RestaurantId = 1,
                CustomerId = 123,
                UserCreated = 1,
                UserModified = 1
            });

            result.Add(new RestaurantReview
            {
                Id = 3,
                Rating = "5",
                Comments = "Good",
                RestaurantId = 1,
                CustomerId = 123,
                UserCreated = 1,
                UserModified = 1
            });
            result.Add(new RestaurantReview
            {
                Id = 5,
                Rating = "4",
                Comments = "OKOK",
                RestaurantId = 1,
                CustomerId = 123,
                UserCreated = 11,
                UserModified = 11
            });
            RestaurantReviewParams restaurantReviewParams = new RestaurantReviewParams { CustomerID = 123, RestaurantID = 1 };
            // var mockReview = new Mock<IReviewRepository>();
            _mockReviewRepository.Setup(x => x.GetResturantReviews(restaurantReviewParams)).Returns(result);
            var restaurantBusiness = new RestaurantBusiness(_mockReviewRepository.Object);
            ///Act
          var resultOfReview=  restaurantBusiness.GetResturantReviews(restaurantReviewParams);

            Assert.AreEqual(resultOfReview.Count(), 3);
            ////Asserts
            //Assert.AreEqual(200, okObjectResult.StatusCode);
            //Assert.IsNotNull(okObjectResult);
            //Assert.AreEqual((okObjectResult.Value as IEnumerable<RestaurantRating>).Count(), restaurantRatings.Count());
        }

        //public void search

        [Test]
        public void PostResturantReview()
        {
            string result = "Comments submiited Successfully";
            RestaurantReview restaurantReview = new RestaurantReview() { Id = 0, Comments="Good",CustomerId=123,RestaurantId=1,Rating="5",UserCreated=1,UserModified=11};

            _mockReviewRepository.Setup(x => x.PostResturantReview(restaurantReview)).Returns(result);
            var restaurantBusiness = new RestaurantBusiness(_mockReviewRepository.Object);
           var resultout= restaurantBusiness.PostResturantReview(restaurantReview);

            Assert.AreEqual(resultout, result);

        }
        [Test]
        public void EditResturantReview()
        {
            bool result = true;
            RestaurantReview restaurantReview = new RestaurantReview() { Id = 1, Comments = "Good", CustomerId = 123, RestaurantId = 1, Rating ="5", UserCreated = 1, UserModified = 11 };
            _mockReviewRepository.Setup(x => x.EditResturantReview(restaurantReview)).Returns(result);
            var restaurantBusiness = new RestaurantBusiness(_mockReviewRepository.Object);
            var resultout = restaurantBusiness.EditResturantReview(restaurantReview);
            Assert.AreEqual(resultout, result);

        }

        [Test]
        public void EditResturantReviewforfalsedata()
        {
            bool result = false;
            RestaurantReview restaurantReview = new RestaurantReview() { Id = 1, Comments = "Good", CustomerId = 0, RestaurantId = 0, Rating = "5", UserCreated = 1, UserModified = 11 };
            _mockReviewRepository.Setup(x => x.EditResturantReview(restaurantReview)).Returns(result);
            var restaurantBusiness = new RestaurantBusiness(_mockReviewRepository.Object);
            var resultout = restaurantBusiness.EditResturantReview(restaurantReview);
            Assert.AreEqual(resultout, result);

        }



    }
}
