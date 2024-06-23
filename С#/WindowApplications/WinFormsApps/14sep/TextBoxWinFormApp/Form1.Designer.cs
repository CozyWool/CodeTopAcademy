namespace TextBoxWinFormApp
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
            FIO = new GroupBox();
            FatherNameLabel = new Label();
            FatherNameTextBox = new TextBox();
            NameLabel = new Label();
            NameTextBox = new TextBox();
            SurnameLabel = new Label();
            SurnameTextBox = new TextBox();
            LivingInfo = new GroupBox();
            label5 = new Label();
            CityTextBox = new TextBox();
            label4 = new Label();
            CountryTextBox = new TextBox();
            AdditionalInfo = new GroupBox();
            label7 = new Label();
            BitrhdayDatePicker = new DateTimePicker();
            label6 = new Label();
            FemaleRadioButton = new RadioButton();
            MaleRadioButton = new RadioButton();
            ShowInfoButton = new Button();
            FIO.SuspendLayout();
            LivingInfo.SuspendLayout();
            AdditionalInfo.SuspendLayout();
            SuspendLayout();
            // 
            // FIO
            // 
            FIO.Controls.Add(FatherNameLabel);
            FIO.Controls.Add(FatherNameTextBox);
            FIO.Controls.Add(NameLabel);
            FIO.Controls.Add(NameTextBox);
            FIO.Controls.Add(SurnameLabel);
            FIO.Controls.Add(SurnameTextBox);
            FIO.Location = new Point(12, 26);
            FIO.Name = "FIO";
            FIO.Size = new Size(247, 154);
            FIO.TabIndex = 12;
            FIO.TabStop = false;
            FIO.Text = "ФИО";
            // 
            // FatherNameLabel
            // 
            FatherNameLabel.AutoSize = true;
            FatherNameLabel.Location = new Point(6, 107);
            FatherNameLabel.Name = "FatherNameLabel";
            FatherNameLabel.Size = new Size(58, 15);
            FatherNameLabel.TabIndex = 22;
            FatherNameLabel.Text = "Отчество";
            // 
            // FatherNameTextBox
            // 
            FatherNameTextBox.Location = new Point(6, 125);
            FatherNameTextBox.Name = "FatherNameTextBox";
            FatherNameTextBox.Size = new Size(186, 23);
            FatherNameTextBox.TabIndex = 21;
            FatherNameTextBox.TextChanged += FatherNameTextBox_TextChanged;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(6, 63);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(31, 15);
            NameLabel.TabIndex = 20;
            NameLabel.Text = "Имя";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(6, 81);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(186, 23);
            NameTextBox.TabIndex = 19;
            NameTextBox.TextChanged += NameTextBox_TextChanged;
            // 
            // SurnameLabel
            // 
            SurnameLabel.AutoSize = true;
            SurnameLabel.Location = new Point(6, 18);
            SurnameLabel.Name = "SurnameLabel";
            SurnameLabel.Size = new Size(58, 15);
            SurnameLabel.TabIndex = 18;
            SurnameLabel.Text = "Фамилия";
            // 
            // SurnameTextBox
            // 
            SurnameTextBox.Location = new Point(6, 36);
            SurnameTextBox.Name = "SurnameTextBox";
            SurnameTextBox.Size = new Size(186, 23);
            SurnameTextBox.TabIndex = 17;
            SurnameTextBox.TextChanged += SurnameTextBox_TextChanged;
            // 
            // LivingInfo
            // 
            LivingInfo.Controls.Add(label5);
            LivingInfo.Controls.Add(CityTextBox);
            LivingInfo.Controls.Add(label4);
            LivingInfo.Controls.Add(CountryTextBox);
            LivingInfo.Location = new Point(12, 186);
            LivingInfo.Name = "LivingInfo";
            LivingInfo.Size = new Size(247, 135);
            LivingInfo.TabIndex = 13;
            LivingInfo.TabStop = false;
            LivingInfo.Text = "Место проживания";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 74);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 26;
            label5.Text = "Город";
            // 
            // CityTextBox
            // 
            CityTextBox.Location = new Point(6, 92);
            CityTextBox.Name = "CityTextBox";
            CityTextBox.Size = new Size(186, 23);
            CityTextBox.TabIndex = 25;
            CityTextBox.TextChanged += CityTextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 22);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 24;
            label4.Text = "Страна";
            // 
            // CountryTextBox
            // 
            CountryTextBox.Location = new Point(6, 40);
            CountryTextBox.Name = "CountryTextBox";
            CountryTextBox.Size = new Size(186, 23);
            CountryTextBox.TabIndex = 23;
            CountryTextBox.TextChanged += CountryTextBox_TextChanged;
            // 
            // AdditionalInfo
            // 
            AdditionalInfo.Controls.Add(label7);
            AdditionalInfo.Controls.Add(BitrhdayDatePicker);
            AdditionalInfo.Controls.Add(label6);
            AdditionalInfo.Controls.Add(FemaleRadioButton);
            AdditionalInfo.Controls.Add(MaleRadioButton);
            AdditionalInfo.Location = new Point(12, 327);
            AdditionalInfo.Name = "AdditionalInfo";
            AdditionalInfo.Size = new Size(247, 143);
            AdditionalInfo.TabIndex = 14;
            AdditionalInfo.TabStop = false;
            AdditionalInfo.Text = "Дополнительная информация";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 96);
            label7.Name = "label7";
            label7.Size = new Size(90, 15);
            label7.TabIndex = 28;
            label7.Text = "Дата рождения";
            // 
            // BitrhdayDatePicker
            // 
            BitrhdayDatePicker.Format = DateTimePickerFormat.Short;
            BitrhdayDatePicker.Location = new Point(6, 114);
            BitrhdayDatePicker.Name = "BitrhdayDatePicker";
            BitrhdayDatePicker.Size = new Size(200, 23);
            BitrhdayDatePicker.TabIndex = 17;
            BitrhdayDatePicker.ValueChanged += BitrhdayDatePicker_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 27;
            label6.Text = "Пол";
            // 
            // FemaleRadioButton
            // 
            FemaleRadioButton.AutoSize = true;
            FemaleRadioButton.Location = new Point(6, 62);
            FemaleRadioButton.Name = "FemaleRadioButton";
            FemaleRadioButton.Size = new Size(75, 19);
            FemaleRadioButton.TabIndex = 18;
            FemaleRadioButton.TabStop = true;
            FemaleRadioButton.Text = "Женский";
            FemaleRadioButton.UseVisualStyleBackColor = true;
            FemaleRadioButton.CheckedChanged += FemaleRadioButton_CheckedChanged;
            // 
            // MaleRadioButton
            // 
            MaleRadioButton.AutoSize = true;
            MaleRadioButton.Location = new Point(6, 37);
            MaleRadioButton.Name = "MaleRadioButton";
            MaleRadioButton.Size = new Size(77, 19);
            MaleRadioButton.TabIndex = 17;
            MaleRadioButton.TabStop = true;
            MaleRadioButton.Text = "Мужской";
            MaleRadioButton.UseVisualStyleBackColor = true;
            MaleRadioButton.CheckedChanged += MaleRadioButton_CheckedChanged;
            // 
            // ShowInfoButton
            // 
            ShowInfoButton.Location = new Point(12, 490);
            ShowInfoButton.Name = "ShowInfoButton";
            ShowInfoButton.Size = new Size(247, 36);
            ShowInfoButton.TabIndex = 15;
            ShowInfoButton.Text = "Показать информацию";
            ShowInfoButton.UseVisualStyleBackColor = true;
            ShowInfoButton.Click += ShowInfoButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 546);
            Controls.Add(ShowInfoButton);
            Controls.Add(AdditionalInfo);
            Controls.Add(LivingInfo);
            Controls.Add(FIO);
            Name = "Form1";
            Text = "Form1";
            FIO.ResumeLayout(false);
            FIO.PerformLayout();
            LivingInfo.ResumeLayout(false);
            LivingInfo.PerformLayout();
            AdditionalInfo.ResumeLayout(false);
            AdditionalInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaskedTextBox maskedTextBox1;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private CheckBox checkBox1;
        private RadioButton radioButton1;
        private Button button1;
        private DateTimePicker dateTimePicker1;
        private MonthCalendar monthCalendar1;
        private GroupBox FIO;
        private GroupBox LivingInfo;
        private GroupBox AdditionalInfo;
        private Button ShowInfoButton;
        private RadioButton radioButton2;
        private Label FatherNameLabel;
        private TextBox FatherNameTextBox;
        private Label NameLabel;
        private TextBox NameTextBox;
        private Label SurnameLabel;
        private TextBox SurnameTextBox;
        private Label label4;
        private TextBox CountryTextBox;
        private Label label5;
        private TextBox CityTextBox;
        private RadioButton FemaleRadioButton;
        private RadioButton MaleRadioButton;
        private Label label7;
        private DateTimePicker BitrhdayDatePicker;
        private Label label6;
    }
}