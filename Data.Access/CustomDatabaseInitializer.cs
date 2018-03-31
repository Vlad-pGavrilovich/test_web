using Data.Access.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Data.Access
{
    internal class CustomDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductsContext>
    {
        protected override void Seed(ProductsContext context)
        {
            Category meat = new Category { Name = "Meat" };
            Category milk = new Category { Name = "Milk products" };
            Category bread = new Category { Name = "Bread products" };
            Country belarus = new Country { Name = "Belarus" };
            Country russia = new Country { Name = "Russia" };
            Country poland = new Country { Name = "Poland" };
            DiscountGroup discountGroup1 = new DiscountGroup { Discount = 25, FinishDate = new DateTime(2018, 10, 10) };
            DiscountGroup discountGroup2 = new DiscountGroup { Discount = 10 };

            context.Products.AddRange(new List<Product>{
                new Product
                {
                    Name = "Chicken Fillet",
                    Category = meat,
                    Country = belarus,
                    Description = "Tasty and fresh",
                    PriceDetail = new PriceDetail { Price = 2, ProductPriceType = ProductPriceType.ForWeight }
                },
                new Product
                {
                    Name = "Chicken Broiler",
                    Category = meat,
                    Country = belarus,
                    Description = "It was very young... 500g",
                    PriceDetail = new PriceDetail { Price = 5, ProductPriceType = ProductPriceType.ForOne }
                },
                new Product
                {
                    Name = "Beef(spinal scapula)",
                    Category = meat,
                    Country = belarus,
                    PriceDetail = new PriceDetail { Price = 4.5f, ProductPriceType = ProductPriceType.ForWeight },
                    Discount = discountGroup2
                },
                new Product
                {
                    Name = "Pork(neck)",
                    Category = meat,
                    Country = belarus,
                    Description = "The most tender part of pig.",
                    PriceDetail = new PriceDetail { Price = 3.5f, ProductPriceType = ProductPriceType.ForWeight }
                },
                new Product
                {
                    Name = "Milk 'Snovskoe'",
                    Category = milk,
                    Country = belarus,
                    Description = "950ml in one bottle.",
                    PriceDetail = new PriceDetail { Price = 1.3f, ProductPriceType = ProductPriceType.ForOne },
                    Discount = discountGroup1
                },
                new Product
                {
                    Name = "Milk 'Polskoe'",
                    Category = milk,
                    Country = poland,
                    Description = "1l in one bottle.",
                    PriceDetail = new PriceDetail { Price = 1.5f, ProductPriceType = ProductPriceType.ForOne }
                },
                new Product
                {
                    Name = "Milk 'Ruzge'",
                    Category = milk,
                    Country = russia,
                    Description = "Too expensive for 500ml",
                    PriceDetail = new PriceDetail { Price = 1, ProductPriceType = ProductPriceType.ForOne }
                },
                new Product
                {
                    Name = "Cheese 'Ruzge'",
                    Category = milk,
                    Country = russia,
                    PriceDetail = new PriceDetail { Price = 3.4f, ProductPriceType = ProductPriceType.ForWeight }
                },
                new Product
                {
                    Name = "Bread 'Smachny'",
                    Category = bread,
                    Country = belarus,
                    PriceDetail = new PriceDetail { Price = 0.95f, ProductPriceType = ProductPriceType.ForOne }
                },
                new Product
                {
                    Name = "Cookies 'Polska'",
                    Category = bread,
                    Country = poland,
                    Description = "600g in one package, very tasty",
                    PriceDetail = new PriceDetail { Price = 1.5f, ProductPriceType = ProductPriceType.ForOne },
                    Discount = discountGroup2
                },
                new Product
                {
                    Name = "White bread 'Ruzge'",
                    Category = bread,
                    Country = russia,
                    PriceDetail = new PriceDetail { Price = 1, ProductPriceType = ProductPriceType.ForOne }
                },
                new Product
                {
                    Name = "Cookies 'Belarus'",
                    Category = bread,
                    Country = belarus,
                    Description = "500g in one package, very tasty",
                    PriceDetail = new PriceDetail { Price = 2.1f, ProductPriceType = ProductPriceType.ForOne },
                    Discount = discountGroup1
                },
                new Product
                {
                    Name = "Sour Cream 'Savushkin'",
                    Category = milk,
                    Country = belarus,
                    Description = "300g in one package, very tasty",
                    PriceDetail = new PriceDetail { Price = 1.25f, ProductPriceType = ProductPriceType.ForOne },
                    Discount = discountGroup2
                },
            });
            context.SaveChanges();
        }
    }
}
