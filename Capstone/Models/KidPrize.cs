using System.Collections.Generic;

namespace Capstone.Models
{
    public class KidPrize
    {
        public int KidPrizeId { get; set; }
        public int KidId { get; set; }
        public Kid Kid { get; set; }
        public int PrizeId { get; set; }
        public Prize Prize { get; set; }
    }
}