using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ToDo
{
    public class Task
    {
        public readonly string Name;
        public readonly string Description;
        public readonly int DateTimeDay = DateTime.Today.Day;
        public readonly int DateTimeMounth = DateTime.Today.Month;
        public readonly int DateTimeYear = DateTime.Today.Year;

        public static string FileName = "Tasks.json";
        public static string FolderPath { get; set; }
        public static bool FolderCreated { get; private set; }
        public Task(string name, string description, DateTime dateTimeCreated)
        {
            this.Name = name;
            this.Description = description;
            this.DateTimeDay= dateTimeCreated.Day;
            this.DateTimeMounth = dateTimeCreated.Month;
            this.DateTimeYear = 2023;
        }
       
        static public void FolderDefault()
        {
            FolderCreated = true;
        }
    }
}
