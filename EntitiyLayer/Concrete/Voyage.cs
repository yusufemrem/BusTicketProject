using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Voyage
    {
        [Key]
        public int VoyageID { get; set; }
        public string StartingPlace { get; set; }
        public string Destination { get; set; }
        public DateTime  StartingDate { get; set; }
        public DateTime DestinationDate { get; set; }
        public DateTime EsimatedTime { get; set; }
        public string ExpeditionStop1 { get; set; }
        public string ExpeditionStop2 { get; set; }
        public string ExpeditionStop3 { get; set; }
        public string ExpeditionStop4 { get; set; }

        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public int SeatCapacity { get; set; }
        public int TicketPrice { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserID { get; set; }
    }
}
