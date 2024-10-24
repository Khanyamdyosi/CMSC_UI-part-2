using System;
using System.ComponentModel;

namespace CMCS_UI
{
    public class Claim : INotifyPropertyChanged
    {
        private string _status;

        public int ClaimID { get; set; }
        public string LecturerName { get; set; }
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public string AdditionalNotes { get; set; }

        // Use the private backing field for status
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value) // Check if the value is actually changing
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public string UploadedFilePath { get; set; } // Path to the uploaded document

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
