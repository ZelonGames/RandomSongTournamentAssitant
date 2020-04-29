using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeatSaverSharp;

using RandomSongTournamentAssistant.UserControls.Filter;


namespace RandomSongTournamentAssistant
{
    public static class RandomKeyGenerator
    {
        public static async Task<Beatmap> GenerateRandomMap(Form1 form, RandomKeyFilter randomKeyFilter)
        {
            int tries = 0;
            int maxTries = 10;

            if (randomKeyFilter != null && randomKeyFilter.UsingFilters)
                maxTries = 50;

            string randomKey = null;

            Beatmap mapData = null;

            var latestMaps = await Form1.beatsaverClient.Latest();
            string latestKey = latestMaps.Docs[0].Key;

            int keyAsDecimal = int.Parse(latestKey, System.Globalization.NumberStyles.HexNumber);

            if (randomKey == null)
            {
                if (randomKeyFilter != null && randomKeyFilter.Rating.HasValue)
                    await FilterHelper.SetFilterPageNumbers(Form1.client, (int)(randomKeyFilter.Rating.Value * 100), "minRatingAPIPage");

                while (true)
                {
                    if (randomKeyFilter != null && randomKeyFilter.Rating.HasValue)
                    {
                        await FilterHelper.SetRandomKey(Form1.client, Form1.rnd);
                        randomKey = FilterHelper.RandomKey;
                    }
                    else
                    {
                        int randomNumber = Form1.rnd.Next(0, keyAsDecimal + 1);
                        randomKey = randomNumber.ToString("x");
                    }

                    mapData = await MapDataHelper.GetMapData(form, randomKeyFilter, randomKey, false);
                    if (mapData != null)
                        break;

                    if (tries == maxTries)
                        break;

                    tries++;
                }
            }

            if (maxTries > 10)
                LoadingScreenHelper.HideLoadingScreen(form);

            if (tries == maxTries)
            {
                return null;
            }

            return mapData;
        }
    }
}
