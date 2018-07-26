using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirTools.FileStructures
{
    public class ServerDetails
    {
        byte FileVersion = 0x1;
        string Header = "MirTools Server Details File";
        List<Details> ServerList = new List<Details>();

        public class Details
        {
            public string Address = string.Empty;
            public string FriendlyName = string.Empty;
            public string ServerName = string.Empty;
            public ushort StatusPort = 7000;
            public ushort LoginPort = 0;
            public ushort SelCharPort = 0;
            public ushort GamePort = 0;
            public string MirVersion = "Unknown"; // Mir 2, Mir 3, Mir X
            public string FilesType = "Unknown"; // AceM2, Crystal
            public string GameVersion = "0"; // 1.4, 2.8 etc
        }
    }
}