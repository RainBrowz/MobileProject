using MobileProject.Models;
using System.Collections.ObjectModel;
namespace MobileProject
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<MajorClass> Majors { get; set; }
        string major;
        public MainPage()
        {
            InitializeComponent();
            Majors = new ObservableCollection<MajorClass>(App.DBTrans.GetAllMajor());
            major_List_View.ItemsSource = Majors;
        }
        private void Del_Button_Clicked(object sender, EventArgs e)
        {
            if (selectedMajor != null)
            {
                App.DBTrans.DeleteMajor(selectedMajor.majId);
                Majors.Remove(selectedMajor);
                selectedMajor = null;
            }
        }

        private void Button_Show_Clicked(object sender, EventArgs e)
        {
            // Refresh the list
            Majors.Clear();
            foreach (var major in App.DBTrans.GetAllMajor())
            {
                Majors.Add(major);
            }
        }

        private void Button_Add_Clicked(object sender, EventArgs e)
        {
            if (!AreAllFieldsFilled())
            {
                DisplayAlert("Error", "Please fill in all required fields.", "OK");
                return;
            }

            App.DBTrans.AddMajor(new MajorClass
            {
                majName = major
            });
            // Add the new major to the database

            MajorPicker.Title = string.Empty;
            major = MajorPicker.SelectedItem as string;

            // Refresh the list after adding the new major
            //Button_Show_Clicked(sender, e);

            // Clear input fields
            MajorPicker.SelectedIndex = -1;
        }

        private bool AreAllFieldsFilled()
        {
            // Check if all required fields are filled
            return MajorPicker.SelectedIndex != -1;
        }

        private async void Continue_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Student");
        }

        private MajorClass selectedMajor;
        private void major_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedMajor = e.Item as MajorClass;
        }
    }
}
