using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventPlayground
{
    public partial class Form1 : Form
    {
        // Delegates
        public delegate void ColorChangedHandler(object sender, ColorEventArgs e);
        public delegate void TextChangedHandler(object sender, string newText);

        // Events
        public event ColorChangedHandler ColorChangedEvent;
        public event TextChangedHandler TextChangedEvent;

        public Form1()
        {
            InitializeComponent();

            // Subscribe multiple handlers to ColorChangedEvent
            ColorChangedEvent += UpdateLabelColor;
            ColorChangedEvent += ShowNotification;
            TextChangedEvent += UpdateLabelText;

            // manual hook for changing color
            btnChangeColor.Click += btnChangeColor_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        // text change
        private void button1_Click(object sender, EventArgs e)
        {
            // Fire TextChangedEvent
            string newText = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            TextChangedEvent?.Invoke(this, newText);
        }

        // change color on click
        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            string selected = cmbColors.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selected))
                return;

            ColorChangedEvent?.Invoke(this, new ColorEventArgs(selected));
        }

        // color change
        private void UpdateLabelColor(object sender, ColorEventArgs e)
        {
            switch (e.ColorName)
            {
                case "Red":
                    lblDisplay.ForeColor = Color.Red;
                    break;
                case "Green":
                    lblDisplay.ForeColor = Color.Green;
                    break;
                case "Blue":
                    lblDisplay.ForeColor = Color.Blue;
                    break;
            }
        }

        // color change
        private void ShowNotification(object sender, ColorEventArgs e)
        {
            MessageBox.Show($"Color changed to: {e.ColorName}");
        }

        // text update
        private void UpdateLabelText(object sender, string newText)
        {
            lblDisplay.Text = newText;
        }
    }
}
