using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CoderByte.UI.Test.Hooks
{
    [Binding]
    public sealed class UITestHook
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;
        private IWebDriver driver;

        public UITestHook(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            _scenarioContext.Add("cdriver", driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                driver.Close();
            }
           
        }
    }
}
