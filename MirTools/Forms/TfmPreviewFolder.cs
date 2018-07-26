using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MirTools.Forms
{
    public partial class TfmPreviewFolder : DevExpress.XtraEditors.XtraForm
    {
        private FileStructures.MLibraryV2 _tempLibrary;

        // string[] Files;
        private List<string> ErrorFiles = new List<string>();

        private UInt16 ArmourOffset = 808, WeaponOffset = 416;
        private ushort FilesCount = 0;

        private void ImageListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(ImageListBox.Items[ImageListBox.SelectedIndices[0]].Tag.ToString());
        }

        public TfmPreviewFolder(String Dir, Common.FolderType Folder = Common.FolderType.None, Common.Gender Gender = Common.Gender.None, Common.Direction Direction = Common.Direction.None)
        {
            InitializeComponent();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }

            FilesCount = (ushort)Directory.GetFiles(Dir).Length;
            // Files = Directory.GetFiles(Dir);

            for (int i = 0; i < FilesCount; i++)
            {
                try
                {
                    //if (Files[i].EndsWith(".LIB", StringComparison.OrdinalIgnoreCase))
                    //{
                    _tempLibrary = new FileStructures.MLibraryV2(Dir + "//" + i.ToString("00") + ".Lib");

                    switch (Folder)
                    {
                        case Common.FolderType.None:
                            // TODO: Add
                            break;

                        case Common.FolderType.CHumEffect:
                            switch (Gender)
                            {
                                case Common.Gender.None:
                                    //string.Format("Library: {0}.Lib\r\nDatabase Effect Number: {1}", i.ToString("00"), (i+1).ToString("00"));
                                    ImageListBox.Items.Add(new ImageListBoxItem(null, string.Format("Library: {0}.Lib\r\nDatabase Effect Number: {1}", i.ToString("00"), (i + 1).ToString("00")), i, "", _tempLibrary.Images[0 + ((byte)Direction * 8)].Image));
                                    break;

                                case Common.Gender.Male:
                                    ImageListBox.Items.Add(new ImageListBoxItem(null, string.Format("Library: {0}.Lib\r\nDatabase Effect Number: {1}\r\nGender: Male", i.ToString("00"), (i + 1).ToString("00")), i, "", _tempLibrary.Images[0 + ((byte)Direction * 8)].Image));
                                    break;

                                case Common.Gender.Female:
                                    ImageListBox.Items.Add(new ImageListBoxItem(null, string.Format("Library: {0}.Lib\r\nDatabase Effect Number: {1}\r\nGender: Female", i.ToString("00"), (i + 1).ToString("00")), i, "", _tempLibrary.Images[0 + ((byte)Direction * 8) + ArmourOffset].Image));
                                    break;

                                case Common.Gender.Both:
                                    ImageListBox.Items.Add(new ImageListBoxItem(null, string.Format("Library: {0}.Lib\r\nDatabase Effect Number: {1}\r\nGender: Male", i.ToString("00"), (i + 1).ToString("00")), i, "", _tempLibrary.Images[0 + ((byte)Direction * 8)].Image));
                                    ImageListBox.Items.Add(new ImageListBoxItem(null, string.Format("Library: {0}.Lib\r\nDatabase Effect Number: {1}\r\nGender: Female", i.ToString("00"), (i + 1).ToString("00")), i, "", _tempLibrary.Images[0 + ((byte)Direction * 8) + ArmourOffset].Image));
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case Common.FolderType.CArmour:
                            switch (Gender)
                            {
                                case Common.Gender.None:
                                    ImageListBox.Items.Add(new ImageListBoxItem(null, "Library: " + i.ToString("00") + ".Lib", i, "", _tempLibrary.Images[0 + ((byte)Direction * 4)].Image));
                                    break;

                                case Common.Gender.Male:
                                    ImageListBox.Items.Add(new ImageListBoxItem(null, "Library: " + i.ToString("00") + ".Lib" + "\r\nGender: Male", i, "", _tempLibrary.Images[0 + ((byte)Direction * 4)].Image));
                                    break;

                                case Common.Gender.Female:
                                    ImageListBox.Items.Add(new ImageListBoxItem(null, "Library: " + i.ToString("00") + ".Lib" + "\r\nGender: Female", i, "", _tempLibrary.Images[0 + ((byte)Direction * 4) + ArmourOffset].Image));
                                    break;

                                case Common.Gender.Both:
                                    ImageListBox.Items.Add(new ImageListBoxItem(null, "Library: " + i.ToString("00") + ".Lib" + "\r\nGender: Male", i, "", _tempLibrary.Images[0 + ((byte)Direction * 4)].Image));
                                    ImageListBox.Items.Add(new ImageListBoxItem(null, "Library: " + i.ToString("00") + ".Lib" + "\r\nGender: Female", i, "", _tempLibrary.Images[0 + ((byte)Direction * 4) + ArmourOffset].Image));
                                    break;

                                default:
                                    break;
                            }
                            break;

                        case Common.FolderType.CWeapon:
                            // TODO: Add
                            break;

                        case Common.FolderType.CShields:
                            // TODO: Add
                            break;

                        case Common.FolderType.CWeaponEffect:
                            // TODO: Add
                            break;

                        case Common.FolderType.AArmour:
                            // TODO: Add
                            break;

                        case Common.FolderType.AHumEffect:
                            // TODO: Add
                            break;

                        case Common.FolderType.AWeapon:
                            // TODO: Add
                            break;

                        case Common.FolderType.AWeaponEffect:
                            // TODO: Add
                            break;

                        case Common.FolderType.ARArmour:
                            // TODO: Add
                            break;

                        case Common.FolderType.ARHumEffect:
                            // TODO: Add
                            break;

                        case Common.FolderType.ARWeapon:
                            // TODO: Add
                            break;

                        case Common.FolderType.ARWeaponEffect:
                            // TODO: Add
                            break;

                        case Common.FolderType.NPC:
                            ImageListBox.Items.Add(new ImageListBoxItem(null, "Library: " + i.ToString("00") + ".Lib", i, i.ToString("00"), Functions.CropImage.CropTransparent(_tempLibrary.Images[0].Image).Image));
                            break;

                        default:
                            break;
                    }
                    //}
                }
                catch (Exception ex)
                {
                    //ErrorFiles.Add(Files[i]);
                    continue;
                }
                finally
                {
                    if (ErrorFiles.Count > 0)
                    {
                        MessageBox.Show(ErrorFiles.ToString());
                    }
                }
                GC.Collect();
            }
            this.Text += " " + ImageListBox.Items.Count.ToString();
        }
    }
}