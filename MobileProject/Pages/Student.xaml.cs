using MobileProject.Models;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace MobileProject;

public partial class Student : ContentPage
{
    public ObservableCollection<StudentClass> Students { get; set; }
    public Student()
    {
        InitializeComponent();
        Students = new ObservableCollection<StudentClass>(App.DBTrans.GetAllStudents());
        StudentListView.ItemsSource = Students;
    }
    private void Del_Button_Clicked(object sender, EventArgs e)
    {
        if (selectedStudent != null)
        {
            App.DBTrans.DeleteStudent(selectedStudent.Id);
            Students.Remove(selectedStudent);
            selectedStudent = null;
        }
    }
    private bool AreAllFieldsFilled()
    {
        // Check if all required fields are filled
        return !string.IsNullOrWhiteSpace(StudentName.Text) &&
               !string.IsNullOrWhiteSpace(PhoneNumberEntry.Text) &&
               !string.IsNullOrWhiteSpace(EmailEntry.Text) &&
               !string.IsNullOrWhiteSpace(AddressEntry.Text) &&

               DateOfBirthPicker.Date != DateTime.Today;
    }
    private async void Button_Add_Clicked(object sender, EventArgs e)
    {
        // Check if all required fields are filled
        if (!AreAllFieldsFilled())
        {
            await DisplayAlert("Error", "Please fill in all required fields.", "OK");
            return;
        }
        // Create a new student object
        var newStudent = new StudentClass
        {
            Name = StudentName.Text,
        };
        App.DBTrans.AddStudent(newStudent);

        // Clear input fields
        StudentName.Text = string.Empty;
        PhoneNumberEntry.Text = string.Empty;
        EmailEntry.Text = string.Empty;
        AddressEntry.Text = string.Empty;


        DateOfBirthPicker.Date = DateTime.Today;
    }

    private void Button_Show_Clicked(object sender, EventArgs e)
    {
        // Refresh the list
        Students.Clear();
        foreach (var student in App.DBTrans.GetAllStudents())
        {
            Students.Add(student);
        }
    }

    public static StudentClass selectedStudent;
    private void Stu_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        selectedStudent = e.Item as StudentClass;
    }

    public static void Numeric(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry == null)
            return;

        // Remove non-numeric characters
        string newText = new string(e.NewTextValue.Where(char.IsDigit).ToArray());

        if (newText != e.NewTextValue)
        {
            entry.Text = newText;
        }
    }

    public static void NonNumeric(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry == null)
            return;

        // Remove numeric characters
        string newText = new string(e.NewTextValue.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

        if (newText != e.NewTextValue)
        {
            entry.Text = newText;
        }
    }

    private async void Previous_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void Continue_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Courses");
    }


}