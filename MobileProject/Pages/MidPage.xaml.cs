namespace MobileProject;

public partial class MidPage : ContentPage
{
	public MidPage()
	{
		InitializeComponent();
	}

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        // Add button click logic here (if needed)
    }

    private void OnShowButtonClicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;
        string lastName = LastNameEntry.Text;
        DisplayLabel.Text = $"{name} {lastName}";
    }
}