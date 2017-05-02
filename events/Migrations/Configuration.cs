namespace events.Migrations
{
    using events.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<events.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(events.Models.ApplicationDbContext context)
        {
            // Add Roles
            var ownerRole = "owner";
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(a => a.Name == ownerRole))
            {
                var role = new IdentityRole { Name = ownerRole };
                manager.Create(role);
            }
            var customerRole = "customer";
            if (!context.Roles.Any(a => a.Name == customerRole))
            {
                var role = new IdentityRole { Name = customerRole };
                manager.Create(role);
            }

            var ownerEmail = "owner@bar.com";
            var defaultPassword = "password";
            if (!context.Users.Any(u => u.UserName == ownerEmail))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = ownerEmail };

                userManager.Create(user, defaultPassword);
                userManager.AddToRole(user.Id, ownerRole);
            }

            var events = new List<Events>
            {
                new Events{ Title = "Pennywise", Description = "punkrock band from Hermosa Beach, CA",
                    StartTime = DateTime.Now, EndTime = DateTime.Now, VenueId = 1, GenreId = 1 }
            };
            events.ForEach(evnt => context.Events.AddOrUpdate(e => e.Title, evnt));
            context.SaveChanges();

            var genres = new List<Genre>
            {
                new Genre {GenreType = "Punk Rock"},
                new Genre {GenreType = "Rock"},
                new Genre {GenreType = "Jam"},
                new Genre {GenreType = "HipHop"},
                new Genre {GenreType = "Blues"}
            };
            genres.ForEach(gnre => context.Genres.AddOrUpdate(g => g.GenreType, gnre));
            context.SaveChanges();

            var venues = new List<Venue>
            {
                new Venue {VenueLocation = "Main Stage"},
                new Venue {VenueLocation = "Back Stage"}
            };
            venues.ForEach(venue => context.Venues.AddOrUpdate(v => v.VenueLocation, venue));
            context.SaveChanges();

        }
    }
}

          