using MobileProject.Models;
using System.Collections.ObjectModel;

namespace MobileProject
{
    public partial class Enrollments : ContentPage
    {
        private ObservableCollection<StudentClass> Students { get; set; }
        private ObservableCollection<CoursesClass> Course { get; set; }
        private ObservableCollection<EnrollmentsClass> Enrollment { get; set; }

        public Enrollments()
        {
            InitializeComponent();

            Students = new ObservableCollection<StudentClass>(App.DBTrans.GetAllStudents());
            Course = new ObservableCollection<CoursesClass>(App.DBTrans.GetAllCourses());
            Enrollment = new ObservableCollection<EnrollmentsClass>(App.DBTrans.GetAllEnrollments());

            // Assign collections as item sources for pickers or dropdowns in your XAML
            StudentPicker.ItemsSource = Students;
            CoursePicker.ItemsSource = Course;
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

            // Check if the student is already enrolled in the course
            var existingEnrollment = App.DBTrans.GetAllEnrollments().FirstOrDefault(enrollment => enrollment.StudentId == selectedStudent.Id
                                                                                               && enrollment.StudentName.Equals(selectedStudent.Name)
                                                                                               && enrollment.CourseId == selectedCourse.CouId);
            if (existingEnrollment != null)
            {
                await DisplayAlert("Error", $"{selectedStudent.Name} is already enrolled in {selectedCourse.CourseName}.", "OK");
                return;
            }

            // Create a new enrollment record
            var newEnrollment = new EnrollmentsClass
            {
                StudentId = selectedStudent.Id,

                StudentName  = selectedStudent.Name,
                CourseId = selectedCourse.CouId,
                EnrollmentDate = DateTime.Now // Set the enrollment date to current date/time
            };

            // Add the new enrollment record to the database
            App.DBTrans.AddEnrollments(newEnrollment);

            await DisplayAlert("Enrollment Successful", $"{selectedStudent.Name} enrolled in {selectedCourse.CourseName}.", "OK");
        }

        private void Button_Show_Clicked(object sender, EventArgs e)
        {
            Enrollment.Clear();
            // Fetch all enrollments from the database
            var allEnrollments = App.DBTrans.GetAllEnrollments();

            // Add all enrollments to the Enrollment collection
            foreach (var enrollment in allEnrollments)
            {
                Enrollment.Add(enrollment);
            }

            // Refresh the ListView to reflect the changes
            EnrollmentListView.ItemsSource = null;
            EnrollmentListView.ItemsSource = Enrollment;
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

        public static EnrollmentsClass selectedEnrollment;
        private void EnrollmentListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedEnrollment = e.Item as EnrollmentsClass;
        }

        private void Del_Button_Clicked(object sender, EventArgs e)
        {
            if (selectedEnrollment != null)
            {
                App.DBTrans.DeleteEnrollments(selectedEnrollment.EnrId);
                Enrollment.Remove(selectedEnrollment);
                selectedEnrollment = null;
            }
        }
    }
}
