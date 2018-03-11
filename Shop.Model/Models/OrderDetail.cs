using Shop.Model.Abstract;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail : Auditable
    {
        [Key]
        [Column(Order=1)]
        public int OrderID { set; get; }
        [Key]
        [Column(Order = 2)]
        public int ProductID { set; get; }

        public int Quantity { set; get; }
        [ForeignKey("OrderID")]
        public virtual IEnumerable<Order> Orders { set; get; }
        [ForeignKey("ProductID")]
        public virtual IEnumerable<Product> Products { set; get; }
    }
}