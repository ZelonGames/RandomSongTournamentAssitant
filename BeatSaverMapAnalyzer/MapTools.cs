using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSongTournamentAssistant
{
    public static class MapTools
    {
        public static double GetNotesPerSecond(double bpm, double duration, int noteCount)
        {
            if (noteCount == 0 || duration == 0)
                return 0;

            double totalSeconds = 60 / bpm * duration;

            double notesPerSecond = Math.Round(noteCount / totalSeconds, 2);

            return notesPerSecond;
        }
    }
}
