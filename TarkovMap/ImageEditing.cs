using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace TarkovMap
{
	internal class ImageEditing
	{
		//Color of text in the game. Brownish
		private static Color tColor = Color.FromArgb(255, 215, 210, 182);
		private static readonly int threshold = 55;

		private static bool ApproximatelyTextColor(UInt32 color)
		{
			if ((color & 255) >= tColor.B - threshold && (color & 255) <= tColor.B + threshold
				&& ((color >> 8) & 255) >= tColor.G - threshold && ((color >> 8) & 255) <= tColor.G + threshold
				&& ((color >> 16) & 255) >= tColor.R - threshold && ((color >> 16) & 255) <= tColor.R + threshold)
				return true;
			return false;
		}

		//Modifies the image so every pixel that is approximately the color of text is turned white, everything else is turned black
		public static unsafe void IncreaseContrast(ref Bitmap bitmap)
		{
			try
			{
				BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
												ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
				IntPtr intptr = data.Scan0;
				UInt32* ptr = (UInt32*)intptr.ToPointer();
				for (int i = 0; i < data.Width * data.Height; i++)
				{
					if (!ApproximatelyTextColor(ptr[i]))
						ptr[i] = UInt32.MaxValue;
					else
						ptr[i] = 255 >> 24;
				}
				bitmap.UnlockBits(data);
			}
			catch (Exception ex)
			{
				Logger.WriteExceptionLog(ex);
			}
		}
	}
}
