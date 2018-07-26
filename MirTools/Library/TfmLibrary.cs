using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirTools.Library
{
    public partial class TfmLibrary : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string FilePath;
        private Common.OpenType openType;
        private Common.LibraryType libraryType;
        private FileStructures.MLibraryV2 CSharpV2ImageLibrary;
        private FileStructures.WeMadeLibrary WemadeLibrary;
        private FileStructures.WTLLibrary WTLLibrary;
        private readonly Dictionary<int, int> _indexList = new Dictionary<int, int>();
        private OpenFileDialog OFD = new OpenFileDialog();

        ListView.SelectedIndexCollection col;

        private UInt16 CurrentFrame = 0;

        public TfmLibrary(string Path, Common.OpenType OpenType, Common.LibraryType LibraryType)
        {
            FilePath = Path;
            openType = OpenType;
            libraryType = LibraryType;

            InitializeComponent();
             
            // Initialize OpenFileDialog
            OFD.Filter = Common.OpenFileDialogFilter;

            switch (LibraryType)
            {
                case Common.LibraryType.None:
                    break;

                case Common.LibraryType.CSharpLibraryV1:
                    break;

                case Common.LibraryType.CSharpLibraryV2:
                    OpenCSharpV2Library();
                    break;

                case Common.LibraryType.WeMadeLibrary:
                    OpenWeMadeLibrary();
                    break;

                case Common.LibraryType.WTLLibrary:
                    OpenWTLLibrary();
                    break;

                default:
                    break;
            }
        }

        private void OpenCSharpV2Library()
        {
            if (CSharpV2ImageLibrary != null) CSharpV2ImageLibrary.Close();
                    
            cbAction.Properties.Items.AddRange(Enum.GetValues(typeof(Common.MirAction)).Cast<Common.MirAction>().ToList());

            ImageList.Images.Clear();
            PreviewListView.SelectedIndices.Clear();
            PreviewListView.Items.Clear();
            _indexList.Clear();

            switch (openType)
            {
                case Common.OpenType.Open:
                    CSharpV2ImageLibrary = new FileStructures.MLibraryV2(FilePath);
                    break;

                case Common.OpenType.New:
                    CSharpV2ImageLibrary = new FileStructures.MLibraryV2(FilePath);
                    CSharpV2ImageLibrary.Save();
                    break;

                case Common.OpenType.None:
                default:
                    MessageBox.Show("Invalid Open Type.");
                    this.Dispose();
                    break;
            }
            this.Text = System.IO.Path.GetFileName(FilePath);

            PreviewListView.VirtualListSize = CSharpV2ImageLibrary.Images.Count;
            PreviewListView.RedrawItems(0, PreviewListView.Items.Count - 1, true);

            if (PreviewListView.Items.Count > 0)
            {
                PreviewListView.Items[0].Selected = true;
            }

            lbImageCount.Caption = string.Format("Images: {0}", CSharpV2ImageLibrary.Images.Count);
            GC.Collect();
        }

        private void OpenWeMadeLibrary()
        {
            if (WemadeLibrary != null) WemadeLibrary = null;

            ImageList.Images.Clear();
            PreviewListView.SelectedIndices.Clear();
            PreviewListView.Items.Clear();
            _indexList.Clear();

            switch (openType)
            {
                case Common.OpenType.Open:
                    WemadeLibrary = new FileStructures.WeMadeLibrary(FilePath);
                    break;

                case Common.OpenType.New:
                    WemadeLibrary = new FileStructures.WeMadeLibrary(FilePath);
                    // WemadeLibrary.Save();
                    break;

                case Common.OpenType.None:
                default:
                    MessageBox.Show("Invalid Open Type.");
                    this.Dispose();
                    break;
            }
            this.Text = System.IO.Path.GetFileName(FilePath);

            PreviewListView.VirtualListSize = WemadeLibrary.Images.Length;
            PreviewListView.RedrawItems(0, PreviewListView.Items.Count - 1, true);

            if (PreviewListView.Items.Count > 0)
            {
                PreviewListView.Items[0].Selected = true;
            }

            lbImageCount.Caption = string.Format("Images: {0}", WemadeLibrary.Images.Length);
          //  GC.Collect();
        }

        private void OpenWTLLibrary()
        {
            if (WTLLibrary != null) WTLLibrary = null;

            ImageList.Images.Clear();
            PreviewListView.SelectedIndices.Clear();
            PreviewListView.Items.Clear();
            _indexList.Clear();

            switch (openType)
            {
                case Common.OpenType.Open:
                    WTLLibrary = new FileStructures.WTLLibrary(FilePath);
                    break;

                case Common.OpenType.New:
                    WTLLibrary = new FileStructures.WTLLibrary(FilePath);
                    // WemadeLibrary.Save();
                    break;

                case Common.OpenType.None:
                default:
                    MessageBox.Show("Invalid Open Type.");
                    this.Dispose();
                    break;
            }
            this.Text = System.IO.Path.GetFileName(FilePath);

            PreviewListView.VirtualListSize = WTLLibrary.Images.Length;
            PreviewListView.RedrawItems(0, PreviewListView.Items.Count - 1, true);

            if (PreviewListView.Items.Count > 0)
            {
                PreviewListView.Items[0].Selected = true;
            }

            lbImageCount.Caption = string.Format("Images: {0}", WTLLibrary.Images.Length);
            GC.Collect();
        }

        private void fixedListView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            int index;

            if (_indexList.TryGetValue(e.ItemIndex, out index))
            {
                e.Item = new ListViewItem { ImageIndex = index, Text = e.ItemIndex.ToString() };
                return;
            }

            _indexList.Add(e.ItemIndex, ImageList.Images.Count);
            ImageList.Images.Add(GetPreview(libraryType, e.ItemIndex));
            e.Item = new ListViewItem { ImageIndex = index, Text = e.ItemIndex.ToString() };
        }

        private Bitmap GetPreview(Common.LibraryType libraryType, int Index)
        {
            switch (libraryType)
            {
                case Common.LibraryType.None:
                    return null;

                case Common.LibraryType.CSharpLibraryV1:
                    return null;

                case Common.LibraryType.CSharpLibraryV2:
                    return CSharpV2ImageLibrary.GetPreview(Index);

                case Common.LibraryType.WeMadeLibrary:
                    return WemadeLibrary.GetPreview(Index);

                case Common.LibraryType.WTLLibrary:
                    return WTLLibrary.GetPreview(Index);

                default:
                    return null;
            }
        }

        private void PreviewListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            col = PreviewListView.SelectedIndices;
            if (col.Count < 1) return;
            else if (col.Count == 1)
                {
                try
                {
                    timerAnimate.Enabled = false;
                    switch (libraryType)
                    {
                        case Common.LibraryType.None:
                            break;

                        case Common.LibraryType.CSharpLibraryV1:
                            break;

                        case Common.LibraryType.CSharpLibraryV2:
                            Preview.Image = CSharpV2ImageLibrary.Images[col[0]].Image;
                            Preview.Image = CSharpV2ImageLibrary.Images[col[0]].Image;
                            break;

                        case Common.LibraryType.WeMadeLibrary:
                            Preview.Image = WemadeLibrary.Images[col[0]].Image;
                            break;

                        case Common.LibraryType.WTLLibrary:
                            Preview.Image = WTLLibrary.Images[col[0]].Image;
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                CurrentFrame = 0;
                timerAnimate.Enabled = true;
                timerAnimate.Start();
            }
        }

        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openType = Common.OpenType.Open;

            GC.Collect();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                FilePath = OFD.FileName;
                switch (Path.GetExtension(FilePath).ToLower())
                {
                    case ".wtl":
                        libraryType = Common.LibraryType.WTLLibrary;
                        OpenWTLLibrary();
                        break;
                    case ".lib":
                        libraryType = Common.LibraryType.CSharpLibraryV2;
                        OpenCSharpV2Library();
                        break;
                    default:
                        libraryType = Common.LibraryType.WeMadeLibrary;
                        OpenWeMadeLibrary();
                        break;
                }
            }
           // GC.Collect();
        }

        private void colourBackground_EditValueChanged(object sender, EventArgs e)
        {
            Preview.BackColor = Functions.ColourFromString.Colour(colourBackground.EditValue.ToString());
        }

        private void btnCropImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < CSharpV2ImageLibrary.Images.Count; i++)
            {
                CSharpV2ImageLibrary.Images[i].Image = Functions.CropImage.CropTransparent(CSharpV2ImageLibrary.Images[i].Image).Image;
                CSharpV2ImageLibrary.Images[i].X += (short)Functions.CropImage.CropTransparent(CSharpV2ImageLibrary.Images[i].Image).X;
                CSharpV2ImageLibrary.Images[i].Y += (short)Functions.CropImage.CropTransparent(CSharpV2ImageLibrary.Images[i].Image).Y;
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (libraryType == Common.LibraryType.CSharpLibraryV2)
                CSharpV2ImageLibrary.Save();
            else
                MessageBox.Show("Cannot save this type yet.");
        }

        private void TfmLibrary_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnRemoveBlack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (workerRemoveBlack.IsBusy != true)
            {
                workerRemoveBlack.RunWorkerAsync();
            }
        }

        class ReportImage
        {
            public Bitmap Image;
            public int Index;
        }

        private void workerRemoveBlack_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Thread.Sleep(1500); // Sleep thread to allow form to be drawn
            BackgroundWorker worker = sender as BackgroundWorker;

            switch (libraryType)
            {
                case Common.LibraryType.None:
                    break;
                case Common.LibraryType.CSharpLibraryV1:
                    break;
                case Common.LibraryType.CSharpLibraryV2:
                    for (int i = 0; i < CSharpV2ImageLibrary.Images.Count; i++)
                        try
                        {
                            workerRemoveBlack.ReportProgress((int)Math.Round((double)(100 * (i + 1)) / CSharpV2ImageLibrary.Images.Count), (ReportImage)new ReportImage { Image = Functions.ColourReplace.Process(CSharpV2ImageLibrary.Images[i].Image, Color.Black, Color.Transparent), Index = i });
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    break;
                case Common.LibraryType.WeMadeLibrary:
                    for (int i = 0; i < WemadeLibrary.Images.Length; i++)
                        try
                        {
                            workerRemoveBlack.ReportProgress((int)Math.Round((double)(100 * (i + 1)) / WemadeLibrary.Images.Length), (ReportImage)new ReportImage { Image = Functions.ColourReplace.Process(WemadeLibrary.Images[i].Image, Color.Black, Color.Transparent), Index = i });
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    break;
                case Common.LibraryType.WTLLibrary:
                    for (int i = 0; i < WTLLibrary.Images.Length; i++)
                        try
                        {
                            workerRemoveBlack.ReportProgress((int)Math.Round((double)(100 * (i + 1)) / WTLLibrary.Images.Length), (ReportImage)new ReportImage { Image = Functions.ColourReplace.Process(WTLLibrary.Images[i].Image, Color.Black, Color.Transparent), Index = i });
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    break;
                default:
                    break;
            }
        }

        private void workerRemoveBlack_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ReportImage _temp = (ReportImage)e.UserState;
            this.Text = e.ProgressPercentage.ToString() + "%";
            
            switch (libraryType)
            {
                case Common.LibraryType.None:
                    break;
                case Common.LibraryType.CSharpLibraryV1:
                    break;
                case Common.LibraryType.CSharpLibraryV2:
                    CSharpV2ImageLibrary.Images[_temp.Index].Image = _temp.Image;
                    break;
                case Common.LibraryType.WeMadeLibrary:
                    WemadeLibrary.Images[_temp.Index].Image = _temp.Image;
                    break;
                case Common.LibraryType.WTLLibrary:
                    WTLLibrary.Images[_temp.Index].Image = _temp.Image;
                    break;
                default:
                    break;
            }            
        }

        private void workerRemoveBlack_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Preview Cancelled");
            }
            else if (e.Error != null)
            {
            }
            else
            {
                this.Text = System.IO.Path.GetFileName(FilePath);

                _indexList.Clear();
                switch (libraryType)
                {
                    case Common.LibraryType.None:
                        break;
                    case Common.LibraryType.CSharpLibraryV1:
                        break;
                    case Common.LibraryType.CSharpLibraryV2:
                        PreviewListView.VirtualListSize = CSharpV2ImageLibrary.Images.Count;

                        try
                        {
                            PreviewListView.RedrawItems(0, PreviewListView.Items.Count - 1, true);
                            Preview.Image = CSharpV2ImageLibrary.Images[PreviewListView.SelectedIndices[0]].Image;
                        }
                        catch (Exception) { return; }
                        break;
                    case Common.LibraryType.WeMadeLibrary:
                        PreviewListView.VirtualListSize = WemadeLibrary.Images.Length;

                        try
                        {
                            PreviewListView.RedrawItems(0, PreviewListView.Items.Count - 1, true);
                            Preview.Image = WemadeLibrary.Images[PreviewListView.SelectedIndices[0]].Image;
                        }
                        catch (Exception) { return; }
                        break;
                    case Common.LibraryType.WTLLibrary:
                        PreviewListView.VirtualListSize = WTLLibrary.Images.Length;

                        try
                        {
                            PreviewListView.RedrawItems(0, PreviewListView.Items.Count - 1, true);
                            Preview.Image = WTLLibrary.Images[PreviewListView.SelectedIndices[0]].Image;
                        }
                        catch (Exception) { return; }
                        break;
                    default:
                        break;
                }
            }
            GC.Collect();
        }

        private void timerAnimate_Tick(object sender, EventArgs e)
        {

            if (CurrentFrame == col.Count)
            {
                CurrentFrame = 0;
                if (btnLoopAnimation.Checked == false)
                {
                    timerAnimate.Enabled = false;
                    btnAnimatePreview.Checked = false;
                }
            }

            try
            {
                switch (libraryType)
                {
                    case Common.LibraryType.None:
                        break;

                    case Common.LibraryType.CSharpLibraryV1:
                        break;

                    case Common.LibraryType.CSharpLibraryV2:
                        Preview.Image = CSharpV2ImageLibrary.Images[col[CurrentFrame]].Image;
                        Preview.Image = CSharpV2ImageLibrary.Images[col[CurrentFrame]].Image;
                        break;

                    case Common.LibraryType.WeMadeLibrary:
                        Preview.Image = WemadeLibrary.Images[col[CurrentFrame]].Image;
                        break;

                    case Common.LibraryType.WTLLibrary:
                        Preview.Image = WTLLibrary.Images[col[CurrentFrame]].Image;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception exception)
            {
               // MessageBox.Show(exception.Message);
            }

            CurrentFrame++;
        }

        private void PreviewListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //col = PreviewListView.SelectedIndices;
            //MessageBox.Show(col.ToString());
        }

        private void PreviewListView_Click(object sender, EventArgs e)
        {
            col = PreviewListView.SelectedIndices;
            if(col.Count>1)
            {
                CurrentFrame = 0;
                timerAnimate.Enabled = true;
                timerAnimate.Start();
            }
        }

        private void repositoryItemSpinEdit1_ValueChanged(object sender, EventArgs e)
        {
            //timerAnimate.Interval = Convert.ToUInt16(nudPlaySpeed.EditValue);
        }

        private void nudPlaySpeed_EditValueChanged(object sender, EventArgs e)
        {

            timerAnimate.Interval = Convert.ToUInt16(nudPlaySpeed.EditValue);
        }

        private void btnAnimatePreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnAnimatePreview_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnAnimatePreview.Checked == false)
                timerAnimate.Enabled = false;
            else
                timerAnimate.Enabled = true;

        }

        private void FrameAssign(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton s = sender as DevExpress.XtraEditors.SimpleButton;
            switch (s.Tag)
            {
                case "FRAME":
                    if (col.Count % 8 == 0)
                    {
                        tbFrameStart.Text = col[0].ToString();
                        tbFrameCount.Text = (col.Count / 8).ToString();
                        tbFrameSkip.Text = "0";
                    }
                    else
                    {
                        MessageBox.Show("Selected frames are not devisable by 8");
                    }
                    break;
                case "EFFECT":
                    break;
                default:
                    break;
            }
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}