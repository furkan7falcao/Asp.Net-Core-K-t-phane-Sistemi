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

            var adminUser = await userManager.FindByNameAsync("ftektas12");
            if (adminUser == null)
            {
                Member member = new Member
                {
                    FullName = "Furkan Tektaş",
                    UserName = "ftektas12",
                    Email = "furkan.ndy17@outlook.com",
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                await userManager.CreateAsync(member, "123456!");

                await userManager.AddToRoleAsync(member, "Admin");
            }


        }



    }
}
