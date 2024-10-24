using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CMCS_UI
{
    /// <summary>
    /// Interaction logic for ClaimsReview.xaml
    /// </summary>
    public partial class ClaimsReview : Window
    {
        private void ApproveClaim_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for future claim approval logic
            MessageBox.Show("Claim Approved");
        }

        private void RejectClaim_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for future rejection logic
            MessageBox.Show("Claim Rejected");
        }

        private void DownloadDocument_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for downloading documents
            MessageBox.Show("Document Downloaded");
        }

    }
}
