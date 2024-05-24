namespace MobileProject;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text?.Trim(); // Trim whitespace
        string password = PasswordEntry.Text?.Trim();

        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
        {
            // Perform more robust validation (e.g., against a database or API)

            if (IsValidUser(username, password)) // Replace with your actual validation logic
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
        }
    }

    // Placeholder for user validation logic
    private bool IsValidUser(string username, string password)
    {
        // Learn hashing algorithm.
        return username == "user" && password == "pass"; //pass and user
    }
}
