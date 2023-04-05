using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Text
    {
        public Guid Id { get; set; }
        public Guid TripId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? Url { get; set; }
        
    }
}
