using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationSeleniumChrome;
public class QuotesWebDriver : IDisposable
{
    private IWebDriver _driver;

    public QuotesWebDriver()
    {
        _driver = new ChromeDriver();
    }

    public void Login(string username, string password)
    {
        _driver.Navigate().GoToUrl("https://quotes.toscrape.com/login");
        _driver.FindElement(By.Id("username")).SendKeys(username);
        _driver.FindElement(By.Id("password")).SendKeys(password);
        _driver.FindElement(By.XPath("//input[@value='Login']")).Click();

    }

    public List<Quotes> GetQuotes(string numberPage = "1")
    {
        var quoteList = new List<Quotes>();
        _driver.Navigate().GoToUrl($"https://quotes.toscrape.com/page/{numberPage}/");

        var elementsQuotes = _driver.FindElements(By.ClassName("quote"));

        foreach (var quoteItem in elementsQuotes)
        {
            // Título e autor
            var title = quoteItem.FindElement(By.ClassName("text")).Text;
            var author = quoteItem.FindElement(By.ClassName("author")).Text;

            // Tags (várias por quote)
            var tagsElements = quoteItem.FindElements(By.ClassName("tag"));
            var tags = tagsElements.Select(tagEl => tagEl.Text).ToList();

            // Criação do objeto Quote
            var quote = new Quotes
            {
                Title = title,
                Author = author,
                Tags = tags
            };

            quoteList.Add(quote);
        }

        return quoteList;
    }

    public void Dispose()
    {
       _driver.Dispose();
    }
}
