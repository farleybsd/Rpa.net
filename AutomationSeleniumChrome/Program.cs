
using AutomationSeleniumChrome;

var quotes = new QuotesWebDriver();
quotes.Login("Farley","123456");

var ListQuotes = quotes.GetQuotes();

var ListQuotesTree = quotes.GetQuotes("3");
var mensagem = string.Empty;

foreach (var item in ListQuotesTree.Union(ListQuotes))
{
    mensagem = $"Title: {item.Title} \n";
    mensagem += $"Autor: {item.Author}\n";
    mensagem += $"Tags: {string.Join(",", item.Tags)}";

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(mensagem);
    Console.ResetColor();
}

Console.WriteLine("Fim");