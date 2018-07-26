using System;

namespace MirTools
{
    public static class Configuration
    {
        // Headers
        public static byte Version = 0;

        public static string Header = "MirTools Config File";

        // Thread Sleeping
        public static bool SleepThread = true;

        public static UInt16 LoadSleepTime = 1500; // Time in milliseconds
        public static UInt16 LoopSleepTime = 25; // Time in milliseconds

        // Folder Preview
        public static bool AutomaticallyCropPreviewImages = false;

        // Start Page
        public static byte BookmarksToKeep = 255;

        public static byte BookmarksToDisplay = 10;
        public static byte HistoryToKeep = 255;
        public static byte HistoryToShow = 10;

        public static void LoadConfiguration()
        {
        }

        public static void SaveConfiguration()
        {
        }
    }
}