using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace Buhalterka
{
    internal class Class
    {
        public Class() { }
        public Class(string name, SubIndex beatscls, SubIndex fallscls, SubIndex prefertype,SubIndex impossible)
        {
            this.Name = name;
            this.FallsClass = fallscls;
            this.BeatsClass = beatscls;
            this.ImpossibleType = impossible;
            this.PreferType = prefertype;
            classes.Add(this);
        }
        
        public static List<Class> classes;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                try
                {
                    if (value != null || value != value.Split(' ')[0])
                    {
                        name = value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверно введено имя");
                }
               
            }
        }

        public SubIndex BeatsClass;
        public SubIndex FallsClass;
        public SubIndex PreferType;
        public SubIndex ImpossibleType;
    }
}
