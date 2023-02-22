using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace ToDo
{
    public class JS<T>
    {
        static public void SE(List<T> values)
        {
            var _ = JsonConvert.SerializeObject(values);
            File.WriteAllText(Task.FolderPath + Task.FileName, _);
        }
        static public List<T> DE()
        {
            return JsonConvert.DeserializeObject<List<T>>(Task.FolderPath + Task.FileName);
        }
    }
}
