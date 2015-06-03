using System;
using System.Windows;
using System.Windows.Threading;

public partial class WarningToaster
{
    private WarningToaster(string message, string position)
  {
    InitializeComponent();

    var msgText = (System.Windows.Documents.Run)WarningToasterInstance.FindName("MessageString");
	msgText.Text = message;
	
    Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
    {
      var workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
      var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
      var corner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));

      var bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
      var topcorner = transform.Transform(new Point(workingArea.Right, workingArea.Top));

      this.Left = bottomcorner.X - this.ActualWidth - 100;
      if (position == "bottomright")
      {
          this.Top = topcorner.Y - this.ActualHeight;
      }
      else 
      {
          this.Top = topcorner.Y + this.ActualHeight;
      }
    }));
  }

    public static void Toast(string message = "Something terrible may have just happened and you are being notified of it.", string position = "topright")
    { 
        var err = new WarningToaster(message, position);
        err.Show();
       
    }

    private void Storyboard_Completed(object sender, EventArgs e)
    {
        this.Close();
    }

}