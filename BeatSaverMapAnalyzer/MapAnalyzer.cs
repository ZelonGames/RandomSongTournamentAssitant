using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeastSaberMapLoader;
using System.Windows.Forms;
using BeatSaverSharp;
using System.Drawing;

namespace RandomSongTournamentAssistant
{
    public static class MapAnalyzer
    {
        public static void AnalyzeMap(Form form, CustomComboBox cmbCharacteristics, CustomComboBox cmbDifficulty, bool testJsonMode)
        {
            int wideWalls = 0;
            int facenotes = 0;

            string fileExtension = testJsonMode ? "json" : "dat";

            MapInfo mapInfo = null;
            string difficultyFileName = null;
            string requirementsList = null;
            bool requires_extensions = false;

            try
            {
                mapInfo = MapLoader.LoadInfo("analyzedMap/info." + fileExtension);

                foreach (var difficultySet in mapInfo._difficultyBeatmapSets)
                {
                    if (cmbCharacteristics.SelectedItemText.ToLower() != difficultySet._beatmapCharacteristicName.ToLower())
                        continue;

                    foreach (var difficulty in difficultySet._difficultyBeatmaps)
                    {
                        if (difficulty._difficulty.ToLower() == cmbDifficulty.SelectedItemText.ToLower())
                        {
                            difficultyFileName = difficulty._beatmapFilename;
                            requires_extensions = difficulty.customData != null && difficulty.customData._requirements != null ? difficulty.customData._requirements.Length > 0 : false;
                            if (requires_extensions)
                            {
                                foreach (var requirement in difficulty.customData._requirements)
                                {
                                    requirementsList += requirement + "\n";
                                }
                            }
                            break;
                        }
                    }
                    if (difficultyFileName != null)
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            if (difficultyFileName == null)
            {
                CustomMessageBox.Show(form, "The difficulty doesn't exist!", new Size(Form1.customMessageBoxWidthSize, 200));
                return;
            }

            Map map = MapLoader.LoadDifficulty("analyzedMap/" + difficultyFileName);

            foreach (var note in map._notes)
            {
                if ((note._lineIndex == 1 || note._lineIndex == 2) && note._lineLayer == 1)
                    facenotes++;
            }

            int wideWallsPercent = (int)((float)wideWalls / map._obstacles.Count * 100);

            if (map != null)
                wideWalls = getAmountOfTooWideWalls(map._obstacles, 3);

            string resultTest = wideWalls + ", three wide walls";
            if (wideWalls == 0)
                resultTest = "No three wide walls in this map :)";

            if (requires_extensions)
                resultTest += "\n\nRequirements:\n" + requirementsList + "\n";

            CustomMessageBox.Show(form, resultTest, new Size(Form1.customMessageBoxWidthSize, 200));

            if (!testJsonMode)
            {
                if (Directory.Exists("analyzedMap"))
                    Directory.Delete("analyzedMap", true);
            }
        }

        private static bool IsWallTouchingAnotherWall(Obstacle wall, Obstacle otherWall)
        {
            return (wall._time >= otherWall._time && wall._time <= otherWall._time + otherWall._duration) &&
                ((wall._lineIndex >= otherWall._lineIndex || wall._lineIndex + wall._width >= otherWall._lineIndex) && wall._lineIndex <= otherWall._lineIndex + otherWall._width);
        }


        private static int getAmountOfTooWideWalls(List<Obstacle> walls, int badWallWidth)
        {
            if (walls.Count == 0)
                return 0;

            double getWidthOfGroup(List<Obstacle> group)
            {
                double minLineIndex = group.First()._type == 0 ? group.First()._lineIndex : 0;
                double maxLineIndex = group.First()._type == 0 ? group.First()._lineIndex + group.First()._width : 0;

                for (int w = 1; w < group.Count; w++)
                {
                    Obstacle wall = group[w];

                    if (wall._type != 0)
                        continue;

                    if (wall._lineIndex < minLineIndex)
                        minLineIndex = wall._lineIndex;

                    if (wall._lineIndex + wall._width > maxLineIndex)
                        maxLineIndex = wall._lineIndex + wall._width;
                }


                return maxLineIndex - minLineIndex;
            }

            walls = walls.OrderBy(x => x._time).ToList();

            int wideWalls = 0;

            var listOfWideWalls = new List<List<Obstacle>>();
            var groupedWalls = new List<List<Obstacle>>();
            groupedWalls.Add(new List<Obstacle>());
            groupedWalls.Last().Add(walls.First());

            var savedGroupedWalls = new List<List<Obstacle>>();
            savedGroupedWalls.Add(groupedWalls.Last());

            List<Obstacle> lastGroupedWall = null;

            for (int i = 1; i < walls.Count; i++)
            {
                Obstacle wall = walls[i];

                if (wall._type != 0)
                    continue;

                foreach (var savedGroupedWall in savedGroupedWalls)
                {
                    if (wall._time > savedGroupedWall.Max(x => x._time + x._duration))
                    {
                        savedGroupedWalls.Remove(savedGroupedWall);
                        break;
                    }
                }

                bool addedWall = false;

                foreach (var savedGroupedWall in savedGroupedWalls)
                {
                    foreach (var individualWall in savedGroupedWall)
                    {

                        if (IsWallTouchingAnotherWall(wall, individualWall))
                        {
                            savedGroupedWall.Add(wall);
                            addedWall = true;
                            break;
                        }
                    }

                    if (addedWall)
                        break;
                }

                if (!addedWall)
                {
                    lastGroupedWall = groupedWalls.Last();

                    for (int g = groupedWalls.Count - 2; g > 0; g--)
                    {
                        List<Obstacle> currentGroupedWall = groupedWalls[g];

                        if (lastGroupedWall.Max(x => x._time + x._duration) < currentGroupedWall.Max(x => x._time + x._duration))
                            lastGroupedWall = currentGroupedWall;
                        else
                            break;
                    }

                    double width = getWidthOfGroup(lastGroupedWall);

                    if (width == 2)
                    {
                        if (lastGroupedWall.Min(x => x._lineIndex) == 1)
                        {
                            wideWalls++;
                            listOfWideWalls.Add(lastGroupedWall);
                        }
                    }
                    else if (width >= badWallWidth)
                    {
                        wideWalls++;
                        listOfWideWalls.Add(lastGroupedWall);
                    }

                    groupedWalls.Add(new List<Obstacle>());
                    groupedWalls.Last().Add(wall);
                    savedGroupedWalls.Add(groupedWalls.Last());
                }
            }


            lastGroupedWall = groupedWalls.Last();
            double width2 = getWidthOfGroup(lastGroupedWall);

            if (width2 == 2)
            {
                if (lastGroupedWall.Min(x => x._lineIndex) == 1)
                {
                    wideWalls++;
                    listOfWideWalls.Add(lastGroupedWall);
                }
            }
            if (width2 >= badWallWidth)
            {
                wideWalls++;
                listOfWideWalls.Add(lastGroupedWall);
            }

            return wideWalls;
        }


    }
}
