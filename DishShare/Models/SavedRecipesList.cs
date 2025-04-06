namespace DishShare.Models
{
    public class SavedRecipesList
    {
        public int ID { get; set; }
        public required string ListName { get; set; }
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public int SavedRecipeID { get; set; }
        public SavedRecipe SavedRecipe { get; set; }
    }
}
