using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscographyTracker
{
    public partial class Form1 : Form
    {
        const string MDF_FILE = @"Res\music.mdf";
        bool readingAlbums = false;
        string selectedArtist = "",
            selectedAlbum = "",
            selectedAlbumID = "",
            selectedTrack = "";

        Dictionary<string, string> albums;
        Dictionary<string, TimeSpan> tracks;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string mdf_path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, MDF_FILE);
            DataManager.CreateConnection(mdf_path);

            ResetAllComponents();
            LoadArtists();
            UpdateControls();
        }

        private void UpdateControls()
        {
            albumCB.Enabled = artistCB.SelectedIndex > -1;
            if(searchTB.Text.Length == 0)
                searchTB.Enabled = dgv.Rows.Count > 0;
            addUrlBTN.Enabled = dgv.SelectedCells.Count != 0;
            editSelectedBTN.Enabled = dgv.SelectedCells.Count != 0;
        }

        private void ResetAllComponents()
        {
            dgv.Rows.Clear();
            albumCB.Items.Clear();
            artistCB.Items.Clear();
            pbox.InitialImage = null;
            searchTB.Text = "";
            urlLabel.Text = "NOPE";
        }

        private void LoadArtists()
        {
            List<string> artists = DataManager.GetArtists();
            artists.ForEach(art =>
            {
                artistCB.Items.Add(art);
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataManager.DropConnection();
        }

        private void AddDiscography(object sender, EventArgs e)
        {
            string file = SelectNewDiscography();
            if (file.Length == 0) return;

            OpenDiscographyFile(file);
            artistCB.Items.Clear();
            LoadArtists();
        }

        private void UnselectArtist()
        {
            albumCB.Items.Clear();
            dgv.Rows.Clear();
            albumCB.Enabled = false;
        }

        private void OpenDiscographyFile(string file)
        {
            StreamReader sr = new StreamReader(file, true);
            while (!sr.EndOfStream) ReadDiscographyFileRow(sr.ReadLine());
            sr.Close();
        }

        private void ReadDiscographyFileRow(string v)
        {
            if(v.Contains(";"))
            {
                if (readingAlbums) DataManager.AddAlbum(v);
                else DataManager.AddTrack(v);
            } else
            {
                readingAlbums = v == "[albums]";
            }
        }

        private string SelectNewDiscography()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text file (.txt)|*.txt";
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ofd.ShowDialog();
            return ofd.FileName;
        }

        private void GetAlbums()
        {
            albums = DataManager.GetAlbums(selectedArtist);

            albums.Keys.ToList().ForEach(album =>
            {
                albumCB.Items.Add(albums[album]); 
            });
        }

        private void artistCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (artistCB.SelectedIndex == -1)
            {
                UnselectArtist();
                return;
            }
            selectedArtist = artistCB.SelectedItem.ToString();
            UpdateControls();
            GetAlbums();
        }

        private void albumCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            if (albumCB.SelectedIndex == -1) return;
            selectedAlbum = albumCB.SelectedItem.ToString();

            selectedAlbumID = GetAlbumIdByName(selectedAlbum);
            
            LoadAlbumCover(selectedAlbumID);
            tracks = LoadTracks();

            UpdateControls();

            TimeSpan albumLength = DataManager.GetAlbumLength(tracks);
            LoadAlbumData(selectedAlbumID, albumLength);

            if(tracks.Count > 0)
            {
                selectedTrack = tracks.Keys.First();
                dgv_CellContentClick(null, null);
            }
        }

        private void LoadAlbumData(string albumId, TimeSpan albumLength)
        {
            string releaseDate = DataManager.GetAlbumReleaseDate(albumId);
            if(releaseDate != "n/a")
            {
                DateTime dt = DateTime.Parse(releaseDate);
                releaseDate = dt.ToString("yyyy. MMMM dd.");
            }
            rtbInfo.SelectAll();
            rtbInfo.SelectionAlignment = HorizontalAlignment.Center;
            rtbInfo.Font = new Font("Arial", 14);
            rtbInfo.ForeColor = Color.DarkBlue;

            rtbInfo.Clear();
            rtbInfo.AppendText("Release date:\n");
            rtbInfo.AppendText(releaseDate+"\n\n");
            rtbInfo.AppendText("Length of Album:\n");
            rtbInfo.AppendText(albumLength.ToString());
        }

        private void LoadAlbumCover(string albumId)
        {
            string filename = albumId + ".jpg";
            string file = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "..", "..", "Res", selectedArtist, filename);
            if(File.Exists(file))
                pbox.Image = Image.FromFile(file);
        }

        private Dictionary<string, TimeSpan> LoadTracks(bool reload = true)
        {
            if(reload) tracks = DataManager.GetTracks(selectedAlbumID);

            dgv.Rows.Clear();
            urlLabel.Text = "NOPE";
            tracks.Keys.ToList().ForEach(track =>
            {
                if(searchTB.Text.Length == 0 || track.ToLower().Contains(searchTB.Text.ToLower()))
                    dgv.Rows.Add(track, tracks[track].ToString());
            });
            return tracks;
        }

        private void urlLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (urlLabel.Text.StartsWith("http"))
                Process.Start(urlLabel.Text);
        }

        private void addUrlBTN_Click(object sender, EventArgs e)
        {
            AddURLForm inputForm = new AddURLForm();
            DialogResult dlg = inputForm.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                ParseAddURL(inputForm);
            }
            inputForm.Dispose();
        }
        
        private void ParseAddURL(AddURLForm inputForm)
        {
            string link = inputForm.textBox1.Text;
            Regex rx = new Regex(@"(?:youtu\.be\/|v=)([^&]+)");
            Match m = rx.Match(link);
            if (m.Success)
            {
                DataManager.AddURLToTrack(selectedArtist, selectedAlbum, selectedTrack, m.Groups[1].Value);
                dgv_CellContentClick(null, null);
            }
            else
            {
                MessageBox.Show("Invalid youtube link provided");
            }
        }

        private void editSelectedBTN_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = DataManager.GetTrackData(selectedArtist, selectedAlbum, selectedTrack);
            if(!(bool)data["success"])
            {
                MessageBox.Show("Couldn't load track data");
                return;
            }
            EditTrackForm etf = new EditTrackForm(data);
            etf.ShowDialog();
            if(etf.doSave)
            {
                DataManager.UpdateTrackData(int.Parse(etf.trackID.Text), etf.trackAlbum.Text, etf.trackLength.Text, etf.trackTitle.Text, etf.trackURL.Text);
                albumCB_SelectedIndexChanged(null, null);
            }
            etf.Dispose();
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            LoadTracks(false);
            UpdateControls();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedTrack = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string url = DataManager.GetTrackURL(selectedArtist, selectedAlbum, selectedTrack);
            urlLabel.Text = url == "NOPE" || url == "null" ? "NOPE" : "https://youtu.be/"+url;
        }

        private string GetAlbumIdByName(string name)
        {
            return albums.Keys.ToList().Find(x => albums[x] == name);
        }
    }
}
