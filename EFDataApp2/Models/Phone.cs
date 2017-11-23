using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp2.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; } // название смартфона
        public string Company { get; set; } // компания
        public int Price { get; set; } // цена


    }
    public class Product
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Country { get; set; }
        public string Style { get; set; }
        public string Album { get; set; }
        public decimal Year { get; set; }
        public string Label { get; set; }
        public string Number { get; set; }
        public string Licensing { get; set; }
        public decimal Price { get; set; }
        public string Cover { get; set; }
        public string Booklet { get; set; }
        public string Picture { get; set; }
        public string Tracks { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }



    }
    public class Order
    {
        // [BindNever]
        public int OrderId { get; set; }
        // [BindNever]

        //   public ICollection<CartLine> Lines { get; set; }

        public string Family { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Index { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool GiftWrap { get; set; }
        public bool Dispatched { get; set; }
        public string EMail { get; set; }
        //    public virtual List<OrderLine> OrderLines { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }

    }

    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
       public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}
