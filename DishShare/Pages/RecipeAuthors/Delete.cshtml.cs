using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DishShare.Data;
using DishShare.Models;

namespace DishShare.Pages.RecipeAuthors
{
    public class DeleteModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public DeleteModel(DishShare.Data.DishShareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecipeAuthor RecipeAuthor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeauthor = await _context.RecipeAuthor.FirstOrDefaultAsync(m => m.ID == id);

            if (recipeauthor == null)
            {
                return NotFound();
            }
            else
            {
                RecipeAuthor = recipeauthor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeauthor = await _context.RecipeAuthor.FindAsync(id);
            if (recipeauthor != null)
            {
                RecipeAuthor = recipeauthor;
                _context.RecipeAuthor.Remove(RecipeAuthor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
