using System;
using System.Windows;
using System.Windows.Threading;

namespace netoaster
{
    public partial class SuccessToaster
    {
        private SuccessToaster(FrameworkElement owner, string title, string message, ToasterPosition position, ToasterAnimation animation, double margin)
        {
            InitializeComponent();

            ToasterTitle = title;
            Message = message ?? string.Empty;

            var story = ToastSupport.GetAnimation(animation, SuccessToasterInstance);
            story.Completed += (sender, args) => { this.Close(); };
            story.Begin(SuccessToasterInstance);

            Dispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
            {
                var topLeftDict = ToastSupport.GetTopandLeft(position, this, margin);
                Top = topLeftDict["Top"];
                Left = topLeftDict["Left"];
            }));

            if (owner != null)
                owner.Unloaded += Owner_Unloaded;
        }

        public static void Toast(
            Window owner,
            string title = "Success",
            string message = "All good.",
            ToasterPosition position = ToasterPosition.PrimaryScreenTopRight,
            ToasterAnimation animation = ToasterAnimation.SlideInFromRight,
            double margin = 10.0)
        {
            var toaster = new SuccessToaster(owner, title, message, position, animation, margin) {ShowActivated = false};
            toaster.Show();
        }
    }
}