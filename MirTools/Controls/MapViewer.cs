using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirTools.Controls
{
    public partial class MapViewer : UserControl
    {
        private string DataFolderPath;
        private FileStructures.MLibraryV2 MapLibraries;

        public MapViewer(string DataFolder)
        {
            InitializeComponent();
            DataFolderPath = DataFolder;
        }
    }
}
