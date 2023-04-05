using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Destination { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? MainUrl { get; set; }
    }
}
