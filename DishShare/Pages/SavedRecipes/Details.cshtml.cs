using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DishShare.Data;
using DishShare.Models;

namespace DishShare.Pages.SavedRecipes
{
    public class DetailsModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public DetailsModel(DishShare.Data.DishShareContext context)
        {
            _context = context;
        }

        public SavedRecipe SavedRecipe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedrecipe = await _context.SavedRecipe.FirstOrDefaultAsync(m => m.ID == id);
            if (savedrecipe == null)
            {
                return NotFound();
            }
            else
            {
                SavedRecipe = savedrecipe;
            }
            return Page();
        }
    }
}
