namespace Gui2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int inc;

        #region Event Handlers - do NOT touch
        private void button1_Click(object sender, EventArgs e)
        {
            inc += Convert.ToInt32(comboBox1.Text)
                   * (checkBox1.Checked ? 2 : 1);
            label1.Text = inc.ToString();
        }

        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}