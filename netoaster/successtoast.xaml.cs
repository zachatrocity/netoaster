using System;
using System.Windows.Threading;
using netoaster;

public partial class SuccessToaster
{
    private SuccessToaster(string message, ToasterPosition position, double margin)
    {
        InitializeComponent();

        var msgText = (System.Windows.Documents.Run) SuccessToasterInstance.FindName("MessageString");
        if (msgText != null) msgText.Text = message ?? string.Empty;

        Dispatcher.BeginInvoke(DispatcherPriority.DataBind, new Action(() =>
        {
            var topLeftDict = ToastSupport.GetTopandLeft(position, this, margin);
            Top = topLeftDict["Top"];
            Left = topLeftDict["Left"];
        }));
    }

    public static void Toast(string message = "Something terrible may have just happened and you are being notified of it.",
        ToasterPosition position = ToasterPosition.PrimaryScreenBottomRight,
        double margin = 10.0)
    {
        var err = new SuccessToaster(message, position, margin);
        err.Show();
    }

    private void Storyboard_Completed(object sender, EventArgs e)
    {
        this.Close();
    }
}