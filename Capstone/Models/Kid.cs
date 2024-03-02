using System.Collections.Generic;

namespace Capstone.Models
{
    public class Kid
    {
        public int KidId { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
        public List<Entry> Entries { get; set; }
    }
}