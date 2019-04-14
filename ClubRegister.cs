using System;
using System.Threading.Tasks;
using fans.Data;
using fans.EntityModels;
using fans.Service;
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
        public static Task RegisterArashi(Member member)
        {

            IWebDriver driver = new FirefoxDriver(Environment.CurrentDirectory);

            driver.Url = member.Club.Homepage; 

            IWebElement emailText = driver.FindElement(By.Id("email"));
            
            emailText.SendKeys(member.User.Email);

            IWebElement submitButton = driver.FindElement(By.XPath("//*[@id='main']/div[2]/section/form/div[2]/div/button"));
            submitButton.Submit();

            if (member == null)
            {
                // this part of code will return from the method with an exception
                throw new ArgumentNullException("member");
            }

            // but this part of code is also expected to return something
            return Task.Run(() => { Console.WriteLine("Hello Task library!"); });

        }
    }
}