using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeatSaverSharp;
using RandomSongTournamentAssistant.Extensions;

namespace RandomSongTournamentAssistant
{
    public static class MapDataHelper
    {
        public static async Task<Beatmap> GetMapData(Form1 form, RandomKeyFilter randomKeyFilter, string randomKey, bool showError = false)
        {
            try
            {
                Beatmap mapData = await Form1.beatsaverClient.Key(randomKey);

                #region NPS Filter
                BeatmapCharacteristicDifficulty highestDifficulty = mapData.Metadata.Characteristics[0].Difficulties.GetHighestDifficulty();
                if (randomKeyFilter != null && !randomKeyFilter.MatchingFilters(highestDifficulty, mapData))
                {
                    mapData = null;
                    return null;
                }
                #endregion

                return mapData;
            }
            catch (Exception ex)
            {
                if (showError)
                    CustomMessageBox.Show(form, "There is no map with this key!", new Size(Form1.customMessageBoxWidthSize, 100));
                return null;
            }
        }
    }
}
