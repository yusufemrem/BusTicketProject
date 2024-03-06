using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.VoyageDto
{
    public class CreateVoyageDto
    {
        public string StartingPlace { get; set; }
        public string Destination { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime DestinationDate { get; set; }
        public int CompanyID { get; set; }
        public int SeatCapacity { get; set; }
        public int TicketPrice { get; set; }
        public int AppUserID { get; set; }
    }
}
