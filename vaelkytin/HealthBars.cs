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
            if (percent == 0)
            {
                Strips[idx].SetStripToTwoColorsByPercentAndFlashed(percent, 255, 0, 0, 253, 165, 15, 0);
            }
            else
            {
                Strips[idx].SetStripToTwoColorsByPercentAndFlashed(percent, 0, 0, 0, 253, 165, 15, (byte)flashed);
            }
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
