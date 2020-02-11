using System;
using System.Collections.Generic;

namespace MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel
{
    public partial class TblRestaurant
    {
    

        public string Name { get; set; }
 
    
        public int Id { get; set; }
  

   
        public ICollection<TblRating> TblRating { get; set; }

    }
}
