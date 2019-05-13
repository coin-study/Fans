using System;
using System.Text.RegularExpressions;
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
    public class KatakanaConverter
    {
        public static Task Convert(
            ApplicationDbContext context,
            IMember memberService,
            Member member)
        {

            IWebDriver driver = new FirefoxDriver(Environment.CurrentDirectory);

            driver.Url = "http://www.hipenpal.com/tool/chinese_simplified_and_traditional_characters_pinyin_to_katakana_converter_in_traditional_chinese.php";

            // input LastName
            WebDriverWait waitInputLN = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            waitInputLN.Until(c => c.FindElement(By.Id("contents")));

            IWebElement InputLNTextArea = driver.FindElement(By.Id("contents"));
            InputLNTextArea.Click();
            InputLNTextArea.SendKeys(member.ChineseLastName);

            IWebElement submitLNButton = driver.FindElement(By.XPath("//*[@id='ltool']/div[2]/div/form/div[3]/center/input"));
            submitLNButton.Submit();

                // wait page load for output
                WebDriverWait waitLNOutput = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                waitLNOutput.Until(c => c.FindElement(By.ClassName("finalresult")));

                IWebElement resultLN = driver.FindElement(By.ClassName("finalresult"));

                string lastName = resultLN.Text;
                lastName = Regex.Replace(lastName, @"\(.*\)", "");
                lastName = lastName.Replace(" ", String.Empty);

                memberService.UpdateKatakanaLastName(member.Id, lastName);
            

            // input FirstName
            WebDriverWait waitInputFN = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            waitInputFN.Until(c => c.FindElement(By.Id("contents")));

            IWebElement InputFNTextArea = driver.FindElement(By.Id("contents"));
            InputFNTextArea.Click();
            InputFNTextArea.Clear();
            InputFNTextArea.SendKeys(member.ChineseFirstName);

            IWebElement submitFNButton = driver.FindElement(By.XPath("//*[@id='ltool']/div[2]/div/form/div[3]/center/input"));
            submitFNButton.Submit();

                // wait page load for output
                WebDriverWait waitFNOutput = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
                waitFNOutput.Until(c => c.FindElement(By.ClassName("finalresult")));

                IWebElement resultFN = driver.FindElement(By.ClassName("finalresult"));

                string firstName = resultFN.Text;
                firstName = Regex.Replace(firstName, @"\(.*\)", "");
                firstName = firstName.Replace(" ", String.Empty);


                memberService.UpdateKatakanaFirstName(member.Id, firstName);

            driver.Close();

            // but this part of code is also expected to return something
            return Task.Run(() => { Console.WriteLine("Hello Task library!"); });

        }
    }
}