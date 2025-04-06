namespace DishShare.Models
{
    public enum RatingValue
    {
        VeryBad = 0, Bad = 1, Okay = 2, Good = 3, VeryGood = 4, Excellent = 5
    }

    public class Rating
    {
        public int ID { get; set; }
        public required RatingValue RatingValue { get; set; }
        public DateTime RatingDate { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
