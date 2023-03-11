using System;
using SQLite;

namespace FoodiesApp
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string displayName { get; set; }
        public DateTime modifiedAt { get; set; }
        public int modifiedBy { get; set; }
        public DateTime createdAt { get; set; }
        public int createdBy { get; set; }
        public bool isDeleted { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public bool isAdmin { get; set; }
    }
}
 