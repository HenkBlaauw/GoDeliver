using GoDeliver.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GoDeliver.Services
{
    public class DataInfoRepository : InfoRepository
    {
        private GoDeliveryContext _context;

        public DataInfoRepository(GoDeliveryContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.OrderBy(c => c.Name).ToList();
        }

        public Customer GetCustomer(int CustomerId)
        {
            return _context.Customers
                .Where(c => c.CustomerId == CustomerId).FirstOrDefault();
        }

        public IEnumerable<Food> GetFoods()
        {
            return _context.Foods.OrderBy(c => c.FoodId).ToList();
        }

        public Food GetFood(int FoodId)
        {
            return _context.Foods.
                Where(c => c.FoodId == FoodId).FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _context.Restaurants.OrderBy(c => c.RestaurantId).ToList();
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
            return _context.Restaurants.Where(c => c.RestaurantId == restaurantId).FirstOrDefault();
        }
    }
}
