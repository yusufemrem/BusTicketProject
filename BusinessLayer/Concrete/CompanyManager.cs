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
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public List<Company> GetList()
        {
           return _companyDal.GetListAll();
        }

        public void TAdd(Company t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Company t)
        {
            throw new NotImplementedException();
        }

        public Company TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Company t)
        {
            throw new NotImplementedException();
        }
    }
}
