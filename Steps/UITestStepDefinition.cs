using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CoderByte.UI.Test.Steps
{
    [Binding]
    public sealed class UITestStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private string pageUrl;
        public UITestStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            
        }

        [Given(@"the URL is ""(.*)""")]
        public void GivenTheURLIs(string url)
        {
            this.pageUrl = url;
        }

        [When(@"the URL is opened in a browser")]
        public void WhenTheURLIsOpenedInABrowser()
        {
            IWebDriver driver = (IWebDriver)_scenarioContext["cdriver"];
            driver.Url = this.pageUrl;
        }

        [Then(@"the facbook link on the page should be ""(.*)""")]
        public void ThenTheFacbookLinkOnThePageShouldBe(string facebookUrl)
        {
            IWebDriver driver = (IWebDriver)_scenarioContext["cdriver"];
            var element = driver.FindElement(By.ClassName("c-footer__social")).FindElements(By.TagName("a"));
            var fbElement = element.Where(e => e.GetAttribute("href") == facebookUrl).FirstOrDefault();
            fbElement.Should().NotBeNull();
        }


    }
}
