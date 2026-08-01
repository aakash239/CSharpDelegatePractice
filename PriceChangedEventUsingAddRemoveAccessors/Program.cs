namespace PriceChangedEventUsingAddRemoveAccessors;

class Program
{
    static void Main(string[] args)
    {
        Stock stock = new();
        stock.PriceChanged += ReactToChangeInPrice;
        stock.PriceChanged += ReactToChangeInPrice2;

        stock.PriceChanged -= ReactToChangeInPrice;
        stock.PriceChanged -= ReactToChangeInPrice2;

        stock.PriceChanged += ReactToChangeInPrice;
        stock.PriceChanged += ReactToChangeInPrice2;

        stock.SetPrice(150);
        stock.SetPrice(200);
    }

    private static void ReactToChangeInPrice(object? obj, StockPriceChangedEventArgs e)
    {
        Console.WriteLine($"Reacted to change1 in oldPrice {e.OldPrice} , NewPrice: {e.NewPrice}!!");
    }
    private static void ReactToChangeInPrice2(object? obj, StockPriceChangedEventArgs e)
    {
        Console.WriteLine($"Reacted to change2 in oldPrice {e.OldPrice} , NewPrice: {e.NewPrice}!!");
    }

}

class StockPriceChangedEventArgs(decimal oldPrice, decimal newPrice) : EventArgs
{
    public decimal OldPrice { get; set; } = oldPrice;
    public decimal NewPrice { get; set; } = newPrice;
}

class Stock
{
    private EventHandler<StockPriceChangedEventArgs>? _priceChanged;
    public event EventHandler<StockPriceChangedEventArgs>? PriceChanged
    {
        add
        {
            System.Console.WriteLine("Subscriber Added!");
            _priceChanged += value;
        }
        remove
        {
            System.Console.WriteLine("Subscriber Removed!");
            _priceChanged -= value;            
        }
    }

    private decimal price = 100;

    public void SetPrice(decimal newPrice)
    {
        decimal oldPrice = price;
        price = newPrice;
        _priceChanged?.Invoke(this, new StockPriceChangedEventArgs(oldPrice, newPrice));
    }
}

 