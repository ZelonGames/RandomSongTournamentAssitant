using System;
using System.Threading;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BeastSaberMapLoader;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RandomSongTournamentAssistant
{
    public partial class Form1 : Form
    {
        #region Fields

        private static readonly HttpClient client = new HttpClient();

        private List<string> difficulties = new List<string>();
        private Random rnd = new Random();

        private RandomKeyFilter randomKeyFilter = null;

        private MapData mapData = null;

        private string customLevelsFolderFilename = "beatsaverFolder.txt";

        private int customMessageBoxWidthSize = 300;

        private bool testJsonMode = false;

        #endregion

        public Form1()
        {
            InitializeComponent();
        }


        #region Events

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            lblVersion.Text = "Version " + version;

            lblDifficulties.Text = "";

            cmbCharacteristics.SetSelectedIndex(0);
            cmbDifficulty.SetSelectedIndex(0);

            if (File.Exists(customLevelsFolderFilename))
            {
                using (var re = new StreamReader(customLevelsFolderFilename))
                {
                    txtBeatsaverFolder.Text = re.ReadLine();
                }
            }
        }

        private void SetTransparentColor(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.FromArgb(100, 255, 0, 0);
        }

        private void ChooseCustomLevelsFolder(object sender, MouseEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = txtBeatsaverFolder.Text;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtBeatsaverFolder.Text = fbd.SelectedPath;
                }
            }
        }

        #region Button Click Events 

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (randomKeyFilter == null)
            {
                randomKeyFilter = new RandomKeyFilter();
                randomKeyFilter.Location = new Point(Size.Width / 2 - randomKeyFilter.Size.Width / 2, Size.Height / 2 - randomKeyFilter.Size.Height / 2);
                Controls.Add(randomKeyFilter);
                randomKeyFilter.BringToFront();
            }
            else
            {
                randomKeyFilter.Visible = true;
            }
        }

        private void btnCopyMapInfo_Click(object sender, EventArgs e)
        {
            if (mapData == null)
            {
                CustomMessageBox.Show(this, "This map doesn't exist!", new Size(customMessageBoxWidthSize, 100));
            }
            else
            {
                string beatsaverURL = "https://beatsaver.com/beatmap/" + txtMapID.Text;
                string bpm = mapData.metadata.bpm.ToString();

                // Stats
                string downloads = mapData.stats.downloads.ToString();
                string plays = mapData.stats.plays.ToString();
                string downVotes = mapData.stats.downVotes.ToString();
                string upVotes = mapData.stats.upVotes.ToString();
                string rating = mapData.stats.rating.ToString();

                string selectedDifficulty = cmbDifficulty.Items[cmbDifficulty.SelectedIndex];


                // Difficulty Info
                string difficultyInfo = "";

                Characteristic selectedCharacteristics = mapData.metadata.characteristics.First();

                if (selectedCharacteristics == null)
                {
                    CustomMessageBox.Show(this, "Could not find info for this difficulty because it doesn't exist!", new Size(customMessageBoxWidthSize, 100));
                    return;
                }

                switch (selectedDifficulty)
                {
                    case "ExpertPlus":
                        if (selectedCharacteristics.difficulties.expertPlus != null)
                            difficultyInfo = selectedCharacteristics.difficulties.expertPlus.GetInfoText(mapData.metadata.bpm);
                        break;
                    case "Expert":
                        if (selectedCharacteristics.difficulties.expert != null)
                            difficultyInfo = selectedCharacteristics.difficulties.expert.GetInfoText(mapData.metadata.bpm);
                        break;
                    case "Hard":
                        if (selectedCharacteristics.difficulties.hard != null)
                            difficultyInfo = selectedCharacteristics.difficulties.hard.GetInfoText(mapData.metadata.bpm);
                        break;
                    case "Normal":
                        if (selectedCharacteristics.difficulties.normal != null)
                            difficultyInfo = selectedCharacteristics.difficulties.normal.GetInfoText(mapData.metadata.bpm);
                        break;
                    case "Easy":
                        if (selectedCharacteristics.difficulties.easy != null)
                            difficultyInfo = selectedCharacteristics.difficulties.easy.GetInfoText(mapData.metadata.bpm);
                        break;
                    default:
                        break;
                }

                if (difficultyInfo == "")
                {
                    CustomMessageBox.Show(this, "The Difficulty doesn't exist!", new Size(customMessageBoxWidthSize, 100));
                    return;
                }

                string mapInfo =
                    beatsaverURL + "\n\n" +
                    "===================== STATS =====================\n" +
                    "Downloads: " + downloads + "\n" +
                    //"Plays: " + plays + "\n" +
                    "Downvotes: " + downVotes + "\n" +
                    "Upvotes: " + upVotes + "\n" +
                    "Rating: " + rating + "\n\n" +
                    "================ Difficulty Info (" + selectedDifficulty + ") =================\n" +
                    difficultyInfo + "\n" +
                    "key: " + mapData.key + "\n\n" +
                    "Note that NPS isn't 100% accurate as it only looks for the amount of notes in the map and how long the map is instead of looking at where the first note begins and where the last note ends.";
                ;

                Clipboard.SetData(DataFormats.Text, mapInfo);
                CustomMessageBox.Show(this, "\"" + mapInfo + "\"" + "\n\nWas added to clipboard", new Size(Size.Width - 50, 400));
            }
        }

        private void btnCopyLink_Click(object sender, EventArgs e)
        {
            if (mapData == null)
            {
                CustomMessageBox.Show(this, "This map doesn't exist!", new Size(customMessageBoxWidthSize, 100));
            }
            else
            {
                Clipboard.SetData(DataFormats.Text, "https://beatsaver.com/beatmap/" + txtMapID.Text);
                CustomMessageBox.Show(this, "https://beatsaver.com/beatmap/" + txtMapID.Text + " was added to clipboard", new Size(customMessageBoxWidthSize, 100));
            }
        }

        private async void btnRandomKey_Click(object sender, EventArgs e)
        {
            txtMapID.Text = "";
            lblDifficulties.Text = "";

            int tries = 0;
            int maxTries = 10;

            if (randomKeyFilter != null && randomKeyFilter.UsingFilters)
                maxTries = 50;

            if (maxTries > 10)
                SwitchToLoadingScreen("Searching for a map...");

            var responseString = await client.GetStringAsync("https://beatsaver.com/api/maps/latest/0");

            var latestMaps = JsonConvert.DeserializeObject<Latest>(responseString);
            string latestKey = latestMaps.docs[0].key;

            int keyAsDecimal = int.Parse(latestKey, System.Globalization.NumberStyles.HexNumber);

            mapData = null;
            while (true)
            {
                int randomNumber = rnd.Next(0, keyAsDecimal + 1);
                string randomKey = randomNumber.ToString("x");

                await UpdateMapData(randomKey);
                if (mapData != null)
                    break;

                if (tries == maxTries)
                    break;

                tries++;
            }

            if (maxTries > 10)
                HideLoadingScreen();

            if (tries == maxTries)
            {
                CustomMessageBox.Show(this, "Could not find a valid key. Try again!", new Size(customMessageBoxWidthSize, 100));
                mapData = null;
                txtMapID.Text = "";
            }
        }

        private void btnRandomDiff_Click(object sender, EventArgs e)
        {
            if (difficulties.Count == 0)
            {
                CustomMessageBox.Show(this, "There are no difficulties", new Size(customMessageBoxWidthSize, 100));
                return;
            }

            int prevIndex = cmbDifficulty.SelectedIndex;

            int[] difficultyValues = new int[5];

            int randomDifficulty = rnd.Next(1, 11);

            switch (difficulties.Count)
            {
                case 5:
                    difficultyValues[4] = 5;
                    difficultyValues[3] = 4;
                    difficultyValues[2] = 3;
                    difficultyValues[1] = 2;
                    difficultyValues[0] = 1;
                    break;
                case 4:
                    difficultyValues[4] = 5;
                    difficultyValues[3] = 3;
                    difficultyValues[2] = 2;
                    difficultyValues[1] = 1;
                    difficultyValues[0] = 0;
                    break;
                case 3:
                    difficultyValues[4] = 5;
                    difficultyValues[3] = 3;
                    difficultyValues[2] = 1;
                    difficultyValues[1] = 0;
                    difficultyValues[0] = 0;
                    break;
                case 2:
                    difficultyValues[4] = 4;
                    difficultyValues[3] = 1;
                    difficultyValues[2] = 0;
                    difficultyValues[1] = 0;
                    difficultyValues[0] = 0;
                    break;
                default:
                    break;
            }

            int index = 0;
            for (int i = difficultyValues.Length - 1; i > 0; i--)
            {
                var difficulty = difficultyValues[i];

                if (randomDifficulty >= difficulty)
                {
                    index = 4 - i;
                    break;
                }
            }

            cmbDifficulty.SetSelectedIndex(cmbDifficulty.Items.IndexOf(difficulties[index]));

            if (prevIndex == cmbDifficulty.SelectedIndex)
                CustomMessageBox.Show(this, "The random difficulty stays the same", new Size(customMessageBoxWidthSize, 100));
        }

        private async void btnGetDifficulties_Click(object sender, EventArgs e)
        {
            await UpdateMapData(txtMapID.Text, true);
        }

        private async void btnAnalyzeMap_Click(object sender, EventArgs e)
        {
            if (txtMapID.Text.Length == 0)
            {
                CustomMessageBox.Show(this, "You forgot the key!", new Size(customMessageBoxWidthSize, 100));
                return;
            }

            SwitchToLoadingScreen("Downloading map...");

            await Task.Run(() => { InstallMap(txtMapID.Text); });

            AnalyzeMap();

            HideLoadingScreen();
        }

        private void btnInstallMap_Click(object sender, EventArgs e)
        {

            if (!CanDownloadMap(txtMapID.Text, txtBeatsaverFolder.Text))
            {
                CustomMessageBox.Show(this, "You have already downloaded this map!", new Size(customMessageBoxWidthSize, 100));
                return;
            }
            else
            {
                SwitchToLoadingScreen("Installing map...");
            }

            Thread downloadMapThread = new Thread(() =>
            {
                DownloadMap(txtMapID.Text, txtBeatsaverFolder.Text);

                if (File.Exists(txtBeatsaverFolder.Text + "/" + txtMapID.Text + ".zip"))
                    UnzipFile(txtBeatsaverFolder.Text + "/" + txtMapID.Text);

                if (!File.Exists(customLevelsFolderFilename))
                    File.Create(customLevelsFolderFilename).Close();

                using (var wr = new StreamWriter(customLevelsFolderFilename, false))
                {
                    wr.WriteLine(txtBeatsaverFolder.Text);
                }
            });
            downloadMapThread.Start();
            downloadMapThread.Join();

            HideLoadingScreen();
            //DownloadMap(txtMapID.Text, txtBeatsaverFolder.Text);
        }

        #region Close Button Events

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(255, 223, 71, 73);
            lblClose.ForeColor = Color.Black;
            this.Cursor = Cursors.Hand;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.Gray;
            lblClose.BackColor = Color.FromArgb(100, 0, 0, 0);
            this.Cursor = Cursors.Default;
        }

        #endregion

        #endregion

        #region Mouse Events

        private bool canMove = false;
        private int marginLeft = 0;
        private int marginTop = 0;

        private void InitializeMoveForm(object sender, MouseEventArgs e)
        {
            canMove = true;

            marginLeft = Cursor.Position.X - Location.X;
            marginTop = Cursor.Position.Y - Location.Y;
        }

        private void DisableMoveForm(object sender, MouseEventArgs e)
        {
            canMove = false;
        }

        private void OnMoveFormWindow(object sender, MouseEventArgs e)
        {
            if (!canMove)
                return;

            Location = new Point(Cursor.Position.X - marginLeft, Cursor.Position.Y - marginTop);
        }

        #endregion

        #endregion

        #region Methods

        public static Size MeasureText(string text, Font font)
        {
            return TextRenderer.MeasureText(text, font);
        }

        private async Task UpdateMapData(string randomKey, bool showError = false)
        {
            try
            {
                var responseString = await client.GetStringAsync("https://beatsaver.com/api/maps/detail/" + randomKey);

                if (!File.Exists("mapData.json"))
                {
                    File.Create("mapData.json").Close();
                }

                if (File.Exists("mapData.json"))
                {
                    using (var wr = new StreamWriter("mapData.json"))
                    {
                        wr.WriteLine(responseString);
                    }
                }

                mapData = JsonConvert.DeserializeObject<MapData>(responseString);

                #region NPS Filter
                Difficulty highestDifficulty = mapData.metadata.characteristics[0].difficulties.GetHighestDifficulty();
                if (randomKeyFilter != null && !randomKeyFilter.MatchingFilters(highestDifficulty, mapData))
                {
                    mapData = null;
                    return;
                }
                #endregion

                difficulties = mapData.metadata.difficulties.GetDifficulties();
                this.lblDifficulties.Text = "";
                foreach (var difficulty in difficulties)
                {
                    this.lblDifficulties.Text += difficulty + " ";
                }

                txtMapID.Text = randomKey;

                txtTitle.Text = mapData.metadata.songName + " - " + mapData.metadata.songSubName + "\n" + mapData.metadata.levelAuthorName;
            }
            catch (Exception ex)
            {
                if (showError)
                    CustomMessageBox.Show(this, "There is no map with this key!", new Size(customMessageBoxWidthSize, 100));
                mapData = null;
            }
        }

        private void InstallMap(string id)
        {
            if (id.Length == 0)
                return;


            if (!testJsonMode)
            {
                if (Directory.Exists("analyzedMap"))
                    DeleteAnalyzedDirectory();

                try
                {
                    DownloadMap(id, "", "analyzedMap");
                }
                catch (WebException we)
                {
                    MessageBox.Show(we.ToString());
                    return;
                }

                try
                {
                    ZipFile.ExtractToDirectory("analyzedMap.zip", "analyzedMap");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }

        private void AnalyzeMap()
        {
            int wideWalls = 0;
            int facenotes = 0;

            string fileExtension = testJsonMode ? "json" : "dat";

            MapInfo mapInfo = null;
            string difficultyFileName = null;

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
                CustomMessageBox.Show(this, "The difficulty doesn't exist!", new Size(customMessageBoxWidthSize, 100));
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
            CustomMessageBox.Show(this, resultTest, new Size(customMessageBoxWidthSize, 100));

            if (!testJsonMode)
            {
                if (Directory.Exists("analyzedMap"))
                    DeleteAnalyzedDirectory();
            }
        }

        private void SwitchToLoadingScreen(string loadingScreenText)
        {
            foreach (var control in Controls)
            {
                ((Control)control).Visible = false;
            }
            BackgroundImage = Properties.Resources.saber_o_sponsor;

            var loadingText = new Label();
            loadingText.Name = "LoadingScreenText";
            loadingText.Text = loadingScreenText;
            loadingText.ForeColor = Color.White;
            loadingText.BackColor = Color.Black;

            loadingText.AutoSize = false;

            loadingText.Font = new Font(loadingText.Font.FontFamily, 20);
            loadingText.Size = MeasureText(loadingText.Text, loadingText.Font);

            loadingText.Location = new Point(Size.Width / 2 - loadingText.Size.Width / 2, Size.Height / 2 - loadingText.Size.Height / 2);

            Controls.Add(loadingText);
            loadingText.BringToFront();
        }

        private void HideLoadingScreen()
        {
            foreach (var control in Controls)
            {
                if (!(control is PageControl))
                    ((Control)control).Visible = true;
            }

            Controls.Remove(Controls["LoadingScreenText"]);

            BackgroundImage = null;
        }

        private void DownloadMap(string key, string directory, string fileName = null)
        {
            if (directory.Length > 0)
                directory += "/";

            fileName = fileName == null ? key : fileName;

            try
            {
                WebClient wc = new WebClient();
                wc.DownloadFile("https://beatsaver.com/api/download/key/" + key, directory + fileName + ".zip");
            }
            catch (WebException we)
            {
                MessageBox.Show(we.ToString());
            }
        }

        private void UnzipFile(string fileName)
        {
            ZipFile.ExtractToDirectory(fileName + ".zip", fileName);
            File.Delete(fileName + ".zip");
        }

        private void DeleteAnalyzedDirectory()
        {
            Directory.Delete("analyzedMap", true);
            File.Delete("analyzedMap.zip");
        }

        private int getAmountOfTooWideWalls(List<Obstacle> walls, int badWallWidth)
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

        public bool IsWallTouchingAnotherWall(Obstacle wall, Obstacle otherWall)
        {
            return (wall._time >= otherWall._time && wall._time <= otherWall._time + otherWall._duration) &&
                ((wall._lineIndex >= otherWall._lineIndex || wall._lineIndex + wall._width >= otherWall._lineIndex) && wall._lineIndex <= otherWall._lineIndex + otherWall._width);
        }

        private bool CanDownloadMap(string key, string directory, string fileName = null)
        {
            if (directory.Length > 0)
                directory += "/";

            fileName = fileName == null ? key : fileName;

            return !Directory.Exists(directory + fileName);
        }

        #endregion

    }
}
