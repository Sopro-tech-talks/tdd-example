namespace Shared
{
    public class BeerItem
    {
        public double Price { get; }

        public int Quantity { get; }

        public string BeerName { get; }

        public BeerItem(int quantity, double price)
        {
            Quantity = quantity;
            Price = price;
        }

        public BeerItem(string beerName, int quantity, double price)
        {
            Price = price;
            Quantity = quantity;
            BeerName = beerName;
        }

        public double Subtotal() => Price * Quantity;
    }
}