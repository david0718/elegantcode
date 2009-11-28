using System.Collections.Generic;

namespace TarantinoSample.Domain
{
    public class Order 
    {
        public virtual int Id { get; set; }
        public virtual int OrderNumber { get; set; }
        public virtual string PONumber { get; set; }

        public virtual IList<OrderItem> OrderItems { get; set;}

       public Order()
       {
           OrderItems = new List<OrderItem>();
       }
    }

    public class OrderItem
    {
        public virtual int Id { get; set; }
        public virtual string ItemName { get; set; }
        public virtual  string Description { get; set; }
        public virtual decimal Cost { get; set; }
    }
}