using System;
using System.Threading.Tasks;
using fans.EntityModels;
using Microsoft.AspNetCore.Identity;

namespace fans.Data
{
    public class DummyData
    {
        public static async Task Initialize(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            string adminId1 = "";
            string adminId2 = "";

            string role1 = "Admin";
            string desc1 = "This is the administrator role";
            
            string role2 = "Member";
            string desc2 = "This is the members role";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role1) == null) {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null) {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("a") == null) {
                var user = new ApplicationUser {
                    UserName = "a@a.a",
                    Email = "a@a.a",
                    MemberSince = DateTime.Now
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded) {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("b") == null) {
                var user = new ApplicationUser {
                    UserName = "b@b.b",
                    Email = "b@b.b",
                    MemberSince = DateTime.Now
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded) {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("m") == null) {
                var user = new ApplicationUser {
                    UserName = "m@m.m",
                    Email = "m@m.m",
                    MemberSince = DateTime.Now
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded) {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }

            if (await userManager.FindByNameAsync("d") == null) {
                var user = new ApplicationUser {
                    UserName = "d@d.d",
                    Email = "d@d.d",
                    MemberSince = DateTime.Now
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded) {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }
        }
    }
}