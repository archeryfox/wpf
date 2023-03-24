using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace Buhalterka
{
    public class Boss
    {
        public Boss() { }
        public bool isCurrent = false;
        public Boss(string name, int hp, int def, SubIndex type, SubIndex weakness)
        {
            Name = name;
            Hp = hp;
            Def = def;
            Type = type;
            Weakness = weakness;
            bosses.Add(this);
        }
        public static List<Boss> bosses = new List<Boss>();

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null || value != value.Split(' ')[0])
                {
                    name = value;
                }
            }
        }

        public int Hp { get; set; } = 0;


        public int Def { get; set; } = 0;

        public SubIndex Type;

        public SubIndex Weakness;

        bool beated = false;

        public bool GetBeated()
        {
            return beated;
        }

        void _UpbeatingBoss()
        {
            List<Type> types = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json"));
            List<Turn> turns = JsonConvert.DeserializeObject<List<Turn>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Turns.json"));
            try
            {
                turns = turns.Where(t => t.PatryDate.Value.Day == turns[turns.Count - 1].PatryDate.Value.Day).ToList();
                if (!beated)
                {
                    if (turns[turns.Count - 1].Type == types[(int)this.Weakness.id].Name)
                        this.beated = true;
                }
            }
            catch (Exception) { }
        }

        public string ToStringBoss()
        {
            List<Type> types = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json"));
            List<Turn> turns = JsonConvert.DeserializeObject<List<Turn>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Turns.json"));
            turns = turns.Where(t => t.PatryDate.Value.Day == turns[turns.Count - 1].PatryDate.Value.Day).ToList();
            _UpbeatingBoss();
            if (beated)
            {
                return $"{this.name}: {this.Hp} HP, {this.Def} DEF\nТип: {types[(int)this.Type.id].Name}, Слабость: {types[(int)this.Weakness.id].Name}";
            }
            else
            {
                return $"{this.name}: {this.Hp} HP, {this.Def} DEF\nТип: {types[(int)this.Type.id].Name}";
            }
        }

    }
}
