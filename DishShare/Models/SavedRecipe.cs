namespace DishShare.Models
{
    public class SavedRecipe
    {
        public int ID { get; set; }
        public DateTime AddingDate { get; set; }
        public required string CollectionName { get; set; }
        public string? PersonalNotes { get; set; }
        public ICollection<SavedRecipesList> SavedRecipesLists { get; set; } = new List<SavedRecipesList>();
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
