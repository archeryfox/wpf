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
using Newtonsoft.Json;

namespace Buhalterka
{
    /// <summary>
    /// Логика взаимодействия для BossCreation.xaml
    /// </summary>
    public partial class BossCreation : Page
    {
        public BossCreation()
        {
            InitializeComponent();
            var json = JsonConvert.DeserializeObject<List<Boss>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Bosses.json"));
            BossList.Items.Clear();
            BossList.ItemsSource = json.OfType<Boss>().Select(x => x.Name).ToList();
            Type.Items.Clear();
            Weakness.Items.Clear();
            Type.ItemsSource = Buhalterka.Type.Types.Select(x => x.Name).ToList();
            Weakness.ItemsSource = Buhalterka.Type.Types.Select(x => x.Name).ToList();
            BossList.SelectedIndex = -1;
        }

        private void Spawn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var json1 = JsonConvert.DeserializeObject<List<Boss>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Bosses.json"));
                var b = new Boss(Bossname.Text, int.Parse(Hp.Text), int.Parse(Def.Text), new SubIndex(Type.SelectedIndex), new SubIndex(Weakness.SelectedIndex));
                json1.Add(b);
                BossList.ItemsSource = Boss.bosses.Select(x => x.Name).ToList();
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Bosses.json", JsonConvert.SerializeObject(json1));
            }
            catch (Exception)
            {
                MessageBox.Show(this.ToString());
            }
        }

        private void BossList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var json = JsonConvert.DeserializeObject<List<Boss>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Bosses.json"));

            try
            {
                if (BossList.SelectedIndex == -1)
                {
                    MainWindow.currentBoss = json[0];
                }
                else if (BossList.SelectedIndex != -1 && Bossname != null)
                {
                    for (int i = 0; i < json.Count; i++)
                    {
                        json[i].isCurrent = false;
                    }
                    json[BossList.SelectedIndex].isCurrent = true;
                    MainWindow.currentBoss = json[BossList.SelectedIndex];
                    Bossname.Text = json[BossList.SelectedIndex].Name;
                    Hp.Text = json[BossList.SelectedIndex].Hp.ToString();
                    Def.Text = json[BossList.SelectedIndex].Def.ToString();
                    Type.SelectedIndex = (int)json[BossList.SelectedIndex].Type.id;
                    Weakness.SelectedIndex = (int)json[BossList.SelectedIndex].Weakness.id;
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Bosses.json",
                        JsonConvert.SerializeObject(json));
                }
                //MessageBox.Show(BossList.SelectedIndex.ToString());
            }
            catch (Exception)
            {

            }
        }
    }
}
