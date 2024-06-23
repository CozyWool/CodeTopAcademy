namespace DialogsWinFormsApp;

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
        dataGridView1 = new DataGridView();
        EditButton = new Button();
        AddButton = new Button();
        DeleteButton = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Dock = DockStyle.Top;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.MultiSelect = false;
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowTemplate.Height = 25;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.Size = new Size(800, 314);
        dataGridView1.TabIndex = 0;
        dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        // 
        // EditButton
        // 
        EditButton.Location = new Point(653, 320);
        EditButton.Name = "EditButton";
        EditButton.Size = new Size(135, 23);
        EditButton.TabIndex = 1;
        EditButton.Text = "Edit Student";
        EditButton.UseVisualStyleBackColor = true;
        EditButton.Click += EditButton_Click;
        // 
        // AddButton
        // 
        AddButton.Location = new Point(12, 320);
        AddButton.Name = "AddButton";
        AddButton.Size = new Size(135, 23);
        AddButton.TabIndex = 1;
        AddButton.Text = "Add Student";
        AddButton.UseVisualStyleBackColor = true;
        AddButton.Click += AddButton_Click;
        // 
        // DeleteButton
        // 
        DeleteButton.Location = new Point(153, 320);
        DeleteButton.Name = "DeleteButton";
        DeleteButton.Size = new Size(135, 23);
        DeleteButton.TabIndex = 1;
        DeleteButton.Text = "Delete Student";
        DeleteButton.UseVisualStyleBackColor = true;
        DeleteButton.Click += DeleteButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(DeleteButton);
        Controls.Add(AddButton);
        Controls.Add(EditButton);
        Controls.Add(dataGridView1);
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridView1;
    private Button EditButton;
    private Button AddButton;
    private Button DeleteButton;
}
