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
using Buhalterka.Dog_AntiCafeDataSetTableAdapters;

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
                BossInfo.Text = currentBoss.ToStringBoss();
                await Task.Delay(1000);
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
            try
            {
                for (int i = 0; i < trnss.Length; i++)
                {
                    if ((currentBoss.Hp - Turn.turns[i].Damage * (new Random().Next(1, 3)) + (int)((float)currentBoss.Def / 2)) > currentBoss.Hp)
                    {
                        Turn.turns[i].Damage -= (int)(uint)((float)currentBoss.Def / 2);
                        currentBoss.Hp -= Turn.turns[i].Damage;
                    }
                    else
                    {
                        Turn.turns[i].Damage -= (int)(uint)((float)currentBoss.Def / 2);
                        currentBoss.Hp -= Turn.turns[i].Damage;
                    }
                }
            } catch (Exception){}
            BossUpdate();
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
                    var r = new Turn(SpellName.SelectedValue.ToString(), TypeSelector.Text, ClassSelector.Text, int.Parse(ManaKeeper.Text), int.Parse(ManaKeeper.Text) + 5 + (int)Rand.Content, (int)Rand.Content, CurrntDate.SelectedDate);
                    TurnList.ItemsSource = Turn.turns.Where(x => x.PatryDate.Value.Day == CurrntDate.SelectedDate.Value.Day).ToList();
                    TurnList.Items.Refresh();
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Turns.json", JsonConvert.SerializeObject(Turn.turns));
                    List<Type> types = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json"));
                    List<Turn> turns = JsonConvert.DeserializeObject<List<Turn>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Turns.json"));

                    if (turns[turns.Count - 1].Type == types[(int)currentBoss.Weakness.id].Name)
                    {
                        if ((currentBoss.Hp - r.Damage * (new Random().Next(1, 3)) + (int)((float)currentBoss.Def / 2)) > currentBoss.Hp)
                        {
                            r.Damage -= (int)(uint)((float)currentBoss.Def / 2);
                            currentBoss.Hp -= r.Damage;
                        }
                        else
                        {
                            r.Damage -= (int)(uint)((float)currentBoss.Def / 2);
                            currentBoss.Hp -= r.Damage;
                        }
                    }
                    else
                    {
                        if ((currentBoss.Hp - r.Damage + currentBoss.Def) > currentBoss.Hp)
                        {
                            r.Damage -= (int)((float)currentBoss.Def / 2);
                            currentBoss.Hp -= (int)(uint)r.Damage;
                        }
                        else
                        {
                            currentBoss.Hp -= r.Damage + currentBoss.Def;
                        }
                    }
                }
                else
                {
                    var r = new Turn(SpellName.SelectedValue.ToString(), TypeSelector.Text, ClassSelector.Text, int.Parse(ManaKeeper.Text), int.Parse(ManaKeeper.Text) * 10 + (int)Rand.Content, 0, CurrntDate.SelectedDate);
                    TurnList.ItemsSource = Turn.turns.Where(x => x.PatryDate.Value.Day == CurrntDate.SelectedDate.Value.Day).ToList();
                    TurnList.Items.Refresh();
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Turns.json", JsonConvert.SerializeObject(Turn.turns));

                    currentBoss.Hp -= r.Damage - currentBoss.Def;
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
                    TurnList.ItemsSource = Turn.turns.Where(x => x.PatryDate.Value.Day == CurrntDate.SelectedDate.Value.Day).ToList();
                    TurnList.Items.Refresh();
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Turns.json", JsonConvert.SerializeObject(Turn.turns));
                }
            }
            catch (Exception) { }
            TurnList.Items.Refresh();
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
            currentBoss = JsonConvert.DeserializeObject<List<Boss>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Bosses.json"))[0];
        }
        ~MainWindow()
        {
            Environment.Exit(0);
        }
    }
}
