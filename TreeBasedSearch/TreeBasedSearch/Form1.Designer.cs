﻿namespace TreeBasedSearch
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
            lblFilePath = new Label();
            tbxFilePath = new TextBox();
            btnGenerateMap = new Button();
            SuspendLayout();
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(47, 46);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(55, 15);
            lblFilePath.TabIndex = 0;
            lblFilePath.Text = "File Path:";
            // 
            // tbxFilePath
            // 
            tbxFilePath.Location = new Point(108, 43);
            tbxFilePath.Name = "tbxFilePath";
            tbxFilePath.Size = new Size(280, 23);
            tbxFilePath.TabIndex = 1;
            // 
            // btnGenerateMap
            // 
            btnGenerateMap.Location = new Point(394, 42);
            btnGenerateMap.Name = "btnGenerateMap";
            btnGenerateMap.Size = new Size(148, 23);
            btnGenerateMap.TabIndex = 2;
            btnGenerateMap.Text = "Generate map";
            btnGenerateMap.UseVisualStyleBackColor = true;
            btnGenerateMap.Click += btnGenerateMap_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGenerateMap);
            Controls.Add(tbxFilePath);
            Controls.Add(lblFilePath);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFilePath;
        private TextBox tbxFilePath;
        private Button btnGenerateMap;
    }
}