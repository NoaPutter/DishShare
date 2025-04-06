using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DishShare.Data;
using DishShare.Models;

namespace DishShare.Pages.Ratings
{
    public class DetailsModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public DetailsModel(DishShare.Data.DishShareContext context)
        {
            _context = context;
        }

        public Rating Rating { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating.FirstOrDefaultAsync(m => m.ID == id);
            if (rating == null)
            {
                return NotFound();
            }
            else
            {
                Rating = rating;
            }
            return Page();
        }
    }
}
