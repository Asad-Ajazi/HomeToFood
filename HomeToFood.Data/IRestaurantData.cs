using HomeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HomeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "Hot Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant{ Id = 2, Name = "Bollywoods", Location = "London", Cuisine = CuisineType.Indian },
                new Restaurant{ Id = 3, Name = "Corazon", Location = "LA", Cuisine = CuisineType.Mexican }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
