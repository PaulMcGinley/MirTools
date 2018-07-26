using System;
using System.Windows.Forms;

namespace MirTools.Forms
{
    public partial class TfmDiagnosticInformation : DevExpress.XtraBars.TabForm
    {
        public TfmDiagnosticInformation()
        {
            InitializeComponent();
            UpdateStatistics();
        }

        private void TfmDiagnosticInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void UpdateStatistics()
        {
            Functions.ProcessMonitor.RefreshProcessStats();
            lvStats.Items[0].SubItems[1].Text = Functions.ProcessMonitor.GetPhysicalMemoryUsage();
            lvStats.Items[1].SubItems[1].Text = Functions.ProcessMonitor.GetBasePriority();
            lvStats.Items[2].SubItems[1].Text = Functions.ProcessMonitor.GetPriorityClass();
            lvStats.Items[3].SubItems[1].Text = Functions.ProcessMonitor.GetProcessorTime();
            lvStats.Items[4].SubItems[1].Text = Functions.ProcessMonitor.GetPrivilegedProcessorTime();
            lvStats.Items[5].SubItems[1].Text = Functions.ProcessMonitor.GetPagedSystemMemorySize64();
            lvStats.Items[6].SubItems[1].Text = Functions.ProcessMonitor.GetPagedMemorySize64();
            lvStats.Items[7].SubItems[1].Text = Functions.ProcessMonitor.GetHandle();
            lvStats.Items[8].SubItems[1].Text = Functions.ProcessMonitor.GetHandleCount();
            lvStats.Items[9].SubItems[1].Text = Functions.ProcessMonitor.GetID();
            lvStats.Items[10].SubItems[1].Text = Functions.ProcessMonitor.GetSessionId();
        }

        private void StatisticsRefreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateStatistics();
        }
    }
}