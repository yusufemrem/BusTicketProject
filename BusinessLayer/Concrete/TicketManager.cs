using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TicketManager : ITicketService
    {
        private ITicketDal _ticketDal;
        private Context _context;
        public TicketManager(ITicketDal ticketDal, Context context)
        {
            _ticketDal = ticketDal;
            _context = context;
        }

        public List<Ticket> GetList()
        {
           return _ticketDal.GetListAll();
        }


        public  List<Ticket> GetUserTicket(int userId)
        {
            return _context.Tickets.Where(ticket => ticket.AppUserID == userId).ToList();
        }

        public void TAdd(Ticket ticket)
        {
            _ticketDal.Insert(ticket);
        }

        public void TDelete(Ticket t)
        {
            throw new NotImplementedException();
        }

        public Ticket TGetById(int id)
        {
          return _ticketDal.GetByID(id);
        }

        public void TUpdate(Ticket t)
        {
            throw new NotImplementedException();
        }
    }
}
