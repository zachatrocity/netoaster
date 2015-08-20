using System;
using System.Windows;
using System.Windows.Threading;

namespace netoaster
{
    public partial class WarningToaster
    {
        private WarningToaster(FrameworkElement owner, string title, string message, ToasterPosition position,
            ToasterAnimation animation, double margin)
        {
            InitializeComponent();

            ToasterTitle = title;
            Message = message ?? string.Empty;

            var story = ToastSupport.GetAnimation(animation, ref WarningToasterInstance);
            story.Completed += (sender, args) => { Close(); };
            story.Begin(WarningToasterInstance);

            Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
            {
                var topLeftDict = ToastSupport.GetTopandLeft(position, this, margin);
                Top = topLeftDict["Top"];
                Left = topLeftDict["Left"];
            }));

            owner.Unloaded += Owner_Unloaded;
        }

        public static void Toast(
            Window owner,
            string title = "Warning",
            string message = "Something terrible may have just happened and you are being notified of it.",
            ToasterPosition position = ToasterPosition.PrimaryScreenBottomRight,
            ToasterAnimation animation = ToasterAnimation.SlideInFromRight,
            double margin = 10.0)
        {
            var toaster = new WarningToaster(owner, title, message, position, animation, margin);
            toaster.Show();
        }
    }
}