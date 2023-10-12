namespace fileLengthReporter
{
    partial class FLR
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
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label_folder = new System.Windows.Forms.Label();
            this.label_report = new System.Windows.Forms.Label();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.textBox_report = new System.Windows.Forms.TextBox();
            this.button_folder = new System.Windows.Forms.Button();
            this.button_report = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBox_recursive = new System.Windows.Forms.CheckBox();
            this.label_scanned = new System.Windows.Forms.Label();
            this.button_scan = new System.Windows.Forms.Button();
            this.textBox_threshold = new System.Windows.Forms.TextBox();
            this.checkBox_threshold = new System.Windows.Forms.CheckBox();
            this.label_threshold = new System.Windows.Forms.Label();
            this.toolTip_folder = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_report = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_filter = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_length = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_recursive = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CheckPathExists = false;
            this.saveFileDialog1.Filter = "txt file|*.txt|All files|*.*";
            this.saveFileDialog1.OverwritePrompt = false;
            this.saveFileDialog1.ValidateNames = false;
            // 
            // label_folder
            // 
            this.label_folder.AutoSize = true;
            this.label_folder.Location = new System.Drawing.Point(10, 24);
            this.label_folder.Name = "label_folder";
            this.label_folder.Size = new System.Drawing.Size(76, 13);
            this.label_folder.TabIndex = 0;
            this.label_folder.Text = "Folder to Scan";
            // 
            // label_report
            // 
            this.label_report.AutoSize = true;
            this.label_report.Location = new System.Drawing.Point(10, 124);
            this.label_report.Name = "label_report";
            this.label_report.Size = new System.Drawing.Size(58, 13);
            this.label_report.TabIndex = 1;
            this.label_report.Text = "Report File";
            // 
            // textBox_folder
            // 
            this.textBox_folder.AllowDrop = true;
            this.textBox_folder.Location = new System.Drawing.Point(92, 21);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(324, 20);
            this.textBox_folder.TabIndex = 1;
            this.textBox_folder.TextChanged += new System.EventHandler(this.textBox_folder_TextChanged);
            this.textBox_folder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_folder_DragDrop);
            this.textBox_folder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_folder_DragEnter);
            this.textBox_folder.MouseHover += new System.EventHandler(this.textBox_folder_MouseHover);
            // 
            // textBox_report
            // 
            this.textBox_report.AllowDrop = true;
            this.textBox_report.Location = new System.Drawing.Point(92, 122);
            this.textBox_report.Name = "textBox_report";
            this.textBox_report.Size = new System.Drawing.Size(324, 20);
            this.textBox_report.TabIndex = 6;
            this.textBox_report.TextChanged += new System.EventHandler(this.textBox_report_TextChanged);
            this.textBox_report.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_report_DragDrop);
            this.textBox_report.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_report_DragEnter);
            this.textBox_report.MouseHover += new System.EventHandler(this.textBox_report_MouseHover);
            // 
            // button_folder
            // 
            this.button_folder.Location = new System.Drawing.Point(422, 20);
            this.button_folder.Name = "button_folder";
            this.button_folder.Size = new System.Drawing.Size(85, 23);
            this.button_folder.TabIndex = 2;
            this.button_folder.Text = "Open";
            this.button_folder.UseVisualStyleBackColor = true;
            this.button_folder.Click += new System.EventHandler(this.button_folder_Click);
            // 
            // button_report
            // 
            this.button_report.Location = new System.Drawing.Point(422, 120);
            this.button_report.Name = "button_report";
            this.button_report.Size = new System.Drawing.Size(85, 23);
            this.button_report.TabIndex = 7;
            this.button_report.Text = "Choose";
            this.button_report.UseVisualStyleBackColor = true;
            this.button_report.Click += new System.EventHandler(this.button_report_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(178, 163);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(153, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // checkBox_recursive
            // 
            this.checkBox_recursive.AutoSize = true;
            this.checkBox_recursive.Location = new System.Drawing.Point(335, 58);
            this.checkBox_recursive.Name = "checkBox_recursive";
            this.checkBox_recursive.Size = new System.Drawing.Size(81, 17);
            this.checkBox_recursive.TabIndex = 5;
            this.checkBox_recursive.Text = "Recursively";
            this.checkBox_recursive.UseVisualStyleBackColor = true;
            this.checkBox_recursive.MouseHover += new System.EventHandler(this.checkBox_recursive_MouseHover);
            // 
            // label_scanned
            // 
            this.label_scanned.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_scanned.AutoSize = true;
            this.label_scanned.Location = new System.Drawing.Point(235, 198);
            this.label_scanned.Name = "label_scanned";
            this.label_scanned.Size = new System.Drawing.Size(38, 13);
            this.label_scanned.TabIndex = 8;
            this.label_scanned.Text = "DONE";
            this.label_scanned.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_scanned.Visible = false;
            // 
            // button_scan
            // 
            this.button_scan.Enabled = false;
            this.button_scan.Location = new System.Drawing.Point(422, 173);
            this.button_scan.Name = "button_scan";
            this.button_scan.Size = new System.Drawing.Size(85, 39);
            this.button_scan.TabIndex = 8;
            this.button_scan.Text = "Scan";
            this.button_scan.UseVisualStyleBackColor = true;
            this.button_scan.Click += new System.EventHandler(this.button_scan_Click);
            // 
            // textBox_threshold
            // 
            this.textBox_threshold.Enabled = false;
            this.textBox_threshold.Location = new System.Drawing.Point(226, 88);
            this.textBox_threshold.Name = "textBox_threshold";
            this.textBox_threshold.Size = new System.Drawing.Size(62, 20);
            this.textBox_threshold.TabIndex = 4;
            this.textBox_threshold.Visible = false;
            this.textBox_threshold.TextChanged += new System.EventHandler(this.textBox_threshold_TextChanged);
            this.textBox_threshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_threshold_KeyPress);
            this.textBox_threshold.MouseHover += new System.EventHandler(this.textBox_threshold_MouseHover);
            // 
            // checkBox_threshold
            // 
            this.checkBox_threshold.AutoSize = true;
            this.checkBox_threshold.Location = new System.Drawing.Point(92, 58);
            this.checkBox_threshold.Name = "checkBox_threshold";
            this.checkBox_threshold.Size = new System.Drawing.Size(106, 17);
            this.checkBox_threshold.TabIndex = 3;
            this.checkBox_threshold.Text = "Use Length Filter";
            this.checkBox_threshold.UseVisualStyleBackColor = true;
            this.checkBox_threshold.CheckedChanged += new System.EventHandler(this.checkBox_threshold_CheckedChanged);
            this.checkBox_threshold.MouseHover += new System.EventHandler(this.checkBox_threshold_MouseHover);
            // 
            // label_threshold
            // 
            this.label_threshold.AutoSize = true;
            this.label_threshold.Location = new System.Drawing.Point(89, 92);
            this.label_threshold.Name = "label_threshold";
            this.label_threshold.Size = new System.Drawing.Size(131, 13);
            this.label_threshold.TabIndex = 12;
            this.label_threshold.Text = "Minimum Length to Report";
            this.label_threshold.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FLR
            // 
            this.AcceptButton = this.button_scan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 224);
            this.Controls.Add(this.label_threshold);
            this.Controls.Add(this.checkBox_threshold);
            this.Controls.Add(this.textBox_threshold);
            this.Controls.Add(this.button_scan);
            this.Controls.Add(this.label_scanned);
            this.Controls.Add(this.checkBox_recursive);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_report);
            this.Controls.Add(this.button_folder);
            this.Controls.Add(this.textBox_report);
            this.Controls.Add(this.textBox_folder);
            this.Controls.Add(this.label_report);
            this.Controls.Add(this.label_folder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FLR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Length Reporter v0.3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label_folder;
        private System.Windows.Forms.Label label_report;
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.TextBox textBox_report;
        private System.Windows.Forms.Button button_folder;
        private System.Windows.Forms.Button button_report;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBox_recursive;
        private System.Windows.Forms.Label label_scanned;
        private System.Windows.Forms.Button button_scan;
        private System.Windows.Forms.TextBox textBox_threshold;
        private System.Windows.Forms.CheckBox checkBox_threshold;
        private System.Windows.Forms.Label label_threshold;
        private System.Windows.Forms.ToolTip toolTip_folder;
        private System.Windows.Forms.ToolTip toolTip_report;
        private System.Windows.Forms.ToolTip toolTip_filter;
        private System.Windows.Forms.ToolTip toolTip_length;
        private System.Windows.Forms.ToolTip toolTip_recursive;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

