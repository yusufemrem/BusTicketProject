using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IVoyageService : IGenericService<Voyage>
    {
        List<Voyage> GetCompanyVoyages(int UserId);
    }
}
