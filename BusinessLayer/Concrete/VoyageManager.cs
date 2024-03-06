using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class VoyageManager : IVoyageService
    {
        private IVoyageDal _voyageDal;
        private Context _context;
        public VoyageManager(IVoyageDal voyageDal,Context context)
        {
            _voyageDal = voyageDal;
            _context = context;
        }

        public List<Voyage> GetCompanyVoyages(int UserId)
        {
            return _context.Voyages.Where(voyage=> voyage.AppUserID == UserId).ToList();
        }

        public List<Voyage> GetList()
        {
            return _voyageDal.GetListAll();
        }

       
        public void TAdd(Voyage t)
        {
            _voyageDal.Insert(t);
        }

        public void TDelete(Voyage t)
        {
           _voyageDal.Delete(t);
        }

        public Voyage TGetById(int id)
        {
            return _voyageDal.GetByID(id);
        }

        public void TUpdate(Voyage t)
        {
            throw new NotImplementedException();
        }
    }
}
