namespace MirTools.Forms
{
    partial class TfmPreviewFolderConfig
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
            this.tbDir = new DevExpress.XtraEditors.ButtonEdit();
            this.cbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.radioGender = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.radioDirection = new DevExpress.XtraEditors.RadioGroup();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.cbListAdditional = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.tbDir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioDirection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbListAdditional)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Library Folder:";
            // 
            // tbDir
            // 
            this.tbDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDir.Location = new System.Drawing.Point(106, 12);
            this.tbDir.Name = "tbDir";
            this.tbDir.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbDir.Properties.ReadOnly = true;
            this.tbDir.Size = new System.Drawing.Size(282, 20);
            this.tbDir.TabIndex = 1;
            this.tbDir.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.tbDir_ButtonClick);
            // 
            // cbType
            // 
            this.cbType.Location = new System.Drawing.Point(106, 38);
            this.cbType.Name = "cbType";
            this.cbType.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True;
            this.cbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbType.Size = new System.Drawing.Size(282, 20);
            this.cbType.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Library Type:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.radioGender);
            this.groupControl1.Location = new System.Drawing.Point(106, 64);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(97, 107);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Display Gender";
            // 
            // radioGender
            // 
            this.radioGender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGender.EditValue = ((byte)(0));
            this.radioGender.Location = new System.Drawing.Point(2, 20);
            this.radioGender.Name = "radioGender";
            this.radioGender.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(0)), "None"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(0)), "Male"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(1)), "Female"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(2)), "Both")});
            this.radioGender.Size = new System.Drawing.Size(93, 85);
            this.radioGender.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.radioDirection);
            this.groupControl2.Location = new System.Drawing.Point(209, 64);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(179, 107);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "View Direction";
            // 
            // radioDirection
            // 
            this.radioDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioDirection.EditValue = ((byte)(0));
            this.radioDirection.Location = new System.Drawing.Point(2, 20);
            this.radioDirection.Name = "radioDirection";
            this.radioDirection.Properties.Appearance.Font = new System.Drawing.Font("Wingdings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.radioDirection.Properties.Appearance.Options.UseFont = true;
            this.radioDirection.Properties.Columns = 3;
            this.radioDirection.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(7)), "ë"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(6)), "ç"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(5)), "í"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(0)), "é"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(0)), "J", false),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(4)), "ê"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(1)), "ì"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(2)), "è"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(3)), "î")});
            this.radioDirection.Size = new System.Drawing.Size(175, 85);
            this.radioDirection.TabIndex = 0;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreview.Location = new System.Drawing.Point(299, 245);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(89, 26);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Configuration:";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.cbListAdditional);
            this.groupControl3.Location = new System.Drawing.Point(106, 175);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(282, 60);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "Additional";
            // 
            // cbListAdditional
            // 
            this.cbListAdditional.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbListAdditional.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbListAdditional.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(false, "Crop Preview", "Crop Preview"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(true, "Sleep Thread", System.Windows.Forms.CheckState.Checked)});
            this.cbListAdditional.Location = new System.Drawing.Point(2, 20);
            this.cbListAdditional.Name = "cbListAdditional";
            this.cbListAdditional.Size = new System.Drawing.Size(278, 38);
            this.cbListAdditional.TabIndex = 0;
            // 
            // TfmPreviewFolderConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 283);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tbDir);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TfmPreviewFolderConfig";
            this.Text = "Preview Folder";
            ((System.ComponentModel.ISupportInitialize)(this.tbDir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioDirection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbListAdditional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ButtonEdit tbDir;
        private DevExpress.XtraEditors.ComboBoxEdit cbType;
        private DevExpress.XtraEditors.RadioGroup radioGender;
        private DevExpress.XtraEditors.RadioGroup radioDirection;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.CheckedListBoxControl cbListAdditional;
    }
}