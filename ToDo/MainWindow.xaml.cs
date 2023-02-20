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
using Newtonsoft.Json.Converters;
using Microsoft.Win32;
using System.IO;

namespace ToDo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Task> todayList = new List<Task>();

        /// <summary>
        /// Сегодняшняя дата календаря
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calendr_Initialized(object sender, EventArgs e)
        {
            (sender as DatePicker).Text = $"{DateTime.Now}";

        }
        /// <summary>
        /// Основной лист
        /// </summary>
        List<Task> TaskList = new List<Task>();

        /// <summary>
        /// Создать заметку
        /// </summary>
        private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var way = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Tasks\\";
            var file = File.ReadAllText(way + Task.FileName);
            //Поправить баг с загрузукой записок
            Task task = new Task(TaskName.Text, TaskDescription.Text, Calendr.DisplayDate);
            TaskList = JsonConvert.DeserializeObject<List<Task>>(file);
            //MessageBox.Show(file);
            TaskList.Add(task);
            var js = JsonConvert.SerializeObject(TaskList);
            File.WriteAllText(way + Task.FileName, js);
            ToDoList.ItemsSource = TaskList;
            ToDoList.ItemsSource = ToDoList.Items.OfType<Task>().Where(x => x.DateTimeDay == Calendr.DisplayDate.Day && x.DateTimeMounth == Calendr.DisplayDate.Month).ToList();
            ToDoList.ItemsSource = ToDoList.Items.OfType<Task>().Select(x => x.Name).ToList();
        }

        /// <summary>
        /// Сохранить в файл заметку
        /// </summary>
        private void SaveTasksButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string js = JsonConvert.SerializeObject(TaskList);
            var way = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!Directory.Exists(way + "\\Tasks") && !Task.FolderCreated)
            {
                if (MessageBox.Show("Задать папку для заметок?", "Mmm?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    saveFileDialog.Filter = "JSON file (*.json)|*.json";
                    saveFileDialog.FileName = "Tasks.json";
                    saveFileDialog.ShowDialog();
                    Directory.CreateDirectory(way + "\\Tasks");
                    Task.FolderPath = way + "\\Tasks\\";
                    Task.FolderDefault();
                    Task.FileName = saveFileDialog.SafeFileName;
                    File.WriteAllText(Task.FolderPath + saveFileDialog.SafeFileName, js.Normalize());
                    MessageBox.Show(Task.FolderPath + saveFileDialog.SafeFileName);
                    return;
                }
            }
            if (Directory.Exists(way + "\\Tasks") || Task.FolderCreated)
            {
                string fn = "Tasks.json";
                Task.FolderDefault();
                Task.FileName = fn;
                Task.FolderPath = way + "\\Tasks\\";
                File.WriteAllText(Task.FolderPath + fn, JsonConvert.SerializeObject(TaskList));
            }
        }
        /// <summary>
        /// Удалить заметку
        /// 
        /// 
        /// 
        /// НАЙТИ ИНДЕКС ВЫДЕЛЕННОГО ЭЛЕМЕНТА В МАССИВЕ ЛИСТА И УДАЛИТЬ
        /// </summary>
        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
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
            //MessageBox.Show(Calendr.Text);
            var way = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Tasks\\";
            if (Task.FolderCreated || Directory.Exists(way))
            {
                var file = File.ReadAllText(way + Task.FileName);
                todayList = JsonConvert.DeserializeObject<List<Task>>(file).Where(x => x.DateTimeDay == Calendr.DisplayDate.Day).ToList();
                ToDoList.ItemsSource = todayList;
                ToDoList.ItemsSource = ToDoList.Items.OfType<Task>().Select(x => x.Name).ToList();
            }
        }

        private void Calendr_Loaded(object sender, RoutedEventArgs e)
        {
            var way = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Tasks\\";
            if (Task.FolderCreated || Directory.Exists(way))
            {
                var file = File.ReadAllText(way + Task.FileName);
                todayList = JsonConvert.DeserializeObject<List<Task>>(file).Where(x => x.DateTimeDay == Calendr.DisplayDate.Day).ToList();
                ToDoList.ItemsSource = todayList;
                ToDoList.ItemsSource = ToDoList.Items.OfType<Task>().Select(x => x.Name).ToList();
            }
        }
    }
}
