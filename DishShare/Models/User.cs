namespace DishShare.Models
{
    public enum Status
    {
        Active, Inactive, Suspended
    }
    public class User
    {
        public int UserID { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string? Email { get; set; }
        public DateTime CreationDate { get; set; }
        public Status? Status { get; set; }
        public virtual ICollection<SavedRecipe> SavedRecipes { get; set; } = new List<SavedRecipe>();
        public virtual ICollection<RecipeAuthor> RecipeAuthors { get; set; } = new List<RecipeAuthor>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
