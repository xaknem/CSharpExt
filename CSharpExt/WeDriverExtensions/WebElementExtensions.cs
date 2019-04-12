using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace CSharpExt.WeDriverExtensions
{
    public static class WebElementExtensions
    {
        /// <summary>
        /// Scroll to element on the page.
        /// Useful for angular elements that can be invisible outside the current browser position;
        /// </summary>
        /// <param name="webDriver">Uses for any driver by IWebDriver interface </param>
        /// <param name="by">By Selector to find element </param>
        /// <returns>Return founded element</returns>
        public static IWebElement FindElementOnPage(this IWebDriver webDriver, By by)
        {
            RemoteWebElement element = (RemoteWebElement)webDriver.FindElement(by);
            var hack = element.LocationOnScreenOnceScrolledIntoView;
            return element;
        }
    }
}