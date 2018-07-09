﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM.UserDetails
{
    public class ChangePasswordPage : BasePage
    {
        public ChangePasswordPage()
        {
        }

        [FindsBy(How = How.Id, Using = "OldPassword")]
        public IWebElement OldPasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "NewPassword")]
        public IWebElement NewPasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmNewPassword")]
        public IWebElement ConfirmNewPasswordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value=Save]")]
        public IWebElement SaveButton { get; set; }

        public void SetNewPassword (string oldPassword, string newPassword, string confirmNewPassword)
        {
            OldPasswordField.SendKeys(oldPassword);
            NewPasswordField.SendKeys(newPassword);
            ConfirmNewPasswordField.SendKeys(confirmNewPassword);
            SaveButton.Click();
        }

        //public NewsPage SaveNewPassword()
        //{
        //    SaveButton.Click();
        //    return ConstructPage<NewsPage>();
            //try
            //{
            //    //return new NewsPage(this.driver);
            //    throw new Exception("Rewrite using Page constructor");
            //} catch (Exception e)
            //{
            //    return null;
            //}
        //}
    }
}
