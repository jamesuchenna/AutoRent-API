using AutoRent.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRent.Data
{
    public class Seeder
    {
        public static async Task SeedDb(AutoRentDbContext dbContext)
        {
            var baseDir = Directory.GetCurrentDirectory();

            await dbContext.Database.EnsureCreatedAsync();
            // await dbContext.Database.MigrateAsync();

            if (!dbContext.Features.Any())
            {
                var features = new List<Feature>
                {
                    new Feature()
                    {
                        Id = "5b15a6e6-80e4-46cd-baec-a3e83579ab1b",
                        Name = "Bluetooth",
                        IconUrl = "",
                    },
                    new Feature()
                    {
                        Id = "12e5aa85-daa7-4376-91fb-8ead13e33816",
                        Name = "Air Conditioned",
                        IconUrl = "",
                    },
                    new Feature()
                    {
                        Id = "57c9ab2b-298b-4172-89b2-879eebb3ac0f",
                        Name = "Tinted Glasses",
                        IconUrl = "",
                    },
                    new Feature()
                    {
                        Id = "17663f20-e385-4895-80de-24eefb473a86",
                        Name = "Automatic",
                        IconUrl = "",
                    },
                };

                await dbContext.AddRangeAsync(features);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Users.Any())
            {
                string json = File.ReadAllText(Path.Combine(baseDir, "dbseed/users.json"));//C:AutoRent/AutoRent.API/dbseed/users.json

                List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

                await dbContext.AddRangeAsync(users);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Locations.Any())
            {
                var json = File.ReadAllText(Path.Combine(baseDir, "dbseed/locations.json"));

                var locations = JsonConvert.DeserializeObject<List<Location>>(json);

                await dbContext.AddRangeAsync(locations);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.CarFeatures.Any())
            {
                var carFeatures = new List<CarFeature>
                {
                    new CarFeature()
                    {
                        CarId = "bb8e6e38-12d1-4130-97e6-abbee700b5e7",
                        FeatureId = "5b15a6e6-80e4-46cd-baec-a3e83579ab1b"
                    },
                    new CarFeature()
                    {
                        CarId = "bb8e6e38-12d1-4130-97e6-abbee700b5e7",
                        FeatureId = "12e5aa85-daa7-4376-91fb-8ead13e33816"
                    },
                    new CarFeature()
                    {
                        CarId = "c610723b-da44-413a-806c-fc2e3fe9ff41",
                        FeatureId = "5b15a6e6-80e4-46cd-baec-a3e83579ab1b"
                    },
                    new CarFeature()
                    {
                        CarId = "db7a396c-da74-4b50-b869-5bbb2568f078",
                        FeatureId = "17663f20-e385-4895-80de-24eefb473a86"
                    },
                };

                await dbContext.AddRangeAsync(carFeatures);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
