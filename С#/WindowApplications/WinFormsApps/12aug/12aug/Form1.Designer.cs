namespace _12aug
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
            CloseButton = new System.Windows.Forms.Button();
            ShowMessageButton = new System.Windows.Forms.Button();
            InputTextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            MouseCoordsLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Location = new System.Drawing.Point(660, 392);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(94, 35);
            CloseButton.TabIndex = 0;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseForm_Click;
            // 
            // ShowMessageButton
            // 
            ShowMessageButton.Location = new System.Drawing.Point(512, 392);
            ShowMessageButton.Name = "ShowMessageButton";
            ShowMessageButton.Size = new System.Drawing.Size(94, 35);
            ShowMessageButton.TabIndex = 1;
            ShowMessageButton.Text = "Show message";
            ShowMessageButton.UseVisualStyleBackColor = true;
            ShowMessageButton.Click += ShowMessage_Click;
            // 
            // InputTextBox
            // 
            InputTextBox.Location = new System.Drawing.Point(214, 161);
            InputTextBox.Multiline = true;
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new System.Drawing.Size(392, 140);
            InputTextBox.TabIndex = 2;
            InputTextBox.TextChanged += InputTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(214, 143);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 15);
            label1.TabIndex = 3;
            label1.Text = "Введите значение";
            // 
            // MouseCoordsLabel
            // 
            MouseCoordsLabel.AutoSize = true;
            MouseCoordsLabel.Location = new System.Drawing.Point(0, 0);
            MouseCoordsLabel.Name = "MouseCoordsLabel";
            MouseCoordsLabel.Size = new System.Drawing.Size(81, 15);
            MouseCoordsLabel.TabIndex = 4;
            MouseCoordsLabel.Text = "MouseCoords";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(MouseCoordsLabel);
            Controls.Add(label1);
            Controls.Add(InputTextBox);
            Controls.Add(ShowMessageButton);
            Controls.Add(CloseButton);
            Name = "Form1";
            Text = "Form1";
            MouseMove += Form1_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ShowMessageButton;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MouseCoordsLabel;
    }
}
