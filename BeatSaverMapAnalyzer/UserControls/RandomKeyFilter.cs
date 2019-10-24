using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomSongTournamentAssistant
{
    public partial class RandomKeyFilter : UserControl, PageControl
    {
        private int? NPS = null;
        private double? rating = null;

        public bool UsingFilters => NPS != null || rating != null;

        public RandomKeyFilter()
        {
            InitializeComponent();

        }

        private void RandomKeyFilter_Load(object sender, EventArgs e)
        {
            cmbNPSFilter.SetSelectedIndex(cmbNPSFilter.Items.Count - 1);
            cmbRatingFilter.SetSelectedIndex(cmbRatingFilter.Items.Count - 1);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbNPSFilter.SelectedItemText != "None")
                NPS = Convert.ToInt32(cmbNPSFilter.SelectedItemText.Replace(">=", "").Replace("NPS", "").Replace(" ", ""));
            else
                NPS = null;

            if (cmbRatingFilter.SelectedItemText != "None")
                rating = Convert.ToDouble(cmbRatingFilter.SelectedItemText.Replace(">=", "").Replace(" ", "").Replace("%", "")) * 0.01;
            else
                rating = null;

            Visible = false;

            cmbNPSFilter.SetSelectedIndex(cmbNPSFilter.SelectedIndex);
        }

        public bool MatchingFilters(Difficulty difficulty, MapData mapData)
        {
            bool npsCondition = NPS.HasValue ? MapTools.GetNotesPerSecond(mapData.metadata.bpm, difficulty.duration, difficulty.notes) >= NPS.Value : true;
            bool ratingCondition = rating.HasValue ? mapData.stats.rating >= rating.Value * 100 : true;

            return UsingFilters ? npsCondition && ratingCondition : true;
        }
    }
}
