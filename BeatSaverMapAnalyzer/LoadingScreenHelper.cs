using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RandomSongTournamentAssistant
{
    public static class LoadingScreenHelper
    {
        public static void SwitchToLoadingScreen(Form form, string loadingScreenText)
        {
            foreach (var control in form.Controls)
            {
                ((Control)control).Visible = false;
            }
            form.BackgroundImage = Properties.Resources.saber_o_sponsor;

            var loadingText = new Label();
            loadingText.Name = "LoadingScreenText";
            loadingText.Text = loadingScreenText;
            loadingText.ForeColor = Color.White;
            loadingText.BackColor = Color.Black;

            loadingText.AutoSize = false;

            loadingText.Font = new Font(loadingText.Font.FontFamily, 20);
            loadingText.Size = Form1.MeasureText(loadingText.Text, loadingText.Font);

            loadingText.Location = new Point(form.Size.Width / 2 - loadingText.Size.Width / 2, form.Size.Height / 2 - loadingText.Size.Height / 2);

            form.Controls.Add(loadingText);
            loadingText.BringToFront();
        }

        public static void HideLoadingScreen(Form form)
        {
            foreach (var control in form.Controls)
            {
                if (!(control is PageControl))
                    ((Control)control).Visible = true;
            }

            form.Controls.Remove(form.Controls["LoadingScreenText"]);

            form.BackgroundImage = null;
        }
    }
}
