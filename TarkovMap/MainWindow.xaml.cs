using System;
using System.Windows.Threading;
using System.Linq;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Configuration;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Windows.Navigation;
using System.Windows.Media;
using Point = System.Windows.Point;
using Tesseract;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace TarkovMap
{

    /// <summary>
    /// Interaction logic for TrkvHelper.xaml
    /// </summary>
    /// 
    public partial class TrkvHelper : Window
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private static string ballisticsURL = "https://escapefromtarkov.fandom.com/wiki/Ballistics";
        private string[] mapStrings = new string[] { "Factory", "Shoreline", "Woods", "Interchange", "Customs", "Reserve", "Lighthouse", "Labs"};
        private DispatcherTimer timer = new DispatcherTimer();
        private static readonly int PRTSCREEN = 0x2C;
        private static readonly int ESC = 0x1B;

        private string LatestScr()
        {
            var dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Escape from Tarkov\Screenshots");
            var latest = (from f in dir.GetFiles() orderby f.LastWriteTime descending select f).First().FullName;
            return latest;
        }

        private BitmapImage ToBMI(Bitmap bmp)
        {
            BitmapImage bitmapImage;
            using (MemoryStream memory = new MemoryStream())
            {
                bmp.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }
        private void LoadNewMap()
        {
            Thread.Sleep(1000);

            Bitmap bmp = new Bitmap(LatestScr());
            Bitmap clone = bmp.Clone(new Rectangle((int)(bmp.Width * 0.42), (int)(bmp.Height * 0.07),
                                                   (int)(bmp.Width * 0.15), (int)(bmp.Height * 0.125)),
                                                   System.Drawing.Imaging.PixelFormat.DontCare);

            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                var page = engine.Process(clone);
                string text = page.GetText();
                DebugLabel.Content = text;
                foreach (string str in mapStrings)
                {
                    if (text.ToLower().Contains(str.ToLower()))
                    {
                        clone.Dispose();
                        bmp.Dispose();
                        File.Delete(LatestScr());
                        string fullPath = Directory.GetCurrentDirectory() + @"\maps\" + str.ToLower() + ".png";
                        Map.Source = new BitmapImage(
                                new Uri(fullPath, UriKind.RelativeOrAbsolute));
                        MapScaleTransform().ScaleX = 1.0;
                        MapScaleTransform().ScaleY = 1.0;
                        MapTranslateTransform().X = 0;
                        MapTranslateTransform().Y = 0;
                    }
                }
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            short keyState = GetAsyncKeyState(PRTSCREEN);
            bool isPressed = (((keyState >> 15) & 1) == 1) // Is pressed currently
                          || (((keyState >> 0) & 1) == 1); // or was pressed at some point in the past
            if (isPressed)
                LoadNewMap();
        }
        public TrkvHelper()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
            webView.ZoomFactor = 0.8;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (webView.Visibility == Visibility.Hidden)
                webView.Visibility = Visibility.Visible;
            else
                webView.Visibility = Visibility.Hidden;
            if (webView.Source.ToString() != ballisticsURL)
                webView.Source = new Uri(ballisticsURL);
        }

        private ScaleTransform MapScaleTransform()
        {
            return (ScaleTransform)((TransformGroup)Map.RenderTransform).Children.ToArray()[1];
        }

        private TranslateTransform MapTranslateTransform()
        {
            return (TranslateTransform)((TransformGroup)Map.RenderTransform)
                .Children.First(tr => tr is TranslateTransform);
        }
        private void Map_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            double zoom = e.Delta * 0.001;
            MapScaleTransform().ScaleX += zoom;
            MapScaleTransform().ScaleY += zoom;
        }

        Point mouseStart, mouseOrigin;
        private void Map_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Map.CaptureMouse();
            var tt = MapTranslateTransform();
            mouseStart = e.GetPosition(MapBorder);
            mouseOrigin = new Point(tt.X, tt.Y);
        }

        private void Map_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Map.ReleaseMouseCapture();
        }

        private void Map_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tt = MapTranslateTransform();
            MapScaleTransform().ScaleX = 1.0;
            MapScaleTransform().ScaleY = 1.0;
            tt.X = 0;
            tt.Y = 0;
        }

        private void ToggleBorder_Click(object sender, RoutedEventArgs e)
        {
            if (WindowStyle == WindowStyle.SingleBorderWindow)
                WindowStyle = WindowStyle.None;
            else
                WindowStyle = WindowStyle.SingleBorderWindow;
        }

        private void Map_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!Map.IsMouseCaptured)
                return;
            var tt = MapTranslateTransform();
            Vector v = mouseStart - e.GetPosition(MapBorder);
            tt.X = mouseOrigin.X - v.X / MapScaleTransform().ScaleX;
            tt.Y = mouseOrigin.Y - v.Y / MapScaleTransform().ScaleY;
        }
    }
}
