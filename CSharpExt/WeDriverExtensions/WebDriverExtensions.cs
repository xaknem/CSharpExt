using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpExt.WeDriverExtensions
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Получить стандартный waiter.
        /// </summary>
        /// <param name="driver">WebDriver object.</param>
        /// <param name="seconds">Количество секунд.</param>
        public static WebDriverWait GetWait(this IWebDriver driver, int seconds = 10)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        }

        /// <summary>
        /// Find All Elements by selectors
        /// </summary>
        /// <param name="driver">Uses for any driver by IWebDriver interface</param>
        /// <param name="by">By Selector</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        /// <returns>Founded element collection</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds = 0)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(drv => drv.FindElements(by).Count > 0);
                return driver.FindElements(by);
            }

            return driver.FindElements(by);
        }

        /// <summary>
        /// Extension method for explicit wait of web element without lazy initialiuzation*
        /// </summary>
        /// <param name="driver">Uses for any driver by IWebDriver interface</param>
        /// <param name="by">By Selector</param>
        /// <param name="timeoutInSeconds">Timeout in seconds</param>
        /// <returns>Founded element</returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv => drv.FindElement(by));
        }
    }
}