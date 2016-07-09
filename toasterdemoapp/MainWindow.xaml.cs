using System.Windows;
using netoaster;

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

        private void showerror(object sender, RoutedEventArgs e)
        {
            ErrorToaster.Toast(this,title: "Error", message: MessageText.Text, position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }

        private void showsuccess(object sender, RoutedEventArgs e)
        {
            SuccessToaster.Toast(this, title: "Success", message: MessageText.Text, position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }

        private void showwarning(object sender, RoutedEventArgs e)
        {
            WarningToaster.Toast(this, title: "Warning", message: MessageText.Text, position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }

        private void showinfo(object sender, RoutedEventArgs e)
        {
            InfoToaster.Toast(this, title: "Info", message: MessageText.Text, position: (ToasterPosition)selectbox.SelectedItem, animation: (ToasterAnimation)aniselectbox.SelectedItem, margin: 20.0);
        }
    }
}
