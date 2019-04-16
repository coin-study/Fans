using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fans.Data;
using fans.EntityModels;
using fans.Service;
using Microsoft.AspNetCore.Identity;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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
        public static Task RegisterArashi_One(Member member)
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

        public static Task RegisterArashi_Two(Member member)
        {

            IWebDriver driver = new FirefoxDriver(Environment.CurrentDirectory);

            driver.Url = member.RegisterLink; 

            IWebElement favourite1Radio = driver.FindElement(By.CssSelector("input#artist_0 + label"));
            IWebElement favourite2Radio = driver.FindElement(By.CssSelector("input#artist_1 + label"));
            IWebElement favourite3Radio = driver.FindElement(By.CssSelector("input#artist_2 + label"));
            IWebElement favourite4Radio = driver.FindElement(By.CssSelector("input#artist_3 + label"));
            IWebElement favourite5Radio = driver.FindElement(By.CssSelector("input#artist_4 + label"));

            IWebElement chineseLastNameText = driver.FindElement(By.Id("member-name"));
            IWebElement chineseFirstNameText = driver.FindElement(By.Id("member-name2"));
            IWebElement englishLastNameText = driver.FindElement(By.Name("family_name_kn"));
            IWebElement englishFirstNameText = driver.FindElement(By.Name("name_kn"));
            IWebElement zipCodeText = driver.FindElement(By.Id("zip"));
            SelectElement addressSelect = new SelectElement(driver.FindElement(By.Name("address_1")));
            IWebElement cityText = driver.FindElement(By.Id("city"));
            IWebElement areaText = driver.FindElement(By.Id("area"));
            IWebElement buildingText = driver.FindElement(By.Id("building"));
            IWebElement roomText = driver.FindElement(By.Id("room_no"));
            IWebElement careOfText = driver.FindElement(By.Id("care_of"));
            IWebElement tel1Text = driver.FindElement(By.Id("tel1"));
            IWebElement tel2Text = driver.FindElement(By.Id("tel2"));
            IWebElement tel3Text = driver.FindElement(By.Id("tel3"));
            IWebElement mobile1Text = driver.FindElement(By.Id("mobile1"));
            IWebElement mobile2Text = driver.FindElement(By.Id("mobile2"));
            IWebElement mobile3Text = driver.FindElement(By.Id("mobile3"));
            SelectElement birthdayYearSelect = new SelectElement(driver.FindElement(By.Id("birthday-year")));
            SelectElement birthdayMonthSelect = new SelectElement(driver.FindElement(By.Name("birthday[month]")));
            SelectElement birthdayDaySelect = new SelectElement(driver.FindElement(By.Name("birthday[day]")));
            IWebElement ageText = driver.FindElement(By.Id("age"));
            SelectElement sexSelect = new SelectElement(driver.FindElement(By.Id("sex")));
            IWebElement password1Text = driver.FindElement(By.Id("password1"));
            IWebElement password2Text = driver.FindElement(By.Id("password2"));
            IWebElement submitButton = driver.FindElement(By.XPath("//*[@id='main']/div[2]/section/form/div[2]/div/button"));

            chineseLastNameText.SendKeys(member.ChineseLastName);
            chineseFirstNameText.SendKeys(member.ChineseFirstName);
            englishLastNameText.SendKeys(member.EnglishLastName);
            englishFirstNameText.SendKeys(member.EnglishFirstName);
            zipCodeText.SendKeys("123");
            addressSelect.SelectByIndex(2);
            cityText.SendKeys("abc村");
            areaText.SendKeys("1-1-2");
            buildingText.SendKeys("abc building");
            roomText.SendKeys("123 room");
            careOfText.SendKeys("mr jack ku 樣方");
            tel1Text.SendKeys("123124");
            tel2Text.SendKeys("2344");
            tel3Text.SendKeys("3444333");
            mobile1Text.SendKeys("99999");
            mobile2Text.SendKeys("88888");
            mobile3Text.SendKeys(member.Phone);
            birthdayYearSelect.SelectByValue(member.BirthDate.Year.ToString());
            birthdayMonthSelect.SelectByValue(member.BirthDate.Month.ToString());
            birthdayDaySelect.SelectByValue(member.BirthDate.Day.ToString());
            ageText.SendKeys("30");
            
            if (member.Gender == "F") {
                sexSelect.SelectByIndex(0);
            } 
            else if (member.Gender == "M") {
                sexSelect.SelectByIndex(1);
            }
            // 6 大野智 7 櫻井翔 8 相葉 9 二宮 10 松本
            if (member.Favourite.Id == 6) {
                favourite4Radio.Click();
            }
            if (member.Favourite.Id == 7) {
                favourite5Radio.Click();
            }
            if (member.Favourite.Id == 8) {
                favourite1Radio.Click();
            }
            if (member.Favourite.Id == 9) {
                favourite3Radio.Click();
            }
            if (member.Favourite.Id == 10) {
                favourite2Radio.Click();
            }
            
            password1Text.SendKeys("Password!234");
            password2Text.SendKeys("Password!234");
            

            submitButton.Submit();

            if (member == null)
            {
                // this part of code will return from the method with an exception
                throw new ArgumentNullException("member");
            }

            // but this part of code is also expected to return something
            return Task.Run(() => { Console.WriteLine("Hello Task library!"); });

        }

        public static Task RegisterBTS_One(Member member)
        {

            IWebDriver driver = new FirefoxDriver(Environment.CurrentDirectory);

            driver.Url = member.Club.Homepage; 

            IWebElement chineseLastNameText = driver.FindElement(By.Name("fname"));
            IWebElement chineseFirstNameText = driver.FindElement(By.Name("lname"));
            IWebElement englishLastNameText = driver.FindElement(By.Name("fname_f"));
            IWebElement englishFirstNameText = driver.FindElement(By.Name("lname_f"));
            IWebElement emailText = driver.FindElement(By.Name("email"));
            IWebElement password1Text = driver.FindElement(By.Name("pass1"));
            IWebElement password2Text = driver.FindElement(By.Name("pass2"));
            SelectElement birthdayYearSelect = new SelectElement(driver.FindElement(By.Name("birthday_y")));
            SelectElement birthdayMonthSelect = new SelectElement(driver.FindElement(By.Name("birthday_m")));
            SelectElement birthdayDaySelect = new SelectElement(driver.FindElement(By.Name("birthday_d")));
            IList<IWebElement> sexRadio = driver.FindElements(By.Name("sex"));
            IWebElement telText = driver.FindElement(By.Name("tel"));
            IWebElement zip1Text = driver.FindElement(By.Name("zipcode_f"));
            IWebElement zip2Text = driver.FindElement(By.Name("zipcode_l"));
            SelectElement addressSelect = new SelectElement(driver.FindElement(By.Name("address_1")));
            IWebElement address2Text = driver.FindElement(By.Name("address_2"));
            IWebElement address3Text = driver.FindElement(By.Name("address_3"));
            IWebElement address4Text = driver.FindElement(By.Name("address_4"));
            SelectElement favouriteSelect = new SelectElement(driver.FindElement(By.Name("like_member")));
            
            IWebElement submitButton = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/form/div/input"));

            chineseLastNameText.SendKeys(member.ChineseLastName);
            chineseFirstNameText.SendKeys(member.ChineseFirstName);
            englishLastNameText.SendKeys(member.EnglishLastName);
            englishFirstNameText.SendKeys(member.EnglishFirstName);
            emailText.SendKeys(member.User.Email);
            password1Text.SendKeys("Password!234");
            password2Text.SendKeys("Password!234");
            birthdayYearSelect.SelectByIndex(member.BirthDate.Year-1900);
            birthdayMonthSelect.SelectByIndex(member.BirthDate.Month);
            birthdayDaySelect.SelectByIndex(member.BirthDate.Day);

            if (member.Gender == "F") {
                sexRadio.ElementAt(1).Click();
            } 
            else if (member.Gender == "M") {
                sexRadio.ElementAt(0).Click();
            }

            telText.SendKeys(member.Phone);
            zip1Text.SendKeys("123");
            zip2Text.SendKeys("456");
            addressSelect.SelectByIndex(2);
            address2Text.SendKeys("abc村");
            address3Text.SendKeys("1-1-2");
            address4Text.SendKeys("abc building");
            
            favouriteSelect.SelectByValue(member.Favourite.EnglishName);

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