using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System.IO;

namespace Buhalterka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Creation r = new Creation();
        List<string> spels = new List<string>();
        public static Boss currentBoss = new Boss();
        async public void BossUpdate()
        {
            var json = JsonConvert.DeserializeObject<List<Boss>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Bosses.json"));
            while (true)
            {
                for (int i = 0; i < json.Count; i++)
                {
                    if (json[i].isCurrent)
                    {
                        //BossInfo.Text = currentBoss.ToStringBoss();
                    }
                }
                BossInfo.Text = currentBoss.ToStringBoss();
                await Task.Delay(1000);
                //MessageBox.Show("a");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            CurrntDate.SelectedDate = DateTime.Now;
            NameSpInp.Visibility = Visibility.Hidden;
            RestartActivity();
            SpellName.Items.Clear();
            string js = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Spells.json");
            spels = JsonConvert.DeserializeObject<List<string>>(js);
            string js1 = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json");
            List<Type> tps = JsonConvert.DeserializeObject<List<Type>>(js1);
            string trnss = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Turns.json");
            List<Turn> tns = JsonConvert.DeserializeObject<List<Turn>>(trnss);
            List<Class> json1 = JsonConvert.DeserializeObject<List<Class>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Classes.json"));
            ClassSelector.Items.Clear();
            ClassSelector.ItemsSource = json1.Select(x => x.Name).ToList();
            Turn.turns = tns.Where(x => x.PatryDate.Value.Day == CurrntDate.SelectedDate.Value.Day).ToList();
            TypeSelector.Items.Clear();
            TypeSelector.ItemsSource = tps.Select(x => x.Name).ToList();
            spels.Add("Добавить заклинание");
            SpellName.ItemsSource = spels;
            BossUpdate();
            TurnList.ItemsSource = tns.Where(x => x.PatryDate.Value.Day == CurrntDate.SelectedDate.Value.Day).ToList();
        }

        void RestartActivity()
        {
            r = new Creation();
            r.Framer1.Content = new BossCreation();
            r.Framer2.Content = new ClassCreation();
            r.Framer3.Content = new TypeCreation();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            r.Close();
        }

        private void AddSmth_Click(object sender, RoutedEventArgs e)
        {
            RestartActivity();
            r.Show();
        }

        /// <summary>
        /// Добавление заклинания в игру
        /// </summary>
        /// <param spell="sender"></param>
        /// <param spell="e"></param>
        private void AddTurn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(Rand.Content.ToString(), out int i))
                {
                    var r = new Turn(SpellName.SelectedValue.ToString(), TypeSelector.Text, ClassSelector.Text, int.Parse(ManaKeeper.Text), 100, (int)Rand.Content, CurrntDate.SelectedDate);
                    TurnList.Items.Clear();
                    TurnList.ItemsSource = Turn.turns.Where(x => x.PatryDate.Value.Day == CurrntDate.SelectedDate.Value.Day).ToList();
                    TurnList.Items.Refresh();
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Turns.json", JsonConvert.SerializeObject(Turn.turns));
                }
                else
                {
                    var r = new Turn(SpellName.SelectedValue.ToString(), TypeSelector.Text, ClassSelector.Text, int.Parse(ManaKeeper.Text), int.Parse(ManaKeeper.Text) * 10, 0, CurrntDate.SelectedDate);
                    TurnList.ItemsSource = Turn.turns.Where(x => x.PatryDate.Value.Day == CurrntDate.SelectedDate.Value.Day).ToList();
                    TurnList.Items.Refresh();
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Turns.json", JsonConvert.SerializeObject(Turn.turns));
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели не все параметры!");
            }
            SpellName.SelectedIndex = -1;
            ClassSelector.SelectedIndex = -1;
            TypeSelector.SelectedIndex = -1;
            ManaKeeper.Text = "0";
            Rand.Content = "🎲";
        }

        /// <summary>
        /// Удаление из списка
        /// </summary>
        /// <param spell="sender"></param>
        /// <param spell="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TurnList.SelectedIndex != -1)
                {
                    Turn.turns.RemoveAt(TurnList.SelectedIndex);
                    TurnList.Items.Clear();
                    TurnList.ItemsSource = Turn.turns.Where(x => x.PatryDate.Value.Day == CurrntDate.SelectedDate.Value.Day).ToList();
                    TurnList.Items.Refresh();
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Turns.json", JsonConvert.SerializeObject(Turn.turns));
                }
            }
            catch (Exception) { }
            TurnList.Items.Refresh();

        }
        /// <summary>
        /// Добавление названия заклинания
        /// </summary>
        /// <param spell="sender"></param>
        /// <param spell="e"></param>
        private void ApplySpellName_Click(object sender, RoutedEventArgs e)
        {
            NameSpInp.Visibility = Visibility.Hidden;
            spels.Insert(0, InputSpellBox.Text);
            spels.RemoveAt(spels.Count - 1);
            string json = JsonConvert.SerializeObject(spels);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Spells.json", json);
            string js = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Spells.json");
            spels = JsonConvert.DeserializeObject<List<string>>(js);
            spels.Add("Добавить заклинание");
            SpellName.ItemsSource = spels;
            SpellName.SelectedIndex = 0;
        }



        private void SpellName_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SpellName.SelectedIndex == spels.Count - 1)
            {
                NameSpInp.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rand.Content = new Random().Next(1, 21);
        }

        private void TurnList_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void CurrntDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TurnList.ItemsSource = Turn.turns.Where(x => x.PatryDate.Value.Day == CurrntDate.SelectedDate.Value.Day).ToList();
            TurnList.Items.Refresh();
        }
    }
}
