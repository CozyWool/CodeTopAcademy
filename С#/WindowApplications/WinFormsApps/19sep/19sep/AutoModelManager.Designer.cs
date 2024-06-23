namespace _19sep;

partial class AutoModelManager
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
        CarListBox = new ListBox();
        SelectedListBox = new ListBox();
        AddButton = new Button();
        RemoveButton = new Button();
        MoveToSourceButton = new Button();
        MoveToDestButton = new Button();
        CarTextBox = new TextBox();
        AddDialogButton = new Button();
        SuspendLayout();
        // 
        // CarListBox
        // 
        CarListBox.FormattingEnabled = true;
        CarListBox.ItemHeight = 15;
        CarListBox.Location = new Point(22, 35);
        CarListBox.Name = "CarListBox";
        CarListBox.SelectionMode = SelectionMode.MultiExtended;
        CarListBox.Size = new Size(329, 214);
        CarListBox.TabIndex = 0;
        CarListBox.SelectedIndexChanged += CarListBox_SelectedIndexChanged;
        // 
        // SelectedListBox
        // 
        SelectedListBox.FormattingEnabled = true;
        SelectedListBox.ItemHeight = 15;
        SelectedListBox.Location = new Point(438, 35);
        SelectedListBox.Name = "SelectedListBox";
        SelectedListBox.SelectionMode = SelectionMode.MultiExtended;
        SelectedListBox.Size = new Size(329, 214);
        SelectedListBox.TabIndex = 1;
        SelectedListBox.SelectedIndexChanged += SelectedListBox_SelectedIndexChanged;
        // 
        // AddButton
        // 
        AddButton.Enabled = false;
        AddButton.Location = new Point(22, 317);
        AddButton.Name = "AddButton";
        AddButton.Size = new Size(75, 23);
        AddButton.TabIndex = 2;
        AddButton.Text = "Add";
        AddButton.UseVisualStyleBackColor = true;
        AddButton.Click += AddButton_Click;
        // 
        // RemoveButton
        // 
        RemoveButton.Enabled = false;
        RemoveButton.Location = new Point(276, 317);
        RemoveButton.Name = "RemoveButton";
        RemoveButton.Size = new Size(75, 23);
        RemoveButton.TabIndex = 3;
        RemoveButton.Text = "Remove";
        RemoveButton.UseVisualStyleBackColor = true;
        RemoveButton.Click += RemoveButton_Click;
        // 
        // MoveToSourceButton
        // 
        MoveToSourceButton.Enabled = false;
        MoveToSourceButton.Location = new Point(357, 58);
        MoveToSourceButton.Name = "MoveToSourceButton";
        MoveToSourceButton.Size = new Size(75, 23);
        MoveToSourceButton.TabIndex = 4;
        MoveToSourceButton.Text = "<<";
        MoveToSourceButton.UseVisualStyleBackColor = true;
        MoveToSourceButton.Click += MoveToSourceButton_Click;
        // 
        // MoveToDestButton
        // 
        MoveToDestButton.Enabled = false;
        MoveToDestButton.Location = new Point(357, 87);
        MoveToDestButton.Name = "MoveToDestButton";
        MoveToDestButton.Size = new Size(75, 23);
        MoveToDestButton.TabIndex = 5;
        MoveToDestButton.Text = ">>";
        MoveToDestButton.UseVisualStyleBackColor = true;
        MoveToDestButton.Click += MoveToDestButton_Click;
        // 
        // CarTextBox
        // 
        CarTextBox.Location = new Point(22, 274);
        CarTextBox.Name = "CarTextBox";
        CarTextBox.Size = new Size(329, 23);
        CarTextBox.TabIndex = 6;
        CarTextBox.TextChanged += CarTextBox_TextChanged;
        // 
        // AddDialogButton
        // 
        AddDialogButton.Location = new Point(379, 317);
        AddDialogButton.Name = "AddDialogButton";
        AddDialogButton.Size = new Size(373, 85);
        AddDialogButton.TabIndex = 7;
        AddDialogButton.Text = "Добавить из диалогового окна";
        AddDialogButton.UseVisualStyleBackColor = true;
        AddDialogButton.Click += AddDialogButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(800, 450);
        Controls.Add(AddDialogButton);
        Controls.Add(CarTextBox);
        Controls.Add(MoveToDestButton);
        Controls.Add(MoveToSourceButton);
        Controls.Add(RemoveButton);
        Controls.Add(AddButton);
        Controls.Add(SelectedListBox);
        Controls.Add(CarListBox);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox CarListBox;
    private ListBox SelectedListBox;
    private Button AddButton;
    private Button RemoveButton;
    private Button MoveToSourceButton;
    private Button MoveToDestButton;
    private TextBox CarTextBox;
    private Button AddDialogButton;
}
