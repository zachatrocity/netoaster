using System.Windows;

namespace netoaster
{
    public static class Toaster
    {
        private static ToasterWindow GetToasterWindow(FrameworkElement owner, ToastType type, string title, string message,
            ToasterPosition position, ToasterAnimation animation, double margin)
        {
            var toaster = new ToasterWindow(owner, title, message, position, animation, margin);
            switch (type)
            {
                case ToastType.Error:
                    toaster.Ico.Data = NotificationIcoPath.Error;
                    toaster.Notification.Background = NotificationColor.Error;
                    break;
                case ToastType.Info:
                    toaster.Ico.Data = NotificationIcoPath.Info;
                    toaster.Notification.Background = NotificationColor.Info;
                    break;
                case ToastType.Warning:
                    toaster.Ico.Data = NotificationIcoPath.Warning;
                    toaster.Notification.Background = NotificationColor.Warning;
                    break;
                case ToastType.Success:
                    toaster.Ico.Data = NotificationIcoPath.Success;
                    toaster.Notification.Background = NotificationColor.Success;
                    break;
            }
            return toaster;
        }

        public static void ShowError(
            Window owner,
            string title = "Error",
            string message = "Something terrible may have just happened and you are being notified of it.",
            ToasterPosition position = ToasterPosition.PrimaryScreenBottomRight,
            ToasterAnimation animation = ToasterAnimation.SlideInFromRight,
            double margin = 10.0)
        {
            var toaster = GetToasterWindow(owner, ToastType.Error, title, message, position, animation, margin);
            toaster.Show();
        }

        public static void ShowInfo(
            Window owner,
            string title = "Info",
            string message = "Something you may notice.",
            ToasterPosition position = ToasterPosition.PrimaryScreenBottomRight,
            ToasterAnimation animation = ToasterAnimation.SlideInFromRight,
            double margin = 10.0)
        {
            var toaster = GetToasterWindow(owner, ToastType.Info, title, message, position, animation, margin);
            toaster.Show();
        }

        public static void ShowSuccess(
            Window owner,
            string title = "Success",
            string message = "All good.",
            ToasterPosition position = ToasterPosition.PrimaryScreenBottomRight,
            ToasterAnimation animation = ToasterAnimation.SlideInFromRight,
            double margin = 10.0)
        {
            var toaster = GetToasterWindow(owner, ToastType.Success, title, message, position, animation, margin);
            toaster.Show();
        }

        public static void ShowWarning(
            Window owner,
            string title = "Warning",
            string message = "Something terrible may have just happened and you are being notified of it.",
            ToasterPosition position = ToasterPosition.PrimaryScreenBottomRight,
            ToasterAnimation animation = ToasterAnimation.SlideInFromRight,
            double margin = 10.0)
        {
            var toaster = GetToasterWindow(owner, ToastType.Warning, title, message, position, animation, margin);
            toaster.Show();
        }
    }
}
