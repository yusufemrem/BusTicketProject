using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Statistics
    {
        [Key]
        public int StatisticsID { get; set; }
        public int TotalTicketCount { get; set; }
        public string PopularCompany { get; set; }

    }
}
