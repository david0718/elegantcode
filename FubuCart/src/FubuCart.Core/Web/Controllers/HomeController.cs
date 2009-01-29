using System;
using System.Collections.Generic;
using FubuCart.Core.Domain;
using FubuCart.Core.Web.DisplayModels;

namespace FubuCart.Core.Web.Controllers
{
    public class HomeController
    {
        public IndexViewModel Index(IndexSetupViewModel inModel)
        {
            var products = new List<Product>();

            // Test data loaded in for test
            products.Add(new Product { Name = "Product 1", Description = "This is a test product", Cost = 32m, Price = 50m });
            products.Add(new Product { Name = "Product 2", Description = "This is a test product 2", Cost = 12m, Price = 40m});
            products.Add(new Product { Name = "Product 3", Description = "This is a test product 3", Cost = 22m, Price = 30m });
            products.Add(new Product { Name = "Product 4", Description = "This is a test product 4", Cost = 92m, Price = 150m });


            var model = new IndexViewModel();

            var list = new List<ProductDisplay>();
            foreach (var product in products)
            {
                list.Add(new ProductDisplay(product));
            }

            model.Products = list;

            return model;
        }
    }

    
    public class IndexSetupViewModel : ViewModel
    {
    }

    [Serializable]
    public class IndexViewModel : ViewModel
    {
        public IEnumerable<ProductDisplay> Products { get; set; }
    }
}