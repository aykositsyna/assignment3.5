using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student : INotifyPropertyChanged
    {
        private string name;
        private string speciality;
        private string group;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; OnPropertyChanged(nameof(Speciality)); }
        }

        public string Group
        {
            get { return group; }
            set { group = value; OnPropertyChanged(nameof(Group)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}
