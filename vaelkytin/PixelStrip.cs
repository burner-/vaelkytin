using System;

namespace vaelkytin
{

    class PixelStrip
    {

        private RGBPixel[] pixels;
        public RGBPixel[] GetPixels { get { return pixels; } }
        public string id;
        private byte rainbowTock = 0;

        public PixelStrip()
        {
            id = "";
            pixels = new RGBPixel[100];
            for(int i = 0; i < 100; i++)
            {
                pixels[i] = new RGBPixel(13,13,13);
            }
        }

        public byte[] GetAsBytes()
        {
            byte[] bytes = new byte[pixels.Length * 3];
            for(int i = 0; i < pixels.Length; i++)
            {
                Buffer.BlockCopy(pixels[i].GetBytes, 0, bytes, i * 3, 3);
            }
            return bytes;
        }

        public void Reset()
        {
            id = "";
            rainbowTock = 0;
            for (int i = 0; i < 100; i++)
            {
                SetStripToColor(13, 13, 13);
            }
        }

        private UInt32 Color (byte r, byte g, byte b)
        {
            return (UInt32)((r << 16) + (g << 8) + b);
        }

        public UInt32 Wheel(byte position)
        {
            position = (byte)(255 - position);
            if (position < 85)
            {
                return Color((byte)(255 - position * 3), 0, (byte)(position * 3));
            }
            else if (position < 170)
            {
                position -= 85;
                return Color(0, (byte)(position * 3), (byte)(255 - position * 3));
            }
            else
            {
                position -= 170;
                return Color((byte)(position * 3), (byte)(255 - position * 3), 0);
            }
        }

        public void Rainbow(byte tick)
        {
            for (int i = 0; i < pixels.Length; i++)
            {
                SetPixel(i, Wheel((byte)(((i * 256 / pixels.Length) + rainbowTock) & 255)));
            }
            rainbowTock++;
        }

        public void SetPixel(int idx, UInt32 color)
        {
            pixels[idx].SetColor(color);
        }

        public void SetPixel(int idx, int red, int green, int blue)
        {
            pixels[idx].Red = (byte)red;
            pixels[idx].Green = (byte)green;
            pixels[idx].Blue = (byte)blue;
        }

        public void SetPixel(int idx, byte red, byte green, byte blue)
        {
            pixels[idx].Red = red;
            pixels[idx].Green = green;
            pixels[idx].Blue = blue;
        }

        public void SetPixelRed(int idx) => pixels[idx].SetToRed();

        public void SetPixelGreen(int idx) => pixels[idx].SetToRed();

        public void SetPixelBlue(int idx) => pixels[idx].SetToRed();

        public void SetPixelWhite(int idx) => pixels[idx].SetToRed();

        public void SetPixelBlack(int idx) => pixels[idx].SetToRed();

        public void SetStripRed()
        {
            foreach(RGBPixel p in pixels)
            {
                p.SetToRed();
            }
        }

        public void SetStripGreen()
        {
            foreach (RGBPixel p in pixels)
            {
                p.SetToGreen();
            }
        }

        public void SetStripBlue()
        {
            foreach (RGBPixel p in pixels)
            {
                p.SetToBlue();
            }
        }

        public void SetStripWhite()
        {
            foreach (RGBPixel p in pixels)
            {
                p.SetToWhite();
            }
        }

        public void SetStripBlack()
        {
            foreach (RGBPixel p in pixels)
            {
                p.SetToBlack();
            }
        }

        public void SetStripToColor(byte r, byte g, byte b)
        {
            foreach(RGBPixel p in pixels)
            {
                p.Red = r;
                p.Green = g;
                p.Blue = b;
            }
        }

        public void SetStripToTwoColorsByPercentAndFlashed(int percent, byte r1, byte g1, byte b1, byte r2, byte g2, byte b2, byte flashed = 0)
        {
            UInt32 color1 = Color(Math.Max(flashed, r1), Math.Max(flashed, g1), Math.Max(flashed, b1));
            UInt32 color2 = Color(Math.Max(flashed, r2), Math.Max(flashed, g2), Math.Max(flashed, b2));
            SetStripToTwoColorsByPercent(percent, color1, color2);
        }

        public void SetStripToTwoColorsByPercent(int percent, UInt32 color1, UInt32 color2)
        {
            int numToColor1 = pixels.Length / 100 * (100 - percent);
            for (int i = 0; i < numToColor1; i++)
            {
                SetPixel(i, color1);
            }
            for (int i = numToColor1; i < pixels.Length; i++)
            {
                SetPixel(i, color2);
            }
        }

    }
}
