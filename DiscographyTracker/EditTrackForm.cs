using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscographyTracker
{
    public partial class EditTrackForm : Form
    {
        public bool doSave = false;

        public EditTrackForm(Dictionary<string, object> data)
        {
            InitializeComponent();
            trackAlbum.Text = data["album"].ToString();
            trackTitle.Text = data["title"].ToString();
            trackID.Text = data["id"].ToString();
            trackLength.Text = TimeSpan.ParseExact(data["length"].ToString(), @"mm\:ss\:\0\0", CultureInfo.InvariantCulture).ToString();
            trackURL.Text = data["url"].ToString();
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to save the changes?", "Save and close", MessageBoxButtons.YesNo);
            if (trackLength.Text.StartsWith("00:")) trackLength.Text = trackLength.Text.Substring(3) + ":00";
            doSave = dr == DialogResult.Yes;
            this.Close();
        }
    }
}
