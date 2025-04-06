namespace DishShare.Models
{
    public enum UserRole
    {
        Author, Editor, Contributor, Reviewer
    }
    public enum ContributionType
    {
        Original, Update, Comment, Review
    }
    public class RecipeAuthor
    {
        public int ID { get; set; }
        public UserRole? UserRole { get; set; }
        public ContributionType? ContributionType { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
