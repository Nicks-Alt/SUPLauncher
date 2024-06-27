using System.Diagnostics;

namespace SUPLauncher
{
    public partial class keyBinder : Form
    {
        public keyBinder()
        {
            InitializeComponent();
        }
        int keycode = 0;
        private void keyBinder_KeyDown(object sender, KeyEventArgs e)
        {
            label2.Text = e.KeyData.ToString();
            keycode = e.KeyValue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uint modifer = 0;
            if (keycode == 0) { return;  }

            if (comboBox1.SelectedItem == null)
            {
                modifer = 0;
            }
            else if (comboBox1.SelectedItem.ToString() == "CTRL")
            {
                modifer = 2;
            }
            else if (comboBox1.SelectedItem.ToString() == "ALT")
            {
                modifer = 1;
            }
            else if (comboBox1.SelectedItem.ToString() == "SHIFT")
            {
                modifer = 4;
            }

            Settings.OverlayModifierKey = modifer;
            Settings.OverlayKey = (Keys)keycode;

            MessageBox.Show("SUPLauncher will now restart to apply the changes!");
            ProcessStartInfo info = new ProcessStartInfo(Application.ExecutablePath);
            Process.Start(info);
            
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
