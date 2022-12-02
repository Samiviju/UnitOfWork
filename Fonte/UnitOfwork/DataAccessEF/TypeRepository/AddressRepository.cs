using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.TypeRepository
{
    public class AddressRepository : GenericRepository<Address>, IAdressRepository
    {
        public AddressRepository(PeopleContext context): base(context) { }
    }
}
