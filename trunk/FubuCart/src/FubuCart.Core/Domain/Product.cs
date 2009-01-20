namespace FubuCart.Core.Domain
{
    public class Product : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual decimal Price { get; set; }

        public virtual Category Category { get; set; }
       
    }
}