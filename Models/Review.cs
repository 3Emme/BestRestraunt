namespace BestRestaurants.Models
{
    public class Review
    {
        public int ReviewId {get;set;}
        public string ReviewUser {get;set;}
        public string ReviewDate {get;set;}
        public string ReviewHeader {get;set;}
        public string ReviewBody {get;set;}
        public int RestaurantId {get;set;}
        public virtual Restaurant Restaurant {get;set;}
        public Review()
        {

        }
    }
}