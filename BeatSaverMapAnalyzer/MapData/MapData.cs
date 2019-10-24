using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSongTournamentAssistant
{
    public class MapData
    {
        public MapMetaData metadata = null;
        public Stats stats = null;
        public string key;

        public MapData(MapMetaData metadata, Stats stats, string key)
        {
            this.metadata = metadata;
            this.stats = stats;
            this.key = key;
        }
    }
}
