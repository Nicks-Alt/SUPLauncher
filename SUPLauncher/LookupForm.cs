namespace SUPLauncher
{
    public partial class LookupForm : Form
    {
        public LookupForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        profile pro;

        private void submit(string text)
        {
            if (pro == null) {
                pro = new profile();
                pro.steam = Clipboard.GetText();
                pro.Show();
            } else {
                pro.steam = Clipboard.GetText();
                pro.Visible = true;
            }
            
            this.Visible = false;
        }
        bool loaded = false;
        private void LookupForm_Load(object sender, EventArgs e)
        {
            loaded = true;
        }

        private void LookupForm_VisibleChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                string text = Clipboard.GetText();
                if (text.Length >= 17)
                {
                    if (this.Visible == true)
                    {
                        submit(text);
                    }
                }
            }
        }
    }
}
