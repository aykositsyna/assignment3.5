using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Model;

namespace ViewModel
{
    public class ViewModelStudent : INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public ViewModelStudent ()
        {
            addCommand = new RelayCommand(AddStudent);
            deleteCommand = new RelayCommand(DeleteStudent);
        }

        private Student newStudent = new Student();
        private Student selectedStudent = new Student();

        public Student NewStudent
        {
            get { return newStudent; }
            set { newStudent = value; OnPropertyChanged(nameof(NewStudent)); }
        }

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set { selectedStudent = value; OnPropertyChanged(nameof(SelectedStudent)); }
        }

        private ICommand addCommand;
        public ICommand AddCommand => addCommand
            ?? (addCommand = new RelayCommand(AddStudent));

        public void AddStudent()
        {
            Student addS = new Student() { Name = newStudent.Name, Speciality = newStudent.Speciality, Group = newStudent.Group};
            Students.Add(addS);
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand => deleteCommand
            ?? (deleteCommand = new RelayCommand(DeleteStudent));

        public void DeleteStudent()
        {
            Students.Remove(selectedStudent);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}
