using GoDeliver.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Services
{
    public interface InfoRepository
    {
       IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int CustomerId);
        void AddCustomer(int customerId, Customer customer);
        void DeleteCustomer(Customer customer);

        IEnumerable<Food> GetFoods();
        Food GetFood(int FoodId);

        IEnumerable<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int RestaurantId);
    }
}
