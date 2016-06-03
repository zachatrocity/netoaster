using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Matrix = System.Windows.Media.Matrix;
using Point = System.Windows.Point;
using StoryBoard = System.Windows.Media.Animation.Storyboard;

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
        public static StoryBoard GetAnimation(ToasterAnimation animation, ref Grid toaster)
        {
            var story = new Storyboard();

            switch (animation)
            {
                case ToasterAnimation.FadeIn:
                    DoubleAnimation fadein = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(2));
                    fadein.BeginTime = TimeSpan.FromSeconds(0);
                    Storyboard.SetTargetProperty(fadein, new PropertyPath("(UIElement.Opacity)"));
                    story.Children.Add(fadein);
                    DoubleAnimation fadeout = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(2));
                    fadeout.BeginTime = TimeSpan.FromSeconds(4);
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
                        (int) currentAppWindow.Left, (int) currentAppWindow.Top,
                        (int) currentAppWindow.ActualWidth, (int) currentAppWindow.ActualHeight
                        );

                    bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
                    retDict["Left"] = bottomcorner.X - windowRef.ActualWidth - 5;
                    retDict["Top"] = bottomcorner.Y - windowRef.ActualHeight;
                    break;
                case ToasterPosition.ApplicationBottomLeft:
                    workingArea = new Rectangle
                        (
                        (int) currentAppWindow.Left, (int) currentAppWindow.Top,
                        (int) currentAppWindow.ActualWidth, (int) currentAppWindow.ActualHeight
                        );
                    bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
                    retDict["Left"] = currentAppWindow.Left + 5;
                    retDict["Top"] = bottomcorner.Y - windowRef.ActualHeight;
                    break;
                case ToasterPosition.ApplicationTopLeft:
                    workingArea = new Rectangle
                        (
                        (int) currentAppWindow.Left, (int) currentAppWindow.Top,
                        (int) currentAppWindow.ActualWidth, (int) currentAppWindow.ActualHeight
                        );
                    bottomcorner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));
                    topcorner = transform.Transform(new Point(workingArea.Right, workingArea.Top));
                    retDict["Left"] = currentAppWindow.Left;
                    retDict["Top"] = topcorner.Y + 25;
                    break;
                case ToasterPosition.ApplicationTopRight:
                    workingArea = new Rectangle
                        (
                        (int) currentAppWindow.Left, (int) currentAppWindow.Top,
                        (int) currentAppWindow.ActualWidth, (int) currentAppWindow.ActualHeight
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