using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Buhalterka
{
    /// <summary>
    /// Логика взаимодействия для ClassCreation.xaml
    /// </summary>
    public partial class ClassCreation : Page
    {
        public ClassCreation()
        {
            InitializeComponent();
            List<Class> json1 = JsonConvert.DeserializeObject<List<Class>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Classes.json"));
            List<Type> json2 = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json"));
            Class.classes = json1;
            ClassList.Items.Clear();
            ImpossibleType.Items.Clear();
            BeatsClass.Items.Clear();
            WeaksClass.Items.Clear();
            PreferType.Items.Clear();
            ClassList.ItemsSource = json1.Select(x => x.Name).ToList();
            PreferType.ItemsSource = json2.Select(x => x.Name).ToList();
            ImpossibleType.ItemsSource = json2.Select(x => x.Name).ToList();
            BeatsClass.ItemsSource = json1.Select(x => x.Name).ToList();
            WeaksClass.ItemsSource = json1.Select(x => x.Name).ToList();
        }

        private void PutIt_Click(object sender, RoutedEventArgs e)
        {
            new Class(ClassName.Text, new SubIndex(BeatsClass.SelectedIndex), new SubIndex(WeaksClass.SelectedIndex),
            new SubIndex(PreferType.SelectedIndex), new SubIndex(ImpossibleType.SelectedIndex));
            var json1 = JsonConvert.SerializeObject(Class.classes);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Classes.json", json1);
        }

        private void ClassList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Class> json1 = JsonConvert.DeserializeObject<List<Class>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Classes.json"));
            List<Type> json2 = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json"));
            ClassName.Text = json1[ClassList.SelectedIndex].Name;
            BeatsClass.SelectedIndex = (int)json1[ClassList.SelectedIndex].BeatsClass.id;
            WeaksClass.SelectedIndex = (int)json1[ClassList.SelectedIndex].FallsClass.id;
            PreferType.SelectedIndex = (int)json1[ClassList.SelectedIndex].PreferType.id;
            ImpossibleType.SelectedIndex = (int)json1[ClassList.SelectedIndex].ImpossibleType.id;
        }
    }
}
