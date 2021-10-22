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

        // SGB palette colors in 15bit BGR format
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

        public static List<(string game, int slot)> gamePresets = new List<(string, int)>
        {
            ("ZELDA", 5),
            ("SUPER MARIOLAND", 6),
            ("MARIOLAND2", 20),
            ("SUPERMARIOLAND3", 2),
            ("KIRBY DREAM LAND", 11),
            ("HOSHINOKA-BI", 11),
            ("KIRBY'S PINBALL", 3),
            ("YOSSY NO TAMAGO", 12),
            ("MARIO & YOSHI", 12),
            ("YOSSY NO COOKIE", 4),
            ("YOSHI'S COOKIE", 4),
            ("DR.MARIO", 18),
            ("TETRIS", 17),
            ("YAKUMAN", 19),
            ("METROID2", 31),
            ("KAERUNOTAMENI", 9),
            ("GOLF", 24),
            ("ALLEY WAY", 22),
            ("BASEBALL", 15),
            ("TENNIS", 23),
            ("F1RACE", 30),
            ("KID ICARUS", 14),
            ("BALLôôN KID", 1),
            ("QIX", 25),
            ("SOLARSTRIKER", 7),
            ("X", 28),
            ("GBWARS", 21)
        };

        public static string[] sgbRevisions =
        {
             "Super Game Boy 2 (Japan)", "Super Game Boy (World) (Rev 2)", "Super Game Boy (Japan, USA) (Rev 1)", "Super Game Boy (Japan)", "Super Game Boy (Japan, USA) (Beta)"
        };

        // 16 bit bytewise sum, palette + preset data zero'd out
        public static int[] sgbChecksums =
        {
            0xD742, 0x4F9F, 0x18FF, 0x1440, 0x18FE
        };

        public static (string name, int tilemap, int tileset, int[] palettes, bool compressed)[] borders = new (string, int, int, int[], bool)[] {
            ("GB (SGB2)", 0x051800, 0x05c2c0, new int[] { 0, 0, 0, 0, 0x58080, 0x57EE0, 0 }, false),
            ("GB (Pink)", 0x051800, 0x05c2c0, new int[] { 0, 0, 0, 0, 0x56E40, 0x56E60, 0 }, false),
            ("GB (Yellow)", 0x051800, 0x05c2c0, new int[] { 0, 0, 0, 0, 0x56E80, 0x56EA0, 0 }, false),
            ("GB (Green)", 0x051800, 0x05c2c0, new int[] { 0, 0, 0, 0, 0x56EC0, 0x56EE0, 0 }, false),
            ("GB (Blue)", 0x051800, 0x05c2c0, new int[] { 0, 0, 0, 0, 0x56F00, 0x56F20, 0 }, false),
            ("GB (Red)", 0x051800, 0x05c2c0, new int[] { 0, 0, 0, 0, 0x56F40, 0x56F60, 0 }, false),
            ("GB (Black)", 0x051800, 0x05c2c0, new int[] { 0, 0, 0, 0, 0x56F80, 0x56FA0, 0 }, false),
            ("Black (SGB2)", 0x0, 0x0, new int[] { 0, 0, 0, 0, 0, 0, 0 }, false),
            ("Printed Circuit Board", 0x052000, 0x059100, new int[] { 0, 0, 0, 0, 0x57080, 0x570A0, 0 }, false),
            ("Palm Trees", 0x067000, 0x063000, new int[] { 0, 0, 0, 0, 0x67880, 0, 0 }, false),
            ("Stone Mosaic", 0x052800, 0x04e000, new int[] { 0, 0, 0, 0, 0x57480, 0, 0 }, false),
            ("Gears", 0x06d000, 0x068000, new int[] { 0, 0, 0, 0, 0x67a80, 0, 0 }, false),
            ("River", 0x053000, 0x048000, new int[] { 0, 0, 0, 0, 0x57a80, 0x57aa0, 0 }, false),
            ("Dolphins", 0x053800, 0x05ccc0, new int[] { 0, 0, 0, 0, 0x57c80, 0, 0 }, false),
            ("Chess Arena", 0x054800, 0x050000, new int[] { 0, 0, 0, 0, 0x57880, 0x578a0, 0 }, false),
            ("GB (SGB1)", 0x01E261, 0x01D868, new int[] { 0, 0, 0, 0, 0x27071, 0, 0 }, true),
            ("Black (SGB1)", 0x0, 0x0, new int[] { 0, 0, 0, 0, 0, 0, 0 }, false),
            ("Windows (SGB1)", 0x01AEA5, 0x018000, new int[] { 0, 0, 0, 0, 0x1b4f4, 0x1b514, 0x1b534 }, true),
            ("Cork Board (SGB1)", 0x025F12, 0x025335, new int[] { 0, 0, 0, 0, 0x2611c, 0, 0 }, true),
            ("Cabin (SGB1)", 0x01C660, 0x01B674, new int[] { 0, 0, 0, 0, 0x1d5e8, 0x1d608, 0 }, true),
            ("Theater (SGB1)", 0x02DC3c, 0x02C6C8, new int[] { 0, 0, 0, 0, 0x2d8bc, 0x2d8dc, 0 }, true),
            ("Cats (SGB1)", 0x020B27, 0x01F716, new int[] { 0, 0, 0, 0, 0x20DF3, 0x20E13, 0 }, true),
            ("Chess Drawing Board (SGB1)", 0x02997a, 0x028000, new int[] { 0, 0, 0, 0, 0x29c21, 0x29e41, 0x29c61 }, true),
            ("Escher (SGB1)", 0x01E3cd, 0x01E90a, new int[] { 0, 0, 0, 0, 0, 0x1e7aa, 0x1e7ca }, true),
        };

        public static List<(string name, Bitmap image)> loadedBorders = new List<(string, Bitmap)>();

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
                return (255, 255, 255);
            }
            int r = bgr15 % 32 << 3;
            int g = (bgr15 >> 5) % 32 << 3;
            int b = bgr15 >> 10 % 32 << 3;
            r += r / 32; /// adjust for higher precision
            g += g / 32;
            b += b / 32;
            return (r, g, b);
        }

        // Convert (r, g, b) tuple to Color
        public static Color ConvertTupletoColor((int r, int g, int b) c)
        {
            return Color.FromArgb(c.r, c.g, c.b);
        }

        // Return RGB converted palette data
        public static (int r, int g, int b)[] GetPaletteRGB(int i)
        {
            (int r, int g, int b)[] palette = new (int, int, int)[4];
            for (int j = 0; j < 4; j++)
            {
                palette[j] = ConvertSFCtoRGB(palettes[4 * i + j]);
            }
            return palette;
        }

        // Store palette in 'palettes'
        public static void SetPaletteRGB(int i, (int r, int g, int b)[] palette)
        {
            for (int j = 0; j < 4; j++)
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

        // Read GB game name
        public static (bool, string) ReadGBName(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    fs.Seek(0x0146, SeekOrigin.Begin);
                    if (fs.ReadByte() == 0x03)
                        return (false, "SGB enhanced game."); // SGB functionality
                    if (fileName.EndsWith(".gbc"))
                    {
                        fs.Seek(0x0143, SeekOrigin.Begin);
                        if (fs.ReadByte() != 0x80)
                            return (false, "GBC exclusive game."); // GBC exclusive
                    }
                    fs.Seek(0x0134, SeekOrigin.Begin);
                    byte[] data = new byte[16];
                    fs.Read(data, 0, 16);
                    return (true, System.Text.Encoding.Default.GetString(data).TrimEnd('\0'));
                }
            }
            catch
            {
                return (false, "File system error.");
            }
        }

        // Convert slot name to number
        public static int ConvertSlottoNumber(string slotName)
        {
            try
            {
                int n = (slotName.First() - '1') * 8 + (slotName.Last() - 'A') + 1;
                if (n < 1 || n > 32)
                    n = -1;
                return n;
            }
            catch
            {
                return -1;
            }
        }

        // Export to IPS
        public static bool SaveIPS(int version, bool buttonTypeA)
        { // todo: make smaller ips patches?
            try
            {
                List<byte> ipsData = new List<byte> { 0x50, 0x41, 0x54, 0x43, 0x48 };
                List<byte> paletteData = new List<byte> { 0x01, 0x00, 0x00, 0x01, 0x00 };
                int checksum = sgbChecksums[version];

                // Control type
                if (buttonTypeA)
                {
                    checksum += 441;
                    ipsData.AddRange(new byte[] { 0x00, 0x50, 0xB1, 0x00, 0x0C, 0xE8, 0x8E, 0x04, 0x0C, 0xCA, 0x9C, 0x4D, 0x0C, 0x9C, 0x4E, 0x0C, 0xEA });
                }

                // Palettes
                foreach (int bgr15 in palettes)
                {
                    byte[] b = BitConverter.GetBytes(bgr15);
                    checksum += b[0] + b[1];
                    paletteData.AddRange(b.Take(2));
                }

                // Game presets
                byte[] presetDataLength = BitConverter.GetBytes(576);
                List<byte> presetData = new List<byte> { 0x03, 0xF0, 0x00, 0x35, 0x03 };
                foreach ((string game, int slot) in gamePresets)
                {
                    byte[] gamePreset = System.Text.Encoding.Default.GetBytes(game.PadRight(17, '\0'));
                    gamePreset[16] = BitConverter.GetBytes(slot)[0];
                    foreach (byte b in gamePreset)
                        checksum += b;
                    presetData.AddRange(gamePreset);
                }
                presetData.AddRange(new byte[] { 0xFF, 0xFF });
                presetData.AddRange(new byte[612 - presetData.Count()]);

                checksum &= 0x0000FFFF;
                int complement = ~checksum & 0x0000FFFF;
                ipsData.AddRange(new byte[] { 0x00, 0x7F, 0xDC, 0x00, 0x04 });
                ipsData.AddRange(BitConverter.GetBytes(complement).Take(2));
                ipsData.AddRange(BitConverter.GetBytes(checksum).Take(2));
                ipsData.AddRange(paletteData);
                ipsData.AddRange(presetData);
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
        public static (bool, bool, int, string) LoadfromFile(string fileName)
        {
            try
            {
                FileInfo f = new FileInfo(fileName);
                if (f.Length != 0x40000 && f.Length != 0x80000)
                {
                    return (false, false, 0, "Wrong filesize.");
                }
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    fs.Seek(0x7FC0, SeekOrigin.Begin); // internal header
                    int sgb_rev = 1;
                    byte[] internalTitle = new byte[13];
                    fs.Read(internalTitle, 0, 13);
                    if (!Enumerable.SequenceEqual(internalTitle, System.Text.Encoding.Default.GetBytes("Super GAMEBOY")))
                        return (false, false, 0, "Internal header title doesn't match.");
                    if (fs.ReadByte() == 0x32)
                        sgb_rev = 0;

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
                            return (false, false, 0, "Invalid data at offset 0x" + (0x10000 + i * 2).ToString("X5") + ".");
                        }
                    }
                    palettes = colors.ToArray();

                    fs.Seek(0x3F000, SeekOrigin.Begin); // game presets
                    gamePresets = new List<(string, int)>();
                    byte[] gameTitle = new byte[16];
                    for (int i = 0; i < 36; i++)
                    {
                        fs.Read(gameTitle, 0, 16);
                        if (gameTitle[0] == 0xFF && gameTitle[0] == gameTitle[1])
                            break;
                        gamePresets.Add((System.Text.Encoding.Default.GetString(gameTitle).TrimEnd('\0'), fs.ReadByte()));
                    }

                    loadBorders(fs, sgb_rev); // borders
                    int border = 0;
                    if (sgb_rev == 0) // only handle SGB 2
                    {
                        fs.Seek(0x3F282, SeekOrigin.Begin);
                        int b3F282 = fs.ReadByte();
                        fs.Seek(0x01, SeekOrigin.Current);
                        int b3F284 = fs.ReadByte(); // 0xFF for SGB1 borders
                        fs.Seek(0x02, SeekOrigin.Current);
                        int b3F287 = fs.ReadByte(); // 0x16 > colored gb
                        fs.Seek(0x04, SeekOrigin.Current);
                        int b3F28C = fs.ReadByte(); // # for SGB1 borders
                        if (b3F284 == 0xD1) // gb color variant
                            border = b3F282;
                        else if (b3F284 == 0xFF) // sgb1 border
                            border = b3F28C + 14;
                        else if (b3F287 > 0) // normal border
                            border = b3F287 + 5;
                    }

                    return (true, buttonTypeA, border, "success");
                }
            }
            catch
            {
                return (false, false, 0, "File system error. Check if file is locked.");
            }
        }

        // Modify SGB rom file
        public static (bool, string) SavetoFile(string fileName, bool setButtonTypeA, int border = -1)
        {
            try
            {
                FileInfo f = new FileInfo(fileName);
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
                    int sgb_rev = 1;
                    byte[] internalTitle = new byte[13];
                    fs.Read(internalTitle, 0, 13);
                    if (!Enumerable.SequenceEqual(internalTitle, System.Text.Encoding.Default.GetBytes("Super GAMEBOY")))
                        return (false, "Internal header title doesn't match.");
                    if (fs.ReadByte() == 0x32)
                        sgb_rev = 0;

                    // backup file before making changes
                    File.Copy(fileName, fileName + ".bak", true);

                    fs.Seek(0x50B1, SeekOrigin.Begin); // control type
                    fs.Write(setButtonTypeA ? buttonTypeA : buttonTypeB, 0, 12);

                    fs.Seek(0x10000, SeekOrigin.Begin); // palettes
                    byte[] paletteData = new byte[0x100];
                    for (int i = 0; i < palettes.Length; i++)
                    {
                        byte[] bytes = BitConverter.GetBytes(palettes[i]);
                        paletteData[2 * i] = bytes[0];
                        paletteData[2 * i + 1] = bytes[1];
                    }
                    fs.Write(paletteData, 0, 0x100);

                    fs.Seek(0x3F000, SeekOrigin.Begin); // game presets
                    foreach ((string game, int slot) in gamePresets)
                    {
                        byte[] gamePreset = System.Text.Encoding.Default.GetBytes(game.PadRight(17, '\0'));
                        gamePreset[16] = BitConverter.GetBytes(slot)[0];
                        fs.Write(gamePreset, 0, 17);
                    }
                    fs.Write(new byte[] { 0xFF, 0xFF }, 0, 2);
                    fs.Write(new byte[17 * (36 - gamePresets.Count())], 0, 17 * (36 - gamePresets.Count())); // overwrite potential old patch data with \0

                    // sgb2 border change
                    // EXPERIMENTAL
                    // code execution never returns to 80:D0B6... is this okay?
                    // todo: switch border after soft reset
                    if (sgb_rev == 0)
                    { // change border only if revision is SGB 2 and border was changed
                        if (border > 0)
                        {
                            fs.Seek(0x50B1, SeekOrigin.Begin);
                            fs.Write(new byte[] { 0x5C, 0x70, 0xF2, 0x87, 0xEA }, 0, 5); // JMP 87:F270 (overwrites write to 7E:0C04)
                            fs.Seek(0x03F270, SeekOrigin.Begin);
                            fs.Write(new byte[] { 0xA9, 0x03, 0xED, 0x4C, 0x06, 0xD0, 0x04, 0x5C, 0xB6, 0xD0, 0x80 }, 0, 11); // abort border change if game is SGB enhanced
                            fs.Write(setButtonTypeA ? buttonTypeA : buttonTypeB, 0, setButtonTypeA ? 5 : 6); // write button initialization here instead (we overwrote it with the jump)
                            if (border > 14) // 7E:07FF 00 = new borders, 01 = old borders
                                fs.Write(new byte[] { 0xA9, 0x01, 0x8D, 0xFF, 0x07 }, 0, 5); // LDA 01; STA 7E:07FF
                            if (border >= 1 && border <= 6) // 7E:03D1 Special colors for GB border
                                fs.Write(new byte[] { 0xA9, BitConverter.GetBytes(border)[0], 0x8D, 0xD1, 0x03 }, 0, 5); // LDA 0x; STA 7E:03D1
                            byte borderByte = 0x01; // GB border
                            if (border > 6) // >6 = not GB, so set it to border #
                                borderByte = BitConverter.GetBytes((border - 6) % 9 + 1)[0];
                            fs.Write(new byte[] { 0xA9, 0x16, 0x8D, 0x2C, 0x21 }, 0, 5); // enable BG3 for game display
                            fs.Write(new byte[] { 0xA9, borderByte, 0x8E, 0x03, 0x0C }, 0, 5); // set border #
                            fs.Write(new byte[] { 0x5C, 0x28, 0xDE, 0x00 }, 0, 4); // call border change routine
                            if (fs.Position < 0x3F293) // overwrite potential old patch data with \0
                                fs.Write(new byte[0x3F293 - (int)fs.Position], 0, 0x3F293 - (int)fs.Position);
                            fs.Seek(0x441F8, SeekOrigin.Begin);
                            fs.WriteByte(0x16); // keep BG1 disabled after fade in
                        }
                        else
                        { // remove changes
                            fs.Seek(0x03F270, SeekOrigin.Begin);
                            fs.Write(new byte[0x3F293 - (int)fs.Position], 0, 0x3F293 - (int)fs.Position);
                            fs.Seek(0x441F8, SeekOrigin.Begin);
                            fs.WriteByte(0x17);
                        }
                    }

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
                return (true, "Checksum: " + checksum.ToString("X2") + "/" + complement.ToString("X2") + ".");
            }
            catch
            {
                return (false, "File access error.");
            }
        }

        private static Color[] loadCGRAMPalette(FileStream fs, int address)
        {
            Color[] palette = new Color[16];

            fs.Seek(address, SeekOrigin.Begin);
            byte[] buffer = new byte[4];
            for (int i = 0; i < 16; i++)
            {
                fs.Read(buffer, 0, 2);
                palette[i] = Program.ConvertTupletoColor(Program.ConvertSFCtoRGB(BitConverter.ToInt32(buffer, 0)));
            }
            return palette;
        }

        private static Bitmap tile(FileStream fs, int addr, int n, Color[] pal, List<byte> tileset = null)
        {
            n *= 0x20;
            Bitmap tile = new Bitmap(8, 8);
            byte[] b = new byte[32];
            if (tileset != null)
            {
                b = tileset.Skip(n).Take(32).ToArray();
            }
            else
            {
                long offs = fs.Position;
                fs.Seek(addr + n, SeekOrigin.Begin);
                fs.Read(b, 0, 32);
                fs.Position = offs;
            }
            for (int i = 0; i < 8; i++)
            {
                int bit = 1 << i;
                for (int j = 0; j < 8; j++)
                {
                    int pal_i = ((b[2 * j] & bit) | ((b[2 * j + 1] & bit) << 1) | ((b[2 * j + 16] & bit) << 2) | ((b[2 * j + 17] & bit) << 3)) >> i;
                    tile.SetPixel(7 - i, j, pal[pal_i]);
                }
            }
            return tile;
        }

        private static void loadBorders(FileStream fs, int sgb_rev)
        {
            foreach ((string, Bitmap) border in loadedBorders)
            {
                border.Item2.Dispose(); // help out the garbage collection a bit
            }
            loadedBorders.Clear();
            for (int i = (sgb_rev == 0 ? 0 : 15); i < borders.Length; i++)
            {
                try
                {
                    var border = borders[i];
                    Bitmap bg = new Bitmap(256, 224);
                    Graphics g = Graphics.FromImage(bg);
                    g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

                    if (border.tilemap == 0) // shortcut for the empty borders
                    {
                        g.Clear(Color.Black);
                        loadedBorders.Add((borders[i].name, bg));
                        continue;
                    }

                    // Decompress data
                    List<byte> tileset = null;
                    List<byte> tilemap = null;
                    if (border.compressed)
                    {
                        byte[] data = new byte[0x2000];
                        fs.Seek(border.tilemap, SeekOrigin.Begin);
                        fs.Read(data, 0, 0x1000);
                        tilemap = SGBCompression.Decompress(data);
                        fs.Seek(border.tileset, SeekOrigin.Begin);
                        fs.Read(data, 0, 0x2000);
                        tileset = SGBCompression.Decompress(data);
                        //File.WriteAllBytes("tilemap.bin", tilemap);
                        //File.WriteAllBytes("tiledata.bin", tileset);
                    }

                    // Load palettes
                    Color[][] palettes = new Color[16][];
                    for (int j = 0; j < 7; j++)
                    {
                        palettes[j] = border.palettes[j] > 0 ? loadCGRAMPalette(fs, border.palettes[j]) : new Color[16];
                    }


                    fs.Seek(border.tilemap, SeekOrigin.Begin);
                    Dictionary<int, Bitmap> tilecache = new Dictionary<int, Bitmap>();
                    for (int j = 0; j < 896; j++)
                    {
                        int tile_dataLo = border.compressed ? tilemap[2 * j] : fs.ReadByte();
                        int tile_dataHi = border.compressed ? tilemap[2 * j + 1] : fs.ReadByte();
                        int tile_data = tile_dataLo + (tile_dataHi << 8);
                        int tile_id = tile_data & 0x1FF;
                        int palette_id = (tile_dataHi & 0x1C) >> 2;
                        bool h_flip = (tile_dataHi & (1 << 6)) != 0;
                        bool v_flip = (tile_dataHi & (1 << 7)) != 0;
                        if (!tilecache.ContainsKey(tile_data))
                        {
                            Bitmap newt = tile(fs, border.tileset, tile_id, palettes[palette_id], tileset);
                            if (h_flip)
                                newt.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            if (v_flip)
                                newt.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            tilecache.Add(tile_data, newt);
                        }
                        Bitmap t = tilecache[tile_data];
                        g.DrawImage(t, new Point((j & 0x1F) << 3, j >> 5 << 3));
                    }
                    /*foreach (KeyValuePair<int, Bitmap> t in tilecache)
                    {
                        t.Value.Dispose();
                    }*/
                    loadedBorders.Add((borders[i].name, bg));
                }
                catch { }
            }
        }
    }
}
