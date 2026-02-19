using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            MusicTitle newSong = new MusicTitle();
            newSong.Title = txtTitle.Text;
            newSong.Artist = txtArtist.Text;
            newSong.Year = txtYear.Text;
            newSong.FilePath = txtPath.Text;

            songList.Add(newSong);
            listSongs.Items.Add(newSong);

            txtTitle.Text = "";
            txtArtist.Text = "";
            txtYear.Text = "";
            txtPath.Text = "";
        }

        private void DeleteSong_Click(object sender, RoutedEventArgs e)
        {
            if (listSongs.SelectedItem != null)
            {
                MusicTitle selectedSong = (MusicTitle)listSongs.SelectedItem;
                songList.Remove(selectedSong);
                listSongs.Items.Remove(selectedSong);
            }
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            Playlist newList = new Playlist();
            newList.ListName = txtListName.Text;

            playlistList.Add(newList);
            listPlaylists.Items.Add(newList);

            txtListName.Text = "";
        }

        private void DeleteList_Click(object sender, RoutedEventArgs e)
        {
            if (listPlaylists.SelectedItem != null)
            {
                Playlist selectedList = (Playlist)listPlaylists.SelectedItem;
                playlistList.Remove(selectedList);
                listPlaylists.Items.Remove(selectedList);
                listListSongs.Items.Clear();
            }
        }

        private void List_Selected(object sender,
            System.Windows.Controls.SelectionChangedEventArgs e)
        {
            listListSongs.Items.Clear();

            if (listPlaylists.SelectedItem != null)
            {
                Playlist activeList = (Playlist)listPlaylists.SelectedItem;

                for (int i = 0; i < activeList.SongItems.Count; i++)
                {
                    listListSongs.Items.Add(activeList.SongItems[i]);
                }
            }
        }

        private void AddToList_Click(object sender, RoutedEventArgs e)
        {
            if (listPlaylists.SelectedItem != null &&
                listSongs.SelectedItem != null)
            {
                Playlist activeList = (Playlist)listPlaylists.SelectedItem;
                MusicTitle selectedSong = (MusicTitle)listSongs.SelectedItem;

                activeList.SongItems.Add(selectedSong);
                listListSongs.Items.Add(selectedSong);
            }
        }

        private void RemoveFromList_Click(object sender, RoutedEventArgs e)
        {
            if (listPlaylists.SelectedItem != null &&
                listListSongs.SelectedItem != null)
            {
                Playlist activeList = (Playlist)listPlaylists.SelectedItem;
                MusicTitle selectedSong = (MusicTitle)listListSongs.SelectedItem;

                activeList.SongItems.Remove(selectedSong);
                listListSongs.Items.Remove(selectedSong);
            }
        }

        private void PlaySong_Click(object sender, RoutedEventArgs e)
        {
            if (listListSongs.SelectedItem != null)
            {
                MusicTitle selectedSong =
                    (MusicTitle)listListSongs.SelectedItem;

                if (selectedSong.FilePath != "")
                {
                    player.Open(new System.Uri(selectedSong.FilePath));
                    player.Play();
                }
            }
        }
    }
}
