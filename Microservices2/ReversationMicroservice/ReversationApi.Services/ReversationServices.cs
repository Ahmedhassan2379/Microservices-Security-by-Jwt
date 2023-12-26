using ReversationApi.Infrastructure;
using ReversationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversationApi.Services
{
    public class ReversationServices : IReversation
    {
        
        public ReversationModels GetReversationById(int BkgNumber)
        {
            return new ReversationModels
            {
                Id=(new Random()).Next(100),
                BKGDate=DateTime.Now,
                BkgNumber= BkgNumber,
                CheckinDate=DateTime.Now.AddDays(30),
                CheckoutDate=DateTime.Now.AddDays(37),
                Amount = (new Random()).Next(1000)
            };
        }
    }
}
