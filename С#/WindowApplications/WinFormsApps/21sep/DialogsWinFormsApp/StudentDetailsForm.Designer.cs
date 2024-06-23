namespace DialogsWinFormsApp;

partial class StudentDetailsForm
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
        IdLabel = new Label();
        IdTextBox = new TextBox();
        NameTextBox = new TextBox();
        NameLabel = new Label();
        GroupTextBox = new TextBox();
        GroupLabel = new Label();
        OkButton = new Button();
        CancelButton = new Button();
        SuspendLayout();
        // 
        // IdLabel
        // 
        IdLabel.AutoSize = true;
        IdLabel.Location = new Point(71, 87);
        IdLabel.Name = "IdLabel";
        IdLabel.Size = new Size(17, 15);
        IdLabel.TabIndex = 0;
        IdLabel.Text = "Id";
        // 
        // IdTextBox
        // 
        IdTextBox.Location = new Point(131, 84);
        IdTextBox.Name = "IdTextBox";
        IdTextBox.Size = new Size(191, 23);
        IdTextBox.TabIndex = 1;
        // 
        // NameTextBox
        // 
        NameTextBox.Location = new Point(131, 113);
        NameTextBox.Name = "NameTextBox";
        NameTextBox.Size = new Size(191, 23);
        NameTextBox.TabIndex = 3;
        // 
        // NameLabel
        // 
        NameLabel.AutoSize = true;
        NameLabel.Location = new Point(71, 116);
        NameLabel.Name = "NameLabel";
        NameLabel.Size = new Size(39, 15);
        NameLabel.TabIndex = 2;
        NameLabel.Text = "Name";
        // 
        // GroupTextBox
        // 
        GroupTextBox.Location = new Point(131, 142);
        GroupTextBox.Name = "GroupTextBox";
        GroupTextBox.Size = new Size(191, 23);
        GroupTextBox.TabIndex = 5;
        // 
        // GroupLabel
        // 
        GroupLabel.AutoSize = true;
        GroupLabel.Location = new Point(71, 145);
        GroupLabel.Name = "GroupLabel";
        GroupLabel.Size = new Size(40, 15);
        GroupLabel.TabIndex = 4;
        GroupLabel.Text = "Group";
        // 
        // OkButton
        // 
        OkButton.DialogResult = DialogResult.OK;
        OkButton.Location = new Point(247, 214);
        OkButton.Name = "OkButton";
        OkButton.Size = new Size(75, 23);
        OkButton.TabIndex = 6;
        OkButton.Text = "OK";
        OkButton.UseVisualStyleBackColor = true;
        OkButton.Click += OkButton_Click;
        // 
        // CancelButton
        // 
        CancelButton.DialogResult = DialogResult.Cancel;
        CancelButton.Location = new Point(341, 214);
        CancelButton.Name = "CancelButton";
        CancelButton.Size = new Size(75, 23);
        CancelButton.TabIndex = 7;
        CancelButton.Text = "Cancel";
        CancelButton.UseVisualStyleBackColor = true;
        CancelButton.Click += CancelButton_Click;
        // 
        // StudentDetailsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(428, 258);
        Controls.Add(CancelButton);
        Controls.Add(OkButton);
        Controls.Add(GroupTextBox);
        Controls.Add(GroupLabel);
        Controls.Add(NameTextBox);
        Controls.Add(NameLabel);
        Controls.Add(IdTextBox);
        Controls.Add(IdLabel);
        Name = "StudentDetailsForm";
        Text = "StudentDetailsForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label IdLabel;
    private TextBox IdTextBox;
    private TextBox NameTextBox;
    private Label NameLabel;
    private TextBox GroupTextBox;
    private Label GroupLabel;
    private Button OkButton;
    private Button CancelButton;
}