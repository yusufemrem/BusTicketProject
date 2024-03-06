using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public List<Discount> GetList()
        {
            return _discountDal.GetListAll();
        }

        public void TAdd(Discount t)
        {
           _discountDal.Insert(t);
        }

        public void TDelete(Discount t)
        {
            _discountDal.Delete(t);
        }

        public Discount TGetById(int id)
        {
           return _discountDal.GetByID(id);
        }

        public void TUpdate(Discount t)
        {
            throw new NotImplementedException();
        }
    }
}
