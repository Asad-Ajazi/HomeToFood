using HomeToFood.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeToFood.Data
{
    public class HomeToFoodDbContext : DbContext
    {
        public HomeToFoodDbContext()
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
