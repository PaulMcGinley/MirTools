using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Runtime.InteropServices;
using System.IO;

namespace MirTools
{
    public partial class TfmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        OpenFileDialog OFD = new OpenFileDialog();
        MirTools.Controls.FolderSelectDialog FSD = new Controls.FolderSelectDialog();

        MirTools.StartPage.TfmStartPage startPage = new MirTools.StartPage.TfmStartPage();

        Forms.TfmDiagnosticInformation diagnosticInformation = new Forms.TfmDiagnosticInformation();

        public TfmMain()
        {
            InitializeComponent();
            Functions.MDIClientSupport.SetBevel(this, false); // Remove 3D Sunken Bevel Effect

            // Initialize OpenFileDialog
            OFD.Filter = Common.OpenFileDialogFilter;
            OFD.Multiselect = true;

            startPage.MdiParent = this;
            startPage.WindowState = FormWindowState.Maximized;
            startPage.Show();
        }

        #region Quick Bar Buttons

        private void btnDiagnosticInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            diagnosticInformation.Show();
            diagnosticInformation.BringToFront();
        }

        #endregion

        #region Ribbon Buttons

        #region Library Buttons
        private void btnLibraryOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            GC.Collect();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < OFD.FileNames.Length; i++)
                {
                    Common.LibraryType LibraryType;
                    switch (Path.GetExtension(OFD.FileNames[i]).ToLower())
                    {
                        case ".wtl":
                            LibraryType = Common.LibraryType.WTLLibrary;
                            break;
                        case ".lib":
                            LibraryType = Common.LibraryType.CSharpLibraryV2;
                            break;
                        case ".wis":
                        case ".pak":
                        case ".dat":
                        case ".data":
                            MessageBox.Show("Cannot yet open WIS, PAK, DAT, or Data files.");
                            return;
                        default:
                            LibraryType = Common.LibraryType.WeMadeLibrary;
                            break;
                    }

                    Library.TfmLibrary libraryForm = new Library.TfmLibrary(OFD.FileNames[i], Common.OpenType.Open, LibraryType);
                    libraryForm.MdiParent = this;
                    libraryForm.Show();
                }
            }
        }

        private void btnLibraryNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            GC.Collect();
            OFD = new OpenFileDialog();
            OFD.ShowDialog();
            if (OFD.FileName == string.Empty || OFD.FileName == null) return;

            using (Library.TfmLibrary libraryForm = new Library.TfmLibrary(OFD.FileName, Common.OpenType.New, Common.LibraryType.CSharpLibraryV2))
            {
                libraryForm.MdiParent = this;
                libraryForm.FormClosing += MDIChild_FormClosing;
                libraryForm.Show();
                GC.Collect();
            }
            //  Library.TfmLibrary libraryForm = new Library.TfmLibrary(OFD.FileName, Common.OpenType.New);
        }

        private void btnPreviewFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.TfmPreviewFolderConfig previewFolderConfig = new Forms.TfmPreviewFolderConfig();
            previewFolderConfig.ShowDialog();

            if (previewFolderConfig.ReturnType == Common.ReturnTye.Preview)
            {
                Forms.TfmPreviewFolderWBGWorker previewFolder = new Forms.TfmPreviewFolderWBGWorker(
                    previewFolderConfig.LibraryFolder,
                    previewFolderConfig.FolderType,
                    previewFolderConfig.Gender,
                    previewFolderConfig.Direction,
                    previewFolderConfig.CropImage,
                    previewFolderConfig.SleepThread);

                previewFolder.MdiParent = this;
                previewFolder.Show();
            }
            else
            {
                previewFolderConfig.Dispose();
            }
            GC.Collect();
        }

        private void btnPreviewArmours_ItemClick(object sender, ItemClickEventArgs e)
        {
            FSD.ShowDialog();
            if (FSD.FileName == String.Empty || FSD.FileName == null) return;
                Forms.TfmPreviewFolderWBGWorker previewFolder = new Forms.TfmPreviewFolderWBGWorker(
                    FSD.FileName,
                    Common.FolderType.Data,
                    Common.Gender.Both,
                    Common.Direction.South,
                    false,
                    true,
                    Common.OfficialMirType.Armour);

                previewFolder.MdiParent = this;
                previewFolder.Show();

            GC.Collect();
        }

        private void btnWeapons_ItemClick(object sender, ItemClickEventArgs e)
        {
            FSD.ShowDialog();
            if (FSD.FileName == String.Empty || FSD.FileName == null) return;
            Forms.TfmPreviewFolderWBGWorker previewFolder = new Forms.TfmPreviewFolderWBGWorker(
                FSD.FileName,
                Common.FolderType.Data,
                Common.Gender.Both,
                Common.Direction.East,
                false,
                true,
                Common.OfficialMirType.Weapon);

            previewFolder.MdiParent = this;
            previewFolder.Show();

            GC.Collect();
        }

        private void btnLibraryConvert_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        #region Map Buttons
        #endregion

        #region Misc Buttons
        private void btnClearMemory_ItemClick(object sender, ItemClickEventArgs e)
        {
            GC.Collect();
        }
        #endregion

        #region MDI Child Events
        private void MDIChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            Form form = sender as Form;
            form.Dispose();
        }
        #endregion

        #endregion

        #region Misc

        private void UsageTimer_Tick(object sender, EventArgs e)
        {
            lbMemoryUsage.Caption = string.Format("Physical Memory Usage: {0}   Paged Memory Usage: {1}", Functions.ProcessMonitor.GetPhysicalMemoryUsage(), Functions.ProcessMonitor.GetPagedMemorySize64());
        }

        #endregion

        private void btnConvertImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.TfmImageConverter convertImageForm = new Forms.TfmImageConverter();
            convertImageForm.MdiParent = this;
            convertImageForm.Show();
        }

        private void btnOpenMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Map.TfmMap mapForm = new Map.TfmMap();
            mapForm.MdiParent = this;
            mapForm.Show();
        }
    }
}