namespace PriceChangeEvent;

class Program
{
    static void Main(string[] args)
    {
        Stock stock = new();
        stock.priceChanged += ReactToChangeInPrice;
        stock.priceChanged += ReactToChangeInPrice2;  

        stock.SetPrice(150);
        stock.SetPrice(200);
    }

    private static void ReactToChangeInPrice(decimal oldPrice, decimal newPrice)
    {
        Console.WriteLine($"Reacted to change1 in oldPrice{oldPrice} , NewPrice: {newPrice}!!");
    }
     private static void ReactToChangeInPrice2(decimal oldPrice, decimal newPrice)
    {
        Console.WriteLine($"Reacted to change2 in oldPrice{oldPrice} , NewPrice: {newPrice}!!");
    }

}

class Stock
{
    public delegate void PriceChangeHandler(decimal oldPrice, decimal newPrice);

    public event PriceChangeHandler? priceChanged;

    private decimal price = 100;

    public void SetPrice(decimal newPrice)
    {
        decimal oldPrice = price;
        price = newPrice;
        priceChanged?.Invoke(oldPrice, newPrice);
    }
}
