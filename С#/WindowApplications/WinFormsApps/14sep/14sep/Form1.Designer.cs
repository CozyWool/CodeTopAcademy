namespace _14sep
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
            components = new System.ComponentModel.Container();
            TimerSecondsLabel = new Label();
            TimerNumericUpDown = new NumericUpDown();
            StartButton = new Button();
            StopButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)TimerNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // TimerSecondsLabel
            // 
            TimerSecondsLabel.AutoSize = true;
            TimerSecondsLabel.Location = new Point(71, 94);
            TimerSecondsLabel.Name = "TimerSecondsLabel";
            TimerSecondsLabel.Size = new Size(205, 15);
            TimerSecondsLabel.TabIndex = 0;
            TimerSecondsLabel.Text = "Количество секунд работы таймера";
            // 
            // TimerNumericUpDown
            // 
            TimerNumericUpDown.Location = new Point(282, 92);
            TimerNumericUpDown.Maximum = new decimal(new int[] { 1200, 0, 0, 0 });
            TimerNumericUpDown.Name = "TimerNumericUpDown";
            TimerNumericUpDown.Size = new Size(77, 23);
            TimerNumericUpDown.TabIndex = 1;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(71, 193);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(75, 23);
            StartButton.TabIndex = 2;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(201, 193);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(75, 23);
            StopButton.TabIndex = 3;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StopButton);
            Controls.Add(StartButton);
            Controls.Add(TimerNumericUpDown);
            Controls.Add(TimerSecondsLabel);
            Name = "Form1";
            Text = "Пример работы таймера";
            ((System.ComponentModel.ISupportInitialize)TimerNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TimerSecondsLabel;
        private NumericUpDown TimerNumericUpDown;
        private Button StartButton;
        private Button StopButton;
        private System.Windows.Forms.Timer timer1;
    }
}