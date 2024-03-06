﻿using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITicketService : IGenericService<Ticket>
    {
    List<Ticket> GetUserTicket(int userId);

    }
}
