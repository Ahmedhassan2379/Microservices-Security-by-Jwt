using ContactApi.Infrastructure;
using ContactApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApi.Services
{
    public class ContactService : IContactApi
    {
        public ContactDto GetContactById(int Id)
        {
            return new ContactDto
            {
                Id = Id,
                FirstName = "Ahmed",
                LastName = "Hassan"
            };
        }
    }
}
