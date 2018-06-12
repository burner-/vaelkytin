using System;
using System.IO;
using Newtonsoft.Json;

namespace vaelkytin
{
    [Serializable]
    class Config
    {
        public int DefaultScreen = 0;
        public bool ArtNetEnabled = false;
        public bool Debug = false;
        public bool Fullscreen = true;
        public bool BarsAlwaysOnTop = true;
        public string ArtNetIP = "127.0.0.1";
        public string ArtNetMask = "255.255.255.0";
        public RGBPixel HealthColor = new RGBPixel(249, 166, 2);
        public RGBPixel DamageColor = new RGBPixel(0, 0, 0);
        public RGBPixel DeathColor = new RGBPixel(255, 0, 0);
        public RGBPixel FlashColor = new RGBPixel(255, 255, 255);

        public void Load()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\config.json";
            if (File.Exists(filePath))
            {
                TextReader reader = null;
                try
                {
                    reader = new StreamReader(filePath);
                    var fileContents = reader.ReadToEnd();
                    var conf = JsonConvert.DeserializeObject<Config>(fileContents);
                    Debug = conf.Debug;
                    Fullscreen = conf.Fullscreen;
                    BarsAlwaysOnTop = conf.BarsAlwaysOnTop;
                    ArtNetEnabled = conf.ArtNetEnabled;
                    ArtNetIP = conf.ArtNetIP;
                    ArtNetMask = conf.ArtNetMask;
                    DefaultScreen = conf.DefaultScreen;
                    HealthColor = conf.HealthColor;
                    DamageColor = conf.DamageColor;
                    FlashColor = conf.FlashColor;
                }
                catch (FileNotFoundException e)
                {
                    
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
        }
        public void Save()
        {
            TextWriter writer = null;
            try
            {
                writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\config.json", false);
                writer.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
