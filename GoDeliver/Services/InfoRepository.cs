using GoDeliver.Entities;
using GoDeliver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Services
{
    public interface InfoRepository
    {
       IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int customerId);
        void AddCustomer(Customer customer);
        //void AddCustomer(CustomerForCreationDto customerInfo);
        void DeleteCustomer(Customer customer);

        IEnumerable<Food> GetFoods();
        Food GetFood(int FoodId);
        void AddFood(Food food);
        void DeleteFood(Food food);
        
        IEnumerable<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int RestaurantId);
        void AddRestaurant(Restaurant restaurant);
        void DeleteRestaurant(Restaurant restaurant);

        IEnumerable<Driver> GetDrivers();
        Driver GetDriver(int driverId);
        void AddDriver(Driver driver);
        void DeleteDriver(Driver driver);

        IEnumerable<Order> GetOrders();
        Order GetOrder(int orderId);
        void AddOrder(Order order);
        void DeleteOrder(Order order);

        IEnumerable<OrderedFood> GetOrderedFoods();
        OrderedFood GetOrderedFood(int orderedFoodId);
        void AddOrderedFood(OrderedFood orderedFood);
        void DeleteOrderedFood(OrderedFood orderedFood);
        
    }
}
