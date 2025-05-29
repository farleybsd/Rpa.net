using EasyAutomationFramework;
using OpenQA.Selenium;

namespace EayAutomation.Robot;
public class CheckoutWebDriver : Web,IDisposable
{
    public CheckoutWebDriver()
    {
        StartBrowser(TypeDriver.GoogleChorme);
    }

    public void Dispose()
    {
        CloseBrowser();
    }

    public void SendForm(Checkout checkout)
    {
        Navigate("https://getbootstrap.com/docs/4.3/examples/checkout/");

        AssignValue(TypeElement.Id, "firstName", checkout.Firstname);
        AssignValue(TypeElement.Id, "lastName", checkout.Lastname);
        AssignValue(TypeElement.Id, "username", checkout.Username);
        AssignValue(TypeElement.Id, "email", checkout.Email);
        AssignValue(TypeElement.Id, "address", checkout.Address);
        SelectValue(TypeElement.Id, TypeSelect.Text, "country", checkout.Country);
        AssignValue(TypeElement.Id, "zip", checkout.Zip);

        driver.FindElements(By.ClassName("custom-control-label"))
                              .SingleOrDefault(x => x.GetAttribute("for").Contains(checkout.Payment))
                              ?.Click();

        //AssignValue(TypeElement.Id, "cc-name", checkout.Name);
        AssignValue(TypeElement.Id, "cc-number", checkout.Creditcard);
        AssignValue(TypeElement.Id, "cc-expiration", checkout.Expiration);
        AssignValue(TypeElement.Id, "cc-cvv", checkout.Cvv);

        Click(TypeElement.Xpath, "/html/body/div[1]/div[2]/div[2]/form/button");
    }
        
}
