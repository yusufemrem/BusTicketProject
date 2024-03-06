using BusTicketProject.CQRS.Results.TicketResults;
using MediatR;
using System.Collections.Generic;

namespace BusTicketProject.CQRS.Queries.GetAllTicketQuery
{
    public class GetAllTicketQuery:IRequest<List<GetAllTicketQueryResult>>
    {
    }
}
