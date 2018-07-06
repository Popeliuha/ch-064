﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class LogInPage : BasePage
    {
        public LogInPage()
        {
        }

        [FindsBy(How = How.Id, Using = "emailLogin")]
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "passwordLogin")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "RememberMe")]
        public IWebElement RememberMeCheckBox { get; set; }

        [FindsBy(How = How.Id, Using = "submitLogin")]
        public IWebElement SignInInputSubmit { get; set; }



        public IndexPage SignIn(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            RememberMeCheckBox.Click();
            SignInInputSubmit.Click();
            //Thread.Sleep(1000);
            //driver.Navigate().Refresh();
            //Thread.Sleep(1000);
            //driver.Navigate().Refresh();
            throw new Exception("Rewrite using extended driver");
            Thread.Sleep(1000);
            return ConstructPage<IndexPage>();
        }

        

        public bool IsSignInPresentedInHeader()
        {
            Header header = ConstructPage<Header>();

            return header.GetSignInElement();
        }
    }
}