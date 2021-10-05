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

            //context.Tickets.Add(new Ticket
            //{
            //    MediaId = 32,
            //    User = user,
            //    ScreeningId = 3
            //});

            //context.Tickets.Add(new Ticket
            //{
            //    MediaId = 32,
            //    User = user,
            //    ScreeningId = 3
            //});

            //context.Tickets.Add(new Ticket
            //{
            //    MediaId = 25,
            //    User = user,
            //    ScreeningId = 59
            //});

            //context.Tickets.Add(new Ticket
            //{
            //    MediaId = 100,
            //    User = user,
            //    ScreeningId = 36
            //});

            //context.Tickets.Add(new Ticket
            //{
            //    MediaId = 99,
            //    User = user,
            //    ScreeningId = 42
            //});

            //context.Tickets.Add(new Ticket
            //{
            //    MediaId = 107,
            //    User = user,
            //    ScreeningId = 49
            //});

            //var screeningData = await System.IO.File.ReadAllTextAsync("../MovieApp.Database/ScreeningsSeedData.json");
            //List<Screening> screenings = JsonSerializer.Deserialize<List<Screening>>(screeningData);
            //foreach (var screening in screenings)
            //{
            //    context.Add(screening);
            //}
            Address cinemaCity = new Address
            {
                Street = "Skenderija",
                HomeNumber = "2b",
                City = "Srajevo",
                Country = "BiH",
                PostalCode = 71000
            };
            Screening s = new Screening
            {
                MediaId = 34,
                StartTime = DateTime.Now,
                MaxSeatsNumber = 35,
                Price = 12,
                Address = cinemaCity
            };
            context.Add(s);

            await context.SaveChangesAsync();
        }
    }
}
