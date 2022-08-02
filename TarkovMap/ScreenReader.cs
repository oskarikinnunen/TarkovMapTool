using System;
using System.Collections.Generic;
using System.Text;
using Tesseract;
using System.Drawing;
using System.Drawing.Imaging;

namespace TarkovMap
{
	internal class ScreenReader
	{
		private TesseractEngine?	engine;

		public ScreenReader ()
		{
			try
			{
				engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
			}
			catch (Exception ex)
			{
				Logger.WriteExceptionLog(ex);
			}
		}

		public string ReadTextFromImage(Bitmap bitmap)
		{
			if (engine == null)
				return "null engine error.";
			// TesseractEngine works better when the image has sufficient dpi,
			// even if it's just hastily scaled up like here.
			Bitmap scaled = new Bitmap(bitmap, new Size(bitmap.Width * 10, bitmap.Height * 10));
			Page page = engine.Process(scaled);
			string result = page.GetText();
			page.Dispose();
			scaled.Dispose();
			return (result);
		}
	}
}
