using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace ToDo
{
    public class Task
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ID;
        public DateTime dt;
        public int DateTimeDay { get; set; }
        public int  DateTimeMounth { get; set; }
        public int DateTimeYear { get; set; }

        public static string FileName = "Tasks.json";
        public static string FolderPath { get; set; }
        public static bool FolderCreated { get; private set; }
        public void NameMod(string Text)
        {
            this.Name = Text;
        }
        public void DescriptMod(string Text)
        {
            this.Description = Text;
        }
        public Task(string name, string description, int id, DateTime dateTimeCreated)
        {
            Name = name;
            Description = description;
            ID = id;
            dt = dateTimeCreated;
            DateTimeDay = dateTimeCreated.Day;
            DateTimeMounth = dateTimeCreated.Month;
            DateTimeYear = 2023;
        }

        static public void FolderDefault()
        {
            FolderCreated = true;
        }
    }
}
