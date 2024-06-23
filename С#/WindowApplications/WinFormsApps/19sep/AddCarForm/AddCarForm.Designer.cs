namespace AddCarForm;

partial class AddCarForm
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
        CarTextBox = new TextBox();
        label1 = new Label();
        CancelButton = new Button();
        OkButton = new Button();
        SuspendLayout();
        // 
        // CarTextBox
        // 
        CarTextBox.Location = new Point(12, 57);
        CarTextBox.Name = "CarTextBox";
        CarTextBox.Size = new Size(231, 23);
        CarTextBox.TabIndex = 0;
        CarTextBox.TextChanged += CarTextBox_TextChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 21);
        label1.Name = "label1";
        label1.Size = new Size(164, 15);
        label1.TabIndex = 1;
        label1.Text = "Введите модель автомобиля";
        // 
        // CancelButton
        // 
        CancelButton.DialogResult = DialogResult.Cancel;
        CancelButton.Location = new Point(168, 103);
        CancelButton.Name = "CancelButton";
        CancelButton.Size = new Size(75, 23);
        CancelButton.TabIndex = 2;
        CancelButton.Text = "Cancel";
        CancelButton.UseVisualStyleBackColor = true;
        CancelButton.Click += CancelButton_Click;
        // 
        // OkButton
        // 
        OkButton.DialogResult = DialogResult.OK;
        OkButton.Enabled = false;
        OkButton.Location = new Point(87, 103);
        OkButton.Name = "OkButton";
        OkButton.Size = new Size(75, 23);
        OkButton.TabIndex = 3;
        OkButton.Text = "OK";
        OkButton.UseVisualStyleBackColor = true;
        OkButton.Click += OkButton_Click;
        // 
        // Form1
        // 
        AcceptButton = CancelButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(257, 138);
        Controls.Add(OkButton);
        Controls.Add(CancelButton);
        Controls.Add(label1);
        Controls.Add(CarTextBox);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox CarTextBox;
    private Label label1;
    private Button CancelButton;
    private Button OkButton;
}
