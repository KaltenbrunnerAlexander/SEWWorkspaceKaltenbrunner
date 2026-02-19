using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_MusicManager
{
    public class MusicTitle
    {
        public string Title;
        public string Artist;
        public string Year;
        public string FilePath;

        public override string ToString()
        {
            return Title + " - " + Artist + " (" + Year + ")";
        }
    }
}
