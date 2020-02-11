using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.BusinessLayer;

namespace MT.OnlineResturant.ReviewManagement.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    //[ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IRestaurantBusiness _restaurantBusiness;
        public ReviewController(IRestaurantBusiness restaurantBusiness)
        {
            _restaurantBusiness = restaurantBusiness;
        }

       

        /// <summary>
        /// Returns the List of Reviews of a particular Resturant 
        /// </summary>
        /// <param name="restaurantReview"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ResturantReveiws")]
       
        public IActionResult GetResturantReviews([FromBody]RestaurantReviewParams restaurantReviewParams)
        {
            _restaurantBusiness.GetResturantReviews(restaurantReviewParams);
            return Ok();
        }
        /// <summary>
        /// Posts the Reviews of the a resturant
        /// </summary>
        /// <param name="restaurantReview"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ResturantReveiws")]
        public IActionResult PostResturantReview([FromBody]RestaurantReview restaurantReview)
        {
            _restaurantBusiness.PostResturantReview(restaurantReview);
            return Ok();
        }

    }
}