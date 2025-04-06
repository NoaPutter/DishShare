namespace DishShare.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public required string TagName { get; set; }
        public bool IsPublic { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
