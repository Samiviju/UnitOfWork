using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.TypeRepository
{
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        public EmailRepository(PeopleContext context): base(context) { }
    }
}
