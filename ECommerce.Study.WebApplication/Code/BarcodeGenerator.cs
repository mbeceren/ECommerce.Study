using BarcodeLib;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ECommerce.Study.WebApplication.Code
{
	public static class BarcodeGenerator
	{
		public static byte[] Generate(string code, int width, int height)
		{
			using (Barcode barcode = new Barcode())
			using (Image img = barcode.Encode(TYPE.CODE128, code, width, height))
			using (MemoryStream ms = new MemoryStream())
			{
				img.Save(ms, ImageFormat.Jpeg);
				return ms.ToArray();
			}
		}
	}
}