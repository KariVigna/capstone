using System.Collections.Generic;

namespace Capstone.Models
{
    public class Prize
    {
        public int PrizeId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public List<KidPrize> JoinEntities { get; set; }
    }
}