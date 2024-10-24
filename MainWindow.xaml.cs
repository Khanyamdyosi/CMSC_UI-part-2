using System.Windows;

namespace CMCS_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CMCSContext _context;  // Assuming the database context is needed

        // Default constructor required by XAML
        public MainWindow()
        {
            InitializeComponent();
        }

        // Constructor with context passed via parameter
        public MainWindow(CMCSContext context)
        {
            InitializeComponent();
            _context = context;  // Assign context
        }

        // Submit button click event handler
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve values from the text boxes
            string hoursWorked = HoursWorkedTextBox.Text;
            string hourlyRate = HourlyRateTextBox.Text;
            string additionalNotes = AdditionalNotesTextBox.Text;

            // Input validation (simple)
            if (string.IsNullOrWhiteSpace(hoursWorked) || string.IsNullOrWhiteSpace(hourlyRate))
            {
                MessageBox.Show("Please fill in both Hours Worked and Hourly Rate.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Convert hours worked and hourly rate to numbers
            if (!double.TryParse(hoursWorked, out double hours) || !double.TryParse(hourlyRate, out double rate))
            {
                MessageBox.Show("Please enter valid numbers for Hours Worked and Hourly Rate.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Show success message (this would be replaced with actual claim submission logic)
            MessageBox.Show("Claim submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear the form after submission
            HoursWorkedTextBox.Clear();
            HourlyRateTextBox.Clear();
            AdditionalNotesTextBox.Clear();
        }

        // Open Coordinator Window event handler
        private void OpenCoordinatorWindow_Click(object sender, RoutedEventArgs e)
        {
            var coordinatorWindow = new Coordinator(_context);
            coordinatorWindow.Show();
        }
    }
}
