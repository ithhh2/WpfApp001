using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp001
{
    public partial class StudentViewModel : ObservableObject
    {
        private EFDbContext _context = new EFDbContext();

        [ObservableProperty]
        private ObservableCollection<Student> students;

        [ObservableProperty]
        private Student selectedStudent;

        public StudentViewModel()
        {
            LoadStudents(null);
        }

        [RelayCommand]
        private void LoadStudents(object parameter)
        {
            Students = new ObservableCollection<Student>(_context.Students.ToList());
            SelectedStudent = new Student();
        }

        [RelayCommand]
        private void AddStudent(object parameter)
        {
            try
            {
                if (SelectedStudent != null && !string.IsNullOrEmpty(SelectedStudent.name.Trim()) && SelectedStudent.age >= 0)
                {
                    SelectedStudent.id = Students.Count + 1;
                    _context.Students.Add(SelectedStudent);
                    _context.SaveChanges();
                    MessageBox.Show("Student added successfully!");
                    LoadStudents(null);
                    SelectedStudent = new Student();
                }
                else
                {
                    MessageBox.Show("Please enter valid student information.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        [RelayCommand]
        private void DeleteStudent(object parameter)
        {
            try
            {
                if (SelectedStudent != null && SelectedStudent.id > 0)
                {
                    _context.Students.Remove(SelectedStudent);
                    _context.SaveChanges();
                    MessageBox.Show("Student deleted successfully!");
                    LoadStudents(null);
                    SelectedStudent = new Student();
                }
                else
                {
                    MessageBox.Show("Please select a student to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        [RelayCommand]
        private void UpdateStudent(object parameter)
        {
            try
            {
                if (SelectedStudent != null && SelectedStudent.id > 0)
                {
                    _context.SaveChanges();
                    MessageBox.Show("Student updated successfully!");
                    LoadStudents(null);
                }
                else
                {
                    MessageBox.Show("Please select a student to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



    }
}
