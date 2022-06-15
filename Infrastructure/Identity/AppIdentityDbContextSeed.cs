﻿using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task  SeedUsersAsync(UserManager<AppUser> manager)
        {
            if (!manager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email= "bob@test.com",
                    UserName = "bob@test.com",
                    Address = new Address
                    {
                        FirstName = "Bob",
                        LastName = "Bobbity",
                        Street = "10 The street",
                        City = "New York",
                        State = "NY",
                        Zipcode = "90213"
                    }
                };

                await manager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
