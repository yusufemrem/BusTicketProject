using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfTicketRepository : GenericRepository<Ticket>, ITicketDal
    {
        private Context _context;

        public EfTicketRepository(Context context)
        {
            _context = context;
        }

        public List<Ticket> GetTicketUser(int userId)
        {
            return _context.Tickets.Where(ticket => ticket.AppUserID == userId).ToList();
        }
    }
}
