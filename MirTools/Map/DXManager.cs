using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Blend = Microsoft.DirectX.Direct3D.Blend;

namespace MirTools.Map
{/*
    internal class DXManager
    {
        public static List<FileStructures.MLibraryV2.MImage> TextureList = new List<FileStructures.MLibraryV2.MImage>();

        /// <summary>
        /// 主设备
        /// </summary>
        public static Device Device;

        /// <summary>
        /// 精灵
        /// </summary>
        public static Sprite Sprite, TextSprite;

        /// <summary>
        /// 线
        /// </summary>
        public static Microsoft.DirectX.Direct3D.Line Line;

        /// <summary>
        /// 当前表面 或者 现有表面
        /// </summary>
        public static Surface CurrentSurface;

        /// <summary>
        /// 主表面
        /// </summary>
        public static Surface MainSurface;

        /// <summary>
        /// 描述呈现参数。
        /// </summary>
        public static PresentParameters Parameters;

        /// <summary>
        /// 设备是否丢失 true 丢失 、false 未丢失
        /// </summary>
        public static bool DeviceLost;

        /// <summary>
        /// 不透明度
        /// </summary>
        public static float Opacity = 1F;

        /// <summary>
        /// 是否混合
        /// </summary>
        public static bool Blending;

        /// <summary>
        ///  雷达纹理
        /// </summary>
        public static Texture RadarTexture;

        /// <summary>
        /// 光源纹理集合
        /// </summary>
        public static List<Texture> Lights = new List<Texture>();

        /// <summary>
        /// 无背景位置纹理
        /// </summary>
        public static Texture PoisonDotBackground;

        /// <summary>
        /// 光源坐标集合
        /// </summary>
        public static Point[] LightSizes =
        {
            new Point(125,95),
            new Point(205,156),
            new Point(285,217),
            new Point(365,277),
            new Point(445,338),
            new Point(525,399),
            new Point(605,460),
            new Point(685,521),
            new Point(765,581),
            new Point(845,642),
            new Point(925,703)
        };

        public static void Create(Control Form)
        {
            Parameters = new PresentParameters
            {
                BackBufferFormat = Format.X8R8G8B8,
                PresentFlag = PresentFlag.LockableBackBuffer,
                //BackBufferWidth = Form.Width,
                //BackBufferWidth = 1000,
                BackBufferWidth = 1024,
                //BackBufferHeight = Form.Height,
                //BackBufferHeight = 1000,
                BackBufferHeight = 800,
                SwapEffect = SwapEffect.Discard,
                PresentationInterval = PresentInterval.One,
                Windowed = true
            };

            Caps devCaps = Manager.GetDeviceCaps(0, DeviceType.Hardware);
            DeviceType devType = DeviceType.Reference;
            CreateFlags devFlags = CreateFlags.HardwareVertexProcessing;
            if (devCaps.VertexShaderVersion.Major >= 2 && devCaps.PixelShaderVersion.Major >= 2)
                devType = DeviceType.Hardware;

            if (devCaps.DeviceCaps.SupportsHardwareTransformAndLight)
                devFlags = CreateFlags.HardwareVertexProcessing;

            if (devCaps.DeviceCaps.SupportsPureDevice)
                devFlags |= CreateFlags.PureDevice;

            Device = new Device(Manager.Adapters.Default.Adapter, devType, Program.Form.panel1, devFlags, Parameters);
            Device.DeviceLost += Device_DeviceLost;
            Device.DeviceResizing += Device_DeviceResizing;
            Device.DeviceReset += Device_DeviceReset;
            Device.Disposing += Device_Disposing;
            Device.SetDialogBoxesEnabled(true);

            LoadTextures();
        }

        #region Device 事件

        private static void Device_Disposing(object sender, EventArgs e)
        {
            Clean();
            //throw new NotImplementedException();
        }

        private static void Device_DeviceReset(object sender, EventArgs e)
        {
            LoadTextures();
        }

        private static void Device_DeviceResizing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private static void Device_DeviceLost(object sender, EventArgs e)
        {
            DeviceLost = true;
        }

        #endregion Device 事件

        /// <summary>
        /// 加载纹理
        /// </summary>
        private static unsafe void LoadTextures()
        {
            Sprite = new Sprite(Device);
            TextSprite = new Sprite(Device);
            Line = new Line(Device) { Width = 1F };

            MainSurface = Device.GetBackBuffer(0, 0, BackBufferType.Mono);
            CurrentSurface = MainSurface;

            Device.SetRenderTarget(0, MainSurface);

            if (RadarTexture == null || RadarTexture.Disposed)
            {
                RadarTexture = new Texture(Device, 2, 2, 1, Usage.None, Format.A8R8G8B8, Pool.Managed);

                using (GraphicsStream stream = RadarTexture.LockRectangle(0, LockFlags.Discard))

                using (Bitmap image = new Bitmap(2, 2, 8, PixelFormat.Format32bppArgb, (IntPtr)stream.InternalDataPointer))
                using (Graphics graphics = Graphics.FromImage(image))
                    graphics.Clear(Color.White);
            }
            if (PoisonDotBackground == null || PoisonDotBackground.Disposed)
            {
                PoisonDotBackground = new Texture(Device, 5, 5, 1, Usage.None, Format.A8R8G8B8, Pool.Managed);
                //锁定纹理资源中的矩形。
                using (GraphicsStream stream = PoisonDotBackground.LockRectangle(0, LockFlags.Discard))
                //用指定的大小、像素格式和像素数据初始化 Bitmap 类的新实例
                using (Bitmap image = new Bitmap(5, 5, 20, PixelFormat.Format32bppArgb, (IntPtr)stream.InternalDataPointer))
                //从指定的 Image 创建新的 Graphics。
                using (Graphics graphics = Graphics.FromImage(image))
                    //清除整个绘图面并以指定背景色填充
                    graphics.Clear(Color.White);
            }
            CreateLights();
        }

        /// <summary>
        /// 创建光源
        /// </summary>
        private unsafe static void CreateLights()
        {
            for (int i = Lights.Count - 1; i >= 0; i--)
                Lights[i].Dispose();

            Lights.Clear();

            for (int i = 1; i < LightSizes.Length; i++)
            {
                // int width = 125 + (57 *i);
                //int height = 110 + (57 * i);
                int width = LightSizes[i].X;
                int height = LightSizes[i].Y;
                Texture light = new Texture(Device, width, height, 1, Usage.None, Format.A8R8G8B8, Pool.Managed);
                ////LockRectangle 锁定纹理资源中的矩形
                using (GraphicsStream stream = light.LockRectangle(0, LockFlags.Discard))
                //用指定的大小、像素格式和像素数据初始化 Bitmap 类的新实例
                using (Bitmap image = new Bitmap(width, height, width * 4, PixelFormat.Format32bppArgb, (IntPtr)stream.InternalDataPointer))
                {
                    //从指定的 Image 创建新的 Graphics。
                    using (Graphics graphics = Graphics.FromImage(image))
                    {
                        //GraphicsPath 表示一系列相互连接的直线和曲线
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            //AddEllipse 向当前路径添加一个椭圆。
                            // 参数

                            //x
                            //    Type: System.Int32
                            //    定义椭圆的边框的左上角的 X 坐标。

                            //y
                            //    Type: System.Int32
                            //    定义椭圆的边框的左上角的 Y 坐标。

                            //width
                            //    定义椭圆的边框的宽度。

                            //height
                            //    定义椭圆的边框的高度。
                            path.AddEllipse(new Rectangle(0, 0, width, height));
                            //PathGradientBrush 类 封装 Brush 对象，它通过渐变填充 GraphicsPath 对象的内部
                            //  使用指定的路径初始化 PathGradientBrush 类的新实例。
                            //  参数
                            //path
                            //    GraphicsPath，定义此 PathGradientBrush 填充的区域。
                            using (PathGradientBrush brush = new PathGradientBrush(path))
                            {
                                graphics.Clear(Color.FromArgb(0, 0, 0, 0));
                                //获取或设置与此 PathGradientBrush 填充的路径中的点相对应的颜色的数组。
                                brush.SurroundColors = new[] { Color.FromArgb(0, 255, 255, 255) };
                                //获取或设置路径渐变的中心处的颜色
                                brush.CenterColor = Color.FromArgb(255, 255, 255, 255);
                                //填充 GraphicsPath 的内部。
                                //参数

                                //brush
                                //    确定填充特性的 Brush。

                                //path
                                //    GraphicsPath，它表示要填充的路径。
                                graphics.FillPath(brush, path);
                                //保存此 Graphics 的当前状态，并用 GraphicsState 标识保存的状态。
                                graphics.Save();
                            }
                        }
                    }
                }
                //添加light
                Lights.Add(light);
                //为light添加 Disposing 事件 ，用来Lights.Remove(light);
                light.Disposing += (o, e) => Lights.Remove(light);
            }
        }

        /// <summary>
        /// 设置表面
        /// </summary>
        /// <param name="surface"></param>
        public static void SetSurface(Surface surface)
        {
            if (CurrentSurface == surface)
                return;
            //强制将所有批子画面都提交给设备。
            Sprite.Flush();
            CurrentSurface = surface;
            //为设备设置新的颜色缓冲区。
            Device.SetRenderTarget(0, surface);
        }

        /// <summary>
        /// 尝试重置
        /// </summary>
        public static void AttemptReset()
        {
            try
            {
                int result;
                //CheckCooperativeLevel 为窗口应用程序或全屏应用程序报告 Direct3D 设备的当前协作级别状态。
                //参数

                //hResult
                //    窗口应用程序或全屏应用程序的设备的当前协作级别状态，用 ResultCode 值进行报告。Success 结果指示设备可操作并且调用应用程序可继续。DeviceLost 结果指示设备已丢失，但是此时无法重置；因此无法进行呈现。DeviceNotReset 结果指示设备已丢失，但是此时可以重置。

                //返回值
                //如果设备可操作并且调用应用程序可以继续，则为 true；如果设备已丢失或者需要重置，则为 false。
                Device.CheckCooperativeLevel(out result);

                //    -------------ResultCode)result 返回值类型-------------
                //    AlreadyLocked	设备已锁定。
                //    ConflictingRenderState	呈现状态不兼容。
                //    ConflictingTextureFilter	当前的纹理筛选器不能一起使用。
                //    ConflictingTexturePalette	当前的纹理调色板不能一起使用。
                //    DeviceLost	设备已丢失，但此时无法对其进行重置。因此，不可能进行呈现。
                //    DeviceNotReset	设备不支持所查询的技术。
                //    DriverInternalError	发生驱动程序内部错误。
                //	    DriverInvalidCall	驱动程序检测到无效的调用。
                // 	DriverUnsupported	驱动程序不受支持。
                // 	GenericFailure	常规失败。
                // 	InvalidCall	方法调用无效；例如，方法的参数可能不是有效的指针。
                // 	InvalidDevice	请求的设备类型无效。
                // 	MemoryPoolEmpty	指定的内存池是空的。
                // 	MoreData	传入例程的缓冲区所含元素数量不足，无法完成该操作。
                // 	NotAvailable	请求的格式不可用。
                // 	NotFound	搜索例程未能返回元素。

                // 	Success	操作成功。

                // 	TooManyOperations	应用程序请求的纹理筛选操作数量多于设备支持的纹理筛选操作数量。
                // 	UnsupportedAlphaArgument	设备不支持 alpha 通道的指定纹理混合参数。
                // 	UnsupportedAlphaOperation	设备不支持 alpha 通道的指定纹理混合操作。
                // 	UnsupportedColorArgument	设备不支持颜色值的指定纹理混合参数。
                //	    UnsupportedColorOperation	设备不支持颜色值的指定纹理混合操作。
                // 	UnsupportedFactorValue	设备不支持指定的纹理因子值。
                // 	UnsupportedTextureFilter	设备不支持指定的纹理筛选器。
                //    WrongTextureFormat	像素格式的纹理图面无效。
                switch ((ResultCode)result)
                {
                    //设备不支持所查询的技术。
                    case ResultCode.DeviceNotReset:
                        //Device.Reset(Parameters)重置当前设备的表示参数。
                        //参数

                        //presentationParameters
                        //    一个 PresentParameters 结构，它描述新的表示参数。此参数不能为空。

                        //备注
                        //切换到全屏模式时，Direct3D 会尝试找到一种与后台缓冲区格式匹配的桌面格式，以便后台缓冲区格式和前台缓冲区格式相同。这样就无需转换颜色了。
                        //如果对 Reset 的调用失败，除非设备处于“未重置”状态（由从 CheckCooperativeLevel 方法的 hResult 参数返回的 DeviceNotReset 来指示），否则设备会被置于“丢失”状态（由从对 CheckCooperativeLevel 的调用返回的值 false 指示）。
                        //调用 Reset 将导致所有纹理内存图面和状态信息丢失，并且还会导致托管纹理在视频内存中被刷新。在对设备调用 Reset 前，应用程序应释放任何与该设备相关联的显式呈现目标、深度模具图面、附加交换链、状态块以及默认资源。
                        //交换链可以是全屏的，也可以是窗口式的。如果新的交换链是全屏的，则会将适配器置于与新大小匹配的显示模式中。
                        //如果调用 Reset 的线程不是用来创建所要重置的设备的线程，则该调用将失败。
                        //调用 Device、Reset 和 SwapChain 时，可以将窗口模式后台缓冲区的格式指定为“未知”。这意味着应用程序在窗口模式下调用 Device 前不必查询当前的桌面格式。对于全屏模式，必须指定后台缓冲区格式。将 BackBufferCount 设置为 0 会创建一个后台缓冲区。
                        //尝试成组重置多个显示适配器时，可传入 PresentParameters 对象数组，该数组中的每个对象都对应于该适配器组中的一个显示适配器。
                        Device.Reset(Parameters);
                        break;
                    //设备已丢失，但此时无法对其进行重置。因此，不可能进行呈现。
                    case ResultCode.DeviceLost:
                        break;
                    //操作成功
                    case ResultCode.Success:
                        DeviceLost = false;
                        //获取指定的后台缓冲区。
                        MainSurface = Device.GetBackBuffer(0, 0, BackBufferType.Mono);
                        //获取指定的后台缓冲区
                        CurrentSurface = Device.GetBackBuffer(0, 0, BackBufferType.Mono);
                        //为设备设置新的颜色缓冲区。
                        Device.SetRenderTarget(0, CurrentSurface);
                        break;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 尝试恢复
        /// </summary>
        public static void AttemptRecovery()
        {
            try
            {
                //将设备还原为调用 Begin 前的状态。
                //备注
                //此方法不能用于替代 Device 的 EndScene。

                Sprite.End();
            }
            catch
            {
            }

            try
            {
                //结束通过调用 BeginScene 方法开始的场景。
                //备注
                //每个对 BeginScene 的调用后面最终都应有一个对 EndScene 的调用，然后才能用 Present 更新显示。
                //当 EndScene 成功时，该场景将进入由驱动程序进行呈现的队列中。该方法不是同步的，因此不能保证该方法返回时，场景已完成呈现。

                Device.EndScene();
            }
            catch
            {
            }

            try
            {
                ////获取指定的后台缓冲区
                MainSurface = Device.GetBackBuffer(0, 0, BackBufferType.Mono);
                CurrentSurface = MainSurface;
                ////为设备设置新的颜色缓冲区。
                Device.SetRenderTarget(0, MainSurface);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 设置不透明度
        /// </summary>
        /// <param name="opacity"> 不透明度</param>
        public static void SetOpacity(float opacity)
        {
            if (Opacity == opacity)
                return;
            //强制将所有批子画面都提交给设备。
            Sprite.Flush();
            //获取设备的呈现状态值。AlphaBlendEnable= true;
            Device.RenderState.AlphaBlendEnable = true;
            if (opacity >= 1 || opacity < 0)
            {
                //----------Blend  枚举 ------------
                //DestinationAlpha	混合因子为 (Ad, Ad, Ad, Ad)。
                //	DestinationColor	混合因子为 (Rd, Gd, Bd, Ad)。
                //	InvDestinationAlpha	混合因子为 (1 - Ad, 1 - Ad, 1 - Ad, 1 - Ad)。
                //	InvDestinationColor	混合因子为 (1 - Rd, 1 - Gd, 1 - Bd, 1 - Ad)。
                //	InvSourceAlpha	混合因子为 ( 1 - As, 1 - As, 1 - As, 1 - As)。
                //	InvSourceColor	混合因子为 (Rs, Gs, Bs, As)。
                //	One	混合因子为 (1,1,1,1)。
                //	SourceAlpha	混合因子为 (As, As, As, As)。
                //	SourceAlphaSat	混合因子为 (f, f, f, 1)；f = min(A, 1 - Ad)。
                //	SourceColor	混合因子为 (Rs, Gs, Bs, As)。
                //	Zero	混合因子为 (0, 0, 0, 0)。

                //获取或设置颜色混合模式。
                Device.RenderState.SourceBlend = Blend.SourceAlpha;
                //表示当前的混合模式或要设置的混合模式
                Device.RenderState.DestinationBlend = Blend.InvSourceAlpha;
                //获取或者设置Alpha混合模式
                Device.RenderState.AlphaSourceBlend = Blend.One;
                //使用现有颜色混合绘制操作
                Device.RenderState.BlendFactor = Color.FromArgb(255, 255, 255, 255);
            }
            else
            {
                Device.RenderState.SourceBlend = Blend.BlendFactor;
                Device.RenderState.DestinationBlend = Blend.InvBlendFactor;
                Device.RenderState.AlphaSourceBlend = Blend.SourceAlpha;
                Device.RenderState.BlendFactor = Color.FromArgb((byte)(255 * opacity), (byte)(255 * opacity),
                                                                (byte)(255 * opacity), (byte)(255 * opacity));
            }
            Opacity = opacity;
            //强制将所有批子画面都提交给设备。
            Sprite.Flush();
        }

        /// <summary>
        /// 设置混合
        /// </summary>
        /// <param name="value"> 是否</param>
        /// <param name="rate">率</param>
        public static void SetBlend(bool value, float rate = 1F)
        {
            if (value == Blending) return;
            Blending = value;
            //强制将所有批子画面都提交给设备。
            Sprite.Flush();
            // //将设备还原为调用 Begin 前的状态。
            Sprite.End();

            if (Blending)
            {
                //Sprite.Begin准备子画面的绘制
                //参数

                //flags
                //来自 SpriteFlags 的零个或多个值的组合，这些值描述子画面呈现选项。

                // AlphaBlend	启用 AlphaTestEnable 设为 true（对于非零 alpha）的 alpha 混合。SourceAlpha 是源混合状态，InvSourceAlpha 是 RenderStateManager 调用中的目标混合状态。绘制文本时，Font 类要求设置此标志。
                // Billboard	围绕每个子画面的中心旋转该子画面，以便使其面向查看者。必须首先调用 SetWorldViewLH 或 SetWorldViewRH。
                // DoNotModifyRenderState	指定调用 Begin 时不更改设备呈现状态。
                // DoNotSaveState	禁止在调用 Begin 和 End 时保存或还原设备状态。
                // None	将值解析为 0。
                // ObjectSpace	指定不修改世界、视图和投影转换。当前为设备设置的转换用于在成批绘制子画面时（即，调用 Begin 或 End 时）转换这些子画面。如果未指定此选项，则修改世界、视图和投影转换，以便以屏幕空间坐标绘制子画面。
                // SortDepthBackToFront	绘制前，按深度从后到前的顺序对子画面进行排序。在绘制不同深度的透明子画面时，建议使用此选项。
                // SortDepthFrontToBack	绘制前，按深度从前到后的顺序对子画面进行排序。在绘制不同深度的不透明子画面时，建议使用此选项。
                // SortTexture	绘制前，按纹理子画面进行排序。在绘制统一深度的不重叠子画面时，建议使用此选项；例如，用 Font 绘制屏幕对齐的文本时。

                Sprite.Begin(SpriteFlags.DoNotSaveState);//禁止在调用 Begin 和 End 时保存或还原设备状态。
                Device.RenderState.AlphaBlendEnable = true;
                Device.RenderState.SourceBlend = Blend.BlendFactor;
                Device.RenderState.DestinationBlend = Blend.One;
                Device.RenderState.BlendFactor = Color.FromArgb((byte)(255 * rate), (byte)(255 * rate),
                                                                (byte)(255 * rate), (byte)(255 * rate));
            }
            else
                //Sprite.Begin准备子画面的绘制
                Sprite.Begin(SpriteFlags.AlphaBlend);//启用 AlphaTestEnable 设为 true（对于非零 alpha）的 alpha 混合。SourceAlpha 是源混合状态，InvSourceAlpha 是 RenderStateManager 调用中的目标混合状态。绘制文本时，Font 类要求设置此标志。
            //SetRenderTarget 为设备设置新的颜色缓冲区。
            Device.SetRenderTarget(0, CurrentSurface);
        }

        /// <summary>
        /// 清除
        /// </summary>
        public static void Clean()
        {
            for (int i = TextureList.Count - 1; i >= 0; i--)
            {
                FileStructures.MLibraryV2.MImage m = TextureList[i];

                if (m == null)
                {
                    TextureList.RemoveAt(i);
                    continue;
                }

                //if (CMain.Time <= m.CleanTime) continue;


                TextureList.RemoveAt(i);
                if (m.Image != null && !m.Image.Disposed)
                    m.Image.Dispose();

            }

        }

        //Aka: to Zoom the map
        public static void ScreenResize(int x, int y)
        {
            Parameters.BackBufferWidth = x;
            Parameters.BackBufferHeight = y;
            MLibrary.ScreenWidth = x;
            MLibrary.ScreenHeight = y;

            Device.Reset(Parameters);
        }
    }
*/}
