using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DishShare.Data;
using DishShare.Models;

namespace DishShare.Pages.SavedRecipesLists
{
    public class CreateModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public CreateModel(DishShare.Data.DishShareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SavedRecipeID"] = new SelectList(_context.SavedRecipe, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public SavedRecipesList SavedRecipesList { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SavedRecipesList.Add(SavedRecipesList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
