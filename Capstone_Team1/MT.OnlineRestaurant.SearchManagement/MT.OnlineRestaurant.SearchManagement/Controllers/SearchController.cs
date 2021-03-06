﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.BusinessLayer;
using MT.OnlineRestaurant.BusinessLayer.interfaces;

namespace MT.OnlineRestaurant.SearchManagement.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class SearchController : Controller
    {
        private readonly IRestaurantBusiness business_Repo;

        private readonly IAzureBus AzureBus;

        public SearchController(IRestaurantBusiness _business_Repo, IAzureBus azureBus)
        {
            business_Repo = _business_Repo;
            AzureBus = azureBus;
        }
        [HttpGet]
        [Route("ResturantDetail")]
        public RestaurantInformation GetResturantDetail([FromQuery] int RestaurantID)
        {          
            RestaurantInformation resturantInformation = new RestaurantInformation();
            resturantInformation = business_Repo.GetResturantDetails(RestaurantID);
            return resturantInformation;
        }

        [HttpGet]
        [Route("ResturantMenuDetail")]
        public IActionResult GetResturantMenuDetail([FromQuery] int RestaurantID)
        {
            IQueryable<RestaurantMenu> restaurantMenuDetails;
            restaurantMenuDetails = business_Repo.GetRestaurantMenus(RestaurantID);
            if (restaurantMenuDetails != null)
            {
                return this.Ok(restaurantMenuDetails);
            }
            return this.StatusCode((int)HttpStatusCode.InternalServerError, string.Empty);
        }

        [HttpGet]
        [Route("ResturantRating")]
        public IActionResult GetResturantRating([FromQuery] int RestaurantID)
        {
            IQueryable<RestaurantRating> restaurantRatings;
            restaurantRatings = business_Repo.GetRestaurantRating(RestaurantID);
            if (restaurantRatings != null)
            {
                return this.Ok(restaurantRatings);
            }

            return this.StatusCode((int)HttpStatusCode.InternalServerError, string.Empty);
        }

        [HttpPost]
        [Route("ResturantRating")]
        public IActionResult ResturantRating([FromQuery] RestaurantRating restaurantRating)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            business_Repo.RestaurantRating(restaurantRating);

            return this.Ok("Submitted the reviewes");
        }

        [HttpGet]
        [Route("ResturantTable")]
        public IActionResult GetResturantTableDetails([FromQuery] int RestaurantID)
        {
            IQueryable<RestaurantTables> restaurant_TableDetails;
            restaurant_TableDetails = business_Repo.GetTableDetails(RestaurantID);
            if (restaurant_TableDetails != null)
            {
                return this.Ok(restaurant_TableDetails);
            }
            return this.StatusCode((int)HttpStatusCode.InternalServerError, string.Empty);
        }

        [HttpPost]
        [Route("SearchRestaurantBasedOnDistance")]
        public IActionResult SearchRestaurantBasedOnDistance([FromBody] LocationDetails locationDetails)
        {
            IQueryable<RestaurantInformation> restaurantDetails;
            restaurantDetails = business_Repo.SearchRestaurantByLocation(locationDetails);
            if (restaurantDetails != null)
            {
                return this.Ok(restaurantDetails);
            }
            return this.StatusCode((int)HttpStatusCode.InternalServerError, string.Empty);

        }

        [HttpPost]
        [Route("SearchRestaurantBasedOnMenu")]
        public IActionResult SearchRestaurantBasedOnMenu([FromBody] AdditionalFeatureForSearch additionalFeatureForSearch)
        {
            IQueryable<RestaurantInformation> restaurantDetails;
            restaurantDetails = business_Repo.GetRestaurantsBasedOnMenu(additionalFeatureForSearch);
            if (restaurantDetails != null)
            {
                return this.Ok(restaurantDetails);
            }
            return this.StatusCode((int)HttpStatusCode.InternalServerError, string.Empty);

        }
        /// <summary>
        /// Method to get Restarunt Details
        /// </summary>
        /// <param name="searchDetails"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("SearchForRestaurant")]
        public  IActionResult SearchForRestaurant([FromBody] SearchForRestaurant searchDetails)
        {
            IQueryable<RestaurantInformation> restaurantDetails;
            restaurantDetails =  business_Repo.SearchForRestaurant(searchDetails);
            if (restaurantDetails != null)
            {
                return this.Ok(restaurantDetails);
            }
            return this.StatusCode((int)HttpStatusCode.InternalServerError, string.Empty);

        }
        [HttpGet]
        [Route("OrderDetail")]
        public IActionResult OrderDetail([FromQuery]int restaurantID,int menuID)
        {
            int query_result = business_Repo.ItemInStock(restaurantID, menuID);
            if (query_result > 0)
            {
                return Ok(restaurantID);
            }
            return this.StatusCode((int)HttpStatusCode.InternalServerError, "error");
        }

        [HttpGet]
        [Route("StockDeatils")]
        public IActionResult GetStockDetails([FromQuery]int ResturantID, int MenuId)
        {
          // string result=AzureBus.AzureServiceBus();
           var result =business_Repo.GetStockDetails(ResturantID, MenuId);
            if (result!=null)
            {
                return Ok(result);
            }
            return this.StatusCode((int)HttpStatusCode.InternalServerError, "error");
        }
    }
}