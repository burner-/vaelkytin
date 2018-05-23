using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaelkytin
{
    class HealthBars : PixelStripArray
    {
        public int Count { get { return Strips.Length; } }
        public int GetHealthIndexBarById(string id)
        {
            return GetStripIndexById(id);
        }
        public void SetHealthBarId(int idx, string id)
        {
            SetStripId(idx, id);
        }
        public void SetHealth(int idx, int percent, int  flashed)
        {
            Strips[idx].SetStripToTwoColorsByPercentAndFlashed(percent, 255, 0, 0, 0, 255, 0, (byte)flashed);
        }
        public void Reset()
        {
            foreach (PixelStrip ps in Strips)
            {
                ps.Reset();
            }
        }
    }
}
