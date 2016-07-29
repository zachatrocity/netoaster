using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Application = System.Windows.Application;
using Matrix = System.Windows.Media.Matrix;
using Point = System.Windows.Point;
using Rectangle = System.Drawing.Rectangle;
using StoryBoard = System.Windows.Media.Animation.Storyboard;

namespace netoaster
{
    public static class Helper
    {
        public static SolidColorBrush ToSolidColorBrush(this string hex)
        {
            var convertFromString = ColorConverter.ConvertFromString(hex);
            var color = (Color?)convertFromString ?? Colors.Black;
            return new SolidColorBrush(color);
        }
    }
    public static class NotificationIcoPath
    {
        public static readonly Geometry Success = Geometry.Parse("F1 M23.7501 37.25 L34.8334 48.3333 L52.2499 26.1668 L56.9999 30.9168 L34.8334 57.8333 L19.0001 42 L23.7501 37.25 Z ");
        public static readonly Geometry Info = Geometry.Parse("F1 M 38,19C 48.4934,19 57,27.5066 57,38C 57,48.4934 48.4934,57 38,57C 27.5066,57 19,48.4934 19,38C 19,27.5066 27.5066,19 38,19 Z M 33.25,33.25L 33.25,36.4167L 36.4166,36.4167L 36.4166,47.5L 33.25,47.5L 33.25,50.6667L 44.3333,50.6667L 44.3333,47.5L 41.1666,47.5L 41.1666,36.4167L 41.1666,33.25L 33.25,33.25 Z M 38.7917,25.3333C 37.48,25.3333 36.4167,26.3967 36.4167,27.7083C 36.4167,29.02 37.48,30.0833 38.7917,30.0833C 40.1033,30.0833 41.1667,29.02 41.1667,27.7083C 41.1667,26.3967 40.1033,25.3333 38.7917,25.3333 Z ");
        public static readonly Geometry Error = Geometry.Parse("F1 M 31.6667,19L 44.3333,19L 57,31.6667L 57,44.3333L 44.3333,57L 31.6667,57L 19,44.3333L 19,31.6667L 31.6667,19 Z M 26.4762,45.0454L 30.9546,49.5238L 38,42.4783L 45.0454,49.5238L 49.5237,45.0454L 42.4783,38L 49.5238,30.9546L 45.0454,26.4763L 38,33.5217L 30.9546,26.4762L 26.4762,30.9546L 33.5217,38L 26.4762,45.0454 Z ");
        public static readonly Geometry Warning = Geometry.Parse("F1 M 38,19C 48.4934,19 57,27.5066 57,38C 57,48.4934 48.4934,57 38,57C 27.5066,57 19,48.4934 19,38C 19,27.5066 27.5066,19 38,19 Z M 34.0417,25.7292L 36.0208,41.9584L 39.9792,41.9583L 41.9583,25.7292L 34.0417,25.7292 Z M 38,44.3333C 36.2511,44.3333 34.8333,45.7511 34.8333,47.5C 34.8333,49.2489 36.2511,50.6667 38,50.6667C 39.7489,50.6667 41.1667,49.2489 41.1667,47.5C 41.1667,45.7511 39.7489,44.3333 38,44.3333 Z ");
    }
    public static class NotificationColor
    {
        public static readonly SolidColorBrush Success = "#4BA253".ToSolidColorBrush();
        public static readonly SolidColorBrush Info = "#5EAEC5".ToSolidColorBrush();
        public static readonly SolidColorBrush Error = "#C43829".ToSolidColorBrush();
        public static readonly SolidColorBrush Warning = "#FF9400".ToSolidColorBrush();
    }

    public enum ToastType
    {
        Error,
        Info,
        Success,
        Warning
    }
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


    public enum ToasterAnimation
    {
        FadeIn,
        SlideInFromRight,
        SlideInFromLeft,
        SlideInFromTop,
        SlideInFromBottom,
        GrowFromRight,
        GrowFromLeft,
        GrowFromTop,
        GrowFromBottom,
    }

    internal class ToastSupport
    {
        public static StoryBoard GetAnimation(ToasterAnimation animation, UIElement toaster)
        {
            var story = new StoryBoard();

            switch (animation)
            {
                case ToasterAnimation.FadeIn:
                    DoubleAnimation fadein = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(2))
                    {
                        BeginTime = TimeSpan.FromSeconds(0)
                    };
                    Storyboard.SetTargetProperty(fadein, new PropertyPath("(UIElement.Opacity)"));
                    story.Children.Add(fadein);
                    DoubleAnimation fadeout = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(2))
                    {
                        BeginTime = TimeSpan.FromSeconds(4)
                    };
                    Storyboard.SetTargetProperty(fadeout, new PropertyPath("(UIElement.Opacity)"));
                    story.Children.Add(fadeout);
                    break;
                case ToasterAnimation.SlideInFromRight:
                    toaster.RenderTransformOrigin = new Point(1, 0);
                    toaster.RenderTransform = new TranslateTransform(300.0, 0);
                    var slideinFromRightAnimation = new DoubleAnimationUsingKeyFrames
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(6)),
                        KeyFrames = new DoubleKeyFrameCollection
                        {
                            new EasingDoubleKeyFrame(300.0, KeyTime.FromPercent(0)),
                            new EasingDoubleKeyFrame(0.0, KeyTime.FromPercent(0.1), new ExponentialEase
                            {
                                EasingMode = EasingMode.EaseInOut
                            }),
                            new EasingDoubleKeyFrame(0.0, KeyTime.FromPercent(0.8)),
                            new EasingDoubleKeyFrame(300.0, KeyTime.FromPercent(0.9), new ExponentialEase
                            {
                                EasingMode = EasingMode.EaseOut
                            })
                        }
                    };

                    Storyboard.SetTargetProperty(slideinFromRightAnimation,
                        new PropertyPath("RenderTransform.(TranslateTransform.X)"));
                    story.Children.Add(slideinFromRightAnimation);
                    break;
                case ToasterAnimation.SlideInFromLeft:
                    toaster.RenderTransformOrigin = new Point(0, 1);
                    toaster.RenderTransform = new TranslateTransform(-300.0, 0);
                    var slideinFromLeftAnimation = new DoubleAnimationUsingKeyFrames
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(6)),
                        KeyFrames = new DoubleKeyFrameCollection
                        {
                            new EasingDoubleKeyFrame(-300.0, KeyTime.FromPercent(0)),
                            new EasingDoubleKeyFrame(0.0, KeyTime.FromPercent(0.1), new ExponentialEase
                            {
                                EasingMode = EasingMode.EaseInOut
                            }),
                            new EasingDoubleKeyFrame(0.0, KeyTime.FromPercent(0.8)),
                            new EasingDoubleKeyFrame(-300.0, KeyTime.FromPercent(0.9), new ExponentialEase
                            {
                                EasingMode = EasingMode.EaseOut
                            })
                        }
                    };

                    Storyboard.SetTargetProperty(slideinFromLeftAnimation,
                        new PropertyPath("RenderTransform.(TranslateTransform.X)"));
                    story.Children.Add(slideinFromLeftAnimation);
                    break;
                case ToasterAnimation.SlideInFromTop:
                    toaster.RenderTransformOrigin = new Point(0, 1);
                    toaster.RenderTransform = new TranslateTransform(0, 300);
                    var slideinFromTopAnimation = new DoubleAnimationUsingKeyFrames
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(6)),
                        KeyFrames = new DoubleKeyFrameCollection
                        {
                            new EasingDoubleKeyFrame(-300.0, KeyTime.FromPercent(0)),
                            new EasingDoubleKeyFrame(0.0, KeyTime.FromPercent(0.1), new ExponentialEase
                            {
                                EasingMode = EasingMode.EaseInOut
                            }),
                            new EasingDoubleKeyFrame(0.0, KeyTime.FromPercent(0.8)),
                            new EasingDoubleKeyFrame(-300.0, KeyTime.FromPercent(0.9), new ExponentialEase
                            {
                                EasingMode = EasingMode.EaseOut
                            })
                        }
                    };

                    Storyboard.SetTargetProperty(slideinFromTopAnimation,
                        new PropertyPath("RenderTransform.(TranslateTransform.Y)"));
                    story.Children.Add(slideinFromTopAnimation);
                    break;
                case ToasterAnimation.SlideInFromBottom:
                    toaster.RenderTransformOrigin = new Point(0, 1);
                    toaster.RenderTransform = new TranslateTransform(0, -300);
                    var slideinFromBottomAnimation = new DoubleAnimationUsingKeyFrames
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(6)),
                        KeyFrames = new DoubleKeyFrameCollection
                        {
                            new EasingDoubleKeyFrame(300.0, KeyTime.FromPercent(0)),
                            new EasingDoubleKeyFrame(0.0, KeyTime.FromPercent(0.1), new ExponentialEase
                            {
                                EasingMode = EasingMode.EaseInOut
                            }),
                            new EasingDoubleKeyFrame(0.0, KeyTime.FromPercent(0.8)),
                            new EasingDoubleKeyFrame(300.0, KeyTime.FromPercent(0.9), new ExponentialEase
                            {
                                EasingMode = EasingMode.EaseOut
                            })
                        }
                    };

                    Storyboard.SetTargetProperty(slideinFromBottomAnimation,
                        new PropertyPath("RenderTransform.(TranslateTransform.Y)"));
                    story.Children.Add(slideinFromBottomAnimation);
                    break;
                case ToasterAnimation.GrowFromRight:
                    toaster.RenderTransformOrigin = new Point(1, 0);
                    DoubleAnimationUsingKeyFrames growfromright = new DoubleAnimationUsingKeyFrames();
                    growfromright.KeyFrames.Add(new SplineDoubleKeyFrame(0, TimeSpan.FromSeconds(0)));
                    growfromright.KeyFrames.Add(new SplineDoubleKeyFrame(1, TimeSpan.FromSeconds(1.5)));
                    growfromright.KeyFrames.Add(new SplineDoubleKeyFrame(1, TimeSpan.FromSeconds(4)));
                    growfromright.KeyFrames.Add(new SplineDoubleKeyFrame(0, TimeSpan.FromSeconds(5.5)));
                    Storyboard.SetTargetProperty(growfromright,
                        new PropertyPath("RenderTransform.(ScaleTransform.ScaleX)"));
                    story.Children.Add(growfromright);
                    break;
                case ToasterAnimation.GrowFromLeft:
                    toaster.RenderTransformOrigin = new Point(0, 1);
                    DoubleAnimationUsingKeyFrames growfromleft = new DoubleAnimationUsingKeyFrames();
                    growfromleft.KeyFrames.Add(new SplineDoubleKeyFrame(0, TimeSpan.FromSeconds(0)));
                    growfromleft.KeyFrames.Add(new SplineDoubleKeyFrame(1, TimeSpan.FromSeconds(1.5)));
                    growfromleft.KeyFrames.Add(new SplineDoubleKeyFrame(1, TimeSpan.FromSeconds(4)));
                    growfromleft.KeyFrames.Add(new SplineDoubleKeyFrame(0, TimeSpan.FromSeconds(5.5)));
                    Storyboard.SetTargetProperty(growfromleft,
                        new PropertyPath("RenderTransform.(ScaleTransform.ScaleX)"));
                    story.Children.Add(growfromleft);
                    break;
                case ToasterAnimation.GrowFromTop:
                    toaster.RenderTransformOrigin = new Point(1, 0);
                    DoubleAnimationUsingKeyFrames growfromtop = new DoubleAnimationUsingKeyFrames();
                    growfromtop.KeyFrames.Add(new SplineDoubleKeyFrame(0, TimeSpan.FromSeconds(0)));
                    growfromtop.KeyFrames.Add(new SplineDoubleKeyFrame(1, TimeSpan.FromSeconds(1.5)));
                    growfromtop.KeyFrames.Add(new SplineDoubleKeyFrame(1, TimeSpan.FromSeconds(4)));
                    growfromtop.KeyFrames.Add(new SplineDoubleKeyFrame(0, TimeSpan.FromSeconds(5.5)));
                    Storyboard.SetTargetProperty(growfromtop,
                        new PropertyPath("RenderTransform.(ScaleTransform.ScaleY)"));
                    story.Children.Add(growfromtop);
                    break;
                case ToasterAnimation.GrowFromBottom:
                    toaster.RenderTransformOrigin = new Point(0, 1);
                    DoubleAnimationUsingKeyFrames growfrombottom = new DoubleAnimationUsingKeyFrames();
                    growfrombottom.KeyFrames.Add(new SplineDoubleKeyFrame(0, TimeSpan.FromSeconds(0)));
                    growfrombottom.KeyFrames.Add(new SplineDoubleKeyFrame(1, TimeSpan.FromSeconds(1.5)));
                    growfrombottom.KeyFrames.Add(new SplineDoubleKeyFrame(1, TimeSpan.FromSeconds(4)));
                    growfrombottom.KeyFrames.Add(new SplineDoubleKeyFrame(0, TimeSpan.FromSeconds(5.5)));
                    Storyboard.SetTargetProperty(growfrombottom,
                        new PropertyPath("RenderTransform.(ScaleTransform.ScaleY)"));
                    story.Children.Add(growfrombottom);
                    break;
            }

            return story;
        }

        public static Dictionary<string, double> GetTopandLeft(ToasterPosition positionSelection, Window windowRef,
            double margin)
        {
            var retDict = new Dictionary<string, double>();
            Point bottomcorner;
            Point topcorner;

            var workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

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
            var transform = GetTransform(windowRef);
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
                    retDict["Top"] = topcorner.Y + 25;
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

        private static Matrix GetTransform(Visual visual)
        {
            var presentationSource = PresentationSource.FromVisual(visual);
            if (presentationSource.CompositionTarget != null)
            {
                return presentationSource.CompositionTarget.TransformFromDevice;
            }

            return new Matrix();
        }
    }
}