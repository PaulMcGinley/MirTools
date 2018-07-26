using MirTools.Controls;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MirTools.Forms
{
    public partial class TfmPreviewFolderConfig : DevExpress.XtraEditors.XtraForm
    {
        private FolderSelectDialog FSD = new FolderSelectDialog();

        public Common.ReturnTye ReturnType = Common.ReturnTye.None;
        public string LibraryFolder;
        public Common.FolderType FolderType;
        public Common.Gender Gender;
        public Common.Direction Direction;
        public bool CropImage;
        public bool SleepThread;

        public TfmPreviewFolderConfig()
        {
            InitializeComponent();

            // Populate combo box with values from enumerator
            cbType.Properties.Items.AddRange(Enum.GetValues(typeof(Common.FolderType)).Cast<Common.FolderType>().ToList());
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Error handle
            if (tbDir.Text.Length == 0)
            {
                MessageBox.Show("Please select a valid folder.");
                return;
            }
            if (cbType.Text == string.Empty)
            {
                MessageBox.Show("Please select a valid folder type");
                return;
            }

            LibraryFolder = tbDir.Text;
            FolderType = (Common.FolderType)Enum.Parse(typeof(Common.FolderType), cbType.Text);
            Gender = (Common.Gender)radioGender.EditValue;
            Direction = (Common.Direction)radioDirection.EditValue;
            CropImage = (cbListAdditional.Items[0].CheckState == CheckState.Checked) ? true : false;
            SleepThread = (cbListAdditional.Items[1].CheckState == CheckState.Checked) ? true : false;

            ReturnType = Common.ReturnTye.Preview;
            this.Close();
        }

        private void tbDir_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FSD.ShowDialog();
            tbDir.Text = FSD.FileName;

            for (int i = 0; i < cbType.Properties.Items.Count; i++)
                if (tbDir.Text.EndsWith(cbType.Properties.Items[i].ToString()))
                    cbType.Text = cbType.Properties.Items[i].ToString();

            if (cbType.Text == string.Empty)
                cbType.Text = "None";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}