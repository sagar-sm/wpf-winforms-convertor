/*DISCLAIMER:
 * THIS SOFTWARE IS PROVIDED AS-IS AND IS COVERED BY NO WARRANTIES OR GUARANTEES. 
 * DEVELOPED BY: SAGAR MOHITE
 * USE THIS CODE AS AND WHEN YOU LIKE. KINDLY ATTRIBUTE THE DEVELOPER.
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace Compatibility
{
    public class Compatibility
    {
        public static BitmapImage BitmapToBitmapImage(Bitmap img) /* Convert from System.Drawing.Bitmap to Windows.Media.Image */
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();

            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);

            bi.StreamSource = ms;
            bi.EndInit();
            return bi;
        }

        public static System.Drawing.Bitmap BitmapImageToBitmap(BitmapImage source)
        {
            Bitmap bmp = new Bitmap(source.PixelWidth, source.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            source.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bmp.UnlockBits(data);
            return bmp;
            /*
            System.Drawing.Bitmap btm = null;
            int width = srs.PixelWidth;
            int height = srs.PixelHeight;
            int stride = width * ((srs.Format.BitsPerPixel + 7) / 8);
            
            byte[] bits = new byte[height * stride];
            
            srs.CopyPixels(bits, stride, 0);
            
            unsafe
            {
                fixed (byte* pB = bits)
                {
                    IntPtr ptr = new IntPtr(pB);
                    btm = new System.Drawing.Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format24bppRgb, ptr);
                }
            }

            return btm;*/
        }
    }

}