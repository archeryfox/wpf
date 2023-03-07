using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Ribbon;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Text.RegularExpressions;

namespace MusicalPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        bool First = true;
        public MainWindow()
        {
            InitializeComponent();
            BeuSlider.Minimum = 0;
            //GetD = UpdateTime;
        }
        bool Repeat = false;
        async void UpdateTime()
        {
            while (true)
            {
                ThisDuration.Content = ME.Position.TotalMinutes.ToString() + ":";
                BeuSlider.Value = (ME.Position.Ticks);
                var min = (int)TimeSpan.FromSeconds(ME.Position.TotalSeconds).TotalMinutes;
                var sec = (int)TimeSpan.FromSeconds(ME.Position.TotalSeconds).TotalSeconds - (min * 60);
                var m = min.ToString();
                var s = sec.ToString();
                if (sec < 10)
                {
                    s = $"0{sec}";
                }
                ThisDuration.Content = (m) + ":" + s;
                await Task.Delay(100);
            }
        }



        public void PlaylistUpdate(List<string> fls)
        {
            try
            {
                if (!IsShuffled)
                {
                    fls = Directory.GetFiles(path, @"*.mp3").ToList();
                    fls = fls.Concat(Directory.GetFiles(path, @"*.m4a")).ToList();
                    fls = fls.Concat(Directory.GetFiles(path, @"*.wav")).ToList();
                }
                if (fls.Count == 0)
                {
                    MusicList.ItemsSource = null;
                    SongName.Content = "Нет доступных треков";
                    Dirc.Content = path.Split('\\')[^1];
                }
                for (int i = 0; i < fls.Count; i++)
                {
                    fls[i] = fls[i].Split('\\')[^1];
                }
                Dirc.Content = path.Split('\\')[^1];
                SongName.Content = fls[0].Split('\\')[^1];
                MusicList.ItemsSource = fls.ToArray();

            }
            catch
            {
                SongName.Content = "Нет доступных треков";
                MusicList.ItemsSource = null;
            }
            finally
            {
                Dirc.Content = path.Split('\\')[^1];
            }

        }
        private void SettinsB_Click(object sender, RoutedEventArgs e)
        {
            var fp = new CommonOpenFileDialog { IsFolderPicker = true };
            var r = fp.ShowDialog();
            if (r == CommonFileDialogResult.Ok)
            {
                var es = fp.FileName.Split('\\').ToList();
                var ews = "";
                foreach (var item in es)
                {
                    if (item != es.Last())
                    {
                        ews += $"{item}\\";
                    }
                    else ews += item;
                }
                MessageBox.Show(ews);
                MainWindow.path = ews;
                List<string> l = Directory.GetFiles(ews).ToList();
                PlaylistUpdate(l);
            }
        }

        private void MusicList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MusicList.SelectedItem != null)
            {
                SongName.Content = MusicList.SelectedItem.ToString();
                var fils = Directory.GetFiles(path, @"*.mp3").ToList();
                fils = fils.Concat(Directory.GetFiles(path, @"*.m4a")).ToList();
                fils = fils.Concat(Directory.GetFiles(path, @"*.wav")).ToList();
                var s = "";
                for (int i = 0; i < fils.Count; i++)
                {
                    s += fils[i] + "\n";
                }
                if (MusicList.SelectedIndex != -1)
                {
                    //MessageBox.Show(MusicList.SelectedItem.ToString());
                    var uri = new Uri(fils[fils.FindIndex(0, MusicList.Items.Count, x => x.Contains(MusicList.SelectedItem.ToString()))]);
                    ME.Source = uri;
                    playStatus = false;
                    Plays_Click(sender, e);
                    UpdateTime();
                }
            }
        }



        private void MusicList_Initialized(object sender, EventArgs e)
        {
            if (First)
            {
                List<string> l;
                l = Directory.GetFiles(path, @"*.mp3").ToList();
                l = l.Concat(Directory.GetFiles(path, @"*.m4a")).ToList();
                l = l.Concat(Directory.GetFiles(path, @"*.wav")).ToList();
                PlaylistUpdate(l);
                First = false;
            }
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                ME.Position = new TimeSpan(Convert.ToInt64((sender as Slider).Value));
                var min = (int)TimeSpan.FromSeconds(ME.NaturalDuration.TimeSpan.TotalSeconds).TotalMinutes;
                var sec = (int)TimeSpan.FromSeconds(ME.NaturalDuration.TimeSpan.TotalSeconds).TotalSeconds - (min * 60);
                AllDuration.Content = (min) + ":" + sec;
                BeuSlider.Maximum = ME.NaturalDuration.TimeSpan.Ticks;
            }
            catch (Exception)
            {

            }
        }

        private void ME_MediaOpened(object sender, RoutedEventArgs e)
        {
            BeuSlider.Maximum = ME.NaturalDuration.TimeSpan.Ticks;
        }

        static bool playStatus = false;


        private void Plays_Click(object sender, RoutedEventArgs e)
        {
            playStatus = !playStatus;
            if (playStatus)
            {
                ME.Play();
                Plays.Content = "I I";
            }
            else
            {
                ME.Pause();
                Plays.Content = "▶";
            }

        }

        private void StopB_Click(object sender, RoutedEventArgs e)
        {
            AllDuration.Content = "0:00";
            playStatus = false;
            ME.Stop();
            Plays.Content = "▶";
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ME.Volume = (Volume.Value / 10);
        }
        bool IsShuffled = false;
        private void Shuflle_Click(object sender, RoutedEventArgs e)
        {
            List<string> l;
            l = Directory.GetFiles(path, @"*.mp3").ToList();
            l = l.Concat(Directory.GetFiles(path, @"*.m4a")).ToList();
            l = l.Concat(Directory.GetFiles(path, @"*.wav")).ToList();
            IsShuffled = !IsShuffled;
            if (IsShuffled)
            {
                var rand = new Random();
                for (int i = l.Count - 1; i >= 1; i--)
                {
                    int j = rand.Next(i + 1);
                    var temp = l[j];
                    l[j] = l[i];
                    l[i] = temp;
                }
                Shuflle.Content = "➡";
                PlaylistUpdate(l);

            }
            else if (!IsShuffled)
            {
                Shuflle.Content = "🔀";
                PlaylistUpdate(l);
            }
        }

        private void ME_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (Repeat)
            {
                ME.Stop();
                ME.Play();
                BeuSlider.Value = 0;
            }
            else if (!Repeat)
            {
                MusicList.SelectedIndex++;
            }
        }

        private void Nexts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    MusicList.SelectedIndex++;
                    ME.Stop();
                    ME.Play();
            }
            catch (Exception)
            {

            }
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MusicList.SelectedIndex != 0)
                {
                    MusicList.SelectedIndex--;
                }
            }
            catch (Exception)
            {

            }
            ME.Stop();
            ME.Play();
        }

        private void ReperatButt_Click(object sender, RoutedEventArgs e)
        {
            Repeat= !Repeat;
            if (Repeat)
            {
                ReperatButt.Content = "❌";
            } else if (!Repeat) { ReperatButt.Content = "🔁"; }
        }
    }
}
