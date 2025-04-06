using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DishShare.Data;
using DishShare.Models;

namespace DishShare.Pages.SavedRecipesLists
{
    public class DeleteModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public DeleteModel(DishShare.Data.DishShareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SavedRecipesList SavedRecipesList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedrecipeslist = await _context.SavedRecipesList.FirstOrDefaultAsync(m => m.ID == id);

            if (savedrecipeslist == null)
            {
                return NotFound();
            }
            else
            {
                SavedRecipesList = savedrecipeslist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savedrecipeslist = await _context.SavedRecipesList.FindAsync(id);
            if (savedrecipeslist != null)
            {
                SavedRecipesList = savedrecipeslist;
                _context.SavedRecipesList.Remove(SavedRecipesList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
