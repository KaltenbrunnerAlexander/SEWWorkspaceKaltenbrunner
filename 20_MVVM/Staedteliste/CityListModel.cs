using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staedteliste
{
    internal class CityListModel
    {
        public string SearchCity { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public bool CapitalCity { get; set; }
    }
}
