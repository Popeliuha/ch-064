﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Pages.POM.CodeHistory.Favourites;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class FavouritesPage : BasePage 
        
    {
        public FavouritesPage(IWebDriver driver) : base(driver)
        {
        }
        [FindsBy(How = How.ClassName, Using = "history")]
        public IWebElement HistoryButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "favourites")]
        public IWebElement FavouritesButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".favouritesblock > .row")]
        public IList<IWebElement> BlocksList { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".checkbox_wrapper label")]
        public IWebElement LikeButton { get; set; }

        public IList<HistoryFavouriteBlock> GetBlocks()
        {
            var blocks = new List<HistoryFavouriteBlock>();
            foreach (var row in BlocksList)
            {
                var block = ConstructPageElement<HistoryFavouriteBlock>(row);
                if (block != null)
                    blocks.Add(block);
            }
            return blocks;
        }

        public string GetId()
        {
            return LikeButton.GetAttribute("data-id");
        }

        public CodeHistoryPage SwitchToHistory()
        {
            HistoryButton.Click();
            return new CodeHistoryPage(this.driver);
        }

        public FavouritesPage SwitchToFavourites()
        {
            FavouritesButton.Click();
            return this;
        }

        
    }
}
