using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeToFood.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }

        public void OnGet(int restaurantId)
        {
            Restaurant = new Restaurant();
            Restaurant.Id = restaurantId;
        }
    }
}