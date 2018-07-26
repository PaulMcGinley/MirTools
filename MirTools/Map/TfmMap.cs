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
using Microsoft.DirectX.Direct3D;

namespace MirTools.Map
{
    public partial class TfmMap : DevExpress.XtraBars.Ribbon.RibbonForm
    {/*
        public CellInfo[,] M2CellInfo;
        public int MapWidth;
        public int MapHeight;
        public int OffSetX, OffSetY;
        public int CellWidth = 48;
        public int CellHeight = 32;
        public int ViewRangeX;
        public int ViewRangeY;
        public int AnimationCount;
        public Point Position;
        //public readonly static Stopwatch Timer = Stopwatch.StartNew();
        public readonly static DateTime StartTime = DateTime.Now;
        public static long Time, OldTime;
        private static long _fpsTime;
        private static int _fps;
        public static int FPS;
        public static long MoveTime;
        public string MapType = "_";
        public int MapAttribToggle = 0;
        public MapReader Map;
        public string SelectedMapName;

        private int zoom = 1;
        private Rectangle zoomedCellSize;
        private Point drawPoint;

        public static Point MPoint;

        public int paintMode = 0;
        public MapReader tempMap;
        public CellInfo[,] tempM2CellInfo;
        public int tempMapWidth;
        public int tempMapHeight;

        public TfmMap()
        {
            InitializeComponent();
        }

        private void RenderEnviroment()
        {
            try
            {
                if (DXManager.DeviceLost)
                {
                    DXManager.AttemptReset();
                    Thread.Sleep(1);
                    return;
                }

                //DXManager.Device.Clear(ClearFlags.Target, Color.Black, 0, 0);
                DXManager.Device.Clear(ClearFlags.Target, Color.White, 0, 0);
                DXManager.Device.BeginScene();
                DXManager.Sprite.Begin(SpriteFlags.AlphaBlend);

                DrawMap(Position);
                DrawObject(Position);
                DrawMapAttribute(Position);

                DXManager.Sprite.End();
                DXManager.Device.EndScene();
                DXManager.Device.Present();
            }
            catch (DeviceLostException)
            {
            }
            catch (Exception ex)
            {
                DXManager.AttemptRecovery();
            }
        }*/
    }
}