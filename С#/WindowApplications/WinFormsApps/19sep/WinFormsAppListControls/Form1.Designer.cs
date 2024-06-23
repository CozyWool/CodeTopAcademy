namespace WinFormsAppListControls;

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
        checkedListBox1 = new CheckedListBox();
        button1 = new Button();
        comboBox1 = new ComboBox();
        SuspendLayout();
        // 
        // checkedListBox1
        // 
        checkedListBox1.FormattingEnabled = true;
        checkedListBox1.Items.AddRange(new object[] { "el 1", "el 2", "el 3", "el 4" });
        checkedListBox1.Location = new Point(125, 90);
        checkedListBox1.Name = "checkedListBox1";
        checkedListBox1.Size = new Size(120, 94);
        checkedListBox1.Sorted = true;
        checkedListBox1.TabIndex = 0;
        // 
        // button1
        // 
        button1.Location = new Point(125, 201);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 1;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "Владислав", "Дмитрий", "Захар", "Никита" });
        comboBox1.Location = new Point(332, 90);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(121, 23);
        comboBox1.Sorted = true;
        comboBox1.TabIndex = 2;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(comboBox1);
        Controls.Add(button1);
        Controls.Add(checkedListBox1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private CheckedListBox checkedListBox1;
    private Button button1;
    private ComboBox comboBox1;
}
