using System;

namespace BusTicketProject.Models
{
    public class VoyageModel
    {
        public string StartingPlace { get; set; }
        public string Destination { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime DestinationDate { get; set; }
        public int SeatCapacity { get; set; }
        public int TicketPrice { get; set; }
        public int CompanyID { get; set; }
    }
}
