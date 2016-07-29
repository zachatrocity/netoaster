using System.Windows;
using netoaster;

namespace toasterdemoapp
{
    public partial class MainWindow
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
            Toaster.ShowError(this,title: TitleText.Text, message: MessageText.Text, position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }

        private void ShowSuccess(object sender, RoutedEventArgs e)
        {
            Toaster.ShowSuccess(this, title: TitleText.Text, message: MessageText.Text, position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }

        private void ShowWarning(object sender, RoutedEventArgs e)
        {
            Toaster.ShowWarning(this, title: TitleText.Text, message: MessageText.Text, position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }

        private void ShowInfo(object sender, RoutedEventArgs e)
        {
            Toaster.ShowInfo(this, title: TitleText.Text, message: MessageText.Text, position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }
    }
}
