using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSongTournamentAssistant
{
    public class CharacteristicsDifficulty
    {
        public Difficulty easy = null;
        public Difficulty normal = null;
        public Difficulty hard = null;
        public Difficulty expert = null;
        public Difficulty expertPlus = null;

        public CharacteristicsDifficulty(Difficulty easy, Difficulty normal, Difficulty hard, Difficulty expert, Difficulty expertPlus)
        {
            this.easy = easy;
            this.normal = normal;
            this.hard = hard;
            this.expert = expert;
            this.expertPlus = expertPlus;
        }

        public Difficulty GetHighestDifficulty()
        {
            if (expertPlus != null)
                return expertPlus;
            else if (expert != null)
                return expert;
            else if (hard != null)
                return hard;
            else if (normal != null)
                return normal;
            else if (easy != null)
                return easy;
            else
                return null;
        }
    }

    public class Difficulty
    {
        public double duration;
        public double length;
        public double njs;
        public int bombs;
        public int notes;
        public int obstacles;

        public Difficulty(double duration, double length, double njs, int bombs, int notes, int obstacles)
        {
            this.duration = duration;
            this.length = length;
            this.njs = njs;
            this.bombs = bombs;
            this.notes = notes;
            this.obstacles = obstacles;
        }

        public string GetInfoText(double bpm)
        {
            int minutes = (int)length / 60;
            int seconds = (int)length - minutes * 60;
            double notesPerSecond = MapTools.GetNotesPerSecond(bpm, duration, notes);
            string lengthInfo = minutes + " minutes " + seconds + " seconds ";

            if (length <= 60)
                lengthInfo = (int)length + " seconds ";

            return 
                "Length: " + lengthInfo + "\n" +
                "Note jump speed: " + njs + "\n" +
                "Notes per second: " + notesPerSecond + "\n" +
                "Bombs: " + bombs + "\n" +
                "Notes: " + notes + "\n" +
                "Obstacles: " + obstacles;
        }
    }
}
