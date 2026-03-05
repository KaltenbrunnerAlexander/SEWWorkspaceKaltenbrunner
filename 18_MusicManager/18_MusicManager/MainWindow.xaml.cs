using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _18_MusicManager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        List<MusicTitle> songList = new List<MusicTitle>();
        List<Playlist> playlistList = new List<Playlist>();

        MediaPlayer player = new MediaPlayer();

        string fileName = "musicdata.txt";

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitle.Text == "" || txtPath.Text == "")
                return;

            MusicTitle song = new MusicTitle();
            song.Title = txtTitle.Text;
            song.Artist = txtArtist.Text;
            song.Year = txtYear.Text;
            song.FilePath = txtPath.Text;

            songList.Add(song);
            listSongs.Items.Add(song);

            txtTitle.Text = "";
            txtArtist.Text = "";
            txtYear.Text = "";
            txtPath.Text = "";
        }

        private void DeleteSong_Click(object sender, RoutedEventArgs e)
        {
            if (listSongs.SelectedItem == null)
                return;

            MusicTitle song = (MusicTitle)listSongs.SelectedItem;

            songList.Remove(song);
            listSongs.Items.Remove(song);
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            if (txtListName.Text == "")
                return;

            Playlist pl = new Playlist();
            pl.ListName = txtListName.Text;

            playlistList.Add(pl);
            Playlists.Items.Add(pl);

            txtListName.Text = "";
        }

        private void DeleteList_Click(object sender, RoutedEventArgs e)
        {
            if (Playlists.SelectedItem == null)
                return;

            Playlist pl = (Playlist)Playlists.SelectedItem;

            playlistList.Remove(pl);
            Playlists.Items.Remove(pl);
            ListSongs.Items.Clear();
        }

        private void AddToList_Click(object sender, RoutedEventArgs e)
        {
            if (listSongs.SelectedItem == null ||
                Playlists.SelectedItem == null)
                return;

            MusicTitle song = (MusicTitle)listSongs.SelectedItem;
            Playlist pl = (Playlist)Playlists.SelectedItem;

            pl.SongItems.Add(song);
            ShowPlaylistSongs(pl);
        }

        private void RemoveFromList_Click(object sender, RoutedEventArgs e)
        {
            if (ListSongs.SelectedItem == null ||
                Playlists.SelectedItem == null)
                return;

            MusicTitle song = (MusicTitle)ListSongs.SelectedItem;
            Playlist pl = (Playlist)Playlists.SelectedItem;

            pl.SongItems.Remove(song);
            ShowPlaylistSongs(pl);
        }

        private void List_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (Playlists.SelectedItem == null)
                return;

            Playlist pl = (Playlist)Playlists.SelectedItem;
            ShowPlaylistSongs(pl);
        }

        private void ShowPlaylistSongs(Playlist pl)
        {
            ListSongs.Items.Clear();

            for (int i = 0; i < pl.SongItems.Count; i++)
            {
                ListSongs.Items.Add(pl.SongItems[i]);
            }
        }

        private void PlaySong_Click(object sender, RoutedEventArgs e)
        {
            if (ListSongs.SelectedItem == null)
                return;

            MusicTitle song = (MusicTitle)ListSongs.SelectedItem;

            if (!File.Exists(song.FilePath))
                return;

            player.Open(new Uri(song.FilePath));
            player.Play();
        }

        protected override void OnClosed(EventArgs e)
        {
            SaveData();
            base.OnClosed(e);
        }

        private void SaveData()
        {
            StreamWriter writer = new StreamWriter(fileName);

            for (int i = 0; i < songList.Count; i++)
            {
                MusicTitle s = songList[i];

                writer.WriteLine("SONG|" +
                                 s.Title + "|" +
                                 s.Artist + "|" +
                                 s.Year + "|" +
                                 s.FilePath);
            }

            for (int i = 0; i < playlistList.Count; i++)
            {
                Playlist pl = playlistList[i];

                writer.WriteLine("PLAYLIST|" + pl.ListName);

                for (int j = 0; j < pl.SongItems.Count; j++)
                {
                    writer.WriteLine("PLSONG|" +
                                     pl.ListName + "|" +
                                     pl.SongItems[j].Title);
                }
            }

            writer.Close();
        }

        private void LoadData()
        {
            if (!File.Exists(fileName))
                return;

            StreamReader reader = new StreamReader(fileName);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split('|');

                if (parts[0] == "SONG")
                {
                    MusicTitle s = new MusicTitle();
                    s.Title = parts[1];
                    s.Artist = parts[2];
                    s.Year = parts[3];
                    s.FilePath = parts[4];

                    songList.Add(s);
                    listSongs.Items.Add(s);
                }

                if (parts[0] == "PLAYLIST")
                {
                    Playlist pl = new Playlist();
                    pl.ListName = parts[1];

                    playlistList.Add(pl);
                    Playlists.Items.Add(pl);
                }

                if (parts[0] == "PLSONG")
                {
                    Playlist pl = playlistList.Find(p =>
                        p.ListName == parts[1]);

                    MusicTitle s = songList.Find(m =>
                        m.Title == parts[2]);

                    if (pl != null && s != null)
                        pl.SongItems.Add(s);
                }
            }

            reader.Close();
        }
    }
}