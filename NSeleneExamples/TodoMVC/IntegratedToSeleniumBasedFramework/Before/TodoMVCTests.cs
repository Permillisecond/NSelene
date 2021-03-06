﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using static NSelene.Selene;


namespace NSeleneExamples.TodoMVC.IntegratedToSeleniumBasedFramework.Before
{
    [TestFixture]
    public class TestTodoMVC
    {
        static IWebDriver driver = new FirefoxDriver();

        [TestFixtureTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void FilterTasks()
        {
            var tasks = new Pages.Tasks(driver);

            tasks.Visit();

            tasks.Add("a", "b", "c");
            tasks.ShouldBe("a", "b", "c");

            tasks.Toggle("b"); 

            tasks.FilterActive();
            tasks.ShouldBe("a", "c");

            tasks.FilterCompleted();
            tasks.ShouldBe("b");
        }
    }
}
