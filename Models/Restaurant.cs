namespace BestRestaurants.Models
{
    public class Restaurant
    {
        public int RestaurantId {get;set;}
        public string RestaurantName {get;set;}
        public string RestaurantLocation {get;set;}
        public string RestaurantPhone {get;set;}
        public string RestaurantMenu {get;set;}
        public int CuisineId {get;set;}
        public virtual Cuisine Cuisine {get;set;}

        public Restaurant()
        {

        }

    }
}