using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public Voyage Voyage { get; set; }
        public int VoyageID { get; set; }
        public int SeatNumber { get; set; }
        public string Abstarct { get; set; }
        public string Abstarct2 { get; set; }

    }
}
