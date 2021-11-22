using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGB_Settings_Editor
{
    public partial class ConfirmationDialog : Form
    {
        public ConfirmationDialog()
        {
            InitializeComponent();
            comboBoxVersion.SelectedIndex = MainWindow.sgb_rev;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWindow.sgb_rev = comboBoxVersion.SelectedIndex;
        }
    }
}
