using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSongTournamentAssistant
{
    public class Document
    {
        public string key;
        public Stats stats = null;

        public Document(string key, Stats stats)
        {
            this.key = key;
            this.stats = stats;
        }
    }
}
