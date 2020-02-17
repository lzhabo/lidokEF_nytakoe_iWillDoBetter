using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBook
{
    [Table("Orders")]
    public partial class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public float TotalPrice { get; set; }

        public virtual Book Books { get; set; }
        public virtual Customer Customers { get; set; }
    }
}
