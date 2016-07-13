using System.Windows;
using netoaster;
using System;

namespace toasterdemoapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            selectbox.SelectedIndex = 0;
            aniselectbox.SelectedIndex = 0;
        }

        public ToasterPosition CurrentPopupPosition { get; set; }
        public ToasterAnimation CurrentPopupAnimation { get; set; }

        private void ShowError(object sender, RoutedEventArgs e)
        {
            ErrorToaster.Toast(this,title: BuildTitle("Error"), message: BuildMessage(), position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }

        private void ShowSuccess(object sender, RoutedEventArgs e)
        {
            SuccessToaster.Toast(this, title: BuildTitle("Success"), message: BuildMessage(), position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }

        private void ShowWarning(object sender, RoutedEventArgs e)
        {
            WarningToaster.Toast(this, title: BuildTitle("Warning"), message: BuildMessage(), position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }

        private void ShowInfo(object sender, RoutedEventArgs e)
        {
            InfoToaster.Toast(this, title: BuildTitle("Info"), message: BuildMessage(), position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }

        private string BuildTitle(string fallback)
        {
            return String.IsNullOrWhiteSpace(TitleText.Text)
                ? fallback
                : TitleText.Text;
        }

        private string BuildMessage()
        {
            return String.IsNullOrWhiteSpace(MessageText.Text)
                ? "You can show your custom message here"
                : MessageText.Text;
        }
    }
}
