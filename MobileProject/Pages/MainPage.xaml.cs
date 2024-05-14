namespace MobileProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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

        private void save_Clicked(object sender, EventArgs e)
        {

        }
    }

}
