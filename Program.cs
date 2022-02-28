using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace FirstProject_Selenium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Open Chrome Browser
             IWebDriver driver = new ChromeDriver();

    //launch Turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            login();
            verifyHomePage();
            createTimeMaterial();
            verifyTimeMaterialRecord();
            editTimeMaterialRecord();
            verifyEditedTimeMaterialRecord();
            deleteTimeMaterialRecord();

    
            void login() {
                //Identify username textbox and enter valid username
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");

                //Identify password textbox and enter valid password
                IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
                passwordTextbox.SendKeys("123123");

                //click on login button
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                loginButton.Click();
            }

            void verifyHomePage()
            {
                //check if user is logged in successfully
                IWebElement hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
                if (hellohari.Text == "Hello hari!")
                {
                    Console.WriteLine("Logged in successfully, test passed.");
                }
                else
                {
                    Console.WriteLine("Login failed, test failed.");
                }
    //create time and material record
                //Go to TM page
                IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
                administrationDropdown.Click();

                IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
                tmOption.Click();

            }

            //Create time and material record
            void createTimeMaterial()
            {

                
                //Click on create new button
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
                createNewButton.Click();

                //Select material from typecode dropdown
                IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
                typeCodeDropdown.Click();
                Thread.Sleep(3000);

                IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
                materialOption.Click();

                //Identify the code textbox and input a code
                IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
                codeTextbox.SendKeys("February");

                //Identify the Description textbox and input the description
                IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
                descriptionTextbox.SendKeys("February");

                //Identify the price field and enter the price
                IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
                priceTag.Click();

                IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id='Price']"));
                priceTextbox.SendKeys("500");

                //Click on save button
                IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
                saveButton.Click();
                Thread.Sleep(3000);

            }
            
            void verifyTimeMaterialRecord()
            {

                //Click on go to last page button
                IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                goToLastPageButton.Click();
                Thread.Sleep(3000);

                //Check if record created is displayed in last page
                IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
                IWebElement actualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
                Console.WriteLine("Actual Code ... " + actualCode.Text);
                Console.WriteLine("Actual Desc ..." + actualDescription.Text);
                Console.WriteLine("Actual Price ..." + actualPrice.Text);

                if (actualCode.Text == "February")
                {
                    Console.WriteLine("materialOption record created successfully, test is passed");
                }
                else
                {
                    Console.WriteLine("Test failed");
                }
            }

    //Edit time and material record
            void editTimeMaterialRecord()
            {

                //Edit time and material record
                //Click on edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(5000);

                //Edit the code, description and price fields
                IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
                IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
                IWebElement priceTag1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
                IWebElement priceTextbox1 = driver.FindElement(By.XPath("//*[@id='Price']"));

                editCodeTextbox.Clear();
                editCodeTextbox.SendKeys("March");
                editDescriptionTextbox.Clear();
                editDescriptionTextbox.SendKeys("March");
                priceTag1.Click();
                priceTextbox1.Clear();
                priceTag1.Click();
                priceTextbox1.SendKeys("100");


                Thread.Sleep(3000);
                //Click save button
                IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
                editSaveButton.Click();
                Thread.Sleep(5000);

            }

            void verifyEditedTimeMaterialRecord()
            {

                //Click on go to last page button
                IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                goToLastPageButton1.Click();
                Thread.Sleep(3000);

                IWebElement actualCode1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                if (actualCode1.Text == "March")
                {
                    Console.WriteLine("Edited successfully, test is passed");
                }
                else
                {
                    Console.WriteLine("Test failed");
                }

            }


    //Delete time and material record
            void deleteTimeMaterialRecord()
            {
                Thread.Sleep(5000);
                //Delete time and material record
                //Click on delete button
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(5000);


                //Wait for the alert to be displayed
                //Store the alert in a variable
                IAlert alert = driver.SwitchTo().Alert();

                //Store the alert in a variable for reuse
                string text = alert.Text;

                //Press Ok button
                alert.Accept();
                Console.WriteLine("Deleted successfully, test is passed");
        
                Thread.Sleep(5000);
               
            }

            driver.Quit();
            
        }
    }
}