using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class DayList
    {
        public DayList(DateTime dayData, List<DItem> list)
        {
            DayData = dayData;
            Items = list;
        }
        public DateTime DayData;
        public List<DItem> Items;
    }
}
