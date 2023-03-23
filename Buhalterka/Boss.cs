using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



        public string ToStringBoss()
        {
            List<Type> json1 = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DnD/Types.json"));
            return $"{this.name} {this.Hp} HP, {this.Def} DEF, {json1[(int)this.Type.id].Name} {json1[(int)this.Weakness.id].Name}";
        }

    }
}
