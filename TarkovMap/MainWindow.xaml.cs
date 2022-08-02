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
using System.Windows.Input;

namespace TarkovMap
{

	/// <summary>
	/// Interaction logic for TrkvHelper.xaml
	/// </summary>
	/// 
	public partial class TarkovMapWindow : Window
	{
		[DllImport("User32.dll")]
		private static extern short GetAsyncKeyState(int vKey);

		private readonly string		ballisticsURL = "https://escapefromtarkov.fandom.com/wiki/Ballistics#Armor_penetration_table";
		private readonly string		marketURL =		"https://tarkov-market.com/";
		private readonly string[]	mapStrings =	new string[] { "Factory", "Shoreline", "Woods", "Interchange", "Customs", "Reserve", "Lighthouse", "Labs"};

		private DispatcherTimer	timer =			new DispatcherTimer();
		private ScreenReader	screenReader =	new ScreenReader();
		private static readonly int PRTSCREEN = 0x2C;

		public TarkovMapWindow()
		{
			InitializeComponent();
			timer.Tick += Timer_Tick;
			timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
			timer.Start();
			webView.ZoomFactor = 0.8;
		}

		//Checks every 500ms if prtscreen was pressed
		private void Timer_Tick(object? sender, EventArgs e)
		{
			short keyState = GetAsyncKeyState(PRTSCREEN);
			bool isPressed = (((keyState >> 15) & 1) == 1) // Is pressed currently
						  || (((keyState >> 0) & 1) == 1); // or was pressed at some point in the past
			if (isPressed)
				LoadNewMap();
		}

		private string LatestScr()
		{
			var dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Escape from Tarkov\Screenshots");
			string latest = "";
			try
			{
				latest = (from f in dir.GetFiles() orderby f.LastWriteTime descending select f).First().FullName;
			}
			catch (Exception ex)
			{
				Logger.WriteExceptionLog(ex);
			}
			return latest;
		}

		private void SetDebugString(string s)
		{
			DebugLabel.Content = s;
			DebugLabel.Width = s.Length * 10;
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
			Thread.Sleep(1200);
			if (!File.Exists(LatestScr()))
			{
				SetDebugString("No screenshots in folder.");
				return;
			}
			Bitmap bmp = new Bitmap(LatestScr());
			//Make two crops of the screenshot, corresponds to the location of the text in the loading screen and the lobby.
			Bitmap crop1 = bmp.Clone(new Rectangle((int)(bmp.Width * 0.44), (int)(bmp.Height * 0.16),
												   (int)(bmp.Width * 0.09), (int)(bmp.Height * 0.04)),
												   System.Drawing.Imaging.PixelFormat.DontCare);
			Bitmap crop2 = bmp.Clone(new Rectangle((int)(bmp.Width * 0.485), (int)(bmp.Height * 0.1),
												   (int)(bmp.Width * 0.14), (int)(bmp.Height * 0.035)),
												   System.Drawing.Imaging.PixelFormat.DontCare);
			ImageEditing.IncreaseContrast(ref crop1);
			ImageEditing.IncreaseContrast(ref crop2);
			string text = screenReader.ReadTextFromImage(crop1);
			text += screenReader.ReadTextFromImage(crop2);
			Map.Source = ToBMI(crop2);
			SetDebugString(text.ToLower());
			crop2.Dispose();
			crop1.Dispose();
			bmp.Dispose();
			foreach (string str in mapStrings)
			{
				if (text.ToLower().Contains(str.ToLower()))
				{
					File.Delete(LatestScr()); //Delete the latest screenshots so the screenshots folder doesn't get cluttered
					string fullPath = Directory.GetCurrentDirectory() + @"\maps\" + str.ToLower() + ".png";
					if (File.Exists(fullPath))
						Map.Source = new BitmapImage(new Uri(fullPath, UriKind.RelativeOrAbsolute));
					else
						SetDebugString("No file named " + str.ToLower() + ".png found in 'maps' folder.");
					MapScaleTransform().ScaleX = 1.0;
					MapScaleTransform().ScaleY = 1.0;
					MapTranslateTransform().X = 0;
					MapTranslateTransform().Y = 0;
				}
			}
		}


		#region WPF EventHandlers
		private void Close_Click(object sender, RoutedEventArgs e)
		{
			if (webgrid.Visibility == Visibility.Hidden)
				webgrid.Visibility = Visibility.Visible;
			else
				webgrid.Visibility = Visibility.Hidden;
		}

		private void Ballistics_Click(object sender, RoutedEventArgs e)
		{
			if (webgrid.Visibility == Visibility.Hidden)
				webgrid.Visibility = Visibility.Visible;
			if (webView.Source.ToString() != ballisticsURL)
				webView.Source = new Uri(ballisticsURL);
		}

		private void Market_Click(object sender, RoutedEventArgs e)
		{
			if (webgrid.Visibility == Visibility.Hidden)
				webgrid.Visibility = Visibility.Visible;
			if (webView.Source.ToString() != marketURL)
				webView.Source = new Uri(marketURL);
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

		private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.Enter)
				webView.Source = new Uri("https://www.google.com/search?q=" + URLBox.Text);
		}

		private void webView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
		{
			LoadLabel.Visibility = Visibility.Hidden;
		}

		private void webView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
		{
			LoadLabel.Visibility = Visibility.Visible;
		}

		private void WikiSearch_GotFocus(object sender, RoutedEventArgs e)
		{
			WikiSearch.Text = "";
		}

		private void WikiSearch_LostFocus(object sender, RoutedEventArgs e)
		{
			WikiSearch.Text = "Search Wiki";
		}

		private void WikiSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				Keyboard.ClearFocus();
				FocusManager.SetFocusedElement(FocusManager.GetFocusScope(WikiSearch), null);
			}

			if (e.Key == Key.Return)
			{
				if (webgrid.Visibility == Visibility.Hidden)
					webgrid.Visibility = Visibility.Visible;
				webView.Source = new Uri("https://escapefromtarkov.fandom.com/wiki/Special:Search?query=" + WikiSearch.Text);
				Keyboard.ClearFocus();
				FocusManager.SetFocusedElement(FocusManager.GetFocusScope(WikiSearch), null);
			}
		}

		private void WikiSearchButton_Click(object sender, RoutedEventArgs e)
		{
			if (webgrid.Visibility == Visibility.Hidden)
				webgrid.Visibility = Visibility.Visible;
			webView.Source = new Uri("https://escapefromtarkov.fandom.com/wiki/Special:Search?query=" + WikiSearch.Text);
			Keyboard.ClearFocus();
			FocusManager.SetFocusedElement(FocusManager.GetFocusScope(WikiSearch), null);
		}

		private void Expander_Collapsed(object sender, RoutedEventArgs e)
		{
			if (DebugLabel == null)
				return;
			DebugLabel.Visibility = Visibility.Hidden;
		}

		private void Expander_Expanded(object sender, RoutedEventArgs e)
		{
			if (DebugLabel == null)
				return;
			DebugLabel.Visibility = Visibility.Visible;
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
		#endregion
	}
}
