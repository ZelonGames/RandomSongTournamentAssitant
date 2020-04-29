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
using System.Reflection;
using RandomSongTournamentAssistant.Extensions;
using BeatSaverSharp;

using RandomSongTournamentAssistant.UserControls.Filter;

namespace RandomSongTournamentAssistant
{
    public partial class Form1 : Form
    {
        #region Fields

        public static BeatSaver beatsaverClient = new BeatSaver(new HttpOptions() { ApplicationName = Assembly.GetExecutingAssembly().GetName().Name, Version = Assembly.GetExecutingAssembly().GetName().Version });
        public static Random rnd = new Random();

        public static readonly HttpClient client = new HttpClient();

        private Beatmap mapData;

        private List<string> difficulties = new List<string>();

        private RandomKeyFilter randomKeyFilter = null;

        private string customLevelsFolderFilename = "beatsaverFolder.txt";

        public const int customMessageBoxWidthSize = 300;

        private bool testJsonMode = false;

        #endregion

        #region Properties

        public int FilterPageNumber { get; private set; }

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
                string bpm = mapData.Metadata.BPM.ToString();

                // Stats
                string downloads = mapData.Stats.Downloads.ToString();
                string plays = mapData.Stats.Plays.ToString();
                string downVotes = mapData.Stats.DownVotes.ToString();
                string upVotes = mapData.Stats.UpVotes.ToString();
                string rating = mapData.Stats.Rating.ToString();

                string selectedDifficultyName = cmbDifficulty.Items[cmbDifficulty.SelectedIndex];
                selectedDifficultyName = selectedDifficultyName.Substring(0, 1).ToLower() + selectedDifficultyName.Substring(1);


                // Difficulty Info
                string difficultyInfo = "";

                var difficulties = mapData.Metadata.Characteristics.FirstOrDefault().Difficulties;
                BeatmapCharacteristicDifficulty selectedDifficulty = new BeatmapCharacteristicDifficulty();

                if (!difficulties.ContainsKey(selectedDifficultyName))
                {
                    CustomMessageBox.Show(this, "Could not find info for this difficulty because it doesn't exist!", new Size(customMessageBoxWidthSize, 100));
                    return;
                }
                selectedDifficulty = difficulties[selectedDifficultyName].Value;

                difficultyInfo = selectedDifficulty.GetInfoText(mapData.Metadata.BPM);

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
                    "================ Difficulty Info (" + selectedDifficultyName + ") =================\n" +
                    difficultyInfo + "\n" +
                    "key: " + mapData.Key + "\n\n" +
                    "Note that NPS isn't 100% accurate as it only looks for the amount of notes in the map and how long the map is instead of looking at where the first note begins and where the last note ends.";

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

            LoadingScreenHelper.SwitchToLoadingScreen(this, "Searching for a map...");

            mapData = await RandomKeyGenerator.GenerateRandomMap(this, randomKeyFilter);
            

            if (mapData == null)
            {
                CustomMessageBox.Show(this, "Could not find a valid key. Try again!", new Size(customMessageBoxWidthSize, 100));
                mapData = null;
                txtMapID.Text = "";
            }
            else
            {
                UpdateMapDataText();
                LoadingScreenHelper.HideLoadingScreen(this);
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

            CustomMessageBox.Show(this, "The new random difficulty is " + cmbDifficulty.Items[cmbDifficulty.SelectedIndex], new Size(customMessageBoxWidthSize, 100));
        }

        private async void btnGetDifficulties_Click(object sender, EventArgs e)
        {
            mapData = await MapDataHelper.GetMapData(this, randomKeyFilter, txtMapID.Text, true);
            UpdateMapDataText();
        }

        private async void btnAnalyzeMap_Click(object sender, EventArgs e)
        {
            if (txtMapID.Text.Length == 0)
            {
                CustomMessageBox.Show(this, "You forgot the key!", new Size(customMessageBoxWidthSize, 100));
                return;
            }

            LoadingScreenHelper.SwitchToLoadingScreen(this, "Downloading map...");

            if (!testJsonMode)
            {
                if (Directory.Exists("analyzedMap"))
                    Directory.Delete("analyzedMap", true);

                Directory.CreateDirectory("analyzedMap");

                try
                {
                    await MapInstaller.InstallMap(mapData, "analyzedMap");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }

            MapAnalyzer.AnalyzeMap(this, cmbCharacteristics, cmbDifficulty, testJsonMode);
            LoadingScreenHelper.HideLoadingScreen(this);
        }

        private async void btnInstallMap_Click(object sender, EventArgs e)
        {
            if (!CanDownloadMap(txtMapID.Text, txtBeatsaverFolder.Text))
            {
                CustomMessageBox.Show(this, "You have already downloaded this map!", new Size(customMessageBoxWidthSize, 100));
                return;
            }
            else
            {
                LoadingScreenHelper.SwitchToLoadingScreen(this, "Installing map...");
            }
            await MapInstaller.InstallMap(mapData, txtBeatsaverFolder.Text);

            LoadingScreenHelper.HideLoadingScreen(this);
        }

        private void btnOpenCustomLevelsFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(txtBeatsaverFolder.Text);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(this, "The folder doesn't exist!", new Size(customMessageBoxWidthSize, 100));
            }
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

        private void UpdateMapDataText()
        {
            difficulties = mapData.GetDifficulties();
            lblDifficulties.Text = "";
            foreach (var difficulty in difficulties)
                this.lblDifficulties.Text += difficulty + " ";

            txtMapID.Text = mapData.Key;

            txtTitle.Text = mapData.Metadata.SongName + " - " + mapData.Metadata.SongSubName + "\n" + mapData.Metadata.LevelAuthorName;
        }

        public static Size MeasureText(string text, Font font)
        {
            return TextRenderer.MeasureText(text, font);
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
