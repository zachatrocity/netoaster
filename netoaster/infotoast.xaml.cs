using System;
using System.Windows;
using System.Windows.Threading;

namespace netoaster
{
    public partial class InfoToaster
    {
        private InfoToaster(FrameworkElement owner, string title, string message, ToasterPosition position, ToasterAnimation animation, double margin)
        {
            InitializeComponent();

            ToasterTitle = title;
            Message = message ?? string.Empty;

            var story = ToastSupport.GetAnimation(animation, InfoToasterInstance);
            story.Completed += (sender, args) => { this.Close(); };
            story.Begin(InfoToasterInstance);

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
            string title = "Info",
            string message = "Something you may notice.",
            ToasterPosition position = ToasterPosition.PrimaryScreenTopRight,
            ToasterAnimation animation = ToasterAnimation.SlideInFromRight,
            double margin = 10.0)
        {
            var toaster = new InfoToaster(owner, title, message, position, animation, margin) {ShowActivated = false};
            toaster.Show();
        }
    }
}