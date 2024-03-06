using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        public int TicketPrice { get; set; }
        public Voyage Voyage { get; set; }
        public int VoyageID { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public int SeatNumber { get; set; }
        public string TicketStatus { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserID { get; set; }
        public string UserStartingPlace { get; set; }
        public string UserDestination { get; set; }
    }
}
