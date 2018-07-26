namespace MirTools.Library
{
    partial class TfmAddImages
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbImages = new DevExpress.XtraEditors.ButtonEdit();
            this.lbImageCount = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.llEnd = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.hyperlinkLabelControl1 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.arrowMiddle = new System.Windows.Forms.PictureBox();
            this.PreviewRight = new System.Windows.Forms.PictureBox();
            this.PreviewLeft = new System.Windows.Forms.PictureBox();
            this.arrowStart = new System.Windows.Forms.PictureBox();
            this.arrowEnd = new System.Windows.Forms.PictureBox();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbImages.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Images";
            // 
            // tbImages
            // 
            this.tbImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbImages.Location = new System.Drawing.Point(75, 9);
            this.tbImages.Name = "tbImages";
            this.tbImages.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbImages.Properties.ReadOnly = true;
            this.tbImages.Size = new System.Drawing.Size(334, 20);
            this.tbImages.TabIndex = 3;
            // 
            // lbImageCount
            // 
            this.lbImageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbImageCount.Appearance.Options.UseTextOptions = true;
            this.lbImageCount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbImageCount.Location = new System.Drawing.Point(460, 12);
            this.lbImageCount.Name = "lbImageCount";
            this.lbImageCount.Size = new System.Drawing.Size(92, 13);
            this.lbImageCount.TabIndex = 4;
            this.lbImageCount.Text = "Selected Images: 0";
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(75, 35);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Size = new System.Drawing.Size(100, 20);
            this.spinEdit1.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Insert After";
            // 
            // llEnd
            // 
            this.llEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llEnd.Location = new System.Drawing.Point(222, 38);
            this.llEnd.Name = "llEnd";
            this.llEnd.Size = new System.Drawing.Size(18, 13);
            this.llEnd.TabIndex = 7;
            this.llEnd.Text = "End";
            // 
            // hyperlinkLabelControl1
            // 
            this.hyperlinkLabelControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hyperlinkLabelControl1.Location = new System.Drawing.Point(181, 38);
            this.hyperlinkLabelControl1.Name = "hyperlinkLabelControl1";
            this.hyperlinkLabelControl1.Size = new System.Drawing.Size(24, 13);
            this.hyperlinkLabelControl1.TabIndex = 8;
            this.hyperlinkLabelControl1.Text = "Start";
            // 
            // arrowMiddle
            // 
            this.arrowMiddle.Image = global::MirTools.Properties.Resources.down_arrow;
            this.arrowMiddle.Location = new System.Drawing.Point(146, 96);
            this.arrowMiddle.Name = "arrowMiddle";
            this.arrowMiddle.Size = new System.Drawing.Size(64, 53);
            this.arrowMiddle.TabIndex = 9;
            this.arrowMiddle.TabStop = false;
            // 
            // PreviewRight
            // 
            this.PreviewRight.BackColor = System.Drawing.Color.White;
            this.PreviewRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewRight.Location = new System.Drawing.Point(181, 150);
            this.PreviewRight.Name = "PreviewRight";
            this.PreviewRight.Size = new System.Drawing.Size(100, 100);
            this.PreviewRight.TabIndex = 1;
            this.PreviewRight.TabStop = false;
            // 
            // PreviewLeft
            // 
            this.PreviewLeft.BackColor = System.Drawing.Color.White;
            this.PreviewLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewLeft.Location = new System.Drawing.Point(75, 150);
            this.PreviewLeft.Name = "PreviewLeft";
            this.PreviewLeft.Size = new System.Drawing.Size(100, 100);
            this.PreviewLeft.TabIndex = 0;
            this.PreviewLeft.TabStop = false;
            // 
            // arrowStart
            // 
            this.arrowStart.Image = global::MirTools.Properties.Resources.down_arrow;
            this.arrowStart.Location = new System.Drawing.Point(43, 96);
            this.arrowStart.Name = "arrowStart";
            this.arrowStart.Size = new System.Drawing.Size(64, 53);
            this.arrowStart.TabIndex = 10;
            this.arrowStart.TabStop = false;
            // 
            // arrowEnd
            // 
            this.arrowEnd.Image = global::MirTools.Properties.Resources.down_arrow;
            this.arrowEnd.Location = new System.Drawing.Point(250, 96);
            this.arrowEnd.Name = "arrowEnd";
            this.arrowEnd.Size = new System.Drawing.Size(64, 53);
            this.arrowEnd.TabIndex = 11;
            this.arrowEnd.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(460, 193);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 31);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(460, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 20);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            // 
            // TfmAddImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.arrowEnd);
            this.Controls.Add(this.arrowStart);
            this.Controls.Add(this.arrowMiddle);
            this.Controls.Add(this.hyperlinkLabelControl1);
            this.Controls.Add(this.llEnd);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.spinEdit1);
            this.Controls.Add(this.lbImageCount);
            this.Controls.Add(this.tbImages);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.PreviewRight);
            this.Controls.Add(this.PreviewLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfmAddImages";
            this.Text = "Add Image";
            ((System.ComponentModel.ISupportInitialize)(this.tbImages.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PreviewLeft;
        private System.Windows.Forms.PictureBox PreviewRight;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit tbImages;
        private DevExpress.XtraEditors.LabelControl lbImageCount;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.HyperlinkLabelControl llEnd;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControl1;
        private System.Windows.Forms.PictureBox arrowMiddle;
        private System.Windows.Forms.PictureBox arrowStart;
        private System.Windows.Forms.PictureBox arrowEnd;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}