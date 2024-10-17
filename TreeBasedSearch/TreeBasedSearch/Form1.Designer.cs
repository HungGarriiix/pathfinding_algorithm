namespace TreeBasedSearch
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
            tlpMap = new TableLayoutPanel();
            btnDFS = new Button();
            btnBFS = new Button();
            SuspendLayout();
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(54, 61);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(67, 20);
            lblFilePath.TabIndex = 0;
            lblFilePath.Text = "File Path:";
            // 
            // tbxFilePath
            // 
            tbxFilePath.Location = new Point(123, 57);
            tbxFilePath.Margin = new Padding(3, 4, 3, 4);
            tbxFilePath.Name = "tbxFilePath";
            tbxFilePath.Size = new Size(319, 27);
            tbxFilePath.TabIndex = 1;
            // 
            // btnGenerateMap
            // 
            btnGenerateMap.Location = new Point(450, 56);
            btnGenerateMap.Margin = new Padding(3, 4, 3, 4);
            btnGenerateMap.Name = "btnGenerateMap";
            btnGenerateMap.Size = new Size(169, 31);
            btnGenerateMap.TabIndex = 2;
            btnGenerateMap.Text = "Generate map";
            btnGenerateMap.UseVisualStyleBackColor = true;
            btnGenerateMap.Click += btnGenerateMap_Click;
            // 
            // tlpMap
            // 
            tlpMap.ColumnCount = 2;
            tlpMap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMap.Location = new Point(14, 133);
            tlpMap.Margin = new Padding(3, 4, 3, 4);
            tlpMap.Name = "tlpMap";
            tlpMap.RowCount = 2;
            tlpMap.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMap.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMap.Size = new Size(1080, 575);
            tlpMap.TabIndex = 3;
            // 
            // btnDFS
            // 
            btnDFS.Location = new Point(450, 95);
            btnDFS.Margin = new Padding(3, 4, 3, 4);
            btnDFS.Name = "btnDFS";
            btnDFS.Size = new Size(169, 31);
            btnDFS.TabIndex = 4;
            btnDFS.Text = "Depth first search";
            btnDFS.UseVisualStyleBackColor = true;
            btnDFS.Click += btnDFS_Click;
            // 
            // btnBFS
            // 
            btnBFS.Location = new Point(625, 95);
            btnBFS.Margin = new Padding(3, 4, 3, 4);
            btnBFS.Name = "btnBFS";
            btnBFS.Size = new Size(169, 31);
            btnBFS.TabIndex = 5;
            btnBFS.Text = "Breadth first search";
            btnBFS.UseVisualStyleBackColor = true;
            btnBFS.Click += btnBFS_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 724);
            Controls.Add(btnBFS);
            Controls.Add(btnDFS);
            Controls.Add(tlpMap);
            Controls.Add(btnGenerateMap);
            Controls.Add(tbxFilePath);
            Controls.Add(lblFilePath);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFilePath;
        private TextBox tbxFilePath;
        private Button btnGenerateMap;
        private TableLayoutPanel tlpMap;
        private Button btnDFS;
        private Button btnBFS;
    }
}