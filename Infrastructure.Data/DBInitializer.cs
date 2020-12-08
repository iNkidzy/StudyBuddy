using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(StudyBuddyContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var user1 = ctx.Users.Add(new User()
            {
                Id = 1,
                Email = "email@email.email",
                UserType = UserType.Teacher,
                Name = "Mig"
            }).Entity;

            var user2 = ctx.Users.Add(new User()
            {
                Id = 2,
                Email = "email@email.email",
                UserType = UserType.Admin,
                Name = "Dig"
            }).Entity;

            var user3 = ctx.Users.Add(new User()
            {
                Id = 3,
                Email = "email@email.email",
                UserType = UserType.User,
                Name = "Ikke Mig"
            }).Entity;

            ctx.SaveChanges();
        }
    }
}
