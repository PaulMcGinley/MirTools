using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MirTools.Forms
{
    public partial class TfmPreviewFolderWBGWorker : DevExpress.XtraEditors.XtraForm
    {
        private FileStructures.MLibraryV2 _tempCrystalV2Library;
        private FileStructures.WeMadeLibrary _tempWeMadeLibrary;
        private FileStructures.WTLLibrary _tempWTLLibrary;
        private List<string> Files = new List<string>();
        private List<string> ErrorFiles = new List<string>();
        private ushort FilesCount = 0;

        private string _dir;
        private Common.FolderType _folder;
        private Common.Gender _gender;
        private Common.Direction _direction;
        private Common.OfficialMirType _officialMirType;
        private bool _cropImage;
        private bool _sleepThread;

        private DateTime startTime;

        public TfmPreviewFolderWBGWorker(
            String Dir,
            Common.FolderType Folder = Common.FolderType.None,
            Common.Gender Gender = Common.Gender.None,
            Common.Direction Direction = Common.Direction.None,
            bool CropImage = false,
            bool SleepThread = true,
            Common.OfficialMirType OfficialMirType = Common.OfficialMirType.None)
        {
            InitializeComponent();


            // Cast signature variables to shared variables
            _dir = Dir;
            lbDirectory.Caption = _dir;
            _folder = Folder;
            _gender = Gender;
            _direction = Direction;
            _cropImage = CropImage;
            _sleepThread = SleepThread;
            _officialMirType = OfficialMirType;

            // Log output
            listLog.Items.Add(string.Format("<b>[{0}]</b> Process started.", DateTime.Now, _dir));
            listLog.Items.Add(string.Format("Directory: <color=blue>{0}</color>", _dir));
            listLog.Items.Add(string.Format("Folder Type: <color=blue>{0}</color>   Gender: <color=blue>{1}</color>   Direction: <color=blue>{2}</color>   Official Mir Type: <color=blue>{3}</color>", _folder.ToString(), _gender.ToString(), Direction.ToString(),_officialMirType.ToString()));
            listLog.Items.Add(string.Format("Crop Images: <color=red>{0}</color>   Sleep Thread: <color=red>{1}</color>", _cropImage.ToString(),_sleepThread.ToString()));
            listLog.TopIndex = listLog.Items.Count - 1;

            // Decide to load structured format or generic
            if (_folder != Common.FolderType.None && _folder != Common.FolderType.Data)
                FilesCount = (ushort)Directory.GetFiles(_dir).Length;
            else
                Files.AddRange( Directory.GetFiles(_dir));            
            
            // Start the asynchronous operation.
            if (backgroundWorker1.IsBusy != true)
            {
                startTime = DateTime.Now; // Log time for time taken log
                backgroundWorker1.RunWorkerAsync();
            }
            GC.Collect();
        }

        #region Background Worder Functions

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_sleepThread)
            {
                listLog.Items.Add(string.Format("<b>[{0}]</b> Sleeping thread.", DateTime.Now)); // Log output
                listLog.TopIndex = listLog.Items.Count - 1;

                Thread.Sleep(1500); // Sleep thread to allow form to be drawn
            }

            BackgroundWorker worker = sender as BackgroundWorker;
            int[] ImageIndexs;
            List<int> imageIndexes = new List<int>();
            Common.Gender _currentGender = Common.Gender.None;

            // Data folder refers to office standard libraries
            if (_folder == Common.FolderType.Data)
            {
                switch (_officialMirType)
                {
                    case Common.OfficialMirType.None:
                        break;
                    case Common.OfficialMirType.Armour:
                        for (int i = 0; i < Files.Count; i++)
                        {
                            try
                            {
                                if (Files[i].ToLower().EndsWith(".wil") || Files[i].ToLower().EndsWith(".wzl") || Files[i].ToLower().EndsWith(".miz")) // Skip if not valid file type
                                {
                                    if (Files[i].ToLower().Contains("effect") || !Files[i].ToLower().Contains("hum")) continue; // Skip effect libraries and ones that are not armour libraries (to the best we can due to naming conventions)
                                    
                                    _tempWeMadeLibrary = new FileStructures.WeMadeLibrary(Files[i], false);

                                    int ArmourCount = (((_tempWeMadeLibrary.Images.Length) / 1200)); // Get the amount of armours in the library

                                    // Loop through the armour count and add the relative male / female index numbers to initialize later
                                    for (int j = 0; j < ArmourCount; j++)
                                    {
                                        imageIndexes.Add((j * 1200) + ((byte)_direction * 8));
                                        imageIndexes.Add((j * 1200) + 600 + ((byte)_direction * 8));
                                    }

                                    _tempWeMadeLibrary.InitializeLibraryImages(imageIndexes.ToArray()); // Initialize armour indexes

                                    // Loop through armour indexes and pull the image to report
                                    for (int k = 0; k < imageIndexes.Count; k+=2)
                                    {
                                        backgroundWorker1.ReportProgress((int)Math.Round((double)(0)), new ImageListBoxItem(null, string.Format("{0}\nGender: {1}", Files[i], "Male"), 0, Files[i], (Image)_tempWeMadeLibrary.Images[imageIndexes[k]].Image));
                                        backgroundWorker1.ReportProgress((int)Math.Round((double)(0)), new ImageListBoxItem(null, string.Format("{0}\nGender: {1}", Files[i], "Female"), 0, Files[i], (Image)_tempWeMadeLibrary.Images[imageIndexes[k + 1]].Image));
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                // TODO: Add error reporting code
                                continue;
                            }
                        }
                        break;
                    case Common.OfficialMirType.Weapon:
                        for (int i = 0; i < Files.Count; i++)
                        {
                            try
                            {
                                if (Files[i].ToLower().EndsWith(".wil") || Files[i].ToLower().EndsWith(".wzl") || Files[i].ToLower().EndsWith(".miz"))
                                {
                                    if (Files[i].ToLower().Contains("effect") || !Files[i].ToLower().Contains("weapon")) continue;

                                    _tempWeMadeLibrary = new FileStructures.WeMadeLibrary(Files[i], false);

                                    int WeaponCount = (((_tempWeMadeLibrary.Images.Length) / 1200));

                                    for (int j = 0; j < WeaponCount; j++)
                                    {
                                        imageIndexes.Add((j * 1200) + ((byte)_direction * 8));
                                        imageIndexes.Add((j * 1200) + 600 + ((byte)_direction * 8));
                                    }

                                    _tempWeMadeLibrary.InitializeLibraryImages(imageIndexes.ToArray());

                                    for (int k = 0; k < imageIndexes.Count; k += 2)
                                    {
                                        backgroundWorker1.ReportProgress((int)Math.Round((double)(0)), new ImageListBoxItem(null, string.Format("{0}\nGender: {1}", Files[i], "Male"), 0, Files[i], (Image)_tempWeMadeLibrary.Images[imageIndexes[k]].Image));
                                        backgroundWorker1.ReportProgress((int)Math.Round((double)(0)), new ImageListBoxItem(null, string.Format("{0}\nGender: {1}", Files[i], "Female"), 0, Files[i], (Image)_tempWeMadeLibrary.Images[imageIndexes[k + 1]].Image));
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                // TODO: Add error reporting code
                                continue;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (_folder != Common.FolderType.None)
                for (int i = 0; i < FilesCount; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    if (_sleepThread) Thread.Sleep(20); // Sleep thread to allow rows to be drawn
                    try
                    {
                        switch (_folder)
                        {
                            case Common.FolderType.CArmour:
                                switch (_gender)
                                {
                                    case Common.Gender.Male:
                                        ImageIndexs = new int[] { 0 + ((byte)_direction * 4) };
                                        break;

                                    case Common.Gender.Female:
                                        ImageIndexs = new int[] { 0 + ((byte)_direction * 4) + (int)Common.LibraryImageOffsets.CArmour };
                                        break;

                                    case Common.Gender.Both:
                                        ImageIndexs = new int[] { 0 + ((byte)_direction * 4), 0 + ((byte)_direction * 4) + (int)Common.LibraryImageOffsets.CArmour };
                                        break;

                                    default:
                                        ImageIndexs = new int[] { 0 };
                                        break;
                                }
                                _tempCrystalV2Library = new FileStructures.MLibraryV2(_dir + @"\" + i.ToString("00") + ".Lib", ImageIndexs);
                                break;

                            case Common.FolderType.CWeapon:
                                switch (_gender)
                                {
                                    case Common.Gender.Male:
                                        ImageIndexs = new int[] { 0 + ((byte)_direction * 4) };
                                        break;

                                    case Common.Gender.Female:
                                        ImageIndexs = new int[] { 0 + ((byte)_direction * 4) + (int)Common.LibraryImageOffsets.CWeapon };
                                        break;

                                    case Common.Gender.Both:
                                        ImageIndexs = new int[] { 0 + ((byte)_direction * 4), 0 + ((byte)_direction * 4) + (int)Common.LibraryImageOffsets.CWeapon };
                                        break;

                                    default:
                                        ImageIndexs = new int[] { 0 };
                                        break;
                                }
                                _tempCrystalV2Library = new FileStructures.MLibraryV2(_dir + @"\" + i.ToString("00") + ".Lib", ImageIndexs);
                                break;

                            case Common.FolderType.Monster:
                                ImageIndexs = new int[] { 0 };
                                _tempCrystalV2Library = new FileStructures.MLibraryV2(_dir + @"\" + i.ToString("000") + ".Lib", ImageIndexs);
                                break;

                            default:
                                return;
                        }

                        for (int j = 0; j < ImageIndexs.Length; j++)
                        {
                            _currentGender = (j == 0) ? Common.Gender.Male : Common.Gender.Female; // Used for displaying gender in error
                            FileStructures.MLibraryV2.MImage _tempImage = _tempCrystalV2Library.Images[ImageIndexs[j]];

                            // Image processing
                            if (_cropImage == true) _tempImage.Image = Functions.CropImage.CropTransparent(_tempImage.Image).Image;
                            if (_tempImage.Image == null || _tempImage.Width == 0) _tempImage.Image = Properties.Resources.ImageError; // Replace new bitmap with error image

                            backgroundWorker1.ReportProgress((int)Math.Round((double)(100 * (i + 1)) / FilesCount), new ImageListBoxItem(null, string.Format("{0}\nGender: {1}", _tempCrystalV2Library.FileName, _currentGender), 0, _tempCrystalV2Library.FileName, (Image)_tempImage.Image));
                        }
                        GC.Collect();
                    }
                    catch (Exception ex)
                    {
                        backgroundWorker1.ReportProgress((int)Math.Round((double)(100 * (i + 1)) / FilesCount), new ImageListBoxItem(null, string.Format("{0}\nGender: {1}", _tempCrystalV2Library.FileName, _currentGender), 0, _tempCrystalV2Library.FileName, (Image)Properties.Resources.ImageError));
                        continue;
                    }
                }
            else
                for (int i = 0; i < Files.Count; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    if (_sleepThread) Thread.Sleep(20); // Sleep thread to allow rows to be drawn
                    try
                    {
                        _tempCrystalV2Library = new FileStructures.MLibraryV2(Files[i], new int[] { 0 });

                        FileStructures.MLibraryV2.MImage _tempImage = _tempCrystalV2Library.Images[0];

                        // Image processing
                        if (_cropImage == true) _tempImage.Image = Functions.CropImage.CropTransparent(_tempImage.Image).Image;
                        if (_tempImage.Image == null || _tempImage.Width == 0) _tempImage.Image = Properties.Resources.ImageError; // Replace new bitmap with error image

                        backgroundWorker1.ReportProgress((int)Math.Round((double)(100 * (i + 1)) / (Files.Count)), new ImageListBoxItem(null, string.Format("{0}\nGender: {1}", _tempCrystalV2Library.FileName, _gender), 0, _tempCrystalV2Library.FileName, (Image)_tempImage.Image));

                        GC.Collect();
                    }
                    catch (Exception ex)
                    {
                        backgroundWorker1.ReportProgress((int)Math.Round((double)(100 * (i + 1)) / FilesCount), new ImageListBoxItem(null, string.Format("{0}\nGender: {1}", _tempCrystalV2Library.FileName, _gender), 0, _tempCrystalV2Library.FileName, (Image)Properties.Resources.ImageError));
                        continue;
                    }
                }
            GC.Collect();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ImageListBox.Items.Add(e.UserState);
            listLog.Items.Add(string.Format("<b>[{0}]</b> Preview pulled.", DateTime.Now)); // Log output
            listLog.TopIndex = listLog.Items.Count - 1;
            this.Text = e.ProgressPercentage.ToString() + "% Loaded";

            pb.EditValue = e.ProgressPercentage;
            lbPercentage.Caption = e.ProgressPercentage.ToString() + "%";

            lbLoaded.Caption = string.Format("Loaded {0} of {1}", ImageListBox.Items.Count, FilesCount);

            GC.Collect();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCancel.Enabled = false;
            if (e.Cancelled)
            {
                listLog.Items.Add(string.Format("<b>[{0}]</b> Process cancelled.", DateTime.Now)); // Log output
                listLog.TopIndex = listLog.Items.Count - 1;
            }
            else if (e.Error != null)
            {
            }
            else
            {
                this.Text = string.Format("Preview: {0}", _dir);
                listLog.Items.Add(string.Format("<b>[{0}]</b> Process complete.", DateTime.Now)); // Log output
                listLog.TopIndex = listLog.Items.Count - 1;
            }
            listLog.Items.Add(string.Format("<b>[{0}]</b> Time taken: {1} seconds", DateTime.Now, (DateTime.Now - startTime).TotalSeconds)); // Log output
            GC.Collect();
        }

        #endregion Background Worder Functions

        #region Toolbar Buttons

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        private void btnOpenDirectory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("explorer.exe", _dir);
        }

        #endregion Toolbar Buttons

        #region StatusBar Buttons

        private void lbDirectory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("explorer.exe", _dir);
        }

        #endregion StatusBar Buttons

        #region ImageListBox Functions

        private void ImageListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Common.LibraryType libraryType = Common.LibraryType.None;
            if (ImageListBox.Items[ImageListBox.SelectedIndices[0]].Tag.ToString().ToLower().EndsWith(".wil")) libraryType = Common.LibraryType.WeMadeLibrary;
            if (ImageListBox.Items[ImageListBox.SelectedIndices[0]].Tag.ToString().ToLower().EndsWith(".wzl")) libraryType = Common.LibraryType.WeMadeLibrary;
            if (ImageListBox.Items[ImageListBox.SelectedIndices[0]].Tag.ToString().ToLower().EndsWith(".miz")) libraryType = Common.LibraryType.WeMadeLibrary;
            if (ImageListBox.Items[ImageListBox.SelectedIndices[0]].Tag.ToString().ToLower().EndsWith(".lib")) libraryType = Common.LibraryType.CSharpLibraryV2;
            if (ImageListBox.Items[ImageListBox.SelectedIndices[0]].Tag.ToString().ToLower().EndsWith(".wtl")) libraryType = Common.LibraryType.WTLLibrary;

            try
            {
                Library.TfmLibrary libraryForm = new Library.TfmLibrary(ImageListBox.Items[ImageListBox.SelectedIndices[0]].Tag.ToString(), Common.OpenType.Open, libraryType);
                libraryForm.MdiParent = this.ParentForm;
                libraryForm.Show();
            }
            catch (Exception)
            {
            }
        }

        #endregion ImageListBox Functions

        #region Misc

        #endregion
    }
}