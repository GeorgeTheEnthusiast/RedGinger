using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Ginger.Dto;

namespace Ginger.Mapping
{
    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Name);

            Table("Company");
        }
    }
}
