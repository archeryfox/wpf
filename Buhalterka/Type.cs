using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Buhalterka
{
    internal class Type
    {
        public Type()
        {

        }
        public Type(string name, SubIndex beats, SubIndex falls)
        {
            this.name = name;
            this.Beats = beats;
            this.Falls = falls;
        }

        public static List<Type> Types = new List<Type>();

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public SubIndex Beats;
        public SubIndex Falls;
    }
}
