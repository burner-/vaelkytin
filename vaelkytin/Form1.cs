using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSGSI;
using ArtNet.Packets;

namespace vaelkytin
{
    public partial class Form1 : Form
    {
        Timer updateTimer = new Timer();
        Timer artNetTimer = new Timer();
        byte tick = 0;

        public Form1()
        {
            InitializeComponent();
            updateTimer.Interval = 12;
            updateTimer.Tick += new System.EventHandler(Update);
            updateTimer.Start();
            if (Program.config.ArtNetEnabled)
            {
                artNetTimer.Interval = 90; // DMX can't handle faster than 90ms
                artNetTimer.Tick += new System.EventHandler(ArtNetUpdate);
                artNetTimer.Start();
            }
        }

        public void SetToScreen(int screenNumber)
        {
            Screen[] screens = Screen.AllScreens;

            if (screenNumber >= 0 && screenNumber < screens.Length)
            {
                bool maximised = false;
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                    maximised = true;
                }
                Location = screens[screenNumber].WorkingArea.Location;
                if (maximised)
                {
                    WindowState = FormWindowState.Maximized;
                }
            }
        }

        public void SetAlwaysOnTop()
        {
            TopMost = true;
        }

        public void UnSetAlwaysOnTop()
        {
            TopMost = false;
        }

        public void EnterFullScreenMode()
        {
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        public void LeaveFullScreenMode()
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            WindowState = FormWindowState.Normal;
        }

        private void ArtNetUpdate(object sender, EventArgs e)
        {
            if (Program.config.ArtNetEnabled)
            {
                for (short i = 0; i < Program.healthBars.Count; i++)
                {
                    ArtNetDmxPacket packet = new ArtNetDmxPacket();
                    packet.Universe = (short)i;
                    byte[] stripBytes = Program.healthBars.GetStrip(i).GetAsBytes();
                    packet.DmxData = new byte[stripBytes.Length];
                    if (stripBytes.Length > 0)
                    {
                        Buffer.BlockCopy(stripBytes, 0, packet.DmxData, 0, stripBytes.Length);
                        Program.artNet.Send(packet);
                    }
                }
            }
        }

        private void Update(object sender, EventArgs e)
        {
            tick++;
            for (int i = 0; i < Program.healthBars.Count; i++)
            {
                PixelStrip strip = Program.healthBars.GetStrip(i);
                if(String.IsNullOrEmpty(strip.id))
                {
                    strip.Rainbow(tick);
                }
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int i = 0; i < Program.healthBars.Count; i++)
            {
                PixelStrip strip = Program.healthBars.GetStrip(i);
                RGBPixel[] pixels = strip.GetPixels;
                for (int j = 0; j < pixels.Length; j++)
                {
                    
                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.FromArgb(pixels[j].Red, pixels[j].Green, pixels[j].Blue));
                    e.Graphics.FillRectangle(myBrush, new Rectangle(i, j, 1, 1));
                    myBrush.Dispose();
                }
            }
            
        }
    }
}
