using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaelkytin
{
    class RGBPixel
    {
        private byte[] color;

        public byte[] GetBytes { get { return color; } }

        public RGBPixel(byte red, byte green, byte blue)
        {
            color = new byte[3];
            color[0] = red;
            color[1] = green;
            color[2] = blue;
        }

        // Returns the Red component of a 32-bit color
        byte RedC(UInt32 color)
        {
            return (byte)((color >> 16) & 0xFF);
        }

        // Returns the Green component of a 32-bit color
        byte GreenC(UInt32 color)
        {
            return (byte)(color & 0xFF);
        }

        // Returns the Blue component of a 32-bit color
        byte BlueC(UInt32 color)
        {
            return (byte)((color >> 8) & 0xFF);
        }

        public byte Red { get => color[0]; set => color[0] = value; }
        public byte Green { get => color[1]; set => color[1] = value; }
        public byte Blue { get => color[2]; set => color[2] = value; }

        public void SetColor(UInt32 color)
        {
            this.color[0] = RedC(color);
            this.color[1] = GreenC(color);
            this.color[2] = BlueC(color);
        }

        public void SetToRed()
        {
            this.color[1] = this.color[2] = 0;
            this.color[0] = 255;
        }

        public void SetToGreen()
        {
            this.color[0] = this.color[2] = 0;
            this.color[1] = 255;
        }

        public void SetToBlue()
        {
            this.color[0] = this.color[1] = 0;
            this.color[2] = 255;
        }

        public void SetToWhite()
        {
            this.color[0] = this.color[1] = this.color[2] = 255;
        }

        public void SetToBlack()
        {
            this.color[0] = this.color[1] = this.color[2] = 0;
        }
    }
}
