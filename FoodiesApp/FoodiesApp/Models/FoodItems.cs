using System;
using SQLite;

namespace FoodiesApp
{
    public class FoodItems
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        //public int restaurantId { get; set; }
        public string foodName { get; set; }
        public int price { get; set; }
    }
}
