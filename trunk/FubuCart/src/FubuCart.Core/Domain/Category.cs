using System.Collections.Generic;

namespace FubuCart.Core.Domain
{
    public class Category : DomainEntity
    {
        public virtual string Name { get; set; }

        public virtual IList<Category> SubCategories { get; set; }
        
        public virtual CategoryImage Image { get; set; }
        
        public virtual bool IsDefault { get; set; }

        #region object overrides
        public override bool Equals(object obj)
        {
            if (obj is Category)
            {
                Category compareTo = (Category)obj;
                return compareTo.ID == this.ID;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
        #endregion

    }
}