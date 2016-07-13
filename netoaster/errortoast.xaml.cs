using System;
using System.Windows;
using System.Windows.Threading;

namespace netoaster
{
    public partial class ErrorToaster
    {
        private ErrorToaster(FrameworkElement owner, string title, string message, ToasterPosition position, ToasterAnimation animation,
            double margin)
        {
            InitializeComponent();

            ToasterTitle = title;
            Message = message ?? string.Empty;

            var story = ToastSupport.GetAnimation(animation, ErrorToasterInstance);
            story.Completed += (sender, args) => { Close(); };
            story.Begin(ErrorToasterInstance);

            Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
            {
                var topLeftDict = ToastSupport.GetTopandLeft(position, this, margin);
                Top = topLeftDict["Top"];
                Left = topLeftDict["Left"];
            }));

            if(owner != null)
                owner.Unloaded += Owner_Unloaded;
        }

        public static void Toast(
            Window owner,
            string title = "Error",
            string message = "Something terrible may have just happened and you are being notified of it.",
            ToasterPosition position = ToasterPosition.PrimaryScreenBottomRight,
            ToasterAnimation animation = ToasterAnimation.SlideInFromRight,
            double margin = 10.0)
        {
            var toaster = new ErrorToaster(owner, title, message, position, animation, margin) {ShowActivated = false};
            toaster.Show();
        }
    }
}