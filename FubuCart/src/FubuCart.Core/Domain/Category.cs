namespace FubuCart.Core.Domain
{
    public class Category : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}