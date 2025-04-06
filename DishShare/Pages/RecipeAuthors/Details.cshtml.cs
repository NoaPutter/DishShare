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
    public class DetailsModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public DetailsModel(DishShare.Data.DishShareContext context)
        {
            _context = context;
        }

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
    }
}
