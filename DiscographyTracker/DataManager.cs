using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace DiscographyTracker
{
    class DataManager
    {
        static SqlConnection conn;
        public static void CreateConnection(string MDF_FILE)
        {
            conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;" +
                @"AttachDbFileName="+MDF_FILE+";" +
                "Trusted_Connection=True;");
            conn.Open();
        }

        public static void DropConnection()
        {
            if (!(conn is null) && conn.State == ConnectionState.Open)
                conn.Close();
        }

        internal static TimeSpan GetAlbumLength(Dictionary<string, TimeSpan> album)
        {
            TimeSpan t = new TimeSpan();
            foreach (KeyValuePair<string, TimeSpan> e in album)
            {
                t += e.Value;
            }
            return t;
        }

        internal static List<string> GetArtists()
        {
            List<string> res = new List<string>();

            SqlCommand command = new SqlCommand("SELECT DISTINCT artist FROM Albums", conn);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                res.Add(reader["artist"].ToString());
            }
            reader.Close();

            return res;
        }

        internal static Dictionary<string, string> GetAlbums(string selectedArtist)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();

            SqlCommand command = new SqlCommand("SELECT DISTINCT title, id FROM Albums WHERE artist = @artist", conn);
            command.Parameters.Add("@artist", SqlDbType.NVarChar).Value = selectedArtist;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                res.Add(reader["id"].ToString(), reader["title"].ToString());
            }
            reader.Close();

            return res;
        }

        internal static Dictionary<string, TimeSpan> GetTracks(string albumId)
        {
            Dictionary<string, TimeSpan> res = new Dictionary<string, TimeSpan>();

            SqlCommand command = new SqlCommand("SELECT title, length FROM Tracks WHERE album = @album", conn);
            command.Parameters.Add("@album", SqlDbType.NVarChar).Value = albumId;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                res.Add(reader["title"].ToString(), TimeSpan.ParseExact(reader["length"].ToString(), @"mm\:ss\:\0\0", CultureInfo.CurrentCulture));
            }
            reader.Close();

            return res;
        }

        internal static string GetAlbumReleaseDate(string albumId)
        {
            SqlCommand cmd = new SqlCommand("SELECT release FROM Albums WHERE id = @album", conn);
            cmd.Parameters.Add("@album", SqlDbType.NVarChar).Value = albumId;
            SqlDataReader reader = cmd.ExecuteReader();

            string release = "n/a";
            if (reader.Read())
            {
                release = reader["release"].ToString();
            }
            reader.Close();

            return release;
        }

        internal static string GetTrackURL(string selectedArtist, string selectedAlbum, string selectedTrack)
        {
            SqlCommand cmd = new SqlCommand("SELECT t.url FROM Tracks t, Albums a WHERE a.title = @album AND a.artist = @artist AND t.title = @track AND a.id = t.album", conn);
            cmd.Parameters.Add("@artist", SqlDbType.NVarChar).Value = selectedArtist;
            cmd.Parameters.Add("@album", SqlDbType.NVarChar).Value = selectedAlbum;
            cmd.Parameters.Add("@track", SqlDbType.NVarChar).Value = selectedTrack;
            SqlDataReader reader = cmd.ExecuteReader();

            string url = "NOPE";
            if (reader.Read())
            {
                url = reader["url"].ToString();
            }
            reader.Close();

            return url;
        }

        internal static void AddAlbum(string csv)
        {
            string[] p = csv.Split(';');
            string queryString = "INSERT INTO Albums (id, artist, title, release) VALUES (@id, @artist, @title, @release)";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = p[0];
            cmd.Parameters.Add("@artist", SqlDbType.NVarChar).Value = p[1];
            cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = p[2];
            cmd.Parameters.Add("@release", SqlDbType.Date).Value = DateTime.Parse(p[3]);

            cmd.ExecuteNonQuery();
        }

        internal static void AddTrack(string csv)
        {
            string[] p = csv.Split(';');
            string queryString = "INSERT INTO Tracks (title, \"length\", album, url) VALUES (@title, @len, @album, @url)";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = p[0];
            cmd.Parameters.Add("@len", SqlDbType.Time).Value = TimeSpan.Parse(p[1]);
            cmd.Parameters.Add("@album", SqlDbType.NVarChar).Value = p[2];
            cmd.Parameters.Add("@url", SqlDbType.NVarChar).Value = p[3];

            cmd.ExecuteNonQuery();
        }

        internal static void AddURLToTrack(string selectedArtist, string selectedAlbum, string selectedTrack, string url)
        {
            string queryString = "UPDATE Tracks SET Tracks.url = @url FROM Tracks INNER JOIN Albums ON Albums.id = Tracks.album WHERE Albums.title = @album AND Tracks.title = @track AND Albums.artist = @artist";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.Add("@url", SqlDbType.NVarChar).Value = url;
            cmd.Parameters.Add("@artist", SqlDbType.NVarChar).Value = selectedArtist;
            cmd.Parameters.Add("@album", SqlDbType.NVarChar).Value = selectedAlbum;
            cmd.Parameters.Add("@track", SqlDbType.NVarChar).Value = selectedTrack;
            cmd.ExecuteNonQuery();
        }

        internal static Dictionary<string, object> GetTrackData(string selectedArtist, string selectedAlbum, string selectedTrack)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Tracks t, Albums a WHERE a.title = @album AND a.artist = @artist AND t.title = @track AND a.id = t.album", conn);
            cmd.Parameters.Add("@artist", SqlDbType.NVarChar).Value = selectedArtist;
            cmd.Parameters.Add("@album", SqlDbType.NVarChar).Value = selectedAlbum;
            cmd.Parameters.Add("@track", SqlDbType.NVarChar).Value = selectedTrack;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                res.Add("id", reader["id"]);
                res.Add("title", reader["title"]);
                res.Add("length", reader["length"]);
                res.Add("album", reader["album"]);
                res.Add("url", reader["url"]);
                res.Add("success", true);
            }
            else res.Add("success", false);
            reader.Close();


            return res;

        }

        internal static void UpdateTrackData(int id, string album, string length, string title, string url)
        {
            string queryString = "UPDATE Tracks SET album = @album, url = @url, title = @title, length = @length " +
                "WHERE id = @id";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
            cmd.Parameters.Add("@url", SqlDbType.NVarChar).Value = url;
            cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.Add("@album", SqlDbType.NVarChar).Value = album;
            cmd.Parameters.Add("@length", SqlDbType.NVarChar).Value = length;
            cmd.ExecuteNonQuery();
        }
    }
}
