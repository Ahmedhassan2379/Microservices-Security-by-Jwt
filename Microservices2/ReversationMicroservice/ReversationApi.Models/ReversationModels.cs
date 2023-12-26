using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversationApi.Models
{
    public class ReversationModels
    {
        public int Id { get; set; }
        public int BkgNumber { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime BKGDate { get; set; }
        public double Amount { get; set; }
    }
}
