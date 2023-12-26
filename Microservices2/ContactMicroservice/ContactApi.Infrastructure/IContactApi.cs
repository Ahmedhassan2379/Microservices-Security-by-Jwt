using ContactApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApi.Infrastructure
{
    public interface IContactApi
    {
        public ContactDto GetContactById(int Id);
    }
}
