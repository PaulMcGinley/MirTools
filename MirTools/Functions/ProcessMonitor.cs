using System.Diagnostics;

namespace MirTools.Functions
{
    public static class ProcessMonitor
    {
        private static Process ThisApplication = Process.GetCurrentProcess(); // Define this application to get process information from

        public static void RefreshProcessStats()
        {
            ThisApplication.Refresh();
        }

        public static string GetPhysicalMemoryUsage(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return Common.GetBytesReadable(ThisApplication.WorkingSet64);
        }

        public static string GetBasePriority(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return ThisApplication.BasePriority.ToString();
        }

        public static string GetPriorityClass(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return ThisApplication.PriorityClass.ToString();
        }

        public static string GetProcessorTime(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return ThisApplication.UserProcessorTime.ToString();
        }

        public static string GetPrivilegedProcessorTime(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return ThisApplication.PrivilegedProcessorTime.ToString();
        }

        public static string GetPagedSystemMemorySize64(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return Common.GetBytesReadable(ThisApplication.PagedSystemMemorySize64);
        }

        public static string GetPagedMemorySize64(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return Common.GetBytesReadable(ThisApplication.PagedMemorySize64);
        }

        public static string GetHandle(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return ThisApplication.Handle.ToString();
        }

        public static string GetHandleCount(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return ThisApplication.HandleCount.ToString();
        }

        public static string GetID(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return ThisApplication.Id.ToString();
        }

        public static string GetSessionId(bool Refresh = false)
        {
            if (Refresh == true) RefreshProcessStats();
            return ThisApplication.SessionId.ToString();
        }
    }
}