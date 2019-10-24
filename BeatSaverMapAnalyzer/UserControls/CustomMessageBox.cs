using System;
using System.Linq;
using System.Linq.Expressions;
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
    public partial class CustomMessageBox : UserControl, PageControl
    {

        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public static void Show(Form form, string message, Size size)
        {
            int textMarginTop = 10;

            var messageBox = new CustomMessageBox();
            var backgroundCover = new Panel();

            messageBox.lblText.Text = message;

            messageBox.Size = size;
            messageBox.lblText.Size = new Size(size.Width - 20, size.Height - textMarginTop);
            messageBox.Location = new Point(form.Size.Width / 2 - messageBox.Size.Width / 2, form.Size.Height / 2 - messageBox.Size.Height / 2);
            messageBox.lblText.Location = new Point(10, textMarginTop);

            int btnMargin = 10;
            messageBox.btnOK.Size = new Size(messageBox.Size.Width - btnMargin * 2, messageBox.btnOK.Size.Height);
            messageBox.btnOK.Location = new Point(btnMargin, messageBox.Size.Height - messageBox.btnOK.Size.Height - btnMargin);

            backgroundCover.Size = form.Size;
            backgroundCover.BackColor = Color.FromArgb(100, 0, 0, 0);

            //form.Controls.Add(backgroundCover);
            form.Controls.Add(messageBox);

            backgroundCover.BringToFront();
            messageBox.BringToFront();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Form currentForm = FindForm();
            currentForm.Controls.Remove(this);
        }
    }
}
