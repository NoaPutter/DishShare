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
    public class IndexModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public IndexModel(DishShare.Data.DishShareContext context)
        {
            _context = context;
        }

        public IList<Rating> Rating { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Rating = await _context.Rating
                .Include(r => r.Recipe)
                .Include(r => r.User).ToListAsync();
        }
    }
}
