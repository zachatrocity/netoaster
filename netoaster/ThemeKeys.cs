using System.Windows;

namespace netoaster
{
    public class ThemeKeys
    {
        public static ComponentResourceKey ToastCardKey
        {
            get { return new ComponentResourceKey(typeof(ThemeKeys), "ToastCard"); }
        }

        public static ComponentResourceKey ToastIconKey
        {
            get { return new ComponentResourceKey(typeof(ThemeKeys), "ToastIcon"); }
        }

        public static ComponentResourceKey ToastIconCanvasKey
        {
            get { return new ComponentResourceKey(typeof(ThemeKeys), "ToastIconCanvas"); }
        }

        public static ComponentResourceKey ToastIconPathKey
        {
            get { return new ComponentResourceKey(typeof(ThemeKeys), "ToastIconPath"); }
        }

        public static ComponentResourceKey ToastTitleKey
        {
            get { return new ComponentResourceKey(typeof(ThemeKeys), "ToastTitle"); }
        }

        public static ComponentResourceKey ToastMessageKey
        {
            get { return new ComponentResourceKey(typeof(ThemeKeys), "ToastMessage"); }
        }
    }
}