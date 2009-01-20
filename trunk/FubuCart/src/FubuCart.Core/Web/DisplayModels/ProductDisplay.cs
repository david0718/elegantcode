using FubuCart.Core.Domain;

namespace FubuCart.Core.Web.DisplayModels
{
    public class ProductDisplay
    {
        public ProductDisplay(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            Cost = product.Cost;
            Price = product.Price;
            Category = product.Category;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}