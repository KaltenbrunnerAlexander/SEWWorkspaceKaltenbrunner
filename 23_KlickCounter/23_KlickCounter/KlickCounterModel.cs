using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_KlickCounter
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }

        public string DisplayText => $"Klick {Id} - {Timestamp:HH:mm:ss:fff}";
    }
}
