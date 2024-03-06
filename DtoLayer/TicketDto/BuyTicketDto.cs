using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.TicketDto
{
    public class BuyTicketDto
    {
        public int TicketPrice { get; set; }
        public int VoyageID { get; set; }
        public int UserID { get; set; }
        public int SeatNumber { get; set; }
        public string TicketStatus { get; set; }
        public int AppUserID { get; set; }
        public string UserStartingPlace { get; set; }
        public string UserDestination { get; set; }
    }
}
