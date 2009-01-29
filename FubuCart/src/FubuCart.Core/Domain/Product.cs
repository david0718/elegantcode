using System.Collections.Generic;

namespace FubuCart.Core.Domain
{
    public enum InventoryStatus
    {
        InStock = 1,
        BackOrder = 2,
        PreOrder = 3,
        SpecialOrder = 4,
        Discontinued = 5,
        CurrentlyUnavailable = 6
    }

    public enum DeliveryMethod
    {
        Shipped = 1,
        Download = 2
    }

    public class Product : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal DiscountPercent { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string Manufacturer { get; set; }
        public virtual DeliveryMethod Delivery { get; set; }
        public virtual decimal WeightInPounds { get; set; }
        public virtual bool IsTaxable { get; set; }
        public virtual InventoryStatus Inventory { get; set; }
        public virtual bool AllowBackOrder { get; set; }
        public virtual string EstimatedDelivery { get; set; }
        public virtual string DefaultImagePath
        { 
            get
            {
                return this.Images.Count > 0 ? this.Images[0].ThumbnailPhoto : "";

            }

        }

        public virtual decimal DiscountedPrice
        {
            get { return Price * (1.0M - DiscountPercent); } 
        }

        public virtual IList<Category> Categories { get; set; }
        //public virtual IList<ProductReview> Reviews { get; set; }
        public virtual IList<ProductImage> Images { get; set; }
        public virtual IList<Product> RelatedProducts { get; set; }
        public virtual IList<Product> CrossSells { get; set; }
        //public virtual IList<ProductDescriptor> Descriptors { get; set; }
        public virtual IList<Product> Recommended { get; set; }
       
    }

    /// <summary>
    /// A class which represents a URL-based image
    /// </summary>
    public class Image
    {

        public string ThumbnailPhoto { get; set; }
        public string FullSizePhoto { get; set; }
        public int ID { get; set; }

        public Image() { }

        public Image(string thumb, string full)
        {
            this.ThumbnailPhoto = thumb;
            this.FullSizePhoto = full;
        }

    }

    /// <summary>
    /// An image for a Product
    /// </summary>
    public class ProductImage : Image
    {
        public ProductImage() : base() { }
        public int ProductID { get; set; }
        public ProductImage(string thumb, string full)
            : base(thumb, full)
        {
        }
    }

    /// <summary>
    /// An image for a Category
    /// </summary>
    public class CategoryImage : Image
    {
        public int CategoryID { get; set; }
        public CategoryImage() : base() { }
        public CategoryImage(string thumb, string full)
            : base(thumb, full)
        {
        }
    }
}