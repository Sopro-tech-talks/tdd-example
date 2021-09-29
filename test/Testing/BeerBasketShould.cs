using System;
using System.Collections.Generic;
using NSubstitute;
using Shared;
using Shouldly;
using Xunit;

namespace Testing
{
    public class BeerBasketShould
    {
        [Fact]
        public void AcceptAnyBeerAnyTotal()
        {
            //Arrange

            var beerShoppingCart = new BeerShoppingCart(Arg.Any<List<BeerItem>>());

            //Act
            var expectedResult = Arg.Any<double>();

            //Assert
            beerShoppingCart.SubTotal.ShouldBe(expectedResult);
        }

        [Fact]
        public void AcceptAnyBeer()
        {
            //Arrange
            var beerShoppingCart = new BeerShoppingCart(Arg.Any<List<BeerItem>>());

            //Act
            var expectedResult = 0.0;

            //Assert
            beerShoppingCart.SubTotal.ShouldBe(expectedResult);
        }

        [Fact]
        public void HaveTotalForSingleBeer()
        {
            //Arrange

            var beerShoppingCart = new BeerShoppingCart(new List<BeerItem> { new(1, 100.00) });

            //Act
            var expectedResult = 100.00;

            //Assert
            beerShoppingCart.SubTotal.ShouldBe(expectedResult);
        }

        [Fact]
        public void HaveTotalForTwoBeers()
        {
            //Arrange

            var beerShoppingCart = new BeerShoppingCart(new List<BeerItem>
            {
                new(1, 100.00),
                new (1,150.00)
            });

            //Act
            var expectedResult = 250.00;

            //Assert
            beerShoppingCart.SubTotal.ShouldBe(expectedResult);
        }


        [Fact]
        public void HaveTotalForTwoBeersWithQuantity()
        {
            //Arrange

            var beerShoppingCart = new BeerShoppingCart(new List<BeerItem>
            {
                new(2, 100.00)
            });

            //Act
            var expectedResult = 200.00;

            //Assert
            beerShoppingCart.SubTotal.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(2, 100.00)]
        [InlineData(1, 120.00)]
        [InlineData(5, 120.00)]
        [InlineData(50, 120.00)]
        public void HaveTotalForDifferentBeerWithQuantity(int quantity, double price)
        {
            //Arrange
            var beerShoppingCart = new BeerShoppingCart(new List<BeerItem>
            {
                new(quantity, price)
            });

            //Act
            var expectedResult = quantity * price;

            //Assert

            beerShoppingCart.SubTotal.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(2, 100.00)]
        [InlineData(1, 120.00)]
        [InlineData(5, 120.00)]
        [InlineData(50, 120.00)]
        public void HaveTotalWithQuantityForMultipleItems(int quantity, double price)
        {
            //Arrange
            var beerShoppingCart = new BeerShoppingCart(new List<BeerItem>
            {
                new(quantity, price),
                new(quantity, price),
                new(quantity, price)
            });

            //Act
            var expectedResult = quantity * price * 3;

            //Assert

            beerShoppingCart.SubTotal.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(100.00)]
        [InlineData(120.00)]
        [InlineData(150.00)]
        [InlineData(180.00)]
        [InlineData(200.00)]
        [InlineData(250.00)]
        public void HaveTotalWithRandomQuantityForMultipleItems(double price)
        {
            //tdd laws -https://www.youtube.com/watch?v=arzREy5zLVU



            //feature envy : https://www.youtube.com/watch?v=e_Twc6kZymo



            //SoProLogin123!


            //soprounverified @sopro.io

             //Arrange
             var rnd = new Random();
            var howManyBeers = rnd.Next(1, 8);

            var beerShoppingCart = new BeerShoppingCart(new List<BeerItem>
            {
                new("Skopsko", howManyBeers, price),
                new("Amstel", howManyBeers, price),
                new(howManyBeers, price),
                new(howManyBeers, price)
            });

            //Act
            var expectedResult = howManyBeers * price * beerShoppingCart.BeerPacks;

            //Assert

            beerShoppingCart.SubTotal.ShouldBe(expectedResult);
        }
    }
}