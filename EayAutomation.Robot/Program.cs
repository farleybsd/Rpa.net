using EayAutomation.Robot;

var file = "C:\\Git\\Rpa.net\\EayAutomation.Robot\\[Cursos RPA] Dados do Cliente - Home.csv";

var lines = File.ReadAllLines(file);

var checkouts = lines.Skip(1).Select(line => Checkout.Map(line)).ToList();

using var checkoutDriver = new CheckoutWebDriver();

foreach (var checkout in checkouts)
{
    checkoutDriver.SendForm(checkout);
}