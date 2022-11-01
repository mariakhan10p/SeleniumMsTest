using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports.Reporter;
namespace SeleniumMsTest
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver driver;
        public static ExtentTest test;
        public static ExtentReports report;

        [TestInitialize]
        public void ClassIntialize()
        {
            driver = new ChromeDriver();
            driver.Url = "http://automationpractice.com/";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();

            report = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\maria.khan\source\repos\SeleniumMsTest\SeleniumMsTest\ReportResults\");
            report.AttachReporter(htmlReporter);

        }
        [TestMethod]
        public void TestMethod1()
        {
            test = report.CreateTest("T1: My Test One").Info("Some job 1");
            driver.Url = "http://automationpractice.com/index.php";
            string title = driver.Title;
            Assert.AreEqual("My Store", title);

            if (title == "My Store")
            {
                test.Log(Status.Pass, "Test Passed");
            }
            else
            {
                test.Log(Status.Fail, "Title Not Matched");
            }

        }

        [TestMethod]
        public void TestMethod2()
        {
            test = report.CreateTest("T2: My Test One").Info("Some job 2");

            driver.FindElement(By.XPath("*//a[@title=\"Women\"]")).Click();
            string title = driver.Title;
            Assert.AreEqual("Women - My Store", title);

            if (title == "Women - My Store")
            {
                test.Log(Status.Pass, "Test Passed");
            }
            else
            {
                test.Log(Status.Fail, "Title Not Matched");
            }

            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Manage().Window.Minimize();
        }

        [TestCleanup]
        public void ClassCleanup()
        {

            driver.Quit();
            report.Flush();
        }
    }
}