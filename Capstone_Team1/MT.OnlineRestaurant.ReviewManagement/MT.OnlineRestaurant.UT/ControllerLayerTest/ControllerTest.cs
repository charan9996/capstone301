using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using MT.OnlineRestaurant.BusinessLayer;
using MT.OnlineRestaurant.ReviewManagement.Controllers;
using MT.OnlineRestaurant.BusinessEntities;
using Microsoft.AspNetCore.Mvc;

namespace MT.OnlineRestaurant.UT.ControllerLayerTest
{
    [TestFixture]
    class ControllerTest
    {

        Mock<IRestaurantBusiness> _mockReviewRepository = new Mock<IRestaurantBusiness>();
        Mock<ReviewController> _mockreviewcontroller = new Mock<ReviewController>();

        [Test]
        public void Get()
        {
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
            _mockReviewRepository.Setup(x => x.GetResturantReviews(restaurantReviewParams)).Returns(result);
           // _mockreviewcontroller.Setup(x => x.GetResturantReviews(1, 123)).Returns();
            ReviewController reviewController = new ReviewController(_mockReviewRepository.Object);
            var results = reviewController.GetResturantReviews(1, 123);
            var status = (results as OkObjectResult).StatusCode;
            Assert.AreEqual(status, 200);



        }

    }
}
