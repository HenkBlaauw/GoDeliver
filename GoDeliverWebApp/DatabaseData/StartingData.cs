using GoDeliverWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliverWebApp.DatabaseData
{
    public static class StartingData
    {

        public static void EnsureSeedDataForContext(this GoDeliveryContext context)
        {
            //if (context.Customers.Any() && context.Foods.Any() && context.Restaurants.Any() && context.Orders.Any() && context.Drivers.Any())
            //{
            //    return;
            //}



            var customers = new List<Customer>
            {

                new Customer()
                {
                    //CustomerId = 1,
                    Name = "Henno",
                    Adress = "12 Le Roux Street, Maryland",
                
                    CreatedAtDate = new DateTime(2012,12,12,10,10,12,DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2013, 04, 12, 08, 39, 10, DateTimeKind.Local)
                },

                new Customer()
                {
                    //CustomerId = 2,
                    Name = "Johan",
                    Adress = "18 Maritz Street, Maryland",
                 
                      CreatedAtDate = new DateTime(2011, 10, 11, 11, 12, 20, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime( 2017, 08, 11, 14, 13, 29, DateTimeKind.Local)
                },

                new Customer()
                {
                   // CustomerId = 3,
                    Name = "Jacques",
                    Adress = "1 Church Street, Maryland",
                   
                    CreatedAtDate = new DateTime(2011, 02, 14, 14, 15, 20, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2014, 03, 17, 15, 28, 49, DateTimeKind.Local)
                },

                new Customer()
                {
                    //CustomerId = 4,
                    Name = "Sarah",
                    Adress = "7 Miners Street, Maryland",
                  
                    CreatedAtDate = new DateTime(2012, 04, 12, 19, 29, 58, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2017, 02, 11, 20, 17, 37, DateTimeKind.Local)
                }

            };
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            //var foods = new List<Food>()
            //{

            //    new Food()
            //    {
            //      //  FoodId = 1,
            //        Name = "Big Mac",
            //        Description = "The original Big Mac Hamburger",
            //        Cost = 32,
            //        Restaurants = 2,
            //        CreatedAtDate = new DateTime(2017, 07, 11, 13, 38,13, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2018, 02, 11, 18, 28, 28, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //      //  FoodId = 2,
            //        Name = "Chicken Mac",
            //        Description = "The original big mac, but with a chicken fillet!",
            //        Cost = 38,
            //        Restaurants = 2,
            //        CreatedAtDate = new DateTime(2012, 09, 14, 13, 21, 19, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2018, 10, 01, 16, 20, 12, DateTimeKind.Local)

            //    },

            //    new Food()
            //    {
            //      //  FoodId = 3,
            //        Name = "Streetwise 3",
            //        Description = "2 Pieces of chicken, and a bowl of mash",
            //        Cost = 29,
            //        Restaurants = 1,
            //        CreatedAtDate = new DateTime(2012, 04, 12, 20, 21, 38, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2017, 02, 11, 19, 21,40, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //        //  FoodId = 4,
            //        Name = "Hawaiian Meal",
            //        Description = "A chicken burger with a pineapple ring",
            //        Cost = 45,
            //        Restaurants = 1,
            //        CreatedAtDate = new DateTime(2012, 04, 12, 10, 12, 20, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2017, 02, 11, 18, 20, 11, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //       // FoodId = 5,
            //        Name = "Chicken Pops",
            //        Description = "It's just that, chicken pops",
            //        Cost = 16,
            //        Restaurants = 1,
            //        CreatedAtDate = new DateTime(2012, 04, 12, 16, 20, 18, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2017, 02, 11, 18, 12, 11, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //       // FoodId = 6,
            //        Name = "Quarter Chicken",
            //        Description = "Quarter of a chicken, grilled to perfection",
            //        Cost = 65,
            //        Restaurants = 3,
            //        CreatedAtDate = new DateTime(2012, 04, 12, 18, 21, 20, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2017, 02, 11, 09, 12, 22, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //        // FoodId = 7,
            //        Name = "Chicken Salad",
            //        Description = "A chicken salad.",
            //        Cost = 45,
            //        Restaurants = 3,
            //        CreatedAtDate = new DateTime(2012, 04, 12, 11, 18, 20, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2017, 02, 11, 18, 12, 22, DateTimeKind.Local)
            //    },

            //    new Food(){

            //        Name = "Happy meal",
            //        Description = "A kiddies meal!",
            //        Cost = 35,
            //        Restaurants = ,
            //        CreatedAtDate = new DateTime( 2013, 02, 01, 18, 20, 20, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime( 2018, 01, 11, 10, 22, 29, DateTimeKind.Local)
            //    }

            //};

            var restaurants = new List<Restaurant>()
                {

                    new Restaurant()

                    {
                       // RestaurantId = 0,
                        Name = "KFC",
                        Adress = "13 Plattekloof Street",
                        Foods = new List<Food> {
                            new Food("Happy meal", "A kiddies meal!", 35, 
                                new DateTime( 2013, 02, 01, 18, 20, 20, DateTimeKind.Local),
                                new DateTime( 2018, 01, 11, 10, 22, 29, DateTimeKind.Local))
                        },
                        CreatedAtDate = new DateTime(2011,11,11, 17, 28, 14, DateTimeKind.Local),
                        UpdatedAtDate = new DateTime(2016, 03, 12, 12, 22, 23, DateTimeKind.Local)
                    },

                    new Restaurant()
                    {
                       // RestaurantId = 1,
                        Name = "McDonald's",
                        Adress = "19 High Street",

                        CreatedAtDate = new DateTime(2013,02,18, 15, 12, 11, DateTimeKind.Local),
                        UpdatedAtDate = new DateTime(2018,03,12, 14, 11, 12, DateTimeKind.Local)
                    },

                    new Restaurant()
                    { 
                        //RestaurantId = 2,
                        Name = "Nando's",
                        Adress = "Shop 73, N1 City",

                        CreatedAtDate = new DateTime(2012, 07, 11, 14, 11, 48, DateTimeKind.Local),
                        UpdatedAtDate = new DateTime(2018, 02, 12, 16, 11, 37, DateTimeKind.Local)
                    },

                    new Restaurant()
                    {
                       // RestaurantId = 3,
                        Name= "Ocean's Basket",
                        Adress = "Shop 98, N1 City",

                        CreatedAtDate = new DateTime(2018, 02, 11, 17, 11, 45, DateTimeKind.Local),
                        UpdatedAtDate = new DateTime(2018, 02, 11, 11, 23, 11, DateTimeKind.Local)
                    },

                    new Restaurant()
                    {
                       // RestaurantId = 4,
                        Name = "Burger King",
                        Adress = "Shop 102, Canal Walk, Century City",

                        CreatedAtDate = new DateTime(2006, 01, 18, 12, 52, 49, DateTimeKind.Local),
                        UpdatedAtDate = new DateTime(2016, 08, 09, 07, 23, 11, DateTimeKind.Local)
                    },

                    new Restaurant()
                    {
                        Name = "Tikkaways",
                        Adress = "Shop 68, N1 City",

                        
                        CreatedAtDate = new DateTime(2010, 02, 02, 00, 00, 00, DateTimeKind.Local),
                        UpdatedAtDate = new DateTime(2012, 12, 12, 01, 01, 01, DateTimeKind.Local)
                    }



            };


            var drivers = new List<Driver>()
            {
                new Driver()
                {
                    Name = "Johnathan",
                    CreatedAtDate = new DateTime(2008, 10, 28, 15, 12, 11, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2012, 11, 09, 17, 11, 20, DateTimeKind.Local)
                },

                new Driver()
                {
                    Name = "Arnold",
                    CreatedAtDate = new DateTime(2018, 08, 12, 17, 18, 10, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2018, 08, 12, 17, 18, 10, DateTimeKind.Local)
                },

                new Driver()
                {
                    Name = "Nathan",
                    CreatedAtDate = new DateTime(2011, 09, 09, 13, 17, 20, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2014, 10, 11, 21, 18, 12, DateTimeKind.Local)
                },

                new Driver()
                {
                    Name = "Nelize",
                    CreatedAtDate = new DateTime(2013, 10, 12, 16, 18, 10, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2015, 10, 11, 13, 12, 12, DateTimeKind.Local)
                }

            };

            //var orders = new List<Order>()
            //{
            //    new Order()
            //    {
            //        CustomerId = 2,
            //        DriverId = 2,
            //        RestaurantId = 1,


            //        TotalCost = 35,
            //        TimeAtRestaurant = new DateTime(2018, 10, 02, 16, 20,00, DateTimeKind.Local),

            //        CreatedAtDate = new DateTime(2018, 10, 02, 16, 00, 00, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2018, 10, 02, 17, 00, 00, DateTimeKind.Local)
            //    }


            //};

            //    context.Orders.AddRange(orders);
            context.Drivers.AddRange(drivers);
            context.Restaurants.AddRange(restaurants);
          // context.Foods.AddRange(foods);
           context.Customers.AddRange(customers);
            
           context.SaveChanges();
            
        }
    }
}
