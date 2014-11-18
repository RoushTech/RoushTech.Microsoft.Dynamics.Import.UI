namespace RoushTech.Microsoft.Dynamics.Import.UI
{
    partial class Import
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
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.TrialButton = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MappingsButton = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.CSVDataPage = new System.Windows.Forms.TabPage();
            this.TrialPage = new System.Windows.Forms.TabPage();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.StatusStrip.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.CSVDataPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "Open File Dialog";
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Location = new System.Drawing.Point(12, 12);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(75, 23);
            this.SelectFileButton.TabIndex = 0;
            this.SelectFileButton.Text = "Select File";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(853, 454);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(75, 23);
            this.ExecuteButton.TabIndex = 1;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // TrialButton
            // 
            this.TrialButton.Location = new System.Drawing.Point(772, 454);
            this.TrialButton.Name = "TrialButton";
            this.TrialButton.Size = new System.Drawing.Size(75, 23);
            this.TrialButton.TabIndex = 2;
            this.TrialButton.Text = "Trial";
            this.TrialButton.UseVisualStyleBackColor = true;
            this.TrialButton.Click += new System.EventHandler(this.TrialButton_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 480);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(940, 22);
            this.StatusStrip.TabIndex = 3;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.ToolStripStatusLabel.Text = "Status";
            // 
            // MappingsButton
            // 
            this.MappingsButton.Location = new System.Drawing.Point(93, 12);
            this.MappingsButton.Name = "MappingsButton";
            this.MappingsButton.Size = new System.Drawing.Size(75, 23);
            this.MappingsButton.TabIndex = 5;
            this.MappingsButton.Text = "Mappings";
            this.MappingsButton.UseVisualStyleBackColor = true;
            this.MappingsButton.Click += new System.EventHandler(this.MappingsButton_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.CSVDataPage);
            this.TabControl.Controls.Add(this.TrialPage);
            this.TabControl.Location = new System.Drawing.Point(12, 41);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(916, 407);
            this.TabControl.TabIndex = 6;
            // 
            // CSVDataPage
            // 
            this.CSVDataPage.Controls.Add(this.DataGridView);
            this.CSVDataPage.Location = new System.Drawing.Point(4, 22);
            this.CSVDataPage.Name = "CSVDataPage";
            this.CSVDataPage.Padding = new System.Windows.Forms.Padding(3);
            this.CSVDataPage.Size = new System.Drawing.Size(908, 381);
            this.CSVDataPage.TabIndex = 0;
            this.CSVDataPage.Text = "CSV Data";
            this.CSVDataPage.UseVisualStyleBackColor = true;
            // 
            // TrialPage
            // 
            this.TrialPage.Location = new System.Drawing.Point(4, 22);
            this.TrialPage.Name = "TrialPage";
            this.TrialPage.Padding = new System.Windows.Forms.Padding(3);
            this.TrialPage.Size = new System.Drawing.Size(908, 381);
            this.TrialPage.TabIndex = 1;
            this.TrialPage.Text = "Trial Results";
            this.TrialPage.UseVisualStyleBackColor = true;
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(6, 6);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(896, 369);
            this.DataGridView.TabIndex = 5;
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 502);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.MappingsButton);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.TrialButton);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.SelectFileButton);
            this.Name = "Import";
            this.Text = "Import";
            this.Load += new System.EventHandler(this.Import_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.CSVDataPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Button TrialButton;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.Button MappingsButton;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage CSVDataPage;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.TabPage TrialPage;
    }
}