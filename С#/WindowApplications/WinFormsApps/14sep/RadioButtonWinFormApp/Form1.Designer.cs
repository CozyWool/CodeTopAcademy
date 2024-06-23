namespace RadioButtonWinFormApp;

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
        groupBox1 = new GroupBox();
        radioButton1 = new RadioButton();
        radioButton3 = new RadioButton();
        radioButton2 = new RadioButton();
        groupBox2 = new GroupBox();
        radioButton5 = new RadioButton();
        radioButton4 = new RadioButton();
        toolTip1 = new ToolTip(components);
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(radioButton1);
        groupBox1.Controls.Add(radioButton3);
        groupBox1.Controls.Add(radioButton2);
        groupBox1.Location = new Point(30, 55);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(202, 153);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "groupBox1";
        // 
        // radioButton1
        // 
        radioButton1.AutoSize = true;
        radioButton1.Location = new Point(6, 22);
        radioButton1.Name = "radioButton1";
        radioButton1.Size = new Size(94, 19);
        radioButton1.TabIndex = 0;
        radioButton1.TabStop = true;
        radioButton1.Text = "radioButton1";
        radioButton1.UseVisualStyleBackColor = true;
        // 
        // radioButton3
        // 
        radioButton3.AutoSize = true;
        radioButton3.Location = new Point(6, 72);
        radioButton3.Name = "radioButton3";
        radioButton3.Size = new Size(94, 19);
        radioButton3.TabIndex = 2;
        radioButton3.TabStop = true;
        radioButton3.Text = "radioButton3";
        radioButton3.UseVisualStyleBackColor = true;
        // 
        // radioButton2
        // 
        radioButton2.AutoSize = true;
        radioButton2.Location = new Point(6, 47);
        radioButton2.Name = "radioButton2";
        radioButton2.Size = new Size(94, 19);
        radioButton2.TabIndex = 1;
        radioButton2.TabStop = true;
        radioButton2.Text = "radioButton2";
        radioButton2.UseVisualStyleBackColor = true;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(radioButton5);
        groupBox2.Controls.Add(radioButton4);
        groupBox2.Location = new Point(339, 55);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(189, 153);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "groupBox2";
        // 
        // radioButton5
        // 
        radioButton5.AutoSize = true;
        radioButton5.Location = new Point(6, 47);
        radioButton5.Name = "radioButton5";
        radioButton5.Size = new Size(94, 19);
        radioButton5.TabIndex = 4;
        radioButton5.TabStop = true;
        radioButton5.Text = "radioButton5";
        radioButton5.UseVisualStyleBackColor = true;
        // 
        // radioButton4
        // 
        radioButton4.AutoSize = true;
        radioButton4.Location = new Point(6, 22);
        radioButton4.Name = "radioButton4";
        radioButton4.Size = new Size(94, 19);
        radioButton4.TabIndex = 3;
        radioButton4.TabStop = true;
        radioButton4.Text = "radioButton4";
        radioButton4.UseVisualStyleBackColor = true;
        // 
        // toolTip1
        // 
        toolTip1.IsBalloon = true;
        toolTip1.ToolTipIcon = ToolTipIcon.Info;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Name = "Form1";
        Text = "Form1";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox1;
    private RadioButton radioButton2;
    private RadioButton radioButton3;
    private RadioButton radioButton1;
    private GroupBox groupBox2;
    private RadioButton radioButton5;
    private RadioButton radioButton4;
    private ToolTip toolTip1;
}
