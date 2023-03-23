using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Newtonsoft.Json;


namespace Buhalterka
{
    internal class Turn
    {
        public Turn(string spell, string type, string _class, int mana, int damage, int bonus, DateTime? ct)
        {
            this.Spell = spell;
            this.Type = type;
            this.Mana = mana;
            this.Class = _class;
            this.Damage = damage;
            this.Bonus = bonus;
            this.PatryDate = ct;
            turns.Add(this);
        }

        public static List<Turn> turns = new List<Turn>();

        public void ToJson()
        {
            string json = JsonConvert.SerializeObject(turns);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), json);
        }

        public Turn() { }

        public int Id;

        private string spell;

        public string Spell
        {
            get { return spell; }
            set
            {
                if (value != null || value != value.Split(' ')[0])
                {
                    spell = value;
                }
            }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set
            {
                if (value != null || value != value.Split(' ')[0])
                {
                    type = value;
                }
            }
        }
        private string _class;

        public string Class
        {
            get { return _class; }
            set { _class = value; }
        }

        private int mana;

        public int Mana
        {
            get { return mana; }
            set { mana = value; }
        }

        private int damage;

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        private int bonus;

        public int Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public DateTime? PatryDate;
    }
}
