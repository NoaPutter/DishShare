using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DishShare.Data;
using DishShare.Models;

namespace DishShare.Pages.Tags
{
    public class IndexModel : PageModel
    {
        private readonly DishShare.Data.DishShareContext _context;

        public IndexModel(DishShare.Data.DishShareContext context)
        {
            _context = context;
        }

        public IList<Tag> Tag { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Tag = await _context.Tag
                .Include(t => t.Recipe)
                .Include(t => t.User).ToListAsync();
        }
    }
}
