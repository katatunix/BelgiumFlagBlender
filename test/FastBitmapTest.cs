using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Belgium;
using System.Drawing;

namespace BelgiumTest
{
	[TestClass]
	public class FastBitmapTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			FastBitmap fb = new FastBitmap(new Bitmap("belgium.bmp"));
			fb.open();
			
			Assert.AreEqual(400, fb.width());
			Assert.AreEqual(400, fb.height());

			Color c = fb.pixel(200, 200);
			Assert.AreNotEqual(0, c.R + c.G + c.B);
			fb.close();
		}
	}
}
