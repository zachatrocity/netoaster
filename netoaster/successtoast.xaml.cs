using System;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using netoaster;

public partial class SuccessToaster
{
    private SuccessToaster(string message, ToasterPosition position, ToasterAnimation animation, double margin)
    {
        InitializeComponent();

        var msgText = (System.Windows.Documents.Run) SuccessToasterInstance.FindName("MessageString");
        if (msgText != null) msgText.Text = message ?? string.Empty;

        Storyboard story = ToastSupport.GetAnimation(animation, ref SuccessToasterInstance);
        story.Completed += (sender, args) => { this.Close(); };
        story.Begin(SuccessToasterInstance);

        Dispatcher.BeginInvoke(DispatcherPriority.DataBind, new Action(() =>
        {
            var topLeftDict = ToastSupport.GetTopandLeft(position, this, margin);
            Top = topLeftDict["Top"];
            Left = topLeftDict["Left"];
        }));
    }

    public static void Toast(string message = "Something terrible may have just happened and you are being notified of it.",
        ToasterPosition position = ToasterPosition.PrimaryScreenTopRight, ToasterAnimation animation = ToasterAnimation.SlideInFromRight,
        double margin = 10.0)
    {
        var err = new SuccessToaster(message, position, animation, margin);
        err.Show();
    }

}