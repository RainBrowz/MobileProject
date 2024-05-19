using MobileProject.Models;
using System.Collections.ObjectModel;

namespace MobileProject;

public partial class Student : ContentPage
{
    public ObservableCollection<StudentClass> Students { get; set; }
    public Student()
    {
        InitializeComponent();
        Students = new ObservableCollection<StudentClass>(App.DBTrans.GetAllStudents());
        Stu_List_View.ItemsSource = Students;
    }
    private void Numeric(object sender, TextChangedEventArgs e)
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

    private void non_numeric(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry == null)
            return;

        // Remove numeric characters
        string newText = new string(e.NewTextValue.Where(char.IsLetter).ToArray());

        if (newText != e.NewTextValue)
        {
            entry.Text = newText;
        }
    }


    private void Del_Button_Clicked(object sender, EventArgs e)
    {
        if (selectedStudent != null)
        {
            App.DBTrans.Delete(selectedStudent.Id);
            Students.Remove(selectedStudent);
            selectedStudent = null;
        }
    }



    private bool AreAllFieldsFilled()
    {
        // Check if all required fields are filled
        return !string.IsNullOrWhiteSpace(Stu_Name.Text) &&
               !string.IsNullOrWhiteSpace(phone.Text) &&
               !string.IsNullOrWhiteSpace(mail.Text) &&
               !string.IsNullOrWhiteSpace(address.Text) &&
               (male.IsChecked || female.IsChecked) &&
                Date.Date != DateTime.Today;
    }


    private void Button_Add_Clicked(object sender, EventArgs e)
    {
        // Check if all required fields are filled
        if (!AreAllFieldsFilled())
        {
            DisplayAlert("Error", "Please fill in all required fields.", "OK");
            return;
        }

        // Create a new student object
        var newStudent = new StudentClass
        {
            Name = Stu_Name.Text,
        };
        App.DBTrans.Add(newStudent);


        // Clear input fields
        Stu_Name.Text = string.Empty;
        phone.Text = string.Empty;
        mail.Text = string.Empty;
        address.Text = string.Empty;

        male.IsChecked = false;
        female.IsChecked = false;

        Date.Date = DateTime.Today;


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

    private StudentClass selectedStudent;
    private void Stu_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        selectedStudent = e.Item as StudentClass;
    }
}
