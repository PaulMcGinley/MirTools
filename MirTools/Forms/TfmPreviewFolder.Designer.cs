namespace MirTools.Forms
{
    partial class TfmPreviewFolder
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
            this.ImageListBox = new DevExpress.XtraEditors.ImageListBoxControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ImageListBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageListBox
            // 
            this.ImageListBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ImageListBox.ColumnWidth = 400;
            this.ImageListBox.ContextMenuStrip = this.contextMenuStrip1;
            this.ImageListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImageListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageListBox.Location = new System.Drawing.Point(0, 0);
            this.ImageListBox.Name = "ImageListBox";
            this.ImageListBox.Size = new System.Drawing.Size(944, 469);
            this.ImageListBox.TabIndex = 0;
            this.ImageListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ImageListBox_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLibraryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 26);
            // 
            // openLibraryToolStripMenuItem
            // 
            this.openLibraryToolStripMenuItem.Name = "openLibraryToolStripMenuItem";
            this.openLibraryToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openLibraryToolStripMenuItem.Text = "Open Library";
            // 
            // TfmPreviewFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 469);
            this.Controls.Add(this.ImageListBox);
            this.Name = "TfmPreviewFolder";
            this.Text = "Preview Folder";
            ((System.ComponentModel.ISupportInitialize)(this.ImageListBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ImageListBoxControl ImageListBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openLibraryToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}