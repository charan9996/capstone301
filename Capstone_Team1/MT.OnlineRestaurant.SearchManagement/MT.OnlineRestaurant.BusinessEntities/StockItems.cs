﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.BusinessEntities
{
   public  class StockItems
    {
        public int MenuId { get; set; }
        public string Item { get; set; }

        public int RestaurantID { get; set; }
        public int Quantity { get; set; }
    }
}
