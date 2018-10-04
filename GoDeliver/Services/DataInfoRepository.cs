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

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public void AddFood(int foodId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return _context.Drivers.OrderBy(c => c.Name).ToList();
        }

        public Driver GetDriver(int driverId)
        {
            return _context.Drivers.Where(c => c.DriverId == driverId).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.OrderBy(c => c.Name).ToList();
        }

        public Order GetOrder(int orderId)
        {
            return _context.Orders.Where(c => c.OrderId == orderId).FirstOrDefault();
        }

        public IEnumerable<OrderedFood> GetOrderedFoods()
        {
            return _context.OrderedFoods.OrderBy(c => c.OrderId).ToList();
        }

        public OrderedFood GetOrderedFood(int orderedFoodId)
        {
            return _context.OrderedFoods.Where(c => c.OrderId == orderedFoodId).FirstOrDefault();
        }

        public void DeleteFood(Food food)
        {
            _context.Foods.Remove(food);
        }

        public void AddRestaurant(int RestaurantId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
        }

        public void AddDriver(int driverId)
        {
            throw new NotImplementedException();
        }

        public void DeleteDriver(Driver driver)
        {
            _context.Drivers.Remove(driver);
        }

        public void AddOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
        }

        public void AddOrderedFood(int orderId)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderedFood(OrderedFood orderedFood)
        {
           _context.OrderedFoods.Remove(orderedFood);
        }
    }
}
