using Microsoft.AspNetCore.Identity;
using Library.Entities.Concreate;
using System;
using System.Threading.Tasks;

namespace Library.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<Member> userManager, RoleManager<Role> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new Role { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new Role { Name = "Member" });
            }

            var adminUser1 = await userManager.FindByNameAsync("b181210049@sakarya.edu.tr");

            if (adminUser1 == null)
            {
                Member admin1 = new Member
                {
                    FullName = "Furkan Tektaş",
                    UserName = "b181210049@sakarya.edu.tr",
                    Email = "furkan.ndy17@outlook.com",
                    SecurityStamp = Guid.NewGuid().ToString()
                };           

                await userManager.CreateAsync(admin1, "123456!");

                await userManager.AddToRoleAsync(admin1, "Admin");
            }


        }



    }
}
