namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.WeatherContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.WeatherContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            //// Seed locations
            //for (int i = 1; i <= 5; i++)
            //{
            //    context.Locations.AddOrUpdate(new EF.Tables.Location
            //    {
            //        Country = "Country-" + i,
            //        City = "City-" + i,
            //        Region = "Region-" + i,
            //        Latitude = (10 * i).ToString("0.0000"),
            //        Longitude = (20 * i).ToString("0.0000")
            //    });
            //}

            //Random random = new Random(); // For generating random references and values

            //// Seed weather data
            //for (int i = 1; i <= 20; i++)
            //{
            //    context.Weathers.AddOrUpdate(new EF.Tables.Weather
            //    {
            //        Temperature = random.Next(-10, 40) + random.NextDouble(), 
            //        Humidity = random.Next(30, 100),
            //        Condition = new[] { "Clear", "Cloudy", "Rainy", "Sunny", "Overcast" }[random.Next(0, 5)],
            //        LocationId = random.Next(1, 6),
            //        Date = DateTime.Today.AddDays(random.Next(-10, 10)) 
            //    });
            //}


            // Seed locations
            for (int i = 1; i <= 5; i++)
            {
                context.Locations.AddOrUpdate(new EF.Tables.Location
                {
                    Country = "Country-" + i,
                    City = "City-" + i,
                    Region = "Region-" + i,
                    Latitude = (10 * i).ToString("0.0000"),
                    Longitude = (20 * i).ToString("0.0000")
                });
            }

            Random random = new Random(); 

            // Seed weather data
            for (int i = 1; i <= 100; i++)
            {
                context.Weathers.AddOrUpdate(new EF.Tables.Weather
                {
                    Temperature = random.Next(-10, 40) + random.NextDouble(),
                    Humidity = random.Next(30, 100), 
                    Condition = new[] { "Clear", "Cloudy", "Rainy", "Sunny", "Overcast" }[random.Next(0, 5)], 
                    LocationId = random.Next(1, 6), 
                    Date = i <= 20
                        ? DateTime.Today
                        : DateTime.Today.AddDays(random.Next(1, 21)) 
                });
            }






























        }
    }
}
