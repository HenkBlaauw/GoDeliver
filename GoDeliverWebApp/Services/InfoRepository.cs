using GoDeliverWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliverWebApp.Services
{
    public interface InfoRepository
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomer(int customerId);
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        
        Food GetFood(int FoodId);
        List<Food> GetForRestaurant(int restaurantId);
        
        Restaurant GetRestaurant(int RestaurantId);
        void AddRestaurant(Restaurant restaurant);
       
        Order GetOrder(int orderId);
        void AddOrder(Order order);

        bool Save();
        
    }
}
