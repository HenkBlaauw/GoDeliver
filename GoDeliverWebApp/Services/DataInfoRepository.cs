
using GoDeliverWebApp.Entities;
using GoDeliverWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GoDeliverWebApp.Services
{
    public class DataInfoRepository : InfoRepository
    {
        private GoDeliveryContext _context;

        public DataInfoRepository(GoDeliveryContext context)
        {
            _context = context;
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

        public void AddFood(Food food)
        {
            _context.Foods.Add(food);
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return _context.Drivers.OrderBy(c => c.Name).ToList();
        }

        public Driver GetDriver(int driverId)
        {
            return _context.Drivers.Where(c => c.DriverId == driverId).FirstOrDefault();
        }



        public Order GetOrder(int orderId)
        {
            return _context.Orders.Where(c => c.OrderId == orderId).FirstOrDefault();
        }

        //public IEnumerable<OrderedFood> GetOrderedFoods()
        //{
        //    return _context.OrderedFoods.OrderBy(c => c.OrderedFoodId).ToList();
        //}

        //public OrderedFood GetOrderedFood(int orderedFoodId)
        //{
        //    return _context.OrderedFoods.Where(c => c.OrderedFoodId == orderedFoodId).FirstOrDefault();
        //}

        public void DeleteFood(Food food)
        {
            _context.Foods.Remove(food);
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
        }

        public void AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
        }

        public void DeleteDriver(Driver driver)
        {
            _context.Drivers.Remove(driver);
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
        }

        //public void AddOrderedFood(OrderedFood orderedFood)
        //{
        //    _context.OrderedFoods.Add(orderedFood);
        //}

        //public void DeleteOrderedFood(OrderedFood orderedFood)
        //{
        //    _context.OrderedFoods.Remove(orderedFood);
        //}

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Customer> GetCustomers()
        {
            throw new System.NotImplementedException();
        }

        public List<Food> GetForRestaurant(int restaurantId)
        {
            return _context.Foods.Where(x =>
                x.RestaurantId == restaurantId
            ).ToList();
        }
    }
}
