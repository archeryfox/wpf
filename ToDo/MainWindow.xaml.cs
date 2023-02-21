using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ToDo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (Directory.Exists(way))
            {
                file = File.ReadAllText(way + Task.FileName);
            }
            InitializeComponent();
        }

        List<Task> todayList = new List<Task>();
        static string way = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Tasks\\";
        string file;
        List<Task> TList = new List<Task>();

        private void Calendr_Initialized(object sender, EventArgs e)
        {
            (sender as DatePicker).Text = DateTime.Now.ToString();
        }

        private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var a = TList.OfType<Task>().Where(x => x.dt.Day == Convert.ToDateTime(Calendr.Text).Day && x.dt.Month == Convert.ToDateTime(Calendr.Text).Month).ToList();
            var Counts = ToDoList.Items.Count;
            if (a.Any(t => t.Name == TaskName.Text && t.Description == TaskDescription.Text))
            {
                MessageBox.Show("Вы не можете создать новую точно такую же запись, надо её тогда дублировать!");
                TaskName.Text = string.Empty;
                TaskDescription.Text = string.Empty;
            }
            else if (TaskName.Text == "" && TaskDescription.Text.Split(' ').All<string>(x => x == ""))
            {
                MessageBox.Show("Вы не можете создать Пустую заметку, её надо заполнить!");
                TaskName.Text = string.Empty;
                TaskDescription.Text = string.Empty;
            }
            else
            {
                TList.Add(new Task(TaskName.Text, TaskDescription.Text, Counts, Convert.ToDateTime(Calendr.Text)));
                a = TList.OfType<Task>().Where(x => x.dt.Day == Convert.ToDateTime(Calendr.Text).Day && x.dt.Month == Convert.ToDateTime(Calendr.Text).Month).ToList();
                ToDoList.ItemsSource = null;
                ToDoList.ItemsSource = from p in a
                                       orderby p.ID
                                       select p;
                ToDoList.ItemsSource = ToDoList.ItemsSource.OfType<Task>().Select(x => x.Name).ToList();
            }
        }
        private void DuplicateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var Counts = ToDoList.Items.Count;
            TList.Add(new Task(TaskName.Text, TaskDescription.Text, Counts, Convert.ToDateTime(Calendr.Text)));
            var a = TList.OfType<Task>().Where(x => x.dt.Day == Convert.ToDateTime(Calendr.Text).Day && x.dt.Month == Convert.ToDateTime(Calendr.Text).Month).ToList();
            ToDoList.ItemsSource = null;
            ToDoList.ItemsSource = from p in a
                                   orderby p.ID
                                   select p;
            ToDoList.ItemsSource = ToDoList.ItemsSource.OfType<Task>().Select(x => x.Name).ToList();
        }
        private void SaveTasksButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            string js = JsonConvert.SerializeObject(TList);
            //MessageBox.Show(js);
            if (!Directory.Exists(way) && !Task.FolderCreated)
            {
                if (MessageBox.Show("Задать папку для заметок?", "Mmm?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    saveFileDialog.Filter = "JSON file (*.json)|*.json";
                    saveFileDialog.FileName = "Tasks.json";
                    saveFileDialog.ShowDialog();
                    Directory.CreateDirectory(way);
                    Task.FolderPath = way;
                    Task.FolderDefault();
                    Task.FileName = saveFileDialog.SafeFileName;
                    File.WriteAllText(Task.FolderPath + saveFileDialog.SafeFileName, js.Normalize());
                    MessageBox.Show(Task.FolderPath + saveFileDialog.SafeFileName);
                    return;
                }
            }
            if (Directory.Exists(way) || Task.FolderCreated)
            {
                Task.FolderDefault();
                Task.FolderPath = way;
                var d = "";
                foreach (var item in TList)
                {
                    d += item.Name + ":" + item.DateTimeDay + "\n";
                }
                //MessageBox.Show(d);
                File.WriteAllText(Task.FolderPath + Task.FileName, JsonConvert.SerializeObject(TList));
            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (ToDoList.SelectedItem != null && ToDoList.SelectedIndex != -1)
            {
                try
                {
                    var lbxitm = ToDoList.SelectedItem.ToString();
                    var lbxid = ToDoList.SelectedIndex;
                    var today = ToDoList.Items[lbxid].ToString();
                    //MessageBox.Show(today);
                    //MessageBox.Show(TList[TList.FindIndex(x => x.Name == lbxitm)].Description.ToString());
                    TList.RemoveAt(TList.FindIndex(x => x.ID == lbxid));
                    var a = TList.OfType<Task>().Where(x => x.dt.Day == Convert.ToDateTime(Calendr.Text).Day).ToList();
                    for (int i = 0; i < a.Count; i++) { a[i].ID = i; }
                    ToDoList.ItemsSource = from p in a
                                           orderby p.ID
                                           select p;
                    var d = a.OfType<Task>().Select(x => x.Name).ToList();
                    ToDoList.ItemsSource = null;
                    ToDoList.ItemsSource = d;
                    
                    File.WriteAllText(file, JsonConvert.SerializeObject(TList));
                }
                catch (Exception) { }
            }
        }

        private void Calendr_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Sync();
        }

        private void Calendr_Loaded(object sender, RoutedEventArgs e)
        {
            /*ighcghc*/
        }

        void Sync()
        {
            //дописать везде существует ли файл!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            пукпыкуппк
            TList = JsonConvert.DeserializeObject<List<Task>>(file).ToList(); // Чтение файла
            var list = TList.Where(x => x.dt.Day == Convert.ToDateTime(Calendr.Text).Day).ToList(); // Выбрал только в этот день
            ToDoList.ItemsSource = null;
            if (list.Count != 0)
            {
                ToDoList.ItemsSource = list.OfType<Task>().Select(x => x.Name); // Вывод в список имён
            }
        }

        private void ToDoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ToDoList.SelectedItem != null && ToDoList.SelectedIndex != -1)
            {
                try
                {
                    var lbxitm = ToDoList.SelectedItem.ToString();
                    var lbxid = ToDoList.SelectedIndex;
                    var today = ToDoList.Items[lbxid].ToString();
                    //MessageBox.Show(today);
                    //MessageBox.Show(TList[TList.FindIndex(x => x.Name == lbxitm)].Description.ToString());
                    TaskName.Text = null;
                    TaskName.Text = lbxitm;
                    TaskDescription.Text = null;
                    TaskDescription.Text = TList[TList.FindIndex(x => x.ID == lbxid)].Description.ToString();
                }
                catch (Exception) { }
            }
        }

        private void EditTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (ToDoList.SelectedItem != null && ToDoList.SelectedIndex != -1)
            {
                try
                {
                    var lbxitm = ToDoList.SelectedItem.ToString();
                    var lbxid = ToDoList.SelectedIndex;
                    var today = ToDoList.Items[lbxid].ToString();
                    TList[TList.FindIndex(x => x.ID == lbxid)].NameMod(TaskName.Text);
                    TList[TList.FindIndex(x => x.ID == lbxid)].DescriptMod(TaskDescription.Text);
                    var a = TList.OfType<Task>().Where(x => x.dt.Day == Convert.ToDateTime(Calendr.Text).Day).ToList();
                    ToDoList.ItemsSource = from p in a
                                           orderby p.ID
                                           select p;
                    var d = a.OfType<Task>().Select(x => x.Name).ToList();
                    ToDoList.ItemsSource = null;
                    ToDoList.ItemsSource = d;
                    File.WriteAllText(file, JsonConvert.SerializeObject(TList));
                }
                catch (Exception) { }
            }
        }
    }
}