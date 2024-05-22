using MobileProject.Models;
using System.Collections.ObjectModel;

namespace MobileProject;

public partial class Courses : ContentPage
{
    public ObservableCollection<CoursesClass> Course { get; set; }

    public Courses()
    {
        InitializeComponent();
        Course = new ObservableCollection<CoursesClass>(App.DBTrans.GetAllCourses());
        Cou_List_View.ItemsSource = Course;
    }

    private CoursesClass selectedCourse;
    private void Cou_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        selectedCourse = e.Item as CoursesClass;
    }
    private void Del_Button_Clicked(object sender, EventArgs e)
    {
        if (selectedCourse != null)
        {
            App.DBTrans.DeleteCourse(selectedCourse.CouId);
            Course.Remove(selectedCourse);
            selectedCourse = null;
        }
    }


    private bool AreAllFieldsFilled()
    {
        // Check if all required fields are filled
        return !string.IsNullOrWhiteSpace(Cou_Name.Text);
    }
    private void AddButton_Clicked(object sender, EventArgs e)
    {
        // Check if all required fields are filled
        if (!AreAllFieldsFilled())
        {
            DisplayAlert("Error", "Please fill in all required fields.", "OK");
            return;
        }

        // Create a new student object
        var newCourse = new CoursesClass
        {
            CourseName = Cou_Name.Text,
        };
        App.DBTrans.AddCourse(newCourse);


        // Clear input fields
        Cou_Name.Text = string.Empty;
    }
    private void ShowButton_Clicked(object sender, EventArgs e)
    {
        // Refresh the list
        Course.Clear();
        foreach (var course in App.DBTrans.GetAllCourses())
        {
            Course.Add(course);
        }
    }
    private async void Previous_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Student");
    }

    private async void Continue_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Enrollments");
    }
}

