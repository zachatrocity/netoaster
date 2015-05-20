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
using System.Windows.Navigation;
using System.Windows.Shapes;


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
        }

        private void showerror(object sender, RoutedEventArgs e)
        {
            var err = new ErrorToaster(MessageText.Text);
            err.Show();
        }

        private void showsuccess(object sender, RoutedEventArgs e)
        {
            var suc = new SuccessToaster(MessageText.Text);
            suc.Show();
        }

        private void showwarning(object sender, RoutedEventArgs e)
        {
            var warn = new WarningToaster(MessageText.Text);
            warn.Show();
        }
    }
}
