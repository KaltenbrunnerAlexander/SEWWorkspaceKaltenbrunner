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
        List<Playlist> playList = new List<Playlist>();

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

            playList.Add(newList);
            Playlists.Items.Add(newList);

            txtListName.Text = "";
        }

        private void DeleteList_Click(object sender, RoutedEventArgs e)
        {
            if (Playlists.SelectedItem != null)
            {
                Playlist selectedList = (Playlist)Playlists.SelectedItem;
                playList.Remove(selectedList);
                Playlists.Items.Remove(selectedList);
                ListSongs.Items.Clear();
            }
        }

        private void List_Selected(object sender, RoutedEventArgs e)
        {
            ListSongs.Items.Clear();

            if (Playlists.SelectedItem != null)
            {
                Playlist activeList = (Playlist)Playlists.SelectedItem;

                for (int i = 0; i < activeList.SongItems.Count; i++)
                {
                    ListSongs.Items.Add(activeList.SongItems[i]);
                }
            }
        }

        private void AddToList_Click(object sender, RoutedEventArgs e)
        {
            if (Playlists.SelectedItem != null && listSongs.SelectedItem != null)
            {
                Playlist activeList = (Playlist)Playlists.SelectedItem;
                MusicTitle selectedSong = (MusicTitle)listSongs.SelectedItem;

                activeList.SongItems.Add(selectedSong);
                ListSongs.Items.Add(selectedSong);
            }
        }
            
        private void RemoveFromList_Click(object sender, RoutedEventArgs e)
        {
            if (Playlists.SelectedItem != null && ListSongs.SelectedItem != null)
            {
                Playlist activeList = (Playlist)Playlists.SelectedItem;
                MusicTitle selectedSong = (MusicTitle)ListSongs.SelectedItem;

                activeList.SongItems.Remove(selectedSong);
                ListSongs.Items.Remove(selectedSong);
            }
        }

        private void PlaySong_Click(object sender, RoutedEventArgs e)
        {
            if (ListSongs.SelectedItem != null)
            {
                MusicTitle selectedSong = (MusicTitle)ListSongs.SelectedItem;

                if (selectedSong.FilePath != "")
                {
                    player.Open(new System.Uri(selectedSong.FilePath));
                    player.Play();
                }
            }
        }
    }
}
