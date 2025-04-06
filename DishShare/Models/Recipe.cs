namespace DishShare.Models
{
    public enum RecipeDifficulty
    {
        VeryEasy, Easy, Medium, Hard, VeryHard
    }
    public enum RecipeCategory
    {
        Appetizer, MainCourse, Dessert, Beverage
    }
    public class Recipe
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Ingredients { get; set; }
        public required string Instructions { get; set; }
        public TimeSpan PreperationTime { get; set; }
        public RecipeDifficulty? Difficulty { get; set; }
        public RecipeCategory? Category { get; set; }
        public virtual ICollection<RecipeAuthor> RecipeAuthors { get; set; } = new List<RecipeAuthor>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public double AverageRating => Ratings.Any() ? Ratings.Average(r => (int)r.RatingValue) : 0;
        public int CommentCount => Comments.Count();
        public int RecipeAuthorCount => RecipeAuthors.Count();
        public int TagCount => Tags.Count();
        public int SavedRecipesListID { get; set; }
        public SavedRecipesList SavedRecipesList { get; set; }
    }
}
