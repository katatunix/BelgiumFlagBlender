using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belgium
{
	public class Avatar
	{
		private Bitmap belgium;

		public Avatar(Bitmap belgium) {
			this.belgium = belgium;
		}

		public Bitmap blend(Bitmap pic) {
			int w = pic.Width, h = pic.Height;
			Bitmap output = new Bitmap(w, h);
			for (int x = 0; x < w; x++) {
				for (int y = 0; y < h; y++) {
					Color c1 = pic.GetPixel(x, y);

					int x2 = belgium.Width * x / w;
					int y2 = belgium.Height * y / h;
					Color c2 = belgium.GetPixel(x2, y2);

					output.SetPixel(x, y,
						Color.FromArgb(255, (c1.R + c2.R) / 2, (c1.G + c2.G) / 2, (c1.B + c2.B) / 2)
					);
				}
			}
			return output;
		}

	}
}
