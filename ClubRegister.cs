using System;
using System.Threading.Tasks;
using fans.Data;
using fans.EntityModels;
using Microsoft.AspNetCore.Identity;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace fans
{
    public class ClubRegister
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ClubRegister(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public static async Task RegisterArashi()
        {
            IWebDriver driver = new FirefoxDriver(Environment.CurrentDirectory);

            driver.Url = "https://google.com"; 

        }
    }
}