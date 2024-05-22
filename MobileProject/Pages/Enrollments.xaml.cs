using MobileProject.Models;
using System.Collections.ObjectModel;

namespace MobileProject
{
    public partial class Enrollments : ContentPage
    {
        private ObservableCollection<StudentClass> Students { get; set; }
        private ObservableCollection<CoursesClass> Courses { get; set; }

        public Enrollments()
        {
            InitializeComponent();


            Students = new ObservableCollection<StudentClass>(App.DBTrans.GetAllStudents());
            Courses = new ObservableCollection<CoursesClass>(App.DBTrans.GetAllCourses());

            // Assign collections as item sources for pickers or dropdowns in your XAML
            StudentPicker.ItemsSource = Students;
            CoursePicker.ItemsSource = Courses;
        }

        public async void Button_Add_Clicked(object sender, EventArgs e)
        {
            if (StudentPicker.SelectedItem == null || CoursePicker.SelectedItem == null)
            {
                await DisplayAlert("Error", "Please select a student and a course.", "OK");
                return;
            }

            // Retrieve selected student and course
            var selectedStudent = (StudentClass)StudentPicker.SelectedItem;
            var selectedCourse = (CoursesClass)CoursePicker.SelectedItem;

            // Perform enrollment logic (e.g., add enrollment record to the database)

            // Optionally, update UI to reflect the enrollment
            // For example, you can refresh the student's enrolled courses list or the course's enrolled students list.

            await DisplayAlert("Enrollment Successful", $"{selectedStudent.Name} enrolled in {selectedCourse.CourseName}.", "OK");
        }

        private void Button_Show_Clicked(object sender, EventArgs e)
        {

        }

        private async void Previous_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Courses");
        }

        public void StudentPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void CoursePicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
