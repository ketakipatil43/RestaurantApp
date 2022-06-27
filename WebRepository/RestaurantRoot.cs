using System.Collections.Generic;

namespace RestaurantApp
{
    public class RestaurantRoot
    {
        public int TotalRestaurants { get; set; }
        public List<RestaurantResult> Result { get; set; }
    }
}
