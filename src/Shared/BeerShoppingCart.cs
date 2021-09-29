using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public class BeerShoppingCart
    {
        private readonly List<BeerItem> _beerItems;

        public BeerShoppingCart(List<BeerItem> beerItems)
        {
            _beerItems = beerItems;
        }

        //public object SubTotal { get; internal set; }
        //public double SubTotal { get; set; }
        //public double SubTotal => beerItems != null && beerItems.Count > 0 ? beerItems.First().Price : 0;

        //public double SubTotal => beerItems?.Aggregate(0, (double total, BeerItem beer) => total + beer.Price * beer.Quantity) ?? 0;

        public double SubTotal => _beerItems?.Aggregate(0, (double total, BeerItem beer) => total + beer.Subtotal()) ?? 0;
        public double BeerPacks => _beerItems.Count;
    }
}
