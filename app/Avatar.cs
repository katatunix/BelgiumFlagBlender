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
			FastBitmap fbBel = new FastBitmap(belgium);
			FastBitmap fbPic = new FastBitmap(pic);
			int w = pic.Width, h = pic.Height;
			Bitmap outBitmap = new Bitmap(w, h);
			FastBitmap fbOut = new FastBitmap(outBitmap);

			fbBel.open();
			fbPic.open();
			fbOut.open(true);

			Parallel.For(0, h, y => {
				for (int x = 0; x < w; x++) {
					Color c1 = fbPic.pixel(x, y);

					int x2 = fbBel.width() * x / w;
					int y2 = fbBel.height() * y / h;
					Color c2 = fbBel.pixel(x2, y2);

					fbOut.pixel(x, y,
						Color.FromArgb(255, (c1.R + c2.R) / 2, (c1.G + c2.G) / 2, (c1.B + c2.B) / 2)
					);
				}
			});

			fbOut.close();
			fbPic.close();
			fbBel.close();
			
			return outBitmap;
		}

	}
}
