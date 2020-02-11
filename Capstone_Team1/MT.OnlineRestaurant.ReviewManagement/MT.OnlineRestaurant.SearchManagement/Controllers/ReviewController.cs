using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.BusinessLayer;


namespace MT.OnlineRestaurant.ReviewManagement.Controllers
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

        public IActionResult GetResturantReviews([FromQuery] int ResturantId,int custumorid)
        {
            RestaurantReviewParams restaurantReviewParams = new RestaurantReviewParams { RestaurantID= ResturantId, CustomerID=custumorid};
           var result= _restaurantBusiness.GetResturantReviews(restaurantReviewParams);
            if (result != null)
                return Ok(result);
            else if(result.Count==0)
                return NotFound((int)HttpStatusCode.NotFound);
            else
                return this.StatusCode((int)HttpStatusCode.InternalServerError, string.Empty);


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
           var result= _restaurantBusiness.PostResturantReview(restaurantReview);
            if(result!=null)
            return Ok(result);
            else
                return this.StatusCode((int)HttpStatusCode.InternalServerError, string.Empty);
        }

        [HttpPut]
        [Route("EditResturantReveiws")]
        public IActionResult PutResturantReview([FromBody]RestaurantReview restaurantReview)
        {
            var result = _restaurantBusiness.EditResturantReview(restaurantReview);
            if (result== true)
                return Ok(restaurantReview);
            else if (result == false)
                return this.StatusCode((int)HttpStatusCode.NoContent, "Please provide proper customer and resturant Combination");
            else
                return this.StatusCode((int)HttpStatusCode.InternalServerError, string.Empty);
        }

    }
}