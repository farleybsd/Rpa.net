public class Checkout
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public string Zip { get; set; }
    public string Payment { get; set; }
    public string Creditcard { get; set; }
    public string Expiration { get; set; }
    public string Cvv { get; set; }

    public static Checkout Map(string line)
    {
        var values = line.Split(',');

        if (values.Length < 11)
            throw new ArgumentException("Linha CSV inválida. Esperado pelo menos 11 valores.");

        return new Checkout()
        {
            Firstname = values[0],
            Lastname = values[1],
            Username = values[2],
            Email = values[3],
            Address = values[4],
            Country = values[6],      // pula o índice 5 (adress 2)
            Zip = values[7],
            Payment = values[8],
            Creditcard = values[9],
            Expiration = values[10],
            Cvv = values[11]
        };
    }
}
