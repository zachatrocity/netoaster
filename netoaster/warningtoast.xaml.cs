using System;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using netoaster;

public partial class WarningToaster
{
    private WarningToaster(string message, ToasterPosition position, ToasterAnimation animation, double margin)
  {
    InitializeComponent();

    var msgText = (System.Windows.Documents.Run)WarningToasterInstance.FindName("MessageString");
    if (msgText != null) msgText.Text = message ?? string.Empty;

    Storyboard story = ToastSupport.GetAnimation(animation, ref WarningToasterInstance);
    story.Completed += (sender, args) => { this.Close(); };
    story.Begin(WarningToasterInstance);

    Dispatcher.BeginInvoke(DispatcherPriority.DataBind, new Action(() =>
    {
        var topLeftDict = ToastSupport.GetTopandLeft(position, this, margin);
        Top = topLeftDict["Top"];
        Left = topLeftDict["Left"];
    }));
  }

    public static void Toast(string message = "Something terrible may have just happened and you are being notified of it.",
            ToasterPosition position = ToasterPosition.PrimaryScreenBottomRight,ToasterAnimation animation = ToasterAnimation.SlideInFromRight,
            double margin = 10.0)
    {
        var err = new WarningToaster(message, position, animation, margin);
        err.Show();
    }

    private void Storyboard_Completed(object sender, EventArgs e)
    {
        this.Close();
    }

}