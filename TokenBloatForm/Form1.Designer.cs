namespace TokenBloatForm
{
    partial class formChubbyChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formChubbyChecker));
            this.tvGroups = new System.Windows.Forms.TreeView();
            this.txtSamAccountName = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblSamaccountName = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblGetGroupMembership = new System.Windows.Forms.Label();
            this.btnGetGroupMembership = new System.Windows.Forms.Button();
            this.cbAlertAt = new System.Windows.Forms.ComboBox();
            this.lbAlertAt = new System.Windows.Forms.Label();
            this.cbSortBy = new System.Windows.Forms.ComboBox();
            this.lblSortBy = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chDirectlyNested = new System.Windows.Forms.CheckBox();
            this.btnImportJsonFile = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvGroups
            // 
            this.tvGroups.CheckBoxes = true;
            this.tvGroups.Location = new System.Drawing.Point(298, 17);
            this.tvGroups.Name = "tvGroups";
            this.tvGroups.Size = new System.Drawing.Size(662, 916);
            this.tvGroups.TabIndex = 100;
            this.tvGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvGroups_AfterSelect);
            // 
            // txtSamAccountName
            // 
            this.txtSamAccountName.Location = new System.Drawing.Point(87, 100);
            this.txtSamAccountName.Name = "txtSamAccountName";
            this.txtSamAccountName.Size = new System.Drawing.Size(146, 26);
            this.txtSamAccountName.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(153, 158);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(114, 34);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblSamaccountName
            // 
            this.lblSamaccountName.AutoSize = true;
            this.lblSamaccountName.Location = new System.Drawing.Point(27, 105);
            this.lblSamaccountName.Name = "lblSamaccountName";
            this.lblSamaccountName.Size = new System.Drawing.Size(54, 20);
            this.lblSamaccountName.TabIndex = 100;
            this.lblSamaccountName.Text = "Samid";
            this.lblSamaccountName.Click += new System.EventHandler(this.label1_Click);
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusBar.Location = new System.Drawing.Point(0, 1025);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.statusBar.Size = new System.Drawing.Size(980, 30);
            this.statusBar.TabIndex = 5;
            this.statusBar.Text = "Ready";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(72, 25);
            this.lblStatus.Text = "Ready...";
            // 
            // lblGetGroupMembership
            // 
            this.lblGetGroupMembership.AutoSize = true;
            this.lblGetGroupMembership.Location = new System.Drawing.Point(9, 391);
            this.lblGetGroupMembership.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblGetGroupMembership.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblGetGroupMembership.Name = "lblGetGroupMembership";
            this.lblGetGroupMembership.Size = new System.Drawing.Size(283, 40);
            this.lblGetGroupMembership.TabIndex = 100;
            this.lblGetGroupMembership.Text = "User with samaccountname testsamid found in domain local.abc";
            this.lblGetGroupMembership.Visible = false;
            // 
            // btnGetGroupMembership
            // 
            this.btnGetGroupMembership.Location = new System.Drawing.Point(12, 446);
            this.btnGetGroupMembership.Name = "btnGetGroupMembership";
            this.btnGetGroupMembership.Size = new System.Drawing.Size(237, 45);
            this.btnGetGroupMembership.TabIndex = 5;
            this.btnGetGroupMembership.Text = "Get Group Membership";
            this.btnGetGroupMembership.UseVisualStyleBackColor = true;
            this.btnGetGroupMembership.Visible = false;
            this.btnGetGroupMembership.Click += new System.EventHandler(this.btnGetGroupMembership_Click);
            // 
            // cbAlertAt
            // 
            this.cbAlertAt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlertAt.FormattingEnabled = true;
            this.cbAlertAt.Location = new System.Drawing.Point(87, 222);
            this.cbAlertAt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAlertAt.Name = "cbAlertAt";
            this.cbAlertAt.Size = new System.Drawing.Size(58, 28);
            this.cbAlertAt.TabIndex = 3;
            this.cbAlertAt.Visible = false;
            // 
            // lbAlertAt
            // 
            this.lbAlertAt.AutoSize = true;
            this.lbAlertAt.Location = new System.Drawing.Point(16, 226);
            this.lbAlertAt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAlertAt.Name = "lbAlertAt";
            this.lbAlertAt.Size = new System.Drawing.Size(62, 20);
            this.lbAlertAt.TabIndex = 102;
            this.lbAlertAt.Text = "Alert At";
            this.lbAlertAt.Visible = false;
            // 
            // cbSortBy
            // 
            this.cbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSortBy.FormattingEnabled = true;
            this.cbSortBy.Location = new System.Drawing.Point(87, 285);
            this.cbSortBy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSortBy.Name = "cbSortBy";
            this.cbSortBy.Size = new System.Drawing.Size(202, 28);
            this.cbSortBy.TabIndex = 4;
            this.cbSortBy.Visible = false;
            // 
            // lblSortBy
            // 
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.Location = new System.Drawing.Point(16, 289);
            this.lblSortBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(61, 20);
            this.lblSortBy.TabIndex = 100;
            this.lblSortBy.Text = "Sort By";
            this.lblSortBy.Visible = false;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(87, 34);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(146, 26);
            this.txtDomain.TabIndex = 0;
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(20, 38);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(64, 20);
            this.lblDomain.TabIndex = 101;
            this.lblDomain.Text = "Domain";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "(leave blank for current domain)";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(32, 537);
            this.btnDownLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(194, 37);
            this.btnDownLoad.TabIndex = 6;
            this.btnDownLoad.Text = "Download to json file";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Visible = false;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // chDirectlyNested
            // 
            this.chDirectlyNested.AutoSize = true;
            this.chDirectlyNested.Location = new System.Drawing.Point(24, 342);
            this.chDirectlyNested.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chDirectlyNested.Name = "chDirectlyNested";
            this.chDirectlyNested.Size = new System.Drawing.Size(213, 24);
            this.chDirectlyNested.TabIndex = 103;
            this.chDirectlyNested.Text = "Show only directly nested";
            this.chDirectlyNested.UseVisualStyleBackColor = true;
            this.chDirectlyNested.Visible = false;
            // 
            // btnImportJsonFile
            // 
            this.btnImportJsonFile.Location = new System.Drawing.Point(789, 962);
            this.btnImportJsonFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImportJsonFile.Name = "btnImportJsonFile";
            this.btnImportJsonFile.Size = new System.Drawing.Size(172, 35);
            this.btnImportJsonFile.TabIndex = 104;
            this.btnImportJsonFile.Text = "Import Json File";
            this.btnImportJsonFile.UseVisualStyleBackColor = true;
            this.btnImportJsonFile.Click += new System.EventHandler(this.btnImportJsonFile_Click);
            // 
            // formChubbyChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 1055);
            this.Controls.Add(this.btnImportJsonFile);
            this.Controls.Add(this.chDirectlyNested);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.lblSortBy);
            this.Controls.Add(this.cbSortBy);
            this.Controls.Add(this.lbAlertAt);
            this.Controls.Add(this.cbAlertAt);
            this.Controls.Add(this.btnGetGroupMembership);
            this.Controls.Add(this.lblGetGroupMembership);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.lblSamaccountName);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtSamAccountName);
            this.Controls.Add(this.tvGroups);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formChubbyChecker";
            this.Text = "Chubby Checker";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvGroups;
        private System.Windows.Forms.TextBox txtSamAccountName;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblSamaccountName;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label lblGetGroupMembership;
        private System.Windows.Forms.Button btnGetGroupMembership;
        private System.Windows.Forms.ComboBox cbAlertAt;
        private System.Windows.Forms.Label lbAlertAt;
        private System.Windows.Forms.ComboBox cbSortBy;
        private System.Windows.Forms.Label lblSortBy;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chDirectlyNested;
        private System.Windows.Forms.Button btnImportJsonFile;
    }
}

