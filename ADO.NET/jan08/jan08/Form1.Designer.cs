﻿namespace jan08;

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
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        dataGridView1 = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(12, 12);
        button1.Name = "button1";
        button1.Size = new Size(200, 46);
        button1.TabIndex = 0;
        button1.Text = "Показать версию PostgreSQL";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(12, 77);
        button2.Name = "button2";
        button2.Size = new Size(200, 46);
        button2.TabIndex = 1;
        button2.Text = "Вывести всех студентов";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new Point(12, 146);
        button3.Name = "button3";
        button3.Size = new Size(200, 46);
        button3.TabIndex = 2;
        button3.Text = "Вывести всех студентов 2";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(238, 12);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowTemplate.Height = 25;
        dataGridView1.Size = new Size(550, 180);
        dataGridView1.TabIndex = 3;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(dataGridView1);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button button1;
    private Button button2;
    private Button button3;
    private DataGridView dataGridView1;
}