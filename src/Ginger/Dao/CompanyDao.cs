using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ginger.Dto;
using NHibernate.Linq;

namespace Ginger.Dao
{
    public class CompanyDao
    {
        public List<Company> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Company>().ToList();
            }
        }
    }
}
