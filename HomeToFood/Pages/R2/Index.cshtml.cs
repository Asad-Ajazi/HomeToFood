using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HomeToFood.Core;
using HomeToFood.Data;

namespace HomeToFood.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly HomeToFood.Data.HomeToFoodDbContext _context;

        public IndexModel(HomeToFood.Data.HomeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
