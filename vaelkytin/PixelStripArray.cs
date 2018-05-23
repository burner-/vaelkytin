using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaelkytin
{
    class PixelStripArray
    {

        private PixelStrip[] strips;

        internal PixelStrip[] Strips { get => strips; set => strips = value; }

        public PixelStripArray()
        {
            Strips = new PixelStrip[10];
            for (int i = 0; i < 10; i++)
            {
                Strips[i] = new PixelStrip();
            }
        }

        public PixelStrip GetStrip(int idx)
        {
            if (idx < Strips.Length)
            {
                return Strips[idx];
            }
            else
            {
                return null;
            }
        }

        public void SetStripId(int idx, string id)
        {
            if (idx < Strips.Length)
            {
                if (String.IsNullOrEmpty(id))
                {
                    Strips[idx].Reset();
                }
                else
                {
                    Strips[idx].id = id;
                }
            }
                
        }

        public PixelStrip GetStripById(string id)
        {
            for (int i = 0; i < Strips.Length; i++)
            {
                if (Strips[i].id == id)
                    return Strips[i];
            }
            return null;
        }

        public int GetStripIndexById(string id)
        {
            for (int i = 0; i < Strips.Length; i++)
            {
                if (Strips[i].id == id)
                    return i;
            }
            return -1;
        }
    }
}
