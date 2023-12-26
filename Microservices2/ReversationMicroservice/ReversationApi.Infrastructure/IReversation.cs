using ReversationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversationApi.Infrastructure
{
    public interface IReversation
    {
        public ReversationModels GetReversationById(int BkgNumber);
    }
}
