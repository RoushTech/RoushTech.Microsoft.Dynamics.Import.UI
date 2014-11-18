namespace RoushTech.Microsoft.Dynamics.Import.UI
{
    partial class Mapping
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
            this.Mappers = new System.Windows.Forms.ComboBox();
            this.TableValueBox = new System.Windows.Forms.ComboBox();
            this.TableValueLabel = new System.Windows.Forms.Label();
            this.CsvSourceLabel = new System.Windows.Forms.Label();
            this.CsvSourceBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConstantTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Mappers
            // 
            this.Mappers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mappers.FormattingEnabled = true;
            this.Mappers.Location = new System.Drawing.Point(12, 12);
            this.Mappers.Name = "Mappers";
            this.Mappers.Size = new System.Drawing.Size(204, 21);
            this.Mappers.TabIndex = 0;
            this.Mappers.SelectedIndexChanged += new System.EventHandler(this.Mappers_SelectedIndexChanged);
            // 
            // TableValueBox
            // 
            this.TableValueBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableValueBox.FormattingEnabled = true;
            this.TableValueBox.Location = new System.Drawing.Point(93, 75);
            this.TableValueBox.Name = "TableValueBox";
            this.TableValueBox.Size = new System.Drawing.Size(204, 21);
            this.TableValueBox.TabIndex = 1;
            this.TableValueBox.SelectedIndexChanged += new System.EventHandler(this.TableValueBox_SelectedIndexChanged);
            // 
            // TableValueLabel
            // 
            this.TableValueLabel.AutoSize = true;
            this.TableValueLabel.Location = new System.Drawing.Point(20, 78);
            this.TableValueLabel.Name = "TableValueLabel";
            this.TableValueLabel.Size = new System.Drawing.Size(67, 13);
            this.TableValueLabel.TabIndex = 2;
            this.TableValueLabel.Text = "Table Value:";
            // 
            // CsvSourceLabel
            // 
            this.CsvSourceLabel.AutoSize = true;
            this.CsvSourceLabel.Location = new System.Drawing.Point(43, 103);
            this.CsvSourceLabel.Name = "CsvSourceLabel";
            this.CsvSourceLabel.Size = new System.Drawing.Size(44, 13);
            this.CsvSourceLabel.TabIndex = 4;
            this.CsvSourceLabel.Text = "Source:";
            // 
            // CsvSourceBox
            // 
            this.CsvSourceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CsvSourceBox.FormattingEnabled = true;
            this.CsvSourceBox.Location = new System.Drawing.Point(93, 103);
            this.CsvSourceBox.Name = "CsvSourceBox";
            this.CsvSourceBox.Size = new System.Drawing.Size(204, 21);
            this.CsvSourceBox.TabIndex = 3;
            this.CsvSourceBox.SelectedIndexChanged += new System.EventHandler(this.SourceBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Constant:";
            // 
            // ConstantTextbox
            // 
            this.ConstantTextbox.Location = new System.Drawing.Point(93, 130);
            this.ConstantTextbox.Name = "ConstantTextbox";
            this.ConstantTextbox.Size = new System.Drawing.Size(204, 20);
            this.ConstantTextbox.TabIndex = 6;
            this.ConstantTextbox.TextChanged += new System.EventHandler(this.ConstantTextbox_TextChanged);
            // 
            // Mapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 180);
            this.Controls.Add(this.ConstantTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CsvSourceLabel);
            this.Controls.Add(this.CsvSourceBox);
            this.Controls.Add(this.TableValueLabel);
            this.Controls.Add(this.TableValueBox);
            this.Controls.Add(this.Mappers);
            this.Name = "Mapping";
            this.Text = "Mapping";
            this.Load += new System.EventHandler(this.Mapping_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Mappers;
        private System.Windows.Forms.ComboBox TableValueBox;
        private System.Windows.Forms.Label TableValueLabel;
        private System.Windows.Forms.Label CsvSourceLabel;
        private System.Windows.Forms.ComboBox CsvSourceBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ConstantTextbox;
    }
}