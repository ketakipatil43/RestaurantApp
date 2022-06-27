using System.Collections.Generic;

namespace RestaurantApp
{
    public class MenuResult
    {
        public List<string> images { get; set; }
        public string _id { get; set; }
        public string menuname { get; set; }
        public string description { get; set; }
        public int __v { get; set; }
    }
}
