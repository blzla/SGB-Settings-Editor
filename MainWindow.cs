using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace SGB_Palette_Editor
{
    public partial class MainWindow : Form
    {

        private Color[] ActivePalette = new Color[]
        {
            Color.White, Color.LightGray, Color.DarkGray, Color.Black
        };

        private readonly Bitmap[] screenshots =
        {
            Properties.Resources.Tetris,
            Properties.Resources.Mario,
            Properties.Resources.MysticQuest,
            Properties.Resources.MetroidII,
            Properties.Resources.NinjaGaiden,
            Properties.Resources.Mario2,
            Properties.Resources.TripWorld,
            Properties.Resources.Zelda,
            Properties.Resources.WarioLand
        };

        private DateTime timer = new DateTime();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            getPalette(0);
            setColorinputs(ActivePalette[0]);
        }

        // #####################################################################################
        // Color input change events

        private void rgb24value_Change(object sender, EventArgs e)
        {
            if (!textboxRGB.Focused)
                return;
            try
            {
                string rgb_input = textboxRGB.Text;
                if (rgb_input.Length == 0)
                    return;
                if (rgb_input.Substring(0, 1) == "#")
                {
                    rgb_input = rgb_input.Substring(1);
                }
                if (rgb_input.Length < 6)
                {
                    rgb_input = rgb_input.PadRight(6, '0');
                }
                else if (rgb_input.Length == 7)
                {
                    rgb_input = rgb_input.Substring(0, 6);
                    textboxRGB.Text = rgb_input;
                }
                int rgb24 = Int32.Parse(rgb_input, System.Globalization.NumberStyles.HexNumber);
                int r = (rgb24 >> 16) % 256;
                int g = (rgb24 >> 8) % 256;
                int b = rgb24 % 256;
                setColorinputs(Color.FromArgb(r, g, b));
            }
            catch
            {
                Color color = panelActiveColor.BackColor;
                textboxRGB.Text = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            }
        }

        private void bgr15value_Change(object sender, EventArgs e)
        {
            if (!textboxBGR15.Focused)
                return;
            try
            {
                string bgr15_input = textboxBGR15.Text;
                if (bgr15_input.Length == 0)
                    return;
                else if (bgr15_input.Length < 4)
                    bgr15_input = bgr15_input.PadRight(4, '0');
                int bgr15 = Int32.Parse(bgr15_input, System.Globalization.NumberStyles.HexNumber);
                if (bgr15 > 0x7FFF)
                {
                    bgr15 = 0x7FFF;
                    if (textboxBGR15.Text.Length == 4) {
                        textboxBGR15.Text = "7FFF";
                    }
                }
                (int r, int g, int b) = Program.ConvertSFCtoRGB(bgr15);
                setColorinputs(Color.FromArgb(r, g, b), true);
            }
            catch
            {
                Color color = panelActiveColor.BackColor;
                textboxBGR15.Text = Program.ConvertRGBtoSFC(color.R, color.G, color.B).ToString("X4");
            }
        }

        // RGB color inputs

        private void rgbsliderChange(object sender, EventArgs e)
        {
            if (!((TrackBar)sender).Focused)
                return;
            setColorinputs(Color.FromArgb(trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value));
        }

        private void rgbdecBox_TextChanged(object sender, EventArgs e)
        {
            TextBox activeTextBox = (TextBox)sender;
            if (!activeTextBox.Focused)
                return;
            try
            {
                setColorinputs(Color.FromArgb(Int32.Parse(textBoxRDec.Text), Int32.Parse(textBoxGDec.Text), Int32.Parse(textBoxBDec.Text)));
            }
            catch
            {
                try
                {
                    int value = Int32.Parse(activeTextBox.Text);
                    if (value < 0)
                        activeTextBox.Text = "0";
                    else
                        activeTextBox.Text = "255";
                }
                catch
                {
                    activeTextBox.Text = "0";
                }
            }
        }

        private void rgbhexBox_TextChanged(object sender, EventArgs e)
        {
            TextBox activeTextBox = (TextBox)sender;
            if (!activeTextBox.Focused)
                return;
            try
            {
                setColorinputs(Color.FromArgb(Int32.Parse(textBoxRHex.Text, System.Globalization.NumberStyles.HexNumber), Int32.Parse(textBoxGHex.Text, System.Globalization.NumberStyles.HexNumber), Int32.Parse(textBoxBHex.Text, System.Globalization.NumberStyles.HexNumber)));
            }
            catch
            {
                activeTextBox.Text = "00";
            }
        }

        // HSV color inputs

        private void trackBarHSV_ValueChanged(object sender, EventArgs e)
        {
            if (!((TrackBar)sender).Focused)
                return;
            Color color = Program.ColorFromHSV((double)trackBarH.Value, (double)trackBarS.Value / 100, (double)trackBarV.Value / 100);
            setColorinputs(color);
        }

        private void textBoxHSV_TextChanged(object sender, EventArgs e)
        {
            TextBox activeTextBox = (TextBox)sender;
            if (!activeTextBox.Focused)
                return;
            try
            {
                Color color = Program.ColorFromHSV(Double.Parse(textBoxH.Text), Double.Parse(textBoxS.Text) / 100, Double.Parse(textBoxV.Text) / 100);
                setColorinputs(color);
            }
            catch
            {
                try
                {
                    int value = Int32.Parse(activeTextBox.Text);
                    if (value < 0)
                        activeTextBox.Text = "0";
                    else if (activeTextBox == textBoxH)
                        activeTextBox.Text = "360";
                    else
                        activeTextBox.Text = "100";
                }
                catch
                {
                    activeTextBox.Text = "0";
                }
            }
        }

        private void panelActiveColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = panelActiveColor.BackColor;
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                setColorinputs(colorDialog.Color);
            }
        }

        // Update all other input fields after a color change
        private void setColorinputs(Color color, bool safe = false, bool all = false)
        {
            if (!textboxRGB.Focused || all)
                textboxRGB.Text = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            if (!textboxBGR15.Focused || all)
                textboxBGR15.Text = Program.ConvertRGBtoSFC(color.R, color.G, color.B).ToString("X4");
            if (!trackBarRed.Focused || all)
                trackBarRed.Value = color.R;
            if (!trackBarGreen.Focused || all)
                trackBarGreen.Value = color.G;
            if (!trackBarBlue.Focused || all)
                trackBarBlue.Value = color.B;
            if (!textBoxRDec.Focused || all)
                textBoxRDec.Text = color.R.ToString();
            if (!textBoxRHex.Focused || all)
                textBoxRHex.Text = color.R.ToString("X2");
            if (!textBoxGDec.Focused || all)
                textBoxGDec.Text = color.G.ToString();
            if (!textBoxGHex.Focused || all)
                textBoxGHex.Text = color.G.ToString("X2");
            if (!textBoxBDec.Focused || all)
                textBoxBDec.Text = color.B.ToString();
            if (!textBoxBHex.Focused || all)
                textBoxBHex.Text = color.B.ToString("X2");

            (double hue, double saturation, double value) = Program.ColorToHSV(color);
            if (!trackBarH.Focused || all)
                trackBarH.Value = (int)Math.Round(hue);
            if (!trackBarS.Focused || all)
                trackBarS.Value = (int)Math.Round(saturation * 100);
            if (!trackBarV.Focused || all)
                trackBarV.Value = (int)Math.Round(value * 100);
            if (!textBoxH.Focused || all)
                textBoxH.Text = trackBarH.Value.ToString();
            if (!textBoxS.Focused || all)
                textBoxS.Text = trackBarS.Value.ToString();
            if (!textBoxV.Focused || all)
                textBoxV.Text = trackBarV.Value.ToString();

            if (!safe)
            { // display SFC safe color, but show 24 bit values in input fields to avoid confusion
                (int r, int g, int b) = Program.ConvertSFCtoRGB(Program.ConvertRGBtoSFC(color.R, color.G, color.B));
                color = Color.FromArgb(r, g, b);
            }
            panelActiveColor.BackColor = color;
        }

        // #####################################################################################
        // Palette

        // Load palette from Program.palettes
        private void getPalette(int i)
        {
            (int r, int g, int b)[] palette = Program.GetPaletteRGB(i);
            for (int j=0; j<4; j++)
            {
                ActivePalette[j] = Color.FromArgb(palette[j].r, palette[j].g, palette[j].b);
                panelPalettebg.Controls[j].BackColor = ActivePalette[j];
            }
            
            pictureBox.Refresh();
            buttonSetPalette.Enabled = false;
        }

        // Save palette in Program.palettes
        private void setPalette(int i)
        {
            (int r, int g, int b)[] palette = new (int, int, int)[4];
            for (int j=0; j<4; j++)
            {
                palette[j] = (ActivePalette[j].R, ActivePalette[j].G, ActivePalette[j].B);
            }
            Program.SetPaletteRGB(i, palette);
            buttonSetPalette.Enabled = false;
        }

        // Move edited color to palette
        private void buttonSetColor_Click(object sender, EventArgs e)
        {
            int i = ((Button)sender).Name[11] - '1';
            ActivePalette[i] = panelActiveColor.BackColor;
            panelPalettebg.Controls[i].BackColor = panelActiveColor.BackColor;
            pictureBox.Refresh();
            buttonSetPalette.Enabled = true;
        }

        // Move colors from palette to edit
        private void panelColor_Click(object sender, EventArgs e)
        {
            setColorinputs(ActivePalette[((Panel)sender).Name[10] - '1'], true, true);
        }

        // Palette slot selection changed
        private void comboBoxPaletteslot_SelectedValueChanged(object sender, EventArgs e)
        {
            getPalette(comboBoxPaletteslot.SelectedIndex);
            buttonSetPalette.Text = "Set as " + comboBoxPaletteslot.Text;
            toolStripStatusLabel.Text = "Switched to palette " + comboBoxPaletteslot.SelectedItem;
            resetStatusText(3000);
        }

        // Store edited palette
        private void buttonSetPalette_Click(object sender, EventArgs e)
        {
            setPalette(comboBoxPaletteslot.SelectedIndex);
            buttonSetPalette.Enabled = false;
        }

        // Couple Set and Reset button states
        private void buttonSetPalette_EnabledChanged(object sender, EventArgs e)
        {
            buttonReset.Enabled = buttonSetPalette.Enabled;
        }

        // Undo changes
        private void buttonReset_Click(object sender, EventArgs e)
        {
            getPalette(comboBoxPaletteslot.SelectedIndex);
        }

        // #####################################################################################
        // Clipboard

        // Load / store from swatch
        private void storagepanelClick(object sender, EventArgs e)
        {
            if (groupBoxClipboard.Text == "Clipboard: Load")
                setColorinputs(((Panel)sender).BackColor, true, true);
            else
                ((Panel)sender).BackColor = panelActiveColor.BackColor;
        }

        // Switch clipboard modes
        private void buttonToggle_Click(object sender, EventArgs e)
        {
            string newMode = groupBoxClipboard.Text == "Clipboard: Load" ? "Store" : "Load";
            groupBoxClipboard.Text = "Clipboard: " + newMode;
            toolStripStatusLabel.Text = "Clipboard switched to " + newMode + " mode.";
            resetStatusText(4200);
        }

        // Load 4 colors from clipboard to active palette
        private void buttonLoadPalette_Click(object sender, EventArgs e)
        {
            int i = ((Button)sender).Name[10] - '1';
            for (int j = 0; j < 4; j++)
            {
                ActivePalette[j] = groupBoxClipboard.Controls[i * 4 + j].BackColor;
                panelPalettebg.Controls[j].BackColor = ActivePalette[j];
            }
            buttonSetPalette.Enabled = true;
            pictureBox.Refresh();
        }

        // Save active palette to clipboard
        private void buttonStorePalette_Click(object sender, EventArgs e)
        {
            int i = ((Button)sender).Name[11] - '1';
            for (int j = 0; j < 4; j++)
            {
                groupBoxClipboard.Controls[i * 4 + j].BackColor = panelPalettebg.Controls[j].BackColor;
            }
        }

        // #####################################################################################
        // Preview screenshot

        // Game selection changed
        private void comboBoxGame_SelectedValueChanged(object sender, EventArgs e)
        { // switch screenshot
            pictureBox.Image = screenshots[comboBoxGame.SelectedIndex];
            //pictureBox.Refresh();
        }

        // Replace colors with currently active palette while drawing the screenshot
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Bitmap bmp = new Bitmap(screenshots[comboBoxGame.SelectedIndex]))
            {
                ColorMap[] colorMap = new ColorMap[4];
                colorMap[0] = new ColorMap
                {
                    OldColor = Color.White,
                    NewColor = ActivePalette[0]
                };
                colorMap[1] = new ColorMap
                {
                    OldColor = Color.FromArgb(173, 173, 173),
                    NewColor = ActivePalette[1]
                };
                colorMap[2] = new ColorMap
                {
                    OldColor = Color.FromArgb(82, 82, 82),
                    NewColor = ActivePalette[2]
                };
                colorMap[3] = new ColorMap
                {
                    OldColor = Color.Black,
                    NewColor = ActivePalette[3]
                };
                ImageAttributes attr = new ImageAttributes();
                attr.SetRemapTable(colorMap);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                g.DrawImage(bmp, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attr);
            }
        }

        // #####################################################################################
        // Import / Export section

        // Import data from SGB rom file
        private void buttonImport_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select \"" + comboBoxVersion.Text + ".sfc\"";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                (bool success, bool buttonTypeA, string text) = Program.LoadfromFile(openFileDialog.FileName);
                if (success)
                {
                    for (int i = 0; i < Program.sgbRevisions.Length; i++)
                    {
                        if (openFileDialog.SafeFileName.StartsWith(Program.sgbRevisions[i]))
                        {
                            comboBoxVersion.SelectedIndex = i;
                            break;
                        }
                    }
                    getPalette(comboBoxPaletteslot.SelectedIndex);
                    checkBoxControls.Checked = buttonTypeA;
                    toolStripStatusLabel.Text = "Successfully loaded palettes from file.";
                }
                else
                {
                    toolStripStatusLabel.Text = "Error loading palettes from file: " + text;
                }
                resetStatusText();
            }
        }

        // Export as IPS patch
        private void buttonIps_Click(object sender, EventArgs e)
        {
            setPalette(comboBoxPaletteslot.SelectedIndex); // make sure current palette is saved
            bool success = Program.SaveIPS(comboBoxVersion.SelectedIndex, checkBoxControls.Checked);
            toolStripStatusLabel.Text = success ? "Saved patch as \"" + comboBoxVersion.Text + " (Custom Palette).ips\"." : "Could not save ips file.";
            resetStatusText();
        }

        // Modify SGB rom file with palette and control mode
        private void buttonModify_Click(object sender, EventArgs e)
        {
            setPalette(comboBoxPaletteslot.SelectedIndex); // make sure current palette is saved
            openFileDialog.Title = "Select \"" + comboBoxVersion.Text + ".sfc\" - FILE WILL BE MODIFIED";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                (bool success, string text) = Program.SavetoFile(openFileDialog.FileName, checkBoxControls.Checked);
                if (success)
                {
                    toolStripStatusLabel.Text = "Successfully saved changes to file. " + text;
                }
                else
                {
                    toolStripStatusLabel.ForeColor = Color.Red;
                    toolStripStatusLabel.Text = "Error while writing to file: " + text;
                }
                resetStatusText();
            }
        }

        // #####################################################################################
        // Status bar

        // Reset status bar text without blocking the UI
        internal async Task resetStatusText(int delay = 6000)
        {
            timer = DateTime.Now.AddSeconds(delay / 1000 - 1);
            await Task.Delay(delay);
            if (DateTime.Now > timer)
                toolStripStatusLabel.Text = "";
            toolStripStatusLabel.ForeColor = Color.Black;
        }
    }
}
