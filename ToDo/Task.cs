using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    public class Task
    {
        public readonly string Name;
        public readonly string Description;
        public readonly DateTime DateTimeCreated;

        public static string FileName = "Tasks.json";
        public static string FolderPath { get; set; }
        public static bool FolderCreated { get; private set; }
        public Task(string name, string description, DateTime dateTimeCreated)
        {
            this.Name = name;
            this.Description = description;
            this.DateTimeCreated = dateTimeCreated;
        }
       
        static public void FolderDefault()
        {
            FolderCreated = true;
        }
    }
}
