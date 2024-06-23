namespace DialogsWinFormsApp;

partial class AddStudentForm
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
        CancelButton = new Button();
        OkButton = new Button();
        GroupTextBox = new TextBox();
        GroupLabel = new Label();
        NameTextBox = new TextBox();
        NameLabel = new Label();
        IdTextBox = new TextBox();
        IdLabel = new Label();
        SuspendLayout();
        // 
        // CancelButton
        // 
        CancelButton.DialogResult = DialogResult.Cancel;
        CancelButton.Location = new Point(336, 215);
        CancelButton.Name = "CancelButton";
        CancelButton.Size = new Size(75, 23);
        CancelButton.TabIndex = 15;
        CancelButton.Text = "Cancel";
        CancelButton.UseVisualStyleBackColor = true;
        // 
        // OkButton
        // 
        OkButton.DialogResult = DialogResult.OK;
        OkButton.Location = new Point(242, 215);
        OkButton.Name = "OkButton";
        OkButton.Size = new Size(75, 23);
        OkButton.TabIndex = 14;
        OkButton.Text = "OK";
        OkButton.UseVisualStyleBackColor = true;
        // 
        // GroupTextBox
        // 
        GroupTextBox.Location = new Point(126, 143);
        GroupTextBox.Name = "GroupTextBox";
        GroupTextBox.Size = new Size(191, 23);
        GroupTextBox.TabIndex = 13;
        GroupTextBox.TextChanged += TextBox_TextChanged;
        // 
        // GroupLabel
        // 
        GroupLabel.AutoSize = true;
        GroupLabel.Location = new Point(66, 146);
        GroupLabel.Name = "GroupLabel";
        GroupLabel.Size = new Size(40, 15);
        GroupLabel.TabIndex = 12;
        GroupLabel.Text = "Group";
        // 
        // NameTextBox
        // 
        NameTextBox.Location = new Point(126, 114);
        NameTextBox.Name = "NameTextBox";
        NameTextBox.Size = new Size(191, 23);
        NameTextBox.TabIndex = 11;
        NameTextBox.TextChanged += TextBox_TextChanged;
        // 
        // NameLabel
        // 
        NameLabel.AutoSize = true;
        NameLabel.Location = new Point(66, 117);
        NameLabel.Name = "NameLabel";
        NameLabel.Size = new Size(39, 15);
        NameLabel.TabIndex = 10;
        NameLabel.Text = "Name";
        // 
        // IdTextBox
        // 
        IdTextBox.Location = new Point(126, 85);
        IdTextBox.Name = "IdTextBox";
        IdTextBox.Size = new Size(191, 23);
        IdTextBox.TabIndex = 9;
        IdTextBox.TextChanged += TextBox_TextChanged;
        // 
        // IdLabel
        // 
        IdLabel.AutoSize = true;
        IdLabel.Location = new Point(66, 88);
        IdLabel.Name = "IdLabel";
        IdLabel.Size = new Size(17, 15);
        IdLabel.TabIndex = 8;
        IdLabel.Text = "Id";
        // 
        // AddStudentForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(435, 279);
        Controls.Add(CancelButton);
        Controls.Add(OkButton);
        Controls.Add(GroupTextBox);
        Controls.Add(GroupLabel);
        Controls.Add(NameTextBox);
        Controls.Add(NameLabel);
        Controls.Add(IdTextBox);
        Controls.Add(IdLabel);
        Name = "AddStudentForm";
        Text = "AddStudentForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button CancelButton;
    private Button OkButton;
    private TextBox GroupTextBox;
    private Label GroupLabel;
    private TextBox NameTextBox;
    private Label NameLabel;
    private TextBox IdTextBox;
    private Label IdLabel;
}