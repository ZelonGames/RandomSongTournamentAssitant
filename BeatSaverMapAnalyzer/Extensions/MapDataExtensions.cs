using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BeatSaverSharp;

namespace RandomSongTournamentAssistant.Extensions
{
    public static class MapDataExtensions
    {
        public static List<string> GetDifficulties(this Beatmap beatmap)
        {
            var difficulties = new List<string>();

            if (beatmap.Metadata.Difficulties.ExpertPlus)
                difficulties.Add("ExpertPlus");
            if (beatmap.Metadata.Difficulties.Expert)
                difficulties.Add("Expert");
            if (beatmap.Metadata.Difficulties.Hard)
                difficulties.Add("Hard");
            if (beatmap.Metadata.Difficulties.Normal)
                difficulties.Add("Normal");
            if (beatmap.Metadata.Difficulties.Easy)
                difficulties.Add("Easy");

            return difficulties;
        }

        public static BeatmapCharacteristicDifficulty GetHighestDifficulty(this ReadOnlyDictionary<string, BeatmapCharacteristicDifficulty?> beatmapCharacteristicDifficulties)
        {
            BeatmapCharacteristicDifficulty highestDifficulty = new BeatmapCharacteristicDifficulty();
            foreach (var difficulty in beatmapCharacteristicDifficulties.Values)
            {
                if (difficulty != null)
                    highestDifficulty = difficulty.Value;
            }
            return highestDifficulty;
        }

        public static string GetInfoText(this BeatmapCharacteristicDifficulty beatmapCharacteristicDifficulty, double bpm)
        {
            long minutes = beatmapCharacteristicDifficulty.Length / 60;
            long seconds = beatmapCharacteristicDifficulty.Length - minutes * 60;
            double notesPerSecond = MapTools.GetNotesPerSecond(bpm, beatmapCharacteristicDifficulty.Duration, beatmapCharacteristicDifficulty.Notes);
            string lengthInfo = minutes + " minutes " + seconds + " seconds ";

            if (beatmapCharacteristicDifficulty.Length <= 60)
                lengthInfo = beatmapCharacteristicDifficulty.Length + " seconds ";

            return
                "Length: " + lengthInfo + "\n" +
                "Note jump speed: " + beatmapCharacteristicDifficulty.NoteJumpSpeed + "\n" +
                "Note jump speed offset: " + beatmapCharacteristicDifficulty.NoteJumpSpeedOffset + "\n" +
                "Notes per second: " + notesPerSecond + "\n" +
                "Bombs: " + beatmapCharacteristicDifficulty.Bombs+ "\n" +
                "Notes: " + beatmapCharacteristicDifficulty.Notes + "\n" +
                "Obstacles: " + beatmapCharacteristicDifficulty.Obstacles;
        }
    }
}
