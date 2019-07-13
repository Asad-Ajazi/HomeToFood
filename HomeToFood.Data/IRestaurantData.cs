using HomeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace HomeToFood.Data
{
    public interface IRestaurantData
    {
        //Interface holding method signatures that classes need to implement.
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCountOfRestaurants();
        int Commit();
    }

}
