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
            btnGBFS = new Button();
            btnAS = new Button();
            btnFindMap = new Button();
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
            btnGenerateMap.Location = new Point(547, 42);
            btnGenerateMap.Name = "btnGenerateMap";
            btnGenerateMap.Size = new Size(148, 23);
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
            tlpMap.Location = new Point(12, 130);
            tlpMap.Name = "tlpMap";
            tlpMap.RowCount = 2;
            tlpMap.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMap.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMap.Size = new Size(1038, 496);
            tlpMap.TabIndex = 3;
            // 
            // btnDFS
            // 
            btnDFS.Location = new Point(394, 71);
            btnDFS.Name = "btnDFS";
            btnDFS.Size = new Size(148, 23);
            btnDFS.TabIndex = 4;
            btnDFS.Text = "Depth first search";
            btnDFS.UseVisualStyleBackColor = true;
            btnDFS.Click += btnDFS_Click;
            // 
            // btnBFS
            // 
            btnBFS.Location = new Point(547, 71);
            btnBFS.Name = "btnBFS";
            btnBFS.Size = new Size(148, 23);
            btnBFS.TabIndex = 5;
            btnBFS.Text = "Breadth first search";
            btnBFS.UseVisualStyleBackColor = true;
            btnBFS.Click += btnBFS_Click;
            // 
            // btnGBFS
            // 
            btnGBFS.Location = new Point(350, 100);
            btnGBFS.Name = "btnGBFS";
            btnGBFS.Size = new Size(192, 23);
            btnGBFS.TabIndex = 6;
            btnGBFS.Text = "Greedy best first search";
            btnGBFS.UseVisualStyleBackColor = true;
            btnGBFS.Click += btnGBFS_Click;
            // 
            // btnAS
            // 
            btnAS.Location = new Point(547, 101);
            btnAS.Name = "btnAS";
            btnAS.Size = new Size(148, 23);
            btnAS.TabIndex = 7;
            btnAS.Text = "A* star search";
            btnAS.UseVisualStyleBackColor = true;
            btnAS.Click += btnAS_Click;
            // 
            // btnFindMap
            // 
            btnFindMap.Location = new Point(394, 42);
            btnFindMap.Name = "btnFindMap";
            btnFindMap.Size = new Size(148, 23);
            btnFindMap.TabIndex = 8;
            btnFindMap.Text = "Find map";
            btnFindMap.UseVisualStyleBackColor = true;
            btnFindMap.Click += btnFindMap_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 635);
            Controls.Add(btnFindMap);
            Controls.Add(btnAS);
            Controls.Add(btnGBFS);
            Controls.Add(btnBFS);
            Controls.Add(btnDFS);
            Controls.Add(tlpMap);
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
        private TableLayoutPanel tlpMap;
        private Button btnDFS;
        private Button btnBFS;
        private Button btnGBFS;
        private Button btnAS;
        private Button btnFindMap;
    }
}