using Newtonsoft.Json;
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

namespace Buhalterka
{
    /// <summary>                                                                                    
    /// Логика взаимодействия для TypeCreation.xaml
    /// </summary>
    public partial class TypeCreation : Page
    {
        public TypeCreation()
        {
            InitializeComponent();
            List<Type> json1 = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json"));
            Type.Types = json1;
            BeatsList.Items.Clear();
            WeakList.Items.Clear();
            TypeList1.Items.Clear();
            TypeList1.ItemsSource = json1.Select(x => x.Name).ToList();
            BeatsList.ItemsSource = json1.Select(x => x.Name).ToList();
            WeakList.ItemsSource = json1.Select(x => x.Name).ToList();
        }



        private void MageIt_Click(object sender, RoutedEventArgs e)
        {
            List<Type> json1 = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json"));
            Type.Types.Add(new Type(TypeName.Text, new SubIndex(BeatsList.SelectedIndex), new SubIndex(WeakList.SelectedIndex)));
            var _json = JsonConvert.SerializeObject(Type.Types);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json", _json);
            Type.Types = json1;
            TypeList1.ItemsSource = null;
            BeatsList.ItemsSource = null;
            WeakList.ItemsSource = null;
            BeatsList.Items.Clear();
            WeakList.Items.Clear();
            TypeList1.Items.Clear();
            TypeList1.ItemsSource = json1.Select(x => x.Name).ToList();
            BeatsList.ItemsSource = json1.Select(x => x.Name).ToList();
            WeakList.ItemsSource = json1.Select(x => x.Name).ToList();
        }

        private void TypeList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Type> json1 = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json"));
            TypeName.Text = json1[TypeList1.SelectedIndex].Name;
            BeatsList.SelectedIndex = (int)json1[TypeList1.SelectedIndex].Beats.id;
            WeakList.SelectedIndex = (int)json1[TypeList1.SelectedIndex].Falls.id;
        }
    }
}
