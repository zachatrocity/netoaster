using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using Matrix = System.Windows.Media.Matrix;
using Point = System.Windows.Point;

namespace netoaster
{
    public enum ToasterPosition
    {
        PrimaryScreenBottomRight,
        PrimaryScreenTopRight,
        PrimaryScreenBottomLeft,
        PrimaryScreenTopLeft,
        ApplicationBottomRight,
        ApplicationTopRight,
        ApplicationBottomLeft,
        ApplicationTopLeft,
    }
    class ToastSupport
    {
        public static Dictionary<string, double> GetTopandLeft(ToasterPosition positionSelection, Window windowRef, double margin)
        {
            var retDict = new Dictionary<string, double>();
            Rectangle workingArea;
            Point bottomcorner;
            Point topcorner;

            workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            
            var currentAppWindow = Application.Current.MainWindow;
            //Get the Currently running applications screen.
            var screen = System.Windows.Forms.Screen.FromHandle(
                new System.Windows.Interop.WindowInteropHelper(currentAppWindow).Handle);
            
            var workingPosition = positionSelection;
            //Application being maximized causes some wonky crap sometimes. 
            //May as well use Primary Screen. 
            if (currentAppWindow.WindowState == WindowState.Maximized)
            {
                switch (positionSelection)
                {
                    case ToasterPosition.ApplicationBottomRight:
                        workingPosition = ToasterPosition.PrimaryScreenBottomRight;
                        break;
                    case ToasterPosition.ApplicationBottomLeft:
                        workingPosition = ToasterPosition.PrimaryScreenBottomLeft;
                        break;
                    case ToasterPosition.ApplicationTopLeft:
                        workingPosition = ToasterPosition.PrimaryScreenTopLeft;
                        break;
                    case ToasterPosition.ApplicationTopRight:
                        workingPosition = ToasterPosition.PrimaryScreenTopRight;
                        break;
                }
            }
            var transform = getTransform(windowRef);
            
            retDict.Add("Left", 0);
            retDict.Add("Top", 0);
            switch (workingPosition)
            {
                case ToasterPosition.PrimaryScreenBottomLeft:
                    workingArea = screen.WorkingArea;
                    bottomcorner = transform.Transform(new Point(workingArea.Left, workingArea.Bottom));
                    retDict["Left"] = bottomcorner.X + margin;
                    retDict["Top"] = bottomcorner.Y - windowRef.ActualHeight - margin;
                    break;
                case ToasterPosition.PrimaryScreenBottomRight:
                    workingArea = screen.WorkingArea;
                    bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
                    retDict["Left"] = bottomcorner.X - windowRef.ActualWidth - margin;
                    retDict["Top"] = bottomcorner.Y - windowRef.ActualHeight - margin;
                    break;
                case ToasterPosition.PrimaryScreenTopLeft:
                    workingArea = screen.WorkingArea;
                    topcorner = transform.Transform(new Point(workingArea.Right, workingArea.Top));
                    retDict["Left"] = margin;
                    retDict["Top"] = topcorner.Y + margin;
                    break;
                case ToasterPosition.PrimaryScreenTopRight:
                    workingArea = screen.WorkingArea;
                    bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
                    topcorner = transform.Transform(new Point(workingArea.Right, workingArea.Top));
                    retDict["Left"] = bottomcorner.X - windowRef.ActualWidth - margin;
                    retDict["Top"] = topcorner.Y + margin;
                    break;
                case ToasterPosition.ApplicationBottomRight:
                    workingArea = new Rectangle
                        (
                        (int)currentAppWindow.Left, (int)currentAppWindow.Top,
                        (int)currentAppWindow.ActualWidth, (int)currentAppWindow.ActualHeight
                        );
                   
                    bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
                    retDict["Left"] = bottomcorner.X - windowRef.ActualWidth - 5;
                    retDict["Top"] = bottomcorner.Y - windowRef.ActualHeight;
                    break;
                case ToasterPosition.ApplicationBottomLeft:
                    workingArea = new Rectangle
                        (
                        (int)currentAppWindow.Left, (int)currentAppWindow.Top,
                        (int)currentAppWindow.ActualWidth, (int)currentAppWindow.ActualHeight
                        );
                    bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
                    retDict["Left"] = currentAppWindow.Left + 5;
                    retDict["Top"] = bottomcorner.Y - windowRef.ActualHeight;
                    break;
                case ToasterPosition.ApplicationTopLeft:
                    workingArea = new Rectangle
                        (
                        (int)currentAppWindow.Left, (int)currentAppWindow.Top,
                        (int)currentAppWindow.ActualWidth, (int)currentAppWindow.ActualHeight
                        );
                    bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
                    topcorner = transform.Transform(new Point(workingArea.Right, workingArea.Top));
                    retDict["Left"] = currentAppWindow.Left;
                    retDict["Top"] = topcorner.Y + 25;
                    break;
                case ToasterPosition.ApplicationTopRight:
                    workingArea = new Rectangle
                        (
                        (int)currentAppWindow.Left, (int)currentAppWindow.Top,
                        (int)currentAppWindow.ActualWidth, (int)currentAppWindow.ActualHeight
                        );
                    bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
                    topcorner = transform.Transform(new Point(workingArea.Right, workingArea.Top));
                    retDict["Left"] = bottomcorner.X - windowRef.ActualWidth - 5;
                    retDict["Top"] = topcorner.Y+ 25;
                    break;
                default:
                    //ToasterPosition.PrimaryScreenBottomRight
                    workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                    bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
                    topcorner = transform.Transform(new Point(workingArea.Right, workingArea.Top));
                    retDict["Left"] = bottomcorner.X - windowRef.ActualWidth - 100;
                    retDict["Top"] = bottomcorner.Y - windowRef.ActualHeight;
                    break;
            }
            return retDict;

        }

        private static Matrix getTransform(Window windowRef)
        {
            var presentationSource = PresentationSource.FromVisual(windowRef);
            if (presentationSource != null)
            {
                if (presentationSource.CompositionTarget != null)
                {
                    return presentationSource.CompositionTarget.TransformFromDevice;
                }
            }
            return new Matrix();
        }
    }
}
