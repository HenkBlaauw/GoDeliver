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
        Customer GetCustomer(int customerId);
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

        IEnumerable<Food> GetFoods();
        Food GetFood(int FoodId);
        void AddFood(int foodId);
        void DeleteFood(Food food);
        
        IEnumerable<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int RestaurantId);
        void AddRestaurant(int RestaurantId);
        void DeleteRestaurant(Restaurant restaurant);

        IEnumerable<Driver> GetDrivers();
        Driver GetDriver(int driverId);
        void AddDriver(int driverId);
        void DeleteDriver(Driver driver);

        IEnumerable<Order> GetOrders();
        Order GetOrder(int orderId);
        void AddOrder(int orderId);
        void DeleteOrder(Order order);

        IEnumerable<OrderedFood> GetOrderedFoods();
        OrderedFood GetOrderedFood(int orderedFoodId);
        void AddOrderedFood(int orderId);
        void DeleteOrderedFood(OrderedFood orderedFood);
    }
}
