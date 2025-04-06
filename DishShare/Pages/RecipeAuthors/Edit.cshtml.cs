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

namespace DishShare.Pages.RecipeAuthors
{
    public class EditModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public EditModel(DishShare.Data.DishShareContext context)
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

            var recipeauthor =  await _context.RecipeAuthor.FirstOrDefaultAsync(m => m.ID == id);
            if (recipeauthor == null)
            {
                return NotFound();
            }
            RecipeAuthor = recipeauthor;
           ViewData["RecipeID"] = new SelectList(_context.Recipe, "ID", "ID");
           ViewData["UserID"] = new SelectList(_context.User, "ID", "ID");
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

            _context.Attach(RecipeAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeAuthorExists(RecipeAuthor.ID))
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

        private bool RecipeAuthorExists(int id)
        {
            return _context.RecipeAuthor.Any(e => e.ID == id);
        }
    }
}
