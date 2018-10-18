using Acr.UserDialogs;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Dimension.ViewModel
{
    public class DimensionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _barcode;
        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; OnPropertyChanged(nameof(Barcode)); }
        }
        private string _width;
        public string Width
        {
            get { return _width; }
            set { _width = value; OnPropertyChanged(nameof(Width)); }
        }
        private string _height;
        public string Height
        {
            get { return _height; }
            set { _height = value; OnPropertyChanged(nameof(Height)); }
        }
        private string _depth;
        public string Depth
        {
            get { return _depth; }
            set { _depth = value; OnPropertyChanged(nameof(Depth)); }
        }
        public ICommand ResetCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public DimensionViewModel()
        {
            ResetCommand = new Command(ResetButtonCommand);
            SaveCommand = new Command(SaveButtonCommand);
        }

        private void SaveButtonCommand(object obj)
        {
            if (string.IsNullOrEmpty(Barcode) || string.IsNullOrEmpty(Width) ||
                string.IsNullOrEmpty(Height) || string.IsNullOrEmpty(Depth) ||
                string.IsNullOrWhiteSpace(Barcode) || string.IsNullOrWhiteSpace(Width) ||
                string.IsNullOrWhiteSpace(Height) || string.IsNullOrWhiteSpace(Depth))
                UserDialogs.Instance.Toast("All fields are required.");
            else
                UserDialogs.Instance.Toast("Dimm (" +
                    Width + " x " +
                    Height + " x " +
                    Depth + ")" +
                    Barcode + " saved");
        }

        private void ResetButtonCommand(object obj)
        {
            Barcode = string.Empty;
            Width = string.Empty;
            Height = string.Empty;
            Depth = string.Empty;
        }
    }
}