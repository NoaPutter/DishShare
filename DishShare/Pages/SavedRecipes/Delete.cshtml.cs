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
    public class DeleteModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public DeleteModel(DishShare.Data.DishShareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SavedRecipe SavedRecipe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedrecipe = await _context.SavedRecipe.FirstOrDefaultAsync(m => m.SavedRecipeID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedrecipe = await _context.SavedRecipe.FindAsync(id);
            if (savedrecipe != null)
            {
                SavedRecipe = savedrecipe;
                _context.SavedRecipe.Remove(SavedRecipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
