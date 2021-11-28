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

        private delegate ushort subroutine(ushort A);

        // $00:E629
        // reverse engineered
        private static ushort sub0(ushort A)
        {
            return (ushort)(0x001f - ((0x001f - A) >> 2));
        }

        // $00:E642
        // reverse engineered
        private static ushort sub1(ushort A)
        {
            return (ushort)(0x001f - (((0x001f - A) >> 1) & 0xfffe));
        }

        // $00:E65D
        // reverse engineered
        private static ushort sub2(ushort A)
        {
            A = (ushort)((0x001f - A) >> 2);
            A = (ushort)((A << 1) + A);
            A = (ushort)(0x001f - A);
            return A;
        }

        // $00:E67E
        // reverse engineered
        private static ushort sub3(ushort A)
        {
            return A;
        }

        // $00:E67F
        // reverse engineered
        private static ushort sub4(ushort A)
        {
            A = (ushort)(A >> 2);
            A = (ushort)((A << 1) + A);
            return A;
        }

        // $00:E692
        // reverse engineered
        private static ushort sub5(ushort A)
        {
            return (ushort)((A >> 1) & 0xfffe);
        }

        // $00:E69F
        // reverse engineered
        private static ushort sub6(ushort A)
        {
            return (ushort)(A >> 2);
        }

        // $00:E5B9
        // reverse engineered
        internal static ushort change_shade(ushort base_color, int shade)
        {
            subroutine sub;
            switch (shade)
            {
                case 0:
                    sub = new subroutine(sub0);
                    break;
                case 1:
                    sub = new subroutine(sub1);
                    break;
                case 2:
                    sub = new subroutine(sub2);
                    break;
                case 4:
                    sub = new subroutine(sub4);
                    break;
                case 5:
                    sub = new subroutine(sub5);
                    break;
                case 6:
                    sub = new subroutine(sub6);
                    break;
                default:
                    sub = new subroutine(sub3);
                    break;
            }

            ushort A, cc;
            A = sub((ushort)((base_color >> 10) & 0x001f));
            A = (ushort)(A << 10);
            A = (ushort)((base_color & 0x03ff) | A);
            cc = A;
            A = sub((ushort)((A >> 5) & 0x001f));
            A = (ushort)(A << 5);
            A = (ushort)((cc & 0x7c1f) | A);
            cc = A;
            A = sub((ushort)(A & 0x001f));
            A = (ushort)((cc & 0x7fe0) | A);
            return A;
        }
    }
}
