using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DishShare.Models;

namespace DishShare.Data
{
    public class DishShareContext : DbContext
    {
        public DishShareContext (DbContextOptions<DishShareContext> options)
            : base(options)
        {
        }

        public DbSet<DishShare.Models.Recipe> Recipe { get; set; } = default!;
        public DbSet<DishShare.Models.User> User { get; set; } = default!;
        public DbSet<DishShare.Models.Tag> Tag { get; set; } = default!;
        public DbSet<DishShare.Models.SavedRecipesList> SavedRecipesList { get; set; } = default!;
        public DbSet<DishShare.Models.SavedRecipe> SavedRecipe { get; set; } = default!;
        public DbSet<DishShare.Models.RecipeAuthor> RecipeAuthor { get; set; } = default!;
        public DbSet<DishShare.Models.Rating> Rating { get; set; } = default!;
        public DbSet<DishShare.Models.Comment> Comment { get; set; } = default!;
    }
}
