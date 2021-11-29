namespace SGB_Settings_Editor
{
    // Convert SGB passwords to color palette
    public static class Passwords
    {
        // The custom colors from the built in palette editor
        private static readonly ushort[] customColors = new ushort[]
        {
            31, 29983, 24792, 17855, 543, 1023, 1008, 608, 32736, 31744, 32363, 32134, 24063, 27295, 12863, 17183, 4991, 12277, 32468, 20454, 32687, 32176, 31157, 4376, 15826, 400, 2679, 1648, 5802, 14912, 11847, 20906, 24875, 20846, 13554, 13874, 10674, 19161, 9779, 8624, 21208, 5781, 7695, 13839, 7722, 16815, 14800, 26425, 17969, 11627, 32767, 0, 0
        };

        // Convert password string to palette colors
        public static (bool valid, bool palette_dependent, int[] colors) ConvertPassword(string password, bool custom_palettes)
        {
            var palette = new int[4];

            password = password.Replace("-", string.Empty);
            if (password.Length != 12)
                return (false, false, palette);

            try
            {
                int[] n = new int[]
                {
                    int.Parse(password.Substring(0, 3)),
                    int.Parse(password.Substring(3, 3)),
                    int.Parse(password.Substring(6, 3)),
                    int.Parse(password.Substring(9, 3))
                };

                bool palette_dependent = false;

                for (int i = 0; i < 4; i++)
                {
                    palette[i] = n[i] < 512 ? BasicColor(n[i], i, custom_palettes) : PaletteBasedColor(n[i], i, custom_palettes);

                    if (n[i] % 64 > 53 || n[i] > 511)
                        palette_dependent = true;
                }

                return (true, palette_dependent, palette);
            }
            catch { }
            return (false, false, palette);
        }

        // Convert number (0 to 511) to color using the built in palette editor colors
        private static ushort BasicColor(int n, int slot, bool custom_palettes)
        {
            if (n < 0 || n > 511)
                return 0;

            if (n % 64 > 52)
                return Program.GetPaletteValue(0, slot, !custom_palettes);

            ushort base_color = customColors[n % 64];
            int shade = n < 448 ? (n / 64) : 3;

            return change_shade(base_color, shade);
        }

        // Convert number (512 to 999) to color using color palettes 1-A to 4-H
        private static ushort PaletteBasedColor(int n, int slot, bool custom_palettes)
        {
            if (n < 512 || n > 999)
                return 0;

            if (n % 64 == 32)
            {
                n -= 32;
            }
            else if (n % 64 > 32 || n > 991)
            {
                n = 0;
            }

            ushort base_color = Program.GetPaletteValue(n % 64, slot, !custom_palettes);
            int shade = n < 960 ? ((n - 512) / 64) : 3;

            return change_shade(base_color, shade);
        }

        private delegate int subroutine(int c);

        // $00:E629
        private static int light3(int c)
        {
            return 24 + (c >> 2);
        }

        // $00:E642
        private static int light2(int c)
        {
            return 17 + 2 * (c >> 2);
        }

        // $00:E65D
        private static int light1(int c)
        {
            return 10 + 3 * (c >> 2);
        }

        // $00:E67E
        private static int nochange(int c)
        {
            return c;
        }

        // $00:E67F
        private static int dark1(int c)
        {
            return 3 * (c >> 2);
        }

        // $00:E692
        private static int dark2(int c)
        {
            return 2 * (c >> 2);
        }

        // $00:E69F
        private static int dark3(int c)
        {
            return c >> 2;
        }

        // $00:E5B9
        // reverse engineered
        internal static ushort change_shade(ushort base_color, int shade)
        {
            subroutine sub;
            switch (shade)
            {
                case 0:
                    sub = new subroutine(light3);
                    break;
                case 1:
                    sub = new subroutine(light2);
                    break;
                case 2:
                    sub = new subroutine(light1);
                    break;
                case 4:
                    sub = new subroutine(dark1);
                    break;
                case 5:
                    sub = new subroutine(dark2);
                    break;
                case 6:
                    sub = new subroutine(dark3);
                    break;
                default:
                    sub = new subroutine(nochange);
                    break;
            }

            int r = base_color & 0x001f;
            int g = (base_color & 0x03e0) >> 5;
            int b = (base_color & 0x7c00) >> 10;
            return (ushort)(sub(r) + (sub(g) << 5) + (sub(b) << 10));
        }
    }
}
