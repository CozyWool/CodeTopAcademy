namespace CurrentTimeWinFormApp
{
    partial class CurrentTimeForm
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
            TimeLabel = new Label();
            SuspendLayout();
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            TimeLabel.Location = new Point(0, 0);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(76, 30);
            TimeLabel.TabIndex = 0;
            TimeLabel.Text = "label1";
            // 
            // CurrentTimeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 449);
            Controls.Add(TimeLabel);
            Name = "CurrentTimeForm";
            Text = "Отображение текущего времени";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TimeLabel;
    }
}