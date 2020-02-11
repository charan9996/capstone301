using System;
using System.ComponentModel.DataAnnotations;

namespace MT.OnlineRestaurant.BusinessEntities
{
    public class RestaurantReview
    {
        [Key]
        public int Id { get; set; }
        public string Rating { get; set; }
        public string Comments { get; set; }
        public int RestaurantId { get; set; }
        public int CustomerId { get; set; }
        public int UserCreated { get; set; }
        public int UserModified { get; set; }
   
    }
}
