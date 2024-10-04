using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using VietNamNet.Framework.Common.Cryptography;

namespace VietNamNet.Framework.Common.Captcha
{
    /*=================================================================================
     *======================================Notes======================================
     * This code was wrote using an article in the code project web site.
     * Web Site: http://www.codeproject.com
     * Article: Captcha Image
     * 
     * Some changes were done to this code
     *=================================================================================
     *====================================End of Notes=================================
     */

    /// <summary>
    /// Summary description for Captcha
    /// </summary>
    public class CaptchaImage
    {
        // Public properties (all read-only).
        private Color bc;

        private FontFamily[] fonts = {
                                         new FontFamily("Verdana"),
                                         new FontFamily("Times New Roman"),
                                         new FontFamily("Georgia"),
                                         new FontFamily("Arial"),
                                         new FontFamily("Comic Sans MS")
                                     };

        private int height;
        private Bitmap image;
        private string text;
        private int width;

        public CaptchaImage(string s, Color bc, int width, int height)
        {
            text = s;
            this.bc = bc;
            this.width = width;
            this.height = height;
            GenerateImage();
        }

        public string Text
        {
            get { return text; }
        }

        public Color BackgroundColor
        {
            get { return bc; }
        }

        public Bitmap Image
        {
            get { return image; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        // Internal properties.

        ~CaptchaImage()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                // Dispose of the bitmap.
                image.Dispose();
        }

        private void GenerateImage()
        {
            // Create a new 32-bit bitmap image.
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // Create a graphics object for drawing.
            Graphics g = Graphics.FromImage(bitmap);
            Rectangle rect = new Rectangle(0, 0, width, height);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush b = new SolidBrush(bc))
            {
                g.FillRectangle(b, rect);
            }

            // Set up the text font.
            int emSize = (int) (width*2/text.Length);
            FontFamily family = fonts[RNG.Next(fonts.Length - 1)];
            Font font = new Font(family, emSize);
            // Adjust the font size until the text fits within the image.
            SizeF measured = new SizeF(0, 0);
            SizeF workingSize = new SizeF(width, height);
            while (emSize > 2 &&
                   (measured = g.MeasureString(text, font)).Width > workingSize.Width ||
                   measured.Height > workingSize.Height)
            {
                font.Dispose();
                font = new Font(family, emSize -= 2);
            }

            // Set up the text format.
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // Create a path using the text and warp it randomly.
            GraphicsPath path = new GraphicsPath();
            path.AddString(text, font.FontFamily, (int) font.Style, font.Size, rect, format);

            // Set font color to a color that is visible within background color
            int bcR = Convert.ToInt32(bc.R);
            // This prevents font color from being near the bg color
            int red = RNG.Next(255), green = RNG.Next(255), blue = RNG.Next(255);
            while (red >= bcR && red - 20 <= bcR ||
                   red < bcR && red + 20 >= bcR)
            {
                red = RNG.Next(0, 255);
            }
            SolidBrush sBrush = new SolidBrush(Color.FromArgb(red, green, blue));
            g.FillPath(sBrush, path);

            // Iterate over every pixel
            double distort = RNG.Next(3, 10)*(RNG.Next(10) <= 3 ? 1 : -1);

            // Copy the image so that we're always using the original for source color
            using (Bitmap copy = (Bitmap) bitmap.Clone())
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Adds a simple wave
                        int newX = (int) (x + (distort*Math.Sin(Math.PI*y/84.0)));
                        int newY = (int) (y + (distort*Math.Cos(Math.PI*x/44.0)));
                        if (newX < 0 || newX >= width) newX = 0;
                        if (newY < 0 || newY >= height) newY = 0;
                        bitmap.SetPixel(x, y, copy.GetPixel(newX, newY));
                    }
                }
            }

            // Clean up.
            font.Dispose();
            sBrush.Dispose();
            g.Dispose();

            // Set the image.
            image = bitmap;
        }
    }
}