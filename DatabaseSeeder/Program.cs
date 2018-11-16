using GoDeliverWebApp.Entities;
using GoDeliverWebApp.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSeeder
{
    class Program
    {
        public static string DbConnectionString = "Data Source=DESKTOP-G8LM1VL\\SQLEXPRESS;Initial Catalog=GoDeliveryTester;Integrated Security=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting seeder");
            GoDeliveryContext dbContext = new GoDeliveryContext(DbConnectionString);
            GoDeliverWebApp.Migrations.Configuration seeder = new Configuration();
            seeder.SeedDatabase(dbContext);
            Console.WriteLine("Seeder SucSEEDED");
        }
    }
}
