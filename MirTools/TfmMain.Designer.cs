namespace MirTools
{
    partial class TfmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TfmMain));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAbout = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnSettings = new DevExpress.XtraBars.BarButtonItem();
            this.btnLibraryNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnLibraryOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnClearMemory = new DevExpress.XtraBars.BarButtonItem();
            this.btnLibraryConvert = new DevExpress.XtraBars.BarButtonItem();
            this.btnPreviewFolder = new DevExpress.XtraBars.BarButtonItem();
            this.lbMemoryUsage = new DevExpress.XtraBars.BarStaticItem();
            this.btnDiagnosticInfo = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowStartPage = new DevExpress.XtraBars.BarButtonItem();
            this.btnPreviewArmours = new DevExpress.XtraBars.BarButtonItem();
            this.btnWeapons = new DevExpress.XtraBars.BarButtonItem();
            this.btnConvertImage = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.tabMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.UsageTimer = new System.Windows.Forms.Timer(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.taskbarAssistant1 = new DevExpress.Utils.Taskbar.TaskbarAssistant();
            this.jumpListItemTask1 = new DevExpress.Utils.Taskbar.JumpListItemTask();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnOpenMap = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnAbout,
            this.btnHelp,
            this.btnSettings,
            this.btnLibraryNew,
            this.btnLibraryOpen,
            this.btnClearMemory,
            this.btnLibraryConvert,
            this.btnPreviewFolder,
            this.lbMemoryUsage,
            this.btnDiagnosticInfo,
            this.btnShowStartPage,
            this.btnPreviewArmours,
            this.btnWeapons,
            this.btnConvertImage,
            this.barStaticItem1,
            this.btnOpenMap});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 29;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.btnHelp);
            this.ribbon.PageHeaderItemLinks.Add(this.btnAbout);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.tabMain,
            this.ribbonPage1});
            this.ribbon.QuickToolbarItemLinks.Add(this.btnShowStartPage);
            this.ribbon.QuickToolbarItemLinks.Add(this.btnSettings);
            this.ribbon.QuickToolbarItemLinks.Add(this.btnDiagnosticInfo);
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.ribbon.Size = new System.Drawing.Size(1206, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnAbout
            // 
            this.btnAbout.Caption = "About";
            this.btnAbout.Id = 1;
            this.btnAbout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.ImageOptions.Image")));
            this.btnAbout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAbout.ImageOptions.LargeImage")));
            this.btnAbout.Name = "btnAbout";
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Help";
            this.btnHelp.Id = 2;
            this.btnHelp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.ImageOptions.Image")));
            this.btnHelp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHelp.ImageOptions.LargeImage")));
            this.btnHelp.Name = "btnHelp";
            // 
            // btnSettings
            // 
            this.btnSettings.Caption = "Settings";
            this.btnSettings.Id = 3;
            this.btnSettings.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.ImageOptions.Image")));
            this.btnSettings.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.ImageOptions.LargeImage")));
            this.btnSettings.Name = "btnSettings";
            // 
            // btnLibraryNew
            // 
            this.btnLibraryNew.Caption = "New";
            this.btnLibraryNew.Id = 15;
            this.btnLibraryNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLibraryNew.ImageOptions.Image")));
            this.btnLibraryNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLibraryNew.ImageOptions.LargeImage")));
            this.btnLibraryNew.Name = "btnLibraryNew";
            this.btnLibraryNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLibraryNew_ItemClick);
            // 
            // btnLibraryOpen
            // 
            this.btnLibraryOpen.Caption = "Open";
            this.btnLibraryOpen.Id = 16;
            this.btnLibraryOpen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLibraryOpen.ImageOptions.Image")));
            this.btnLibraryOpen.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLibraryOpen.ImageOptions.LargeImage")));
            this.btnLibraryOpen.Name = "btnLibraryOpen";
            this.btnLibraryOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLibraryOpen_ItemClick);
            // 
            // btnClearMemory
            // 
            this.btnClearMemory.Caption = "Clear Memory";
            this.btnClearMemory.Id = 17;
            this.btnClearMemory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClearMemory.ImageOptions.Image")));
            this.btnClearMemory.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClearMemory.ImageOptions.LargeImage")));
            this.btnClearMemory.Name = "btnClearMemory";
            toolTipTitleItem1.Text = "Clear Memory";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Clear out unused RAM that hasn\'t been taken care of automatically.\r\nOnly use this" +
    " if you are working with a high data load.";
            toolTipTitleItem2.LeftIndent = 6;
            toolTipTitleItem2.Text = "Garbage Collection";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            superToolTip1.Items.Add(toolTipTitleItem2);
            this.btnClearMemory.SuperTip = superToolTip1;
            this.btnClearMemory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearMemory_ItemClick);
            // 
            // btnLibraryConvert
            // 
            this.btnLibraryConvert.Caption = "Convert";
            this.btnLibraryConvert.Id = 18;
            this.btnLibraryConvert.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLibraryConvert.ImageOptions.Image")));
            this.btnLibraryConvert.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLibraryConvert.ImageOptions.LargeImage")));
            this.btnLibraryConvert.Name = "btnLibraryConvert";
            toolTipTitleItem3.Text = "Convert Library";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Convert libraries between all known library configurations.";
            superToolTip2.Items.Add(toolTipTitleItem3);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnLibraryConvert.SuperTip = superToolTip2;
            this.btnLibraryConvert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLibraryConvert_ItemClick);
            // 
            // btnPreviewFolder
            // 
            this.btnPreviewFolder.Caption = "Folder";
            this.btnPreviewFolder.Id = 20;
            this.btnPreviewFolder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewFolder.ImageOptions.Image")));
            this.btnPreviewFolder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPreviewFolder.ImageOptions.LargeImage")));
            this.btnPreviewFolder.Name = "btnPreviewFolder";
            this.btnPreviewFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPreviewFolder_ItemClick);
            // 
            // lbMemoryUsage
            // 
            this.lbMemoryUsage.Caption = "RAM Usage";
            this.lbMemoryUsage.Id = 21;
            this.lbMemoryUsage.Name = "lbMemoryUsage";
            // 
            // btnDiagnosticInfo
            // 
            this.btnDiagnosticInfo.Caption = "Diagnostic Information";
            this.btnDiagnosticInfo.Id = 22;
            this.btnDiagnosticInfo.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnDiagnosticInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDiagnosticInfo.ImageOptions.Image")));
            this.btnDiagnosticInfo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDiagnosticInfo.ImageOptions.LargeImage")));
            this.btnDiagnosticInfo.Name = "btnDiagnosticInfo";
            this.btnDiagnosticInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDiagnosticInfo_ItemClick);
            // 
            // btnShowStartPage
            // 
            this.btnShowStartPage.Caption = "Start Page";
            this.btnShowStartPage.Id = 23;
            this.btnShowStartPage.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnShowStartPage.ImageOptions.Image = global::MirTools.Properties.Resources.menu;
            this.btnShowStartPage.Name = "btnShowStartPage";
            // 
            // btnPreviewArmours
            // 
            this.btnPreviewArmours.Caption = "Armours";
            this.btnPreviewArmours.Id = 24;
            this.btnPreviewArmours.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewArmours.ImageOptions.Image")));
            this.btnPreviewArmours.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPreviewArmours.ImageOptions.LargeImage")));
            this.btnPreviewArmours.Name = "btnPreviewArmours";
            this.btnPreviewArmours.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPreviewArmours_ItemClick);
            // 
            // btnWeapons
            // 
            this.btnWeapons.Caption = "Weapons";
            this.btnWeapons.Id = 25;
            this.btnWeapons.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWeapons.ImageOptions.Image")));
            this.btnWeapons.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnWeapons.ImageOptions.LargeImage")));
            this.btnWeapons.Name = "btnWeapons";
            this.btnWeapons.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWeapons_ItemClick);
            // 
            // btnConvertImage
            // 
            this.btnConvertImage.Caption = "Convert Image";
            this.btnConvertImage.Id = 26;
            this.btnConvertImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConvertImage.ImageOptions.Image")));
            this.btnConvertImage.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnConvertImage.ImageOptions.LargeImage")));
            this.btnConvertImage.Name = "btnConvertImage";
            this.btnConvertImage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConvertImage_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.barStaticItem1.Caption = "Created by <color=skyblue>Tikky</color> for <b>Fables Of Mir</b> (LoMCN: <color=s" +
    "kyblue>paulkerr</color>)";
            this.barStaticItem1.Id = 27;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // tabMain
            // 
            this.tabMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup5,
            this.ribbonPageGroup2});
            this.tabMain.Name = "tabMain";
            this.tabMain.Text = "Main";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLibraryOpen);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLibraryNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLibraryConvert, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Library";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnConvertImage);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnClearMemory);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Misc";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Preview";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPreviewFolder);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Crystal Libraries";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnPreviewArmours);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnWeapons);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Official";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.Step = 1;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.lbMemoryUsage);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 697);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1206, 23);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // UsageTimer
            // 
            this.UsageTimer.Enabled = true;
            this.UsageTimer.Interval = 1000;
            this.UsageTimer.Tick += new System.EventHandler(this.UsageTimer_Tick);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            // 
            // taskbarAssistant1
            // 
            this.taskbarAssistant1.ParentControl = this;
            // 
            // jumpListItemTask1
            // 
            this.jumpListItemTask1.Caption = "test";
            this.jumpListItemTask1.IconPath = null;
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnOpenMap);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Map";
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.Caption = "Open";
            this.btnOpenMap.Id = 28;
            this.btnOpenMap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenMap.ImageOptions.Image")));
            this.btnOpenMap.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnOpenMap.ImageOptions.LargeImage")));
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenMap_ItemClick);
            // 
            // TfmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 720);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.IsMdiContainer = true;
            this.Name = "TfmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Mir Tools";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage tabMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnAbout;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnSettings;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.BarButtonItem btnLibraryNew;
        private DevExpress.XtraBars.BarButtonItem btnLibraryOpen;
        private DevExpress.XtraBars.BarButtonItem btnClearMemory;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnLibraryConvert;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarButtonItem btnPreviewFolder;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarStaticItem lbMemoryUsage;
        private System.Windows.Forms.Timer UsageTimer;
        private DevExpress.XtraBars.BarButtonItem btnDiagnosticInfo;
        private DevExpress.XtraBars.BarButtonItem btnShowStartPage;
        private DevExpress.XtraBars.BarButtonItem btnPreviewArmours;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnWeapons;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem btnConvertImage;
        private DevExpress.Utils.Taskbar.TaskbarAssistant taskbarAssistant1;
        private DevExpress.Utils.Taskbar.JumpListItemTask jumpListItemTask1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem btnOpenMap;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
    }
}