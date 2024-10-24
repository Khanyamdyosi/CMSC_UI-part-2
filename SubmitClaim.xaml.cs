using Microsoft.EntityFrameworkCore;  // For EF Core functionality
using Microsoft.Win32;  // For OpenFileDialog
using System;
using System.IO;
using System.Linq;

using System.Windows;

namespace CMCS_UI
{
    /// <summary>
    /// Interaction logic for SubmitClaim.xaml
    /// </summary>
    public partial class SubmitClaim : Window
    {
        private string _uploadedFilePath = string.Empty; // To store the uploaded file path
        private readonly CMCSContext _context; // Database context

        public SubmitClaim(CMCSContext context)  // Pass context via constructor
        {
            InitializeComponent();
            _context = context;  // Assign context
        }

        // Upload button click event
        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Documents (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx",
                Title = "Select a Document"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Validate file size (e.g., limit to 5 MB)
                if (new FileInfo(openFileDialog.FileName).Length > 5 * 1024 * 1024)
                {
                    MessageBox.Show("File size must be less than 5 MB.", "File Size Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Store the file path
                _uploadedFilePath = openFileDialog.FileName;
                // Display the uploaded file name
                UploadedFileNameTextBlock.Text = Path.GetFileName(_uploadedFilePath);
            }
        }

        // Submit Button Click Event
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string hoursWorked = HoursWorkedTextBox.Text;
            string hourlyRate = HourlyRateTextBox.Text;
            string additionalNotes = AdditionalNotesTextBox.Text;

            // Ensure valid numeric inputs
            if (double.TryParse(hoursWorked, out double hours) && double.TryParse(hourlyRate, out double rate))
            {
                // Save the claim to the database and return the claim object
                var claim = SaveClaim(hours, rate, additionalNotes, _uploadedFilePath);

                // Update the UI with the new claim status
                ClaimStatusTextBlock.Text = "Status: Pending";

                MessageBox.Show("Claim submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for hours worked and hourly rate.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Modify SaveClaim to return the saved claim object
        private Claim SaveClaim(double hoursWorked, double hourlyRate, string additionalNotes, string filePath)
        {
            // Create and save the claim in the database, return the claim object
            var claim = new Claim
            {
                // Populate properties here
                HoursWorked = hoursWorked,
                HourlyRate = hourlyRate,
                AdditionalNotes = additionalNotes,
                Status = "Pending",
                UploadedFilePath = filePath
            };

            _context.Claims.Add(claim);
            _context.SaveChanges();

            return claim; // Return the saved claim object
        }

    }

}


