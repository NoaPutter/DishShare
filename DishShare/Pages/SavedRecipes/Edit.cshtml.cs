using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DishShare.Data;
using DishShare.Models;

namespace DishShare.Pages.SavedRecipes
{
    public class EditModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public EditModel(DishShare.Data.DishShareContext context)
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

            var savedrecipe =  await _context.SavedRecipe.FirstOrDefaultAsync(m => m.SavedRecipeID == id);
            if (savedrecipe == null)
            {
                return NotFound();
            }
            SavedRecipe = savedrecipe;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SavedRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavedRecipeExists(SavedRecipe.SavedRecipeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SavedRecipeExists(int id)
        {
            return _context.SavedRecipe.Any(e => e.SavedRecipeID == id);
        }
    }
}
