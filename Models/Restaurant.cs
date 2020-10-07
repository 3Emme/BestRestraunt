namespace BestRestaurants.Models
{
    public class Restaurant
    {
        public int RestaurantId;
        public string RestaurantName;
        public string RestaurantLocation;
        public string RestaurantPhone;
        public string RestaurantMenu;
        public string CuisineType;
        public virtual Cuisine Cuisine {get;set;}

        public Restaurant()
        {

        }

    }
}