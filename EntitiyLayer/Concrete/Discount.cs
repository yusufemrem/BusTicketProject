using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Discount
    {
        [Key]
        public int DiscountID { get; set; }
        public string DiscountName { get; set; }
        public int DiscountAmount { get; set; }
    }
}
