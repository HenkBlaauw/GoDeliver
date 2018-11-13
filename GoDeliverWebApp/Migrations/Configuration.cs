namespace GoDeliverWebApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using GoDeliverWebApp.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<GoDeliverWebApp.Entities.GoDeliveryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GoDeliverWebApp.Entities.GoDeliveryContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Customers.AddOrUpdate(a => a.CustomerId,

                new Customer()
                {
                    
                    Name = "Jackie",
                    Adress = "123 Test Avenue, Example District, Try City",
                    CreatedAtDate = new DateTime(2013, 10, 12, 16, 18, 10, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2013, 10, 12, 16, 18, 10, DateTimeKind.Local)
                },

                new Customer()
                {
                   
                    Name = "Testie",
                    Adress = "15 Examination Street, Template District, Model City",
                    CreatedAtDate = new DateTime(2013, 10, 12, 16, 18, 10, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2013, 10, 12, 16, 18, 10, DateTimeKind.Local)

                },
                new Customer()
                {
                    
                    Name = "Henno",
                    Adress = "12 Le Roux Street, Maryland",
                    CreatedAtDate = new DateTime(2012, 12, 12, 10, 10, 12, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2013, 04, 12, 08, 39, 10, DateTimeKind.Local)
                },

                new Customer()
                {
                    //CustomerId = 2,
                    Name = "Johan",
                    Adress = "18 Maritz Street, Maryland",
                    CreatedAtDate = new DateTime(2011, 10, 11, 11, 12, 20, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2017, 08, 11, 14, 13, 29, DateTimeKind.Local)
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
                });

            //context.Foods.AddOrUpdate(a => a.FoodId,
            //    new Food()
            //    {
            //        //  FoodId = 1,
            //        Name = "Big Mac",
            //        Description = "The original Big Mac Hamburger",
            //        Cost = 32,
            //        RestaurantId = 2,
            //        CreatedAtDate = new DateTime(2017, 07, 11, 13, 38, 13, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2018, 02, 11, 18, 28, 28, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //        //  FoodId = 2,
            //        Name = "Chicken Mac",
            //        Description = "The original big mac, but with a chicken fillet!",
            //        Cost = 38,
            //        RestaurantId = 2,
            //        CreatedAtDate = new DateTime(2012, 09, 14, 13, 21, 19, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2018, 10, 01, 16, 20, 12, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //        //  FoodId = 3,
            //        Name = "Streetwise 3",
            //        Description = "2 Pieces of chicken, and a bowl of mash",
            //        Cost = 29,
            //        RestaurantId = 1,
            //        CreatedAtDate = new DateTime(2012, 04, 12, 20, 21, 38, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2017, 02, 11, 19, 21, 40, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //        //  FoodId = 4,
            //        Name = "Hawaiian Meal",
            //        Description = "A chicken burger with a pineapple ring",
            //        Cost = 45,
            //        RestaurantId = 1,
            //        CreatedAtDate = new DateTime(2012, 04, 12, 10, 12, 20, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2017, 02, 11, 18, 20, 11, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //        // FoodId = 5,
            //        Name = "Chicken Pops",
            //        Description = "It's just that, chicken pops",
            //        Cost = 16,
            //        RestaurantId = 1,
            //        CreatedAtDate = new DateTime(2012, 04, 12, 16, 20, 18, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2017, 02, 11, 18, 12, 11, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //        // FoodId = 6,
            //        Name = "Quarter Chicken",
            //        Description = "Quarter of a chicken, grilled to perfection",
            //        Cost = 65,
            //        RestaurantId = 3,
            //        CreatedAtDate = new DateTime(2012, 04, 12, 18, 21, 20, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2017, 02, 11, 09, 12, 22, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {
            //        // FoodId = 7,
            //        Name = "Chicken Salad",
            //        Description = "A chicken salad.",
            //        Cost = 45,
            //        RestaurantId = 3,
            //        CreatedAtDate = new DateTime(2012, 04, 12, 11, 18, 20, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2017, 02, 11, 18, 12, 22, DateTimeKind.Local)
            //    },

            //    new Food()
            //    {

            //        Name = "Happy meal",
            //        Description = "A kiddies meal!",
            //        Cost = 35,
            //        RestaurantId = 2,
            //        CreatedAtDate = new DateTime(2013, 02, 01, 18, 20, 20, DateTimeKind.Local),
            //        UpdatedAtDate = new DateTime(2018, 01, 11, 10, 22, 29, DateTimeKind.Local)
            //    });

            context.Restaurants.AddOrUpdate(a => a.RestaurantId,

                new Restaurant()
                {
                    // RestaurantId = 0,
                    Name = "KFC",
                    Adress = "13 Plattekloof Street",
                    Foods = new List<Food>()
                    {

                        new Food(
                              1
                            ,"Chicken"
                            ,"Chicken pieces"
                            , 46
                            , new DateTime(2012,12,12,12,12,12)
                            , new DateTime(2013,11,11,11,11,11)
                            ),
                      new Food(
                            2
                            ,"Kiddies Meal"
                            ,"Chicken burger with chips and a soft drink"
                            , 35
                            , new DateTime(2012,12,12,12,12,12)
                            , new DateTime(2013,11,11,11,11,11)
                            ),
                      new Food(
                            3
                            ,"Box Meal"
                            ,"Chicken Wrap with chips and a soft drink"
                            , 65
                            , new DateTime(2012,12,12,12,12,12)
                            , new DateTime(2013,11,11,11,11,11)
                            ),

                    },
                    CreatedAtDate = new DateTime(2011, 11, 11, 17, 28, 14, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2016, 03, 12, 12, 22, 23, DateTimeKind.Local)
                },

                new Restaurant()
                {
                    // RestaurantId = 1,
                    Name = "McHenkies's",
                    Adress = "19 High Street",
                    CreatedAtDate = new DateTime(2013, 02, 18, 15, 12, 11, DateTimeKind.Local),
                    UpdatedAtDate = new DateTime(2018, 03, 12, 14, 11, 12, DateTimeKind.Local)
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
                    Name = "Ocean's Basket",
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
                });

            //context.Orders.AddOrUpdate(a => a.OrderId, new Order()
            //{
            //    CustomerId = 2,
            //    CustomerAddress = "14 Sucker Street, Mainville",
            //    DriverId = 5,
            //    RestaurantId = 7,
            //    RestaurantAddress = "Shop 20, Canal walk",
            //    TimeAtRestaurant = new DateTime(2013, 10, 12, 16, 18, 10, DateTimeKind.Local),
            //    TotalCost = 25,
            //    CreatedAtDate = new DateTime(2013, 10, 12, 16, 18, 10, DateTimeKind.Local),
            //    UpdatedAtDate = new DateTime(2013, 10, 12, 17, 18, 10, DateTimeKind.Local)

            //});


            context.Drivers.AddOrUpdate(a => a.DriverId,
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

            );



             void SaveChanges()
            {
                

                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    var sb = new StringBuilder();
                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }
                    throw new DbEntityValidationException(
                        "Entity Validation Failed - errors follow:\n" +
                        sb.ToString(), ex
                    );
                }
            }

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
