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
        }

        public ToasterPosition CurrentPopupPosition { get; set; }

        private void showerror(object sender, RoutedEventArgs e)
        {
            ErrorToaster.Toast(MessageText.Text, (ToasterPosition)selectbox.SelectedItem);
        }

        private void showsuccess(object sender, RoutedEventArgs e)
        {
            SuccessToaster.Toast(MessageText.Text, (ToasterPosition)selectbox.SelectedItem);
        }

        private void showwarning(object sender, RoutedEventArgs e)
        {
            WarningToaster.Toast(MessageText.Text, (ToasterPosition)selectbox.SelectedItem);
        }
    }
}
