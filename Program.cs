using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SGB_Settings_Editor
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Array.Copy(palettes, default_palettes, 128);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        // #####################################################################################
        // Constants

        // sgb_rev 0: SGB2, 1-4: SGB1
        public static readonly string[] sgbRevisions =
        {
             "Super Game Boy 2 (Japan)", "Super Game Boy (World) (Rev 2)", "Super Game Boy (Japan, USA) (Rev 1)", "Super Game Boy (Japan)", "Super Game Boy (Japan, USA) (Beta)"
        };

        // 16 bit bytewise sum, palette + preset data zero'd out
        // used to calculate the correct checksum for ips patches
        public static readonly int[] sgbChecksums =
        {
            0xD544, 0x4DA1, 0x1701, 0x1242, 0x1700
        };

        // offsets for border data in the rom file. SGB1 offsets are the same for every version
        public static readonly (string name, int tilemap, (int addr, int chunk_length)[] tileset_chunks, int[] palettes, bool compressed)[] borders = new (string, int, (int, int)[], int[], bool)[] {
            ("GB (SGB2)", 0x051800, new (int, int)[] { (0x05C2C0, 0x1000) }, new int[] { 0x56E00, 0x56E20, 0x580C0 }, false),
            ("GB (Pink)", 0x051800, new (int, int)[] { (0x05C2C0, 0x1000) }, new int[] { 0x56E40, 0x56E60, 0x580C0 }, false),
            ("GB (Yellow)", 0x051800, new (int, int)[] { (0x05C2C0, 0x1000) }, new int[] { 0x56E80, 0x56EA0, 0x580C0 }, false),
            ("GB (Green)", 0x051800, new (int, int)[] { (0x05C2C0, 0x1000) }, new int[] { 0x56EC0, 0x56EE0, 0x580C0 }, false),
            ("GB (Blue)", 0x051800, new (int, int)[] { (0x05C2C0, 0x1000) }, new int[] { 0x56F00, 0x56F20, 0x580C0 }, false),
            ("GB (Red)", 0x051800, new (int, int)[] { (0x05C2C0, 0x1000) }, new int[] { 0x56F40, 0x56F60, 0x580C0 }, false),
            ("GB (Black)", 0x051800, new (int, int)[] { (0x05C2C0, 0x1000) }, new int[] { 0x56F80, 0x56FA0, 0x580C0 }, false),
            ("Black (SGB2)", 0x0, new (int, int)[] { (0x0, 0x0) }, new int[] { 0, 0, 0 }, false),
            ("Printed Circuit Board", 0x052000, new (int, int)[] { (0x059100, 0x1D00) }, new int[] { 0x57080, 0x570A0, 0x570C0 }, false),
            ("Palm Trees", 0x067000, new (int, int)[] { (0x063000, 0x4000) }, new int[] { 0x67880, 0x678A0, 0x678C0 }, false),
            ("Stone Mosaic", 0x052800, new (int, int)[] { (0x04E000, 0x16E0), (0x04C000, 0x2000) }, new int[] { 0x57480, 0x574A0, 0x574C0 }, false),
            ("Gears", 0x06d000, new (int, int)[] { (0x068000, 0x5000) }, new int[] { 0x67A80, 0x67AA0, 0x67AC0 }, false),
            ("Swamp", 0x053000, new (int, int)[] { (0x048000, 0x4000) }, new int[] { 0x57A80, 0x57AA0, 0x57AC0 }, false),
            ("Dolphins", 0x053800, new (int, int)[] { (0x05CCC0, 0x30C0) }, new int[] { 0x57C80, 0x57CA0, 0x57CC0 }, false),
            ("Chess Arena", 0x054800, new (int, int)[] { (0x050000, 0x1000), (0x055800, 0x2000) }, new int[] { 0x57880, 0x578A0, 0x578C0 }, false),
            ("GB (SGB1)", 0x01E261, new (int, int)[] { (0x01D868, 0x2000) }, new int[] { 0x27071, 0x27091, 0x270B1 }, true),
            ("Black (SGB1)", 0x0, new (int, int)[] { (0x0, 0x0) }, new int[] { 0, 0, 0 }, false),
            ("Windows (SGB1)", 0x01AEA5, new (int, int)[] { (0x018000, 0x2000) }, new int[] { 0x1B4F4, 0x1B514, 0x1B534 }, true),
            ("Cork Board (SGB1)", 0x025F12, new (int, int)[] { (0x025335, 0x2000) }, new int[] { 0x2611C, 0x2613C, 0x2615C }, true),
            ("Log Cabin In The Countryside (SGB1)", 0x01C660, new (int, int)[] { (0x01B674, 0x2000) }, new int[] { 0x1D5E8, 0x1D608, 0x1D628 }, true),
            ("Movie Theater (SGB1)", 0x02DC3C, new (int, int)[] { (0x02C6C8, 0x2000) }, new int[] { 0x2D8BC, 0x2D8DC, 0x2D8FC }, true),
            ("Cats (SGB1)", 0x020B27, new (int, int)[] { (0x01F716, 0x2000) }, new int[] { 0x20DF3, 0x20E13, 0x20E33 }, true),
            ("Chequered Desk With Pencils (SGB1)", 0x02997a, new (int, int)[] { (0x028000, 0x2000) }, new int[] { 0x29C21, 0x29E41, 0x29C61 }, true),
            ("Escher (SGB1)", 0x01E3cd, new (int, int)[] { (0x01E90a, 0x2000) }, new int[] { 0x1E78A, 0x1E7AA, 0x1E7CA }, true),
        };

        // assembly code to set the button type
        private static readonly byte[] buttonTypeA = new byte[] { 0xA9, 0x01, 0x8D, 0x04, 0x0C, 0x9C, 0x4D, 0x0C, 0x9C, 0x4E, 0x0C, 0xEA };
        private static readonly byte[] buttonTypeB = new byte[] { 0x9C, 0x04, 0x0C, 0x9C, 0x4D, 0x0C, 0x9C, 0x4E, 0x0C, 0x9C, 0x2D, 0x0C };

        // #####################################################################################
        // Static variables to store data

        // SGB palette colors in 15bit BGR format
        private static ushort[] palettes = new ushort[] {
            26559, 9819, 4277, 10342, 25467, 15065, 2390, 0, 32543, 10877, 12531, 19687, 22527, 9752, 31, 106,
            23423, 16143, 8749, 4331, 32699, 10812, 21, 2304, 10240, 30336, 495, 12287, 29631, 18175, 272, 102,
            21310, 9784, 485, 0, 32767, 11199, 223, 11274, 32543, 17981, 29903, 19621, 21503, 992, 223, 10240,
            17215, 29394, 12357, 2082, 32762, 10847, 20, 3, 7917, 8540, 17148, 96, 32767, 24311, 14798, 0,
            20319, 25358, 5535, 12582, 25467, 4636, 320, 2112, 26300, 16383, 32480, 11396, 24574, 16060, 801, 0,
            25599, 14044, 4598, 14634, 26095, 32191, 863, 8456, 11116, 32767, 7385, 7, 21500, 7983, 3625, 97,
            14014, 32431, 26650, 15360, 31678, 12957, 7656, 1059, 29599, 27291, 29331, 1, 24575, 26418, 15785, 9345,
            22399, 16060, 17775, 6272, 27479, 28187, 20496, 7, 3990, 11415, 69, 12800, 26623, 12055, 8752, 5448
        };
        private static ushort[] default_palettes = new ushort[128];
        private static bool palettesChanged = false;

        // Default game presets
        // BALLôôN KID is a misspelling of BALLOON KID
        internal static List<(string game, int n)> gamePresets = new List<(string, int)>
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
        private static bool gamePresetsChanged = false;

        // Save bitmaps for borders that were loaded from file
        public static List<(int i, string name, Bitmap image)> loadedBorders = new List<(int, string, Bitmap)>();

        // #####################################################################################
        // Access functions for static variables

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
                int sfcColor = ConvertRGBtoSFC(palette[j].r, palette[j].g, palette[j].b);
                if (palettes[4 * i + j] != sfcColor)
                {
                    palettes[4 * i + j] = (ushort) ConvertRGBtoSFC(palette[j].r, palette[j].g, palette[j].b);
                    palettesChanged = true;
                }
            }
        }

        // Return single color from palette
        public static ushort GetPaletteValue(int i, int n, bool original = false)
        {
            return original ? default_palettes[4 * i + n] : palettes[4 * i + n];
        }

        // Store game preset in 'gamePresets'
        public static void SetGamePreset((string, int) item, int slot = -1)
        {
            try
            {
                if (slot < 0)
                    gamePresets.Add(item);
                else
                {
                    if (gamePresets[slot] == item)
                        return;
                    gamePresets[slot] = item;
                }
                gamePresetsChanged = true;
            }
            catch { }
        }

        // Store game preset in 'gamePresets'
        public static void RemoveGamePreset(int slot)
        {
            try
            {
                gamePresets.RemoveAt(slot);
                gamePresetsChanged = true;
            }
            catch { }
        }

        // Convert slot name to number
        public static int ConvertSlottoNumber(string slotName)
        {
            try
            {
                int n = (slotName.First() - '1') * 8 + (slotName.Last() - 'A') + 1;
                return n;
            }
            catch
            {
                return -1;
            }
        }

        // #####################################################################################
        // Format conversion functions

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

        // #####################################################################################
        // Data loading from file

        // Load data from SGB rom file
        public static (bool, bool, int, string) LoadDatafromFile(string fileName)
        {
            try
            {
                FileInfo f = new FileInfo(fileName);
                if (f.Length != 0x40000 && f.Length != 0x80000)
                    return (false, false, 0, "Wrong filesize.");

                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    // internal header
                    fs.Seek(0x7FC0, SeekOrigin.Begin);
                    int sgb_rev = 1;
                    byte[] internalTitle = new byte[13];
                    fs.Read(internalTitle, 0, 13);
                    if (!Enumerable.SequenceEqual(internalTitle, System.Text.Encoding.Default.GetBytes("Super GAMEBOY")))
                        return (false, false, 0, "Internal header title doesn't match.");
                    if (fs.ReadByte() == 0x32)
                        sgb_rev = 0;

                    // control type
                    // the byte at offset 0x50B5 happens to work as an indicator for all versions of the hack
                    fs.Seek(0x50B5, SeekOrigin.Begin);
                    bool buttonTypeA = fs.ReadByte() == 0x0C;

                    // palettes
                    List<ushort> colors = new List<ushort> { };
                    fs.Seek(0x10000, SeekOrigin.Begin);
                    for (int i = 0; i < 128; i++)
                    {
                        ushort color = (ushort) (fs.ReadByte() + (fs.ReadByte() << 8));
                        colors.Add(color);
                        if (color > 0x7FFF || color < 0) // invalid bytes || EOF
                        {
                            return (false, false, 0, "Invalid data at offset 0x" + (0x10000 + i * 2).ToString("X5") + ".");
                        }
                    }
                    if (!Enumerable.SequenceEqual(palettes, colors.ToArray()))
                    {
                        palettes = colors.ToArray();
                        palettesChanged = true;
                    }

                    // game presets
                    fs.Seek(0x3F000, SeekOrigin.Begin);
                    List<(string, int)> fileGamePresets = new List<(string, int)>();
                    byte[] gameTitle = new byte[16];
                    for (int i = 0; i < 36; i++)
                    {
                        fs.Read(gameTitle, 0, 16);
                        if (gameTitle[0] == 0xFF && gameTitle[1] == 0xFF) // FF FF terminator
                            break;
                        fileGamePresets.Add((System.Text.Encoding.Default.GetString(gameTitle).TrimEnd('\0'), fs.ReadByte()));
                    }
                    if (!Enumerable.SequenceEqual(gamePresets, fileGamePresets))
                    {
                        gamePresets = fileGamePresets;
                        gamePresetsChanged = true;
                    }

                    // borders
                    loadBorders(fs, sgb_rev);
                    int border = 0;
                    fs.Seek(0x3F281, SeekOrigin.Begin);
                    int b3F281 = fs.ReadByte();
                    fs.Seek(0x01, SeekOrigin.Current);
                    int b3F283 = fs.ReadByte(); // 0xFF for SGB1 borders
                    fs.Seek(0x02, SeekOrigin.Current);
                    int b3F286 = fs.ReadByte(); // # for SGB1 borders

                    if (sgb_rev > 0 && b3F281 > 0) // sgb1 (b3F281 should always be correct)
                        border = b3F283 == 0x03 ? b3F281 - 1 : b3F286 - 1;
                    else if (b3F283 == 0xD1) // gb color variant
                        border = b3F281;
                    else if (b3F283 == 0xFF) // sgb1 border on sgb2
                        border = b3F286 + 14;
                    else if (b3F281 > 0) // normal sgb2 border
                        border = b3F281 + 5;

                    return (true, buttonTypeA, border, "success");
                }
            }
            catch
            {
                return (false, false, 0, "File system error. Check if file is locked.");
            }
        }

        // Like LoadDatafromFile, but don't change any settings
        public static bool loadImagesfromFile(string fileName)
        {
            try
            {
                FileInfo f = new FileInfo(fileName);
                if (f.Length != 0x40000 && f.Length != 0x80000)
                    return false;

                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    // internal header
                    fs.Seek(0x7FC0, SeekOrigin.Begin);
                    int sgb_rev = 1;
                    byte[] internalTitle = new byte[13];
                    fs.Read(internalTitle, 0, 13);
                    if (!Enumerable.SequenceEqual(internalTitle, System.Text.Encoding.Default.GetBytes("Super GAMEBOY")))
                        return false;
                    if (fs.ReadByte() == 0x32)
                        sgb_rev = 0;
                    loadBorders(fs, sgb_rev);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // Load the borders defined in "borders" from the rom file
        // The rom file FileStream is already opened for read by LoadFromFile()
        private static void loadBorders(FileStream fs, int sgb_rev)
        {
            // Clear loadedBorders first
            foreach ((int i, string name, Bitmap image) border in loadedBorders)
            {
                border.image.Dispose(); // help out the garbage collection
            }
            loadedBorders.Clear();

            for (int i = (sgb_rev == 0 ? 0 : 15); i < borders.Length; i++)
            {
                try
                {
                    var border = borders[i];
                    Bitmap bg = new Bitmap(256, 224);
                    Graphics g = Graphics.FromImage(bg);

                    // Shortcut for the empty borders
                    if (border.tilemap == 0)
                    {
                        g.Clear(Color.Black);
                        loadedBorders.Add((i, borders[i].name, bg));
                        continue;
                    }

                    // Load tilemap and tileset
                    byte[] tilemap, tileset;
                    if (!border.compressed)
                    {
                        tilemap = new byte[0x700];
                        fs.Seek(border.tilemap, SeekOrigin.Begin);
                        fs.Read(tilemap, 0, 0x700);

                        int pos = 0, tileset_size = border.tileset_chunks.Aggregate(0, (a, b) => a + b.chunk_length);
                        tileset = new byte[tileset_size];
                        foreach (var (addr, chunk_length) in border.tileset_chunks)
                        {
                            fs.Seek(addr, SeekOrigin.Begin);
                            fs.Read(tileset, pos, chunk_length);
                            pos += chunk_length;
                        }
                    }
                    else
                    {
                        // Decompress data
                        // We could check the exact amount of data we need to read, but it's faster to always read a safe amount of bytes
                        byte[] data = new byte[0x2000];
                        fs.Seek(border.tilemap, SeekOrigin.Begin);
                        fs.Read(data, 0, 0x700);
                        tilemap = SGBCompression.Decompress(data);
                        fs.Seek(border.tileset_chunks[0].addr, SeekOrigin.Begin);
                        fs.Read(data, 0, 0x2000);
                        tileset = SGBCompression.Decompress(data);
#if DEBUG
                        //File.WriteAllBytes("tilemap.bin", tilemap);
                        //File.WriteAllBytes("tiledata.bin", tileset);
#endif
                    }

                    // Load palettes
                    Color[][] palettes = new Color[16][];
                    palettes[0] = new Color[16];
                    for (int j = 0; j < 3; j++)
                    {
                        palettes[j + 4] = loadCGRAMPalette(fs, border.palettes[j]);
                    }

                    // Load tiles and assemble the image
                    Dictionary<int, DirectBitmap> tilecache = new Dictionary<int, DirectBitmap>(); // a tile atlas would be faster
                    for (int j = 0; j < 896; j++)
                    {
                        // info on tilemap format: https://en.wikibooks.org/wiki/Super_NES_Programming/Graphics_tutorial
                        int tile_dataLo = tilemap[2 * j];
                        int tile_dataHi = tilemap[2 * j + 1];
                        int tile_data = tile_dataLo + (tile_dataHi << 8);
                        int tile_id = tile_data & 0x1FF;
                        int palette_id = (tile_dataHi & 0x1C) >> 2;
                        bool h_flip = (tile_dataHi & (1 << 6)) != 0;
                        bool v_flip = (tile_dataHi & (1 << 7)) != 0;
                        if (!tilecache.ContainsKey(tile_data))
                        {
                            DirectBitmap newt = tile(tileset, tile_id, palettes[palette_id]);
                            if (h_flip)
                                newt.Bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            if (v_flip)
                                newt.Bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            tilecache.Add(tile_data, newt);
                        }
                        DirectBitmap t = tilecache[tile_data];
                        g.DrawImage(t.Bitmap, new Point((j & 0x1F) << 3, j >> 5 << 3));
                    }

                    foreach (KeyValuePair<int, DirectBitmap> t in tilecache)
                    {
                        t.Value.Dispose(); // necessary for DirectBitmap
                    }

                    loadedBorders.Add((i, borders[i].name, bg));
                }
                catch { }
            }
        }

        // Load palette from rom file
        private static Color[] loadCGRAMPalette(FileStream fs, int address)
        {
            Color[] palette = new Color[16];

            fs.Seek(address, SeekOrigin.Begin);
            byte[] buffer = new byte[4];
            for (int i = 0; i < 16; i++)
            {
                fs.Read(buffer, 0, 2);
                palette[i] = ConvertTupletoColor(ConvertSFCtoRGB(BitConverter.ToInt32(buffer, 0)));
            }

            return palette;
        }

        // Load 8x8 pixel tile from rom file
        // Each pixel is stored as a 4bpp palette number, with the bits distributed over 4 separate bytes (4bpp planar, composite)
        // DirectBitmap is used for performance reasons because Bitmap.SetPixel() is painfully slow
        private static DirectBitmap tile(byte[] tileset, int n, Color[] pal)
        {
            n *= 0x20;
            DirectBitmap tile = new DirectBitmap(8, 8);
            byte[] b = tileset.Skip(n).Take(32).ToArray();
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

        // Read GB game name
        // ignores SGB enhanced and GBC exclusive games
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

        // #####################################################################################
        // Data saving to file

        // Modify SGB rom file
        public static (bool, string) SavetoFile(string fileName, bool setButtonTypeA, int border = -1)
        {
            try
            {
                FileInfo f = new FileInfo(fileName);
                int checksum = 0;
                int complement = 0;

                if (f.Length != 0x40000 && f.Length != 0x80000)
                {
                    return (false, "Wrong filesize.");
                }

                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    // internal header
                    fs.Seek(0x7FC0, SeekOrigin.Begin);
                    int sgb_rev = 1;
                    byte[] internalTitle = new byte[13];
                    fs.Read(internalTitle, 0, 13);
                    if (!Enumerable.SequenceEqual(internalTitle, System.Text.Encoding.Default.GetBytes("Super GAMEBOY")))
                        return (false, "Internal header title doesn't match.");
                    if (fs.ReadByte() == 0x32)
                        sgb_rev = 0;

                    // backup file before making changes
                    File.Copy(fileName, fileName + ".bak", true);

                    // control type
                    fs.Seek(0x50B1, SeekOrigin.Begin);
                    fs.Write(setButtonTypeA ? buttonTypeA : buttonTypeB, 0, 12);

                    // palettes
                    fs.Seek(0x10000, SeekOrigin.Begin);
                    byte[] paletteData = new byte[0x100];
                    for (int i = 0; i < palettes.Length; i++)
                    {
                        byte[] bytes = BitConverter.GetBytes(palettes[i]);
                        paletteData[2 * i] = bytes[0];
                        paletteData[2 * i + 1] = bytes[1];
                    }
                    fs.Write(paletteData, 0, 0x100);

                    // game presets
                    fs.Seek(0x3F000, SeekOrigin.Begin);
                    // preset list needs at least 1 entry to trigger the terminator
                    if (gamePresets.Count == 0)
                    {
                        gamePresets.Add(("", 1));
                    }
                    foreach ((string game, int slot) in gamePresets)
                    {
                        byte[] gamePreset = System.Text.Encoding.Default.GetBytes(game.PadRight(17, '\0'));
                        gamePreset[16] = BitConverter.GetBytes(slot)[0];
                        fs.Write(gamePreset, 0, 17);
                    }
                    // terminate list with FF FF
                    // up to 60 presets might be possible, or even more by moving the list to a different location in rom
                    fs.Write(new byte[] { 0xFF, 0xFF }, 0, 2);
                    fs.Write(new byte[17 * (36 - gamePresets.Count())], 0, 17 * (36 - gamePresets.Count())); // overwrite potential old patch data with \0

                    // sgb1 + 2 border change
                    // EXPERIMENTAL
                    // the jump from 00:D0AB happens during ram initialization, jumping later would result in the wrong item highlighted in the menu
                    // but do we skip anything important? no idea. seems to work though
                    if ((sgb_rev == 0 && border > 0) || (sgb_rev > 0 && border > 0 && border != 15))
                    {
                        fs.Seek(0x50AB, SeekOrigin.Begin);
                        // move button initialization ahead
                        fs.Write(setButtonTypeA ? buttonTypeA : buttonTypeB, 0, 12);
                        // then jump to custom code at 87:F270
                        fs.Write(new byte[] { 0x5C, 0x70, 0xF2, 0x87, 0xEA, 0xEA }, 0, 6); // jml $87f270, nop slide

                        fs.Seek(0x03F270, SeekOrigin.Begin);
                        // abort border change if game is SGB enhanced (do all enhanced games have a special border?)
                        fs.Write(new byte[] { 0xA9, 0x03, 0xCD, 0x4C, 0x06, 0xD0, 0x04, 0x5C, 0xBD, 0xD0, 0x00 }, 0, 11); // lda #$03, cmp $064C, bne $f287, jml $00d0bd
                        // enable BG3 for game display
                        fs.Write(new byte[] { 0xA9, 0x16, 0x8D, 0x2C, 0x21 }, 0, 5); // lda #$16, sta $212c
                        if (sgb_rev == 0) // 0 = SGB2
                        {
                            // 7e07ff 00 = new borders, 01 = old borders
                            if (border > 14)
                                fs.Write(new byte[] { 0xA9, 0x01, 0x8D, 0xFF, 0x07 }, 0, 5); // lda #$01; sta $7e07ff
                            // 7e03d1 special colors for GB border
                            else if (border >= 1 && border <= 6)
                                fs.Write(new byte[] { 0xA9, BitConverter.GetBytes(border)[0], 0x8D, 0xD1, 0x03 }, 0, 5); // lda #$0x, sta 7e03d1
                        }
                        byte borderByte = 0x01; // GB border #, starts at 1
                        if (border > 6) // 1 to 6 = special color GB, same # as basic border
                            borderByte = BitConverter.GetBytes((border - 6) % 9 + 1)[0];
                        // store border # to 7e0c03 and 0 to 7e0341 to disable the sfx
                        fs.Write(new byte[] { 0xA9, borderByte, 0x8D, 0x03, 0x0C, 0x9C, 0x41, 0x03 }, 0, 8); // lda #$0x, sta $0c03, stz $0341
                        // jump into border change routine, after the border and audio selection
                        fs.Write(new byte[] { 0x5C, 0x30, 0xDE, 0x00 }, 0, 4); // jml 00de30
                        if (fs.Position < 0x3F290) // overwrite potential old patch data with \0
                            fs.Write(new byte[0x3F290 - (int)fs.Position], 0, 0x3F290 - (int)fs.Position);

                        // keep BG1 (bottom menu) disabled during border transition (lda #$16, sta $212c)
                        fs.Seek(sgb_rev == 0 ? 0x441F8 : 0x4E79, SeekOrigin.Begin);
                        fs.WriteByte(0x16);
                    }
                    else
                    { // remove changes in case file was already patched before
                        fs.Seek(0x50AB, SeekOrigin.Begin);
                        fs.Write(new byte[] { 0xAD, 0x0D, 0x0F, 0xF0, 0x01, 0x60 }, 0, 6);
                        fs.Seek(0x03F270, SeekOrigin.Begin);
                        byte[] zero = new byte[0x3F290 - (int)fs.Position];
                        fs.Write(zero, 0, zero.Length);
                        fs.Seek(sgb_rev == 0 ? 0x441F8 : 0x4E79, SeekOrigin.Begin);
                        fs.WriteByte(0x17);
                    }

                    // write changes to file
                    fs.Flush();

                    // calculate checksum
                    fs.Seek(0, SeekOrigin.Begin);
                    int b = 0;
                    while ((b = fs.ReadByte()) != -1)
                        checksum += b; // checksum can never reach maxint32, so this is fine
                    checksum &= 0x0000FFFF;
                    complement = ~checksum & 0x0000FFFF;

                    fs.Seek(0x7FDC, SeekOrigin.Begin);
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

        // Export to IPS
        // ips format was selected for its simplicity, but bps would be preferable
        // more information about the format: https://zerosoft.zophar.net/ips.php
        // only sections (palettes, button, presets, border) that were changed get saved
        // potential further space saving: make a copy of the initial values and only change bytes that were changed
        public static (bool, string) SaveIPS(int sgb_rev, bool setButtonTypeA, int border = 0)
        {
            if (sgb_rev < 0)
                return (false, "Error. Please select SGB revision.");
            try
            {
                List<byte> ipsData = new List<byte> { 0x50, 0x41, 0x54, 0x43, 0x48 }; // PATCH
                int checksum = sgbChecksums[sgb_rev];
                bool borderChange = border > 0 && (sgb_rev == 0 || (sgb_rev > 0 && border != 15));

                // Control type
                if (setButtonTypeA && !borderChange)
                {
                    checksum += 441;
                    ipsData.AddRange(new byte[] { 0x00, 0x50, 0xB1, 0x00, 0x0C, 0xE8, 0x8E, 0x04, 0x0C, 0xCA, 0x9C, 0x4D, 0x0C, 0x9C, 0x4E, 0x0C, 0xEA });
                }

                // Palettes
                List<byte> paletteData = new List<byte> { 0x01, 0x00, 0x00, 0x01, 0x00 };
                foreach (int bgr15 in palettes)
                {
                    byte[] b = BitConverter.GetBytes(bgr15);
                    checksum += b[0] + b[1];
                    paletteData.AddRange(b.Take(2));
                }

                // Game presets
                List<byte> presetData = new List<byte>();
                presetData.AddRange(new byte[] { 0x03, 0xF0, 0x00, 0x01, 0xCD });
                if (gamePresets.Count == 0)
                {
                    gamePresets.Add(("", 1));
                }
                foreach ((string game, int slot) in gamePresets)
                {
                    byte[] gamePreset = System.Text.Encoding.Default.GetBytes(game.PadRight(17, '\0'));
                    gamePreset[16] = BitConverter.GetBytes(slot)[0];
                    presetData.AddRange(gamePreset);
                }
                presetData.AddRange(new byte[] { 0xFF, 0xFF });
                byte[] presetDataLength = BitConverter.GetBytes(presetData.Count - 5);
                presetData[3] = presetDataLength[1];
                presetData[4] = presetDataLength[0];
                foreach (byte b in presetData.Skip(5))
                    checksum += b;

                // Zero out original presets if necessary, run-length encoded
                if (presetData.Count < 466)
                {
                    byte[] startzero = BitConverter.GetBytes(0x3F000 + presetData.Count - 5);
                    byte[] zeros = BitConverter.GetBytes(466 - presetData.Count);
                    presetData.AddRange(new byte[] { 0x03, startzero[1], startzero[0], 0x00, 0x00, zeros[1], zeros[0], 0x00});
                }

                // Border
                // see SavetoFile() for comments / explanation
                List<byte> borderPart1 = new List<byte>();
                List<byte> borderPart2 = new List<byte>();
                List<byte> borderPart3 = new List<byte>();

                if (borderChange)
                {
                    borderPart1.AddRange(new byte[] { 0x00, 0x50, 0xAB, 0x00, 0x12 });
                    borderPart1.AddRange(setButtonTypeA ? buttonTypeA : buttonTypeB);
                    borderPart1.AddRange(new byte[] { 0x5C, 0x70, 0xF2, 0x87, 0xEA, 0xEA });

                    checksum -= 1414;
                    foreach (byte b in borderPart1.Skip(5))
                        checksum += b;


                    borderPart2.AddRange(new byte[] { 0x03, 0xF2, 0x70, 0x00, 0x1C, 0xA9, 0x03, 0xCD, 0x4C, 0x06, 0xD0, 0x04, 0x5C, 0xBD, 0xD0, 0x00, 0xA9, 0x16, 0x8D, 0x2C, 0x21 });
                    if (sgb_rev == 0)
                    {
                        if (border > 14)
                            borderPart2.AddRange(new byte[] { 0xA9, 0x01, 0x8D, 0xFF, 0x07 });
                        if (border >= 1 && border <= 6)
                            borderPart2.AddRange(new byte[] { 0xA9, BitConverter.GetBytes(border)[0], 0x8D, 0xD1, 0x03 });
                    }
                    byte borderByte = 0x01;
                    if (border > 6)
                        borderByte = BitConverter.GetBytes((border - 6) % 9 + 1)[0];
                    borderPart2.AddRange(new byte[] { 0xA9, borderByte, 0x8D, 0x03, 0x0C, 0x9C, 0x41, 0x03, 0x5C, 0x30, 0xDE, 0x00 });
                    if (borderPart2.Count > 0x21)
                        borderPart2[4] = (byte)(borderPart2.Count - 5);

                    foreach (byte b in borderPart2.Skip(5))
                        checksum += b;

                    if (sgb_rev == 0)
                        borderPart3.AddRange(new byte[] { 0x04, 0x41, 0xF8, 0x00, 0x01 });
                    else
                        borderPart3.AddRange(new byte[] { 0x00, 0x4E, 0x79, 0x00, 0x01 });
                    borderPart3.Add(0x16);
                    checksum -= 1;
                }

                checksum &= 0x0000FFFF;
                int complement = ~checksum & 0x0000FFFF;

                // Assemble patch data in order of file offset
                if (borderChange && sgb_rev > 0)
                    ipsData.AddRange(borderPart3);
                if (borderChange)
                    ipsData.AddRange(borderPart1);
                ipsData.AddRange(new byte[] { 0x00, 0x7F, 0xDC, 0x00, 0x04 });
                ipsData.AddRange(BitConverter.GetBytes(complement).Take(2));
                ipsData.AddRange(BitConverter.GetBytes(checksum).Take(2));
                if (palettesChanged)
                    ipsData.AddRange(paletteData);
                if (gamePresetsChanged)
                    ipsData.AddRange(presetData);
                if (borderChange)
                    ipsData.AddRange(borderPart2);
                if (borderChange && sgb_rev == 0)
                    ipsData.AddRange(borderPart3);
                ipsData.AddRange(new List<byte> { 0x45, 0x4F, 0x46 }); // EOF

                if (ipsData.Count > 17) // only write patch if a section changed
                {
                    String fileName = sgbRevisions[sgb_rev] + " (Custom).ips";
                    System.IO.File.WriteAllBytes(fileName, ipsData.ToArray());
                    return (true, fileName);
                }
                else
                    return (false, "Patch creation cancelled. No changes detected.");
            }
            catch
            {
                return (false, "Error. Patch creation failed.");
            }
        }
    }
}
