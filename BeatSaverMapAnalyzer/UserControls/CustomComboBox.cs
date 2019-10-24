using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;

namespace RandomSongTournamentAssistant
{
    public partial class CustomComboBox : UserControl
    {
        public Color startColor = Color.White;

        public int borderSize = 2;

        public bool expanded = false;
        public bool shouldMoveTitle = true;

        public Size startSize;

        #region Properties

        public string SelectedItemText { get; private set; }

        public int SelectedIndex { get; private set; }

        [Category("ComboBox")]
        public Color BackgroundColor { get { return BackColor; } set { BackColor = value; } }

        [Category("ComboBox")]
        public int ItemHeight { get; set; }

        [Category("ComboBox")]
        public int MarginBottom { get; set; }

        [Category("ComboBox")]
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<string> Items { get; set; }

        #endregion

        public CustomComboBox()
        {
            InitializeComponent();
            Items = new List<string>();
            lblTitle.Text = "";


        }

        private void CustomComboBox_Load(object sender, EventArgs e)
        {
            startSize = Size;
            startColor = BackColor;
            pnlHoverController.Size = Size;

            UpdateBorders();


            if (Items.Count > 0)
                SetSelectedIndex(0);
        }

        private void UpdateBorders()
        {
            leftBorder.Location = new Point(0, 0);
            leftBorder.Size = new Size(borderSize, Size.Height);

            rightBorder.Location = new Point(Size.Width - borderSize, 0);
            rightBorder.Size = new Size(borderSize, Size.Height);

            topBorder.Location = new Point(0, 0);
            topBorder.Size = new Size(Size.Width, borderSize);

            bottomBorder.Location = new Point(0, Size.Height - borderSize);
            bottomBorder.Size = new Size(Size.Width, borderSize);
        }

        private void AnimateHeight(bool expand)
        {
            int extraHeight = (ItemHeight + MarginBottom) * Items.Count;

            if (expand)
            {
                while (Height < startSize.Height + extraHeight)
                {
                    Height++;
                    UpdateBorders();

                    Application.DoEvents();
                }
            }
            else
            {
                Size = startSize;
                UpdateBorders();
            }
        }

        private void CustomComboBox_Resize(object sender, EventArgs e)
        {
            if (shouldMoveTitle)
                lblTitle.Location = new Point(lblTitle.Location.X, Size.Height / 2 - lblTitle.Size.Height / 2);

        }

        private void pnlHoverController_MouseLeave(object sender, EventArgs e)
        {
            pnlHoverController.BackColor = startColor;
            lblTitle.BackColor = pnlHoverController.BackColor;
        }

        private void pnlHoverController_MouseEnter(object sender, EventArgs e)
        {
            pnlHoverController.BackColor = Color.FromArgb(255, 14, 205, 247);
            lblTitle.BackColor = pnlHoverController.BackColor;

        }

        private void pnlHoverController_MouseClick(object sender, MouseEventArgs e)
        {
            shouldMoveTitle = false;
            expanded = !expanded;
            AnimateHeight(expanded);

            if (expanded)
            {
                int row = 0;
                foreach (var itemName in Items)
                {
                    Label item = new Label();

                    item.Text = itemName;
                    item.Padding = new Padding(lblTitle.Location.X, item.Padding.Right, item.Padding.Top, item.Padding.Bottom);
                    item.Size = new Size(Size.Width, ItemHeight);
                    item.Location = new Point(0, startSize.Height + (ItemHeight + MarginBottom) * row);

                    item.MouseEnter += new EventHandler(ChangeToHoverColor);
                    item.MouseLeave += new EventHandler(ChangeToNormalColor);
                    item.Click += new EventHandler(OnItemClicked);

                    Controls.Add(item);
                    row++;
                }
            }
        }

        private void ChangeToHoverColor(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.FromArgb(255, 14, 205, 247);
        }

        private void ChangeToNormalColor(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void OnItemClicked(object sender, EventArgs e)
        {
            string itemName = ((Control)sender).Text;
            SetSelectedIndex(Items.IndexOf(itemName));
        }

        public void SetSelectedIndex(int index)
        {
            expanded = false;
            Size = startSize;
            lblTitle.Text = SelectedItemText = Items[index];
            this.SelectedIndex = index;

            UpdateBorders();
        }
    }
}
