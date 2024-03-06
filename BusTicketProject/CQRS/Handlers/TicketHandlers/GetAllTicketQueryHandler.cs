using BusTicketProject.CQRS.Queries.GetAllTicketQuery;
using BusTicketProject.CQRS.Results.TicketResults;
using DataAccessLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusTicketProject.CQRS.Handlers.TicketHandlers
{
    public class GetAllTicketQueryHandler:IRequestHandler<GetAllTicketQuery,List<GetAllTicketQueryResult>>
    {
        private readonly Context _context;

        public GetAllTicketQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllTicketQueryResult>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tickets.Select(x=> new GetAllTicketQueryResult
            {
                TicketID = x.TicketID,
                AppUserID = x.AppUserID,
                SeatNumber = x.SeatNumber,
                TicketPrice = x.TicketPrice,
                TicketStatus = x.TicketStatus,
                UserID = x.UserID,
                VoyageID = x.VoyageID
            }).AsNoTracking().ToListAsync();
        }
    }
}
