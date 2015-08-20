using System.Windows;

namespace netoaster
{
    public class Toaster : Window
    {
        public static readonly DependencyProperty ToasterTitleProperty =
            DependencyProperty.Register("Title",
                typeof (string), typeof (Toaster),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message",
                typeof (string), typeof (Toaster),
                new PropertyMetadata(string.Empty));

        public string ToasterTitle
        {
            get { return (string) GetValue(ToasterTitleProperty); }
            set { SetValue(ToasterTitleProperty, value); }
        }

        public string Message
        {
            get { return (string) GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        protected void Owner_Unloaded(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
