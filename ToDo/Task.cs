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
        public readonly string Name;
        public readonly string Description;
        public readonly DateTime dt = DateTime.Today;
        public readonly string DateTimeDay = DateTime.Today.Day.ToString();
        public readonly string DateTimeMounth = DateTime.Today.Month.ToString();
        public readonly string DateTimeYear = DateTime.Today.Year.ToString();

        public static string FileName = "Tasks.json";
        public static string FolderPath { get; set; }
        public static bool FolderCreated { get; private set; }
        public Task(string name, string description, DateTime dateTimeCreated)
        {
            Name = name;
            Description = description;
            dt = dateTimeCreated;
            DateTimeDay = dateTimeCreated.Day.ToString();
            DateTimeMounth = dateTimeCreated.Month.ToString();
            DateTimeYear = "2023";
        }
        
        static public void FolderDefault()
        {
            FolderCreated = true;
        }
    }
}
