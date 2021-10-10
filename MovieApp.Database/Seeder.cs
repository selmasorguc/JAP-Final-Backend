namespace MovieApp.Database
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MovieApp.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Seeds data to the local Sql database from a json file 
    /// </summary>
    public class Seeder
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            if (await context.Media.AnyAsync()) return;

            var mediaData = await System.IO.File.ReadAllTextAsync("../MovieApp.Database/MovieSeedData.json");
            var media = JsonSerializer.Deserialize<List<Media>>(mediaData);
            foreach (var item in media)
            {
                context.Add(item);
            }

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Admin"},
                new AppRole{Name = "Member"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var admin = new AppUser
            {
                UserName = "Selma",
            };

            var user = new AppUser
            {
                UserName = "Dummy",
            };

            await userManager.CreateAsync(admin, "Selma1");
            user.PasswordHash = userManager.PasswordHasher.HashPassword(admin, "Selma1");
            await userManager.AddToRoleAsync(admin, "Admin");

            await userManager.CreateAsync(user, "Dummy1");
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "Dummy1");
            await userManager.AddToRoleAsync(user, "Member");

            Address cinemaCity = new Address
            {
                Street = "Skenderija",
                HomeNumber = "2b",
                City = "Srajevo",
                Country = "BiH",
                PostalCode = 71000
            };
            Address cinemaCity2 = new Address
            {
                Street = "Titova",
                HomeNumber = "10",
                City = "Srajevo",
                Country = "BiH",
                PostalCode = 71000
            };
            Screening s = new Screening
            {
                MediaId = 34,
                StartTime = DateTime.Today.AddDays(7),
                MaxSeatsNumber = 35,
                Price = 12,
                Address = cinemaCity
            };
            Screening s1 = new Screening
            {
                MediaId = 3,
                StartTime = DateTime.Today.AddDays(7),
                MaxSeatsNumber = 100,
                Price = 7,
                Address = cinemaCity2
            };
            Screening s2 = new Screening
            {
                MediaId = 20,
                StartTime = DateTime.Today.AddDays(7),
                MaxSeatsNumber = 130,
                Price = 18,
                Address = cinemaCity
            };
            context.Add(s);
            context.Add(s1);
            context.Add(s2);

            Ticket t = new Ticket
            {
                Screening = s2,
                DateOfPurchase = DateTime.Today,
                User = user,
                UserId = user.Id,
                ScreeningId = s2.Id,
                MediaId = s2.MediaId
            };
            context.Add(t);
            await context.SaveChangesAsync();
        }
    }
}
