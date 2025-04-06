namespace DishShare.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public required string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
