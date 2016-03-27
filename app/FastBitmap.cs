using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belgium
{
	public class FastBitmap
	{
		private Bitmap origin;
		private BitmapData bitmapData;
		private unsafe byte* ptr;
		private int bytesPerPixel;
		
		public FastBitmap(Bitmap origin) {
			this.origin = origin;

		}

		public void open(bool write = false)
		{
			unsafe
			{
				bitmapData = origin.LockBits(
					new Rectangle(0, 0, origin.Width, origin.Height),
					write ? ImageLockMode.ReadWrite : ImageLockMode.ReadOnly, origin.PixelFormat);
				bytesPerPixel = Bitmap.GetPixelFormatSize(origin.PixelFormat) / 8;
				ptr = (byte*)bitmapData.Scan0;
			}
		}

		public void close()
		{
			origin.UnlockBits(bitmapData);
		}

		public Color pixel(int x, int y) {
			unsafe
			{
				byte* p = ptr + y * bitmapData.Stride + x * bytesPerPixel;
				byte alpha = bytesPerPixel <= 3 ? (byte)255 : p[3];
				return Color.FromArgb(alpha, p[2], p[1], p[0]);
			}
		}

		public void pixel(int x, int y, Color color) {
			unsafe
			{
				byte* p = ptr + y * bitmapData.Stride + x * bytesPerPixel;
				p[2] = color.R;
				p[1] = color.G;
				p[0] = color.B;
				if (bytesPerPixel > 3) {
					p[3] = color.A;
				}
			}
		}

		public int width() {
			return bitmapData.Width;
		}

		public int height() {
			return bitmapData.Height;
		}

	}
}
