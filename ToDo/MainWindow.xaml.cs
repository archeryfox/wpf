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
using Newtonsoft.Json;
using Microsoft.Win32;
using System.IO;
using System.Threading;

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
        List<Task> TaskList = new List<Task>();

        private void Calendr_Initialized(object sender, EventArgs e)
        {
            (sender as DatePicker).DisplayDate = DateTime.Now;
            (sender as DatePicker).Text = DateTime.Now.ToString();
            
        }

        private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var file = File.ReadAllText(way + Task.FileName);
            MessageBox.Show(file.Normalize());
            TaskList.Add(new Task(TaskName.Text, TaskDescription.Text, Convert.ToDateTime(Calendr.Text)));
            if (Task.FolderCreated || Directory.Exists(way))
            {
                var a = TaskList.OfType<Task>().Where(x => x.dt.Day == Convert.ToDateTime(Calendr.Text).Day && x.dt.Month == Convert.ToDateTime(Calendr.Text).Month).ToList();
                ToDoList.ItemsSource = null;
                ToDoList.ItemsSource = a.OfType<Task>().Select(x => x.Name).ToList();
                //var js = JsonConvert.SerializeObject(TaskList);
            }
        }

        private void SaveTasksButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            string js = JsonConvert.SerializeObject(TaskList);
            MessageBox.Show(js);
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
                foreach (var item in TaskList)
                {
                    d += item.Name + ":" + item.DateTimeDay + "\n";
                }
                MessageBox.Show(d);
                File.WriteAllText(Task.FolderPath + Task.FileName, JsonConvert.SerializeObject(TaskList));
            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (Task.FolderCreated || Directory.Exists(way))
            {

                todayList = JsonConvert.DeserializeObject<List<Task>>(file).Where(x => x.dt == Convert.ToDateTime(Calendr.Text)).ToList();
                ToDoList.ItemsSource = todayList;
                ToDoList.ItemsSource = ToDoList.Items.OfType<Task>().Select(x => x.Name).ToList();
            }
            MessageBox.Show(ToDoList.SelectedIndex.ToString());
            if (ToDoList.SelectedItem != null)
            {
                TaskList.RemoveAt(ToDoList.SelectedIndex);
                ToDoList.ItemsSource = TaskList;
                ToDoList.ItemsSource = ToDoList.Items.OfType<Task>().Select(x => x.Name).ToList();
            }
        }

        private void Calendr_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Task.FolderCreated || Directory.Exists(way))
            {
                todayList.Clear();
                //todayList = JsonConvert.DeserializeObject<List<Task>>(file);
            }

        }

        private void Calendr_Loaded(object sender, RoutedEventArgs e)
        {
            //Sync();
            TaskList = JsonConvert.DeserializeObject<List<Task>>(file); // Чтение файла
            var list = TaskList.Where(x => x.dt.Day == (Convert.ToDateTime(Calendr.Text).Day)).ToList(); // Выбрал только в этот день
            ToDoList.ItemsSource = null;
            ToDoList.ItemsSource = list.OfType<Task>().Select(x => x.Name).ToList(); // Вывод в список имён
/*            if (list.Count == 0)
            {
                MessageBox.Show(list[0].DateTimeYear);
                //System.Environment.Exit(0);
            }*/
        }

        void Sync()
        {
            if (Task.FolderCreated || Directory.Exists(way))
            {
                todayList.Clear();
                todayList = JsonConvert.DeserializeObject<List<Task>>(file);
                var lis = todayList.Where(x => x.dt.Day == Convert.ToDateTime(Calendr.DisplayDate).Day).ToList();
                ToDoList.ItemsSource = null;
                ToDoList.ItemsSource = lis.OfType<Task>().Select(x => x.Name).ToList();
            }
        }
    }
}
