namespace SecondHWWinFormsApp;

partial class Task2Form
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        AddInfoButton = new Button();
        AdditionalInfo = new GroupBox();
        label7 = new Label();
        BirthdayDatePicker = new DateTimePicker();
        label6 = new Label();
        FemaleRadioButton = new RadioButton();
        MaleRadioButton = new RadioButton();
        LivingInfo = new GroupBox();
        EmailTextBox = new TextBox();
        PhoneNumberTextBox = new MaskedTextBox();
        label5 = new Label();
        label4 = new Label();
        FIO = new GroupBox();
        FatherNameLabel = new Label();
        FatherNameTextBox = new TextBox();
        NameLabel = new Label();
        NameTextBox = new TextBox();
        SurnameLabel = new Label();
        SurnameTextBox = new TextBox();
        listBox = new ListBox();
        LoadButton = new Button();
        SaveButton = new Button();
        openFileDialog = new OpenFileDialog();
        saveFileDialog = new SaveFileDialog();
        DeleteButton = new Button();
        SaveChangesButton = new Button();
        AdditionalInfo.SuspendLayout();
        LivingInfo.SuspendLayout();
        FIO.SuspendLayout();
        SuspendLayout();
        // 
        // AddInfoButton
        // 
        AddInfoButton.Location = new Point(12, 518);
        AddInfoButton.Name = "AddInfoButton";
        AddInfoButton.Size = new Size(247, 36);
        AddInfoButton.TabIndex = 19;
        AddInfoButton.Text = "Добавить пользователя";
        AddInfoButton.UseVisualStyleBackColor = true;
        AddInfoButton.Click += AddInfoButton_Click;
        // 
        // AdditionalInfo
        // 
        AdditionalInfo.Controls.Add(label7);
        AdditionalInfo.Controls.Add(BirthdayDatePicker);
        AdditionalInfo.Controls.Add(label6);
        AdditionalInfo.Controls.Add(FemaleRadioButton);
        AdditionalInfo.Controls.Add(MaleRadioButton);
        AdditionalInfo.Location = new Point(12, 313);
        AdditionalInfo.Name = "AdditionalInfo";
        AdditionalInfo.Size = new Size(247, 143);
        AdditionalInfo.TabIndex = 18;
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
        // BirthdayDatePicker
        // 
        BirthdayDatePicker.Format = DateTimePickerFormat.Short;
        BirthdayDatePicker.Location = new Point(6, 114);
        BirthdayDatePicker.Name = "BirthdayDatePicker";
        BirthdayDatePicker.Size = new Size(200, 23);
        BirthdayDatePicker.TabIndex = 17;
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
        // LivingInfo
        // 
        LivingInfo.Controls.Add(EmailTextBox);
        LivingInfo.Controls.Add(PhoneNumberTextBox);
        LivingInfo.Controls.Add(label5);
        LivingInfo.Controls.Add(label4);
        LivingInfo.Location = new Point(12, 172);
        LivingInfo.Name = "LivingInfo";
        LivingInfo.Size = new Size(247, 135);
        LivingInfo.TabIndex = 17;
        LivingInfo.TabStop = false;
        LivingInfo.Text = "Контактная информация";
        // 
        // EmailTextBox
        // 
        EmailTextBox.Location = new Point(7, 92);
        EmailTextBox.Name = "EmailTextBox";
        EmailTextBox.Size = new Size(186, 23);
        EmailTextBox.TabIndex = 23;
        EmailTextBox.TextChanged += EmailTextBox_TextChanged;
        // 
        // PhoneNumberTextBox
        // 
        PhoneNumberTextBox.Location = new Point(7, 40);
        PhoneNumberTextBox.Mask = "+7 (999) 000-0000";
        PhoneNumberTextBox.Name = "PhoneNumberTextBox";
        PhoneNumberTextBox.Size = new Size(185, 23);
        PhoneNumberTextBox.TabIndex = 27;
        PhoneNumberTextBox.TextChanged += PhoneNumberTextBox_TextChanged;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(6, 74);
        label5.Name = "label5";
        label5.Size = new Size(113, 15);
        label5.TabIndex = 26;
        label5.Text = "Электронная почта";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(6, 22);
        label4.Name = "label4";
        label4.Size = new Size(101, 15);
        label4.TabIndex = 24;
        label4.Text = "Номер телефона";
        // 
        // FIO
        // 
        FIO.Controls.Add(FatherNameLabel);
        FIO.Controls.Add(FatherNameTextBox);
        FIO.Controls.Add(NameLabel);
        FIO.Controls.Add(NameTextBox);
        FIO.Controls.Add(SurnameLabel);
        FIO.Controls.Add(SurnameTextBox);
        FIO.Location = new Point(12, 12);
        FIO.Name = "FIO";
        FIO.Size = new Size(247, 154);
        FIO.TabIndex = 16;
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
        // listBox
        // 
        listBox.FormattingEnabled = true;
        listBox.ItemHeight = 15;
        listBox.Location = new Point(265, 30);
        listBox.Name = "listBox";
        listBox.Size = new Size(986, 499);
        listBox.TabIndex = 20;
        listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
        // 
        // LoadButton
        // 
        LoadButton.Location = new Point(1044, 535);
        LoadButton.Name = "LoadButton";
        LoadButton.Size = new Size(207, 56);
        LoadButton.TabIndex = 21;
        LoadButton.Text = "Загрузить из файла";
        LoadButton.UseVisualStyleBackColor = true;
        LoadButton.Click += LoadButton_Click;
        // 
        // SaveButton
        // 
        SaveButton.Location = new Point(831, 535);
        SaveButton.Name = "SaveButton";
        SaveButton.Size = new Size(207, 56);
        SaveButton.TabIndex = 22;
        SaveButton.Text = "Сохранить в файл";
        SaveButton.UseVisualStyleBackColor = true;
        SaveButton.Click += SaveButton_Click;
        // 
        // openFileDialog
        // 
        openFileDialog.FileName = "openFileDialog1";
        openFileDialog.Filter = "XML файлы|*.xml|Текстовые файлы|*.txt";
        // 
        // saveFileDialog
        // 
        saveFileDialog.Filter = "XML файлы|*.xml|Текстовые файлы|*.txt";
        // 
        // DeleteButton
        // 
        DeleteButton.Location = new Point(12, 560);
        DeleteButton.Name = "DeleteButton";
        DeleteButton.Size = new Size(247, 36);
        DeleteButton.TabIndex = 23;
        DeleteButton.Text = "Удалить пользователя";
        DeleteButton.UseVisualStyleBackColor = true;
        DeleteButton.Click += DeleteButton_Click;
        // 
        // SaveChangesButton
        // 
        SaveChangesButton.Location = new Point(12, 476);
        SaveChangesButton.Name = "SaveChangesButton";
        SaveChangesButton.Size = new Size(247, 36);
        SaveChangesButton.TabIndex = 24;
        SaveChangesButton.Text = "Сохранить изменения";
        SaveChangesButton.UseVisualStyleBackColor = true;
        SaveChangesButton.Click += SaveChangesButton_Click;
        // 
        // Task2Form
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1263, 786);
        Controls.Add(SaveChangesButton);
        Controls.Add(DeleteButton);
        Controls.Add(SaveButton);
        Controls.Add(LoadButton);
        Controls.Add(listBox);
        Controls.Add(AddInfoButton);
        Controls.Add(AdditionalInfo);
        Controls.Add(LivingInfo);
        Controls.Add(FIO);
        Name = "Task2Form";
        Text = "Task2Form";
        AdditionalInfo.ResumeLayout(false);
        AdditionalInfo.PerformLayout();
        LivingInfo.ResumeLayout(false);
        LivingInfo.PerformLayout();
        FIO.ResumeLayout(false);
        FIO.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Button AddInfoButton;
    private GroupBox AdditionalInfo;
    private Label label7;
    private DateTimePicker BirthdayDatePicker;
    private GroupBox LivingInfo;
    private Label label5;
    private Label label4;
    private GroupBox FIO;
    private Label FatherNameLabel;
    private TextBox FatherNameTextBox;
    private Label NameLabel;
    private TextBox NameTextBox;
    private Label SurnameLabel;
    private TextBox SurnameTextBox;
    private Label label6;
    private RadioButton FemaleRadioButton;
    private RadioButton MaleRadioButton;
    private MaskedTextBox PhoneNumberTextBox;
    private TextBox EmailTextBox;
    private ListBox listBox;
    private Button LoadButton;
    private Button SaveButton;
    private OpenFileDialog openFileDialog;
    private SaveFileDialog saveFileDialog;
    private Button DeleteButton;
    private Button SaveChangesButton;
}