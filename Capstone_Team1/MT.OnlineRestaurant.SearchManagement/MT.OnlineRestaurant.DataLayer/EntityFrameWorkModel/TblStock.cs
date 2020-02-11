using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel
{
    public class TblStock
    {
        public int MenuId { get; set; }
        public string Item  { get;set; }
                                            
        public int RestaurantID { get; set; }
      public int Quantity { get; set; }


    }
}
