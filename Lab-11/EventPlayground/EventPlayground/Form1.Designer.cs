namespace EventPlayground
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDisplay = new Label();
            cmbColors = new ComboBox();
            btnChangeColor = new Button();
            btnChangeText = new Button();
            SuspendLayout();
            // 
            // lblDisplay
            // 
            lblDisplay.AutoSize = true;
            lblDisplay.Font = new Font("Segoe UI", 12F);
            lblDisplay.Location = new Point(223, 28);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(262, 32);
            lblDisplay.TabIndex = 0;
            lblDisplay.Text = "Welcome to Events Lab";
            lblDisplay.Click += label1_Click;
            // 
            // cmbColors
            // 
            cmbColors.FormattingEnabled = true;
            cmbColors.Items.AddRange(new object[] { "Red", "Green", "Blue" });
            cmbColors.Location = new Point(55, 78);
            cmbColors.Name = "cmbColors";
            cmbColors.Size = new Size(182, 33);
            cmbColors.TabIndex = 1;
            // 
            // btnChangeColor
            // 
            btnChangeColor.Location = new Point(55, 155);
            btnChangeColor.Name = "btnChangeColor";
            btnChangeColor.Size = new Size(182, 34);
            btnChangeColor.TabIndex = 2;
            btnChangeColor.Text = "Change Color";
            btnChangeColor.UseVisualStyleBackColor = true;
            // 
            // btnChangeText
            // 
            btnChangeText.Location = new Point(55, 233);
            btnChangeText.Name = "btnChangeText";
            btnChangeText.Size = new Size(182, 34);
            btnChangeText.TabIndex = 3;
            btnChangeText.Text = "Change Text";
            btnChangeText.UseVisualStyleBackColor = true;
            btnChangeText.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnChangeText);
            Controls.Add(btnChangeColor);
            Controls.Add(cmbColors);
            Controls.Add(lblDisplay);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDisplay;
        private ComboBox cmbColors;
        private Button btnChangeColor;
        private Button btnChangeText;
    }
}
