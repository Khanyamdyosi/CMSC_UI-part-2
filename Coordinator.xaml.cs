using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CMCS_UI
{
    /// <summary>
    /// Interaction logic for Coordinator.xaml
    /// </summary>
    public partial class Coordinator : Window
    {
        private readonly CMCSContext _context;

        // Ensure the constructor name matches the class name
        public Coordinator(CMCSContext context)
        {
            InitializeComponent();
            _context = context;

            // Load pending claims when the window loads
            LoadPendingClaims();
        }

        // Method to load pending claims into the DataGrid
        private void LoadPendingClaims()
        {
            // Fetch all claims where Status is 'Submitted' (pending approval)
            var pendingClaims = _context.Claims
                                        .Where(c => c.Status == "Submitted")
                                        .ToList();

            // Bind the pending claims to the DataGrid
            ClaimsDataGrid.ItemsSource = pendingClaims;
        }

        // Approve Button Click Event
        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            var claim = (Claim)((FrameworkElement)sender).DataContext;
            claim.Status = "Approved";
            _context.SaveChanges();
            LoadPendingClaims(); // Refresh the DataGrid
        }

        // Reject Button Click Event
        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            var claim = (Claim)((FrameworkElement)sender).DataContext;
            claim.Status = "Rejected";
            _context.SaveChanges();
            LoadPendingClaims(); // Refresh the DataGrid
        }
    }
}
