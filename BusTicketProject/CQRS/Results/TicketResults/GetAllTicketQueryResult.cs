using EntitiyLayer.Concrete;

namespace BusTicketProject.CQRS.Results.TicketResults
{
    public class GetAllTicketQueryResult
    {
        public int TicketID { get; set; }
        public int TicketPrice { get; set; }  
        public int VoyageID { get; set; }
        public int UserID { get; set; }
        public int SeatNumber { get; set; }
        public string TicketStatus { get; set; }
        public int AppUserID { get; set; }
    }
}
