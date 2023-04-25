using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    /// <summary>
    /// Logic for Day list items
    /// </summary>
    public class DItem
    {
        public DItem(string name, string path, bool IsChecked)
        {
            this.Name = name;
            this.PathIco = path;
            this.IsChecked = IsChecked;
        }
        public string Name;
        public string PathIco;
        public bool IsChecked;
    }
}
