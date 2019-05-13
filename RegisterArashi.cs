using System;
using System.Threading.Tasks;
using fans.EntityModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace fans
{
    public class RegisterArashi
    {
        public static Task RegEmail(Member member)
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

        public static Task FillInfo(Member member)
        {

            IWebDriver driver = new FirefoxDriver(Environment.CurrentDirectory);

            driver.Url = member.RegisterLink; 

            WebDriverWait waitFillInfo = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            waitFillInfo.Until(c => c.FindElement(By.XPath("//*[@id='main']/div[2]/section/form/div[2]/div/button")));

            IWebElement favourite1Radio = driver.FindElement(By.CssSelector("input#artist_0 + label"));
            IWebElement favourite2Radio = driver.FindElement(By.CssSelector("input#artist_1 + label"));
            IWebElement favourite3Radio = driver.FindElement(By.CssSelector("input#artist_2 + label"));
            IWebElement favourite4Radio = driver.FindElement(By.CssSelector("input#artist_3 + label"));
            IWebElement favourite5Radio = driver.FindElement(By.CssSelector("input#artist_4 + label"));

            IWebElement chineseLastNameText = driver.FindElement(By.Id("member-name"));
            IWebElement chineseFirstNameText = driver.FindElement(By.Id("member-name2"));
            IWebElement katakanaLastNameText = driver.FindElement(By.Name("family_name_kn"));
            IWebElement katakanaFirstNameText = driver.FindElement(By.Name("name_kn"));
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
            katakanaLastNameText.SendKeys(member.KatakanaLastName);
            katakanaFirstNameText.SendKeys(member.KatakanaFirstName);
            zipCodeText.SendKeys("6580032");
            addressSelect.SelectByValue("兵庫県");
            cityText.SendKeys("神戸市東灘区");
            areaText.SendKeys("向洋町中1丁目17");
            buildingText.SendKeys("アジアワンセンター");
            roomText.SendKeys("room " + member.Id); //further develop later
            string careOf = member.EnglishFirstName + " " + member.EnglishLastName; 
            careOfText.SendKeys(careOf);
            tel1Text.SendKeys("078");
            tel2Text.SendKeys("856");
            tel3Text.SendKeys("6368");
            // mobile1Text.SendKeys("99999");
            // mobile2Text.SendKeys("88888");
            // mobile3Text.SendKeys(member.Phone);
            birthdayYearSelect.SelectByValue(member.BirthDate.Year.ToString());
            birthdayMonthSelect.SelectByValue(member.BirthDate.Month.ToString());
            birthdayDaySelect.SelectByValue(member.BirthDate.Day.ToString());
            ageText.SendKeys(CalculateAge(member.BirthDate).ToString());
            
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
            
            password1Text.SendKeys("PPass12345word");
            password2Text.SendKeys("PPass12345word");
            

            submitButton.Submit();


            WebDriverWait waitConfirm = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            waitConfirm.Until(c => c.FindElement(By.ClassName("checkbox")));

            IWebElement agreement = driver.FindElement(By.ClassName("checkbox"));
            agreement.Click();

            IWebElement confirmButton = driver.FindElement(By.XPath("/html/body/div/main/div[2]/section/form/div[2]/div[3]/button"));
            confirmButton.Click();

            if (member == null)
            {
                // this part of code will return from the method with an exception
                throw new ArgumentNullException("member");
            }

            // but this part of code is also expected to return something
            return Task.Run(() => { Console.WriteLine("Hello Task library!"); });

        }

        public static int CalculateAge(DateTime birthDay)
        {
            int years = DateTime.Now.Year - birthDay.Year;

            if((birthDay.Month > DateTime.Now.Month) || (birthDay.Month == DateTime.Now.Month && birthDay.Day > DateTime.Now.Day))
                years--;

            return years;
        }
    }
}