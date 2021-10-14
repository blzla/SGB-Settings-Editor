using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SGB_Palette_Editor
{
    public static class Program
    {

        /// SGB palette colors in 15bit BGR format
        private static Int32[] palettes = new Int32[] {
            26559, 9819, 4277, 10342, 25467, 15065, 2390, 0, 32543, 10877, 12531, 19687, 22527, 9752, 31, 106,
            23423, 16143, 8749, 4331, 32699, 10812, 21, 2304, 10240, 30336, 495, 12287, 29631, 18175, 272, 102,
            21310, 9784, 485, 0, 32767, 11199, 223, 11274, 32543, 17981, 29903, 19621, 21503, 992, 223, 10240,
            17215, 29394, 12357, 2082, 32762, 10847, 20, 3, 7917, 8540, 17148, 96, 32767, 24311, 14798, 0,
            20319, 25358, 5535, 12582, 25467, 4636, 320, 2112, 26300, 16383, 32480, 11396, 24574, 16060, 801, 0,
            25599, 14044, 4598, 14634, 26095, 32191, 863, 8456, 11116, 32767, 7385, 7, 21500, 7983, 3625, 97,
            14014, 32431, 26650, 15360, 31678, 12957, 7656, 1059, 29599, 27291, 29331, 1, 24575, 26418, 15785, 9345,
            22399, 16060, 17775, 6272, 27479, 28187, 20496, 7, 3990, 11415, 69, 12800, 26623, 12055, 8752, 5448
        };

        public static string[] sgbRevisions =
        {
             "Super Game Boy 2 (Japan)", "Super Game Boy (World) (Rev 2)", "Super Game Boy (Japan, USA) (Rev 1)", "Super Game Boy (Japan)", "Super Game Boy (Japan, USA) (Beta)"
        };

        // 4bit sum of all bytes excluding the palette chunk
        public static int[] sgbChecksums =
        {
            9335, 40148, 26164, 24949, 26163
        };

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        // Convert 24 bit RGB value to 15 bit BGR value
        // Algorithm from: https://wiki.superfamicom.org/palettes
        public static int ConvertRGBtoSFC(int r, int g, int b)
        {
            int bgr15 = (b >> 3 << 10) + (g >> 3 << 5) + (r >> 3);
            return bgr15;
        }

        // Convert 15 bit BGR value to 24 bit RGB value
        // Algorithm from: https://wiki.superfamicom.org/palettes
        public static (int r, int g, int b) ConvertSFCtoRGB(int bgr15)
        {
            if (bgr15 > 0x7FFF)
            {
                return ( 255, 255, 255 );
            }
            int r = bgr15 % 32 << 3;
            int g = (bgr15 >> 5) % 32 << 3;
            int b = bgr15 >> 10 % 32 << 3;
            r += r / 32; /// adjust for higher precision
            g += g / 32;
            b += b / 32;
            return ( r, g, b );
        }

        // Return RGB converted palette data
        public static (int r, int g, int b)[] GetPaletteRGB(int i)
        {
            (int r, int g, int b)[] palette = new (int, int, int)[4];
            for (int j=0; j<4; j++)
            {
                palette[j] = ConvertSFCtoRGB(palettes[4 * i + j]);
            }
            return palette;
        }

        // Store palette in 'palettes'
        public static void SetPaletteRGB(int i, (int r, int g, int b)[] palette)
        {
            for (int j=0; j<4; j++)
            {
                palettes[4 * i + j] = ConvertRGBtoSFC(palette[j].r, palette[j].g, palette[j].b);
            }
        }

        // Convert Color to HSV values
        // Code from stackoverflow by Greg, based on Wikipedia. https://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv
        public static (double, double, double) ColorToHSV(Color color)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));
            return (color.GetHue(), (max == 0) ? 0 : 1d - (1d * min / max), max / 255d);
        }

        // Convert HSV values to Color
        // Code from stackoverflow by Greg, based on Wikipedia. https://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value *= 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(v, t, p);
            else if (hi == 1)
                return Color.FromArgb(q, v, p);
            else if (hi == 2)
                return Color.FromArgb(p, v, t);
            else if (hi == 3)
                return Color.FromArgb(p, q, v);
            else if (hi == 4)
                return Color.FromArgb(t, p, v);
            else
                return Color.FromArgb(v, p, q);
        }

        // Export to IPS
        public static bool SaveIPS(int version, bool buttonTypeA)
        {
            try
            {
                List<byte> ipsData = new List<byte> { 0x50, 0x41, 0x54, 0x43, 0x48 };
                List<byte> paletteData = new List<byte> { 0x01, 0x00, 0x00, 0x01, 0x00 };
                int checksum = sgbChecksums[version];
                if (buttonTypeA)
                {
                    checksum += 441;
                    ipsData.AddRange(new byte[] { 0x00, 0x50, 0xB1, 0x00, 0x0C, 0xE8, 0x8E, 0x04, 0x0C, 0xCA, 0x9C, 0x4D, 0x0C, 0x9C, 0x4E, 0x0C, 0xEA });
                }
                foreach (int bgr15 in palettes)
                {
                    byte[] b = BitConverter.GetBytes(bgr15);
                    checksum += b[0] + b[1];
                    paletteData.AddRange(b.Take(2));
                }
                checksum &= 0x0000FFFF;
                int complement = ~checksum & 0x0000FFFF;
                ipsData.AddRange(new byte[] { 0x00, 0x7F, 0xDC, 0x00, 0x04 });
                ipsData.AddRange(BitConverter.GetBytes(complement).Take(2));
                ipsData.AddRange(BitConverter.GetBytes(checksum).Take(2));
                ipsData.AddRange(paletteData);
                ipsData.AddRange(new List<byte> { 0x45, 0x4F, 0x46 });
                System.IO.File.WriteAllBytes(sgbRevisions[version] + " (Custom Palette).ips", ipsData.ToArray());
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Load data from SGB rom file
        public static (bool, bool, string) LoadfromFile(string fileName)
        {
            try
            {
                FileInfo f = new FileInfo(fileName);
                if (f.Length != 0x40000 && f.Length != 0x80000)
                {
                    return (false, false, "Wrong filesize.");
                }
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    List<int> colors = new List<int> { };

                    fs.Seek(0x50B1, SeekOrigin.Begin); // control type
                    bool buttonTypeA = fs.ReadByte() == 0xE8;

                    fs.Seek(0x10000, SeekOrigin.Begin); // palettes
                    for (int i = 0; i < 128; i++)
                    {
                        int color = fs.ReadByte() + (fs.ReadByte() << 8);
                        colors.Add(color);
                        if (color > 0x7FFF || color < 0) // invalid bytes || EOF
                        {
                            return (false, false, "Invalid data at offset 0x" + (0x10000+i*2).ToString("X5") + ".");
                        }
                    }
                    palettes = colors.ToArray();
                    return (true, buttonTypeA, "success");
                }
            }
            catch
            {
                return (false, false, "File system error. Check if file is locked.");
            }
        }

        // Modify SGB rom file
        public static (bool, string) SavetoFile(string fileName, bool setButtonTypeA)
        {
            try
            {
                FileInfo f = new FileInfo(fileName);
                byte[] goodTitle = new byte[] { 0x53, 0x75, 0x70, 0x65, 0x72, 0x20, 0x47, 0x41, 0x4D, 0x45, 0x42, 0x4F, 0x59 }; // Super GAMEBOY
                byte[] buttonTypeA = new byte[] { 0xE8, 0x8E, 0x04, 0x0C, 0xCA, 0x9C, 0x4D, 0x0C, 0x9C, 0x4E, 0x0C, 0xEA };
                byte[] buttonTypeB = new byte[] { 0x9C, 0x04, 0x0C, 0x9C, 0x4D, 0x0C, 0x9C, 0x4E, 0x0C, 0x9C, 0x2D, 0x0C };
                int checksum = 0;
                int complement = 0;

                if (f.Length != 0x40000 && f.Length != 0x80000)
                {
                    return (false, "Wrong filesize.");
                }

                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    fs.Seek(0x7FC0, SeekOrigin.Begin); // internal header
                    byte[] internalTitle = new byte[13];
                    fs.Read(internalTitle, 0, 13);
                    if (!Enumerable.SequenceEqual(internalTitle, goodTitle))
                    {
                        return (false, "Internal header title doesn't match.");
                    }

                    fs.Seek(0x50B1, SeekOrigin.Begin); // control type
                    fs.Write(setButtonTypeA ? buttonTypeA : buttonTypeB, 0, 12);
                    
                    fs.Seek(0x10000, SeekOrigin.Begin); // palettes
                    byte[] paletteData = new byte[0x100];
                    for (int i=0; i<palettes.Length; i++)
                    {
                        byte[] bytes = BitConverter.GetBytes(palettes[i]);
                        paletteData[2 * i] = bytes[0];
                        paletteData[2 * i + 1] = bytes[1];
                    }
                    fs.Write(paletteData, 0, 0x100);
                    fs.Flush();

                    fs.Seek(0, SeekOrigin.Begin);
                    int b = 0;
                    while ((b = fs.ReadByte()) != -1)
                    {
                        checksum += b;
                        //checksum %= 65536;
                    }
                    checksum &= 0x0000FFFF; // checksum can never reach maxint32, so doing it here is fine
                    complement = ~checksum & 0x0000FFFF;

                    fs.Seek(0x7FDC, SeekOrigin.Begin); // checksum & complement
                    fs.Write(BitConverter.GetBytes(complement), 0, 2);
                    fs.Write(BitConverter.GetBytes(checksum), 0, 2);
                }
                return (true, "Checksum: "+checksum.ToString("X2")+"/"+complement.ToString("X2")+".");
            }
            catch
            {
                return (false, "File access error.");
            }
        }
    }
}
