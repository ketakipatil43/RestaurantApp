using System;
using System.Collections.Generic;

namespace RestaurantApp
{
    public class RestaurantResult
    {
        public int reviews { get; set; }
        public bool parkinglot { get; set; }
        public string location { get; set; }
        public string phone { get; set; }
        public int averagecost { get; set; }
        public string image { get; set; }
        public string imageId { get; set; }
        public string restauranttype { get; set; }
        public string _id { get; set; }
        public string businessname { get; set; }
        public string address { get; set; }
        public string menu { get; set; }
        public string slug { get; set; }
        public string email { get; set; }
        public int __v { get; set; }
        public List<object> foodMenu { get; set; }
        public string id { get; set; }
        public string website { get; set; }
    }
}
