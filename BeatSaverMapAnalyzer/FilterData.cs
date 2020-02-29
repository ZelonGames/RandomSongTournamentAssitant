using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSongTournamentAssistant
{
    public class FilterData
    {
        public Dictionary<string, Dictionary<int, int>> filterData = null;

        public FilterData(Dictionary<string, Dictionary<int, int>> filterData)
        {
            this.filterData = filterData;
        }
    }
}
