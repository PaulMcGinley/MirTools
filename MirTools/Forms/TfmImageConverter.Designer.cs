namespace MirTools.Forms
{
    partial class TfmImageConverter
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
            this.cbBatchFrom = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbPath = new DevExpress.XtraEditors.ButtonEdit();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.listProcessOptions = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.cbToFormat = new DevExpress.XtraEditors.ComboBoxEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.cbBatchFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listProcessOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbToFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbBatchFrom
            // 
            this.cbBatchFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBatchFrom.Location = new System.Drawing.Point(74, 12);
            this.cbBatchFrom.Name = "cbBatchFrom";
            this.cbBatchFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBatchFrom.Properties.Items.AddRange(new object[] {
            "Files",
            "Folder"});
            this.cbBatchFrom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBatchFrom.Size = new System.Drawing.Size(422, 20);
            this.cbBatchFrom.TabIndex = 0;
            this.cbBatchFrom.TextChanged += new System.EventHandler(this.cbBatchFrom_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Batch from:";
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(74, 38);
            this.tbPath.Name = "tbPath";
            this.tbPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbPath.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tbPath.Size = new System.Drawing.Size(422, 20);
            this.tbPath.TabIndex = 2;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(392, 382);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(104, 26);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            // 
            // listProcessOptions
            // 
            this.listProcessOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listProcessOptions.Cursor = System.Windows.Forms.Cursors.Default;
            this.listProcessOptions.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Remove black"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Quantize image")});
            this.listProcessOptions.Location = new System.Drawing.Point(3, 32);
            this.listProcessOptions.Name = "listProcessOptions";
            this.listProcessOptions.Size = new System.Drawing.Size(480, 255);
            this.listProcessOptions.TabIndex = 0;
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit1.Location = new System.Drawing.Point(64, 6);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.buttonEdit1.Size = new System.Drawing.Size(419, 20);
            this.buttonEdit1.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Rename:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.checkedListBoxControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(472, 101);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "From Format";
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkedListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "JPEG (*.jpg)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Bitmap (*.bmp)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Portable Network Graphic (*.png)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Tagged Image File Format (*.TIFF)")});
            this.checkedListBoxControl1.Location = new System.Drawing.Point(2, 20);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(468, 79);
            this.checkedListBoxControl1.TabIndex = 0;
            // 
            // cbToFormat
            // 
            this.cbToFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbToFormat.Location = new System.Drawing.Point(3, 24);
            this.cbToFormat.Name = "cbToFormat";
            this.cbToFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbToFormat.Properties.Items.AddRange(new object[] {
            "Bitmap (8-Bit)",
            "Bitmap (16-Bit)",
            "Bitmap (24-Bit)",
            "Bitmap (32-Bit)",
            "PNG with transparency"});
            this.cbToFormat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbToFormat.Size = new System.Drawing.Size(464, 20);
            this.cbToFormat.TabIndex = 8;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 64);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(484, 312);
            this.xtraTabControl1.TabIndex = 9;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.listProcessOptions);
            this.xtraTabPage1.Controls.Add(this.buttonEdit1);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.xtraTabPage1.Size = new System.Drawing.Size(482, 287);
            this.xtraTabPage1.Text = "Process Options";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.groupControl1);
            this.xtraTabPage2.Controls.Add(this.groupControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.xtraTabPage2.Size = new System.Drawing.Size(478, 284);
            this.xtraTabPage2.Text = "Conversion";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cbToFormat);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(3, 104);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(472, 52);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Output Format";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(478, 284);
            this.xtraTabPage3.Text = "Log";
            // 
            // TfmImageConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 420);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cbBatchFrom);
            this.Name = "TfmImageConverter";
            this.Text = "Batch Image Converter";
            ((System.ComponentModel.ISupportInitialize)(this.cbBatchFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listProcessOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbToFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbBatchFrom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit tbPath;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.CheckedListBoxControl listProcessOptions;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbToFormat;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
    }
}