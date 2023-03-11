using System;
using SQLite;

namespace FoodiesApp
{
    public class Restaurant
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string displayName { get; set; }
        public string address { get; set; }
        public int priceForTwo { get; set; }
        public int adminId { get; set; }
    }
}
