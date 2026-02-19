using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_MusicManager
{
    public class Playlist
    {
        public string ListName;
        public List<MusicTitle> SongItems = new List<MusicTitle>();

        public override string ToString()
        {
            return ListName;
        }
    }
}
