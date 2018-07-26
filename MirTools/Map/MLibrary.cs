using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace MirTools.Map
{
    /*
    public static class Libraries
    {
        public static bool Loaded;
        public static int Count, Progress;
        
        public const string DataPath = @".\Data\",
            MapPath = @".\Map\",
            ResourcePath = @".\MapEditor\";

        public static readonly MLibrary[] MapLibs = new MLibrary[400];

        static Libraries( )
        {
            PanelSize = panelSize;

            #region Maplibs

            //wemade mir2 (allowed from 0-99)
            MapLibs[0] = new MLibrary(DataPath + "Map\\WemadeMir2\\Tiles");
            MapLibs[1] = new MLibrary(DataPath + "Map\\WemadeMir2\\Smtiles");
            MapLibs[2] = new MLibrary(DataPath + "Map\\WemadeMir2\\Objects");
            for (int i = 2; i < 99; i++)
            {
                MapLibs[i + 1] = new MLibrary(DataPath + "Map\\WemadeMir2\\Objects" + i);
            }
            //shanda mir2 (allowed from 100-199)
            MapLibs[100] = new MLibrary(DataPath + "Map\\ShandaMir2\\Tiles");
            for (int i = 1; i < 10; i++)
            {
                MapLibs[100 + i] = new MLibrary(DataPath + "Map\\ShandaMir2\\Tiles" + (i + 1));
            }
            MapLibs[110] = new MLibrary(DataPath + "Map\\ShandaMir2\\SmTiles");
            for (int i = 1; i < 10; i++)
            {
                MapLibs[110 + i] = new MLibrary(DataPath + "Map\\ShandaMir2\\SmTiles" + (i + 1));
            }
            MapLibs[120] = new MLibrary(DataPath + "Map\\ShandaMir2\\Objects");
            for (int i = 1; i < 99; i++)
            {
                MapLibs[120 + i] = new MLibrary(DataPath + "Map\\ShandaMir2\\Objects" + (i + 1));
            }
            MapLibs[190] = new MLibrary(DataPath + "Map\\ShandaMir2\\AniTiles1");
            //wemade mir3 (allowed from 200-299)
            string[] Mapstate = { "", "wood\\", "sand\\", "snow\\", "forest\\" };
            for (int i = 0; i < Mapstate.Length; i++)
            {
                MapLibs[200 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Tilesc");
                MapLibs[201 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Tiles30c");
                MapLibs[202 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Tiles5c");
                MapLibs[203 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Smtilesc");
                MapLibs[204 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Housesc");
                MapLibs[205 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Cliffsc");
                MapLibs[206 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Dungeonsc");
                MapLibs[207 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Innersc");
                MapLibs[208 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Furnituresc");
                MapLibs[209 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Wallsc");
                MapLibs[210 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "smObjectsc");
                MapLibs[211 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Animationsc");
                MapLibs[212 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Object1c");
                MapLibs[213 + (i * 15)] = new MLibrary(DataPath + "Map\\WemadeMir3\\" + Mapstate[i] + "Object2c");
            }
            Mapstate = new[] { "", "wood", "sand", "snow", "forest" };
            //Aka:  note these .lib files are not currently in the crystal client data folder
            //      the most recent shanda clients map files have a different header and have tile errors
            //      if you convert the files and load the maps with MapType 3
            //shanda mir3 (allowed from 300-399)
            for (int i = 0; i < Mapstate.Length; i++)
            {
                MapLibs[300 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Tilesc" + Mapstate[i]);
                MapLibs[301 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Tiles30c" + Mapstate[i]);
                MapLibs[302 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Tiles5c" + Mapstate[i]);
                MapLibs[303 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Smtilesc" + Mapstate[i]);
                MapLibs[304 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Housesc" + Mapstate[i]);
                MapLibs[305 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Cliffsc" + Mapstate[i]);
                MapLibs[306 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Dungeonsc" + Mapstate[i]);
                MapLibs[307 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Innersc" + Mapstate[i]);
                MapLibs[308 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Furnituresc" + Mapstate[i]);
                MapLibs[309 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Wallsc" + Mapstate[i]);
                MapLibs[310 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "smObjectsc" + Mapstate[i]);
                MapLibs[311 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Animationsc" + Mapstate[i]);
                MapLibs[312 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Object1c" + Mapstate[i]);
                MapLibs[313 + (i * 15)] = new MLibrary(DataPath + "Map\\ShandaMir3\\" + "Object2c" + Mapstate[i]);
            }

            #endregion Maplibs

            //Thread thread = new Thread(LoadLibraries) { IsBackground = true };
            //thread.Start();
        }

        public static void LoadLibraries()
        {
            Count = MapLibs.Length;

            for (int i = 0; i < MapLibs.Length; i++)
            {
                if (MapLibs[i] == null)
                    MapLibs[i] = new MLibrary("");
                else
                    MapLibs[i].Initialize();
                Progress++;
            }
            Loaded = true;
        }
    }



    public sealed class MLibrary
    {
        private const string Extention = ".Lib";
        public const int LibVersion = 2;

        private readonly string _fileName;

        private MImage[] _images;
        private int[] _indexList;
        private int _count;
        private bool _initialized;

        private BinaryReader _reader;
        private FileStream _fStream;

        //public static int ScreenWidth = 1024;
        //public static int ScreenHeight = 800;
        public static int ScreenWidth = 1024;
        public static int ScreenHeight = 800;

        public MLibrary(string filename)
        {
            _fileName = Path.ChangeExtension(filename, Extention);
        }

        public void Initialize()
        {
            int CurrentVersion = 0;
            _initialized = true;

            if (!File.Exists(_fileName))
                return;
            try
            {
                _fStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                _reader = new BinaryReader(_fStream);
                CurrentVersion = _reader.ReadInt32();
                if (CurrentVersion != LibVersion)
                {
                    //cant use a directx based error popup cause it could be the lib file containing the interface is invalid :(
                    MessageBox.Show("Wrong version, expecting lib version: " + LibVersion + " found version: " + CurrentVersion + ".", _fileName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Application.Exit();
                    return;
                }
                _count = _reader.ReadInt32();
                _images = new MImage[_count];
                _indexList = new int[_count];

                for (int i = 0; i < _count; i++)
                    _indexList[i] = _reader.ReadInt32();
            }
            catch (Exception)
            {
                _initialized = false;
                throw;
            }
        }

        private bool CheckImage(int index)
        {
            if (!_initialized)
                Initialize();

            if (_images == null || index < 0 || index >= _images.Length)
                return false;

            if (_images[index] == null)
            {
                _fStream.Position = _indexList[index];
                _images[index] = new MImage(_reader);
            }
            MImage mi = _images[index];
            if (!mi.TextureValid)
            {
                if ((mi.Width == 0) || (mi.Height == 0))
                    return false;
                _fStream.Seek(_indexList[index] + 17, SeekOrigin.Begin);
                mi.CreateTexture(_reader);
            }

            return true;
        }

        public Point GetOffSet(int index)
        {
            if (!_initialized) Initialize();

            if (_images == null || index < 0 || index >= _images.Length)
                return Point.Empty;

            if (_images[index] == null)
            {
                _fStream.Seek(_indexList[index], SeekOrigin.Begin);
                _images[index] = new MImage(_reader);
            }

            return new Point(_images[index].X, _images[index].Y);
        }

        public Size GetSize(int index)
        {
            if (!_initialized) Initialize();
            if (_images == null || index < 0 || index >= _images.Length)
                return Size.Empty;

            if (_images[index] == null)
            {
                _fStream.Seek(_indexList[index], SeekOrigin.Begin);
                _images[index] = new MImage(_reader);
            }

            return new Size(_images[index].Width, _images[index].Height);
        }

        public Size GetTrueSize(int index)
        {
            if (!_initialized)
                Initialize();

            if (_images == null || index < 0 || index >= _images.Length)
                return Size.Empty;

            if (_images[index] == null)
            {
                _fStream.Position = _indexList[index];
                _images[index] = new MImage(_reader);
            }
            MImage mi = _images[index];
            if (mi.TrueSize.IsEmpty)
            {
                if (!mi.TextureValid)
                {
                    if ((mi.Width == 0) || (mi.Height == 0))
                        return Size.Empty;

                    _fStream.Seek(_indexList[index] + 17, SeekOrigin.Begin);
                    mi.CreateTexture(_reader);
                }
                return mi.GetTrueSize();
            }
            return mi.TrueSize;
        }

        #region Draw Methods

        public void Draw(int index, int x, int y)
        {
            if (x >= ScreenWidth || y >= ScreenHeight)
                return;

            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (x + mi.Width < 0 || y + mi.Height < 0)
                return;

            DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, new PointF(x, y), Color.White);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void Draw(int index, Point point, Color colour, bool offSet = false)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (offSet) point.Offset(mi.X, mi.Y);

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, point, colour);

            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void Draw(int index, Point point, Color colour, bool offSet, float opacity)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (offSet) point.Offset(mi.X, mi.Y);

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            float oldOpacity = DXManager.Opacity;
            DXManager.SetOpacity(opacity);

            DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, point, colour);
            DXManager.SetOpacity(oldOpacity);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void DrawBlend(int index, Point point, Color colour, bool offSet = false, float rate = 1)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (offSet) point.Offset(mi.X, mi.Y);

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            bool oldBlend = DXManager.Blending;
            DXManager.SetBlend(true, rate);

            DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, point, colour);

            DXManager.SetBlend(oldBlend);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void DrawBlend(int index, Rectangle section, Size destinationSize, int zoom, Point point, Color colour, bool offSet = false, float rate = 1)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (offSet) point.Offset(mi.X / zoom, mi.Y / zoom);

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            if (section.Right > mi.Width)
                section.Width -= section.Right - mi.Width;

            if (section.Bottom > mi.Height)
                section.Height -= section.Bottom - mi.Height;

            bool oldBlend = DXManager.Blending;
            DXManager.SetBlend(true, rate);

            DXManager.Sprite.Draw2D(mi.Image, section, destinationSize, point, colour);

            DXManager.SetBlend(oldBlend);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void Draw(int index, Rectangle section, Size destinationSize, Point point, Color colour, float opacity)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            if (section.Right > mi.Width)
                section.Width -= section.Right - mi.Width;

            if (section.Bottom > mi.Height)
                section.Height -= section.Bottom - mi.Height;

            float oldOpacity = DXManager.Opacity;
            DXManager.SetOpacity(opacity);

            DXManager.Sprite.Draw2D(mi.Image, section, destinationSize, point, colour);

            DXManager.SetOpacity(oldOpacity);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void DrawUp(int index, Rectangle section, Size destinationSize, int zoom, Point point, Color colour, float opacity)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            point.Y -= mi.Height / zoom;

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            if (section.Right > mi.Width)
                section.Width -= section.Right - mi.Width;

            if (section.Bottom > mi.Height)
                section.Height -= section.Bottom - mi.Height;

            float oldOpacity = DXManager.Opacity;
            DXManager.SetOpacity(opacity);

            DXManager.Sprite.Draw2D(mi.Image, section, destinationSize, point, colour);

            DXManager.SetOpacity(oldOpacity);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void Draw(int index, Rectangle section, Point point, Color colour, bool offSet)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (offSet) point.Offset(mi.X, mi.Y);

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            if (section.Right > mi.Width)
                section.Width -= section.Right - mi.Width;

            if (section.Bottom > mi.Height)
                section.Height -= section.Bottom - mi.Height;

            DXManager.Sprite.Draw2D(mi.Image, section, section.Size, point, colour);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void Draw(int index, Rectangle section, Point point, Color colour, float opacity)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            if (section.Right > mi.Width)
                section.Width -= section.Right - mi.Width;

            if (section.Bottom > mi.Height)
                section.Height -= section.Bottom - mi.Height;

            float oldOpacity = DXManager.Opacity;
            DXManager.SetOpacity(opacity);

            DXManager.Sprite.Draw2D(mi.Image, section, section.Size, point, colour);

            DXManager.SetOpacity(oldOpacity);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void Draw(int index, Point point, Size size, Color colour)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + size.Width < 0 || point.Y + size.Height < 0)
                return;

            DXManager.Sprite.Draw2D(mi.Image, new Rectangle(Point.Empty, new Size(mi.Width, mi.Height)), size, point, colour);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void DrawTinted(int index, Point point, Color colour, Color Tint)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;
            DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, point, colour);

            if (mi.HasMask != true) return;
            DXManager.Sprite.Draw2D(mi.MaskImage, Point.Empty, 0, point, Tint);

            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void DrawUp(int index, int x, int y)
        {
            if (x >= ScreenWidth)
                return;

            if (!CheckImage(index))
                return;

            MImage mi = _images[index];
            y -= mi.Height;
            if (y >= ScreenHeight)
                return;
            if (x + mi.Width < 0 || y + mi.Height < 0)
                return;

            DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, new PointF(x, y), Color.White);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public void DrawUpBlend(int index, Point point)
        {
            if (!CheckImage(index))
                return;

            MImage mi = _images[index];

            point.Y -= mi.Height;

            if (point.X >= ScreenWidth || point.Y >= ScreenHeight || point.X + mi.Width < 0 || point.Y + mi.Height < 0)
                return;

            bool oldBlend = DXManager.Blending;
            DXManager.SetBlend(true, 1);

            DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, point, Color.White);

            DXManager.SetBlend(oldBlend);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        public Bitmap DrawBitmap(int index)
        {
            if (!CheckImage(index))
                return null;

            MImage mi = _images[index];

            if (mi.Width < 0 || mi.Height < 0)
                return null;

            GraphicsStream imageStream = mi.Image.LockRectangle(0, LockFlags.Discard);
            Bitmap MyBitmap = new Bitmap(mi.Width, mi.Height, mi.Width * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, imageStream.InternalData);

            mi.Image.UnlockRectangle(0);

            return MyBitmap;
            //DXManager.Sprite.Draw2D(mi.Image, Point.Empty, 0, new PointF(x, y), Color.White);
            //mi.CleanTime = CMain.Time + CleanDelay;
        }

        #endregion Draw Methods
    }

    public sealed class MImage
    {
        public short Width, Height, X, Y, ShadowX, ShadowY;
        public byte Shadow;
        public int Length;

        public bool TextureValid;
        public Texture Image;

        //layer 2:
        public short MaskWidth, MaskHeight, MaskX, MaskY;

        public int MaskLength;

        public Texture MaskImage;
        public Boolean HasMask;

        public long CleanTime;
        public Size TrueSize;

        public unsafe byte* Data;

        public MImage(BinaryReader reader)
        {
            //read layer 1
            Width = reader.ReadInt16();
            Height = reader.ReadInt16();
            X = reader.ReadInt16();
            Y = reader.ReadInt16();
            ShadowX = reader.ReadInt16();
            ShadowY = reader.ReadInt16();
            Shadow = reader.ReadByte();
            Length = reader.ReadInt32();

            //check if there's a second layer and read it
            HasMask = ((Shadow >> 7) == 1) ? true : false;
            if (HasMask)
            {
                reader.ReadBytes(Length);
                MaskWidth = reader.ReadInt16();
                MaskHeight = reader.ReadInt16();
                MaskX = reader.ReadInt16();
                MaskY = reader.ReadInt16();
                MaskLength = reader.ReadInt32();
            }
        }

        public unsafe void CreateTexture(BinaryReader reader)
        {
            int w = Width;// + (4 - Width % 4) % 4;
            int h = Height;// + (4 - Height % 4) % 4;
            GraphicsStream stream = null;

            Image = new Texture(DXManager.Device, w, h, 1, Usage.None, Format.A8R8G8B8, Pool.Managed);
            stream = Image.LockRectangle(0, LockFlags.Discard);
            Data = (byte*)stream.InternalDataPointer;

            byte[] decomp = DecompressImage(reader.ReadBytes(Length));

            stream.Write(decomp, 0, decomp.Length);

            stream.Dispose();
            Image.UnlockRectangle(0);

            if (HasMask)
            {
                reader.ReadBytes(12);
                w = Width;// + (4 - Width % 4) % 4;
                h = Height;// + (4 - Height % 4) % 4;

                MaskImage = new Texture(DXManager.Device, w, h, 1, Usage.None, Format.A8R8G8B8, Pool.Managed);
                stream = MaskImage.LockRectangle(0, LockFlags.Discard);

                decomp = DecompressImage(reader.ReadBytes(Length));

                stream.Write(decomp, 0, decomp.Length);

                stream.Dispose();
                MaskImage.UnlockRectangle(0);
            }

            DXManager.TextureList.Add(this);
            TextureValid = true;
            Image.Disposing += (o, e) =>
            {
                TextureValid = false;
                Image = null;
                MaskImage = null;
                Data = null;
                DXManager.TextureList.Remove(this);
            };

            //CleanTime = CMain.Time + CleanDelay;
        }

        public unsafe bool VisiblePixel(Point p, bool acurrate)
        {
            if (p.X < 0 || p.Y < 0 || p.X >= Width || p.Y >= Height)
                return false;

            //if(!acurrate)
            //{
            //    Size trueSize = GetTrueSize();

            //    int widthDiff = (Width - trueSize.Width) / 2;
            //    int heightDiff = (Height - trueSize.Height ) /2 ;

            //    if (p.X < widthDiff || p.X > Width + widthDiff || p.Y < heightDiff || p.Y > Height + heightDiff) return false;
            //    return true;
            //}

            int w = Width;// +(4 - Width % 4) % 4;

            bool result = false;
            if (Data != null)
            {
                int x = p.X;// (p.X - p.X % 4) / 4;
                int y = p.Y;// (p.Y - p.Y % 4) / 4;

                int index = (y * (w << 2)) + (x << 2); //(y * (w * 4)) + (x * 4);

                int col0 = (Data[index + 1] << 8 | Data[index]), col1 = (Data[index + 3] << 8 | Data[index + 2]);

                //if (col0 == 0 && col1 == 0) return false;
                byte col = Data[index];

                if (col == 0) return false;
                return true;

                //if (!acurrate || col1 < col0) return true;

                x = p.X;// % 4;
                y = p.Y;// % 4;
                //x *= 2;

                //result = ((Data[index + y] & 1 << x) >> x) != 1 || ((Data[index + y] & 1 << x + 1) >> x + 1) != 1;
            }
            return result;
        }

        public Size GetTrueSize()
        {
            if (TrueSize != Size.Empty) return TrueSize;

            int l = 0, t = 0, r = Width, b = Height;

            bool visible = false;
            for (int x = 0; x < r; x++)
            {
                for (int y = 0; y < b; y++)
                {
                    if (!VisiblePixel(new Point(x, y), true)) continue;

                    visible = true;
                    break;
                }

                if (!visible) continue;

                l = x;
                break;
            }

            visible = false;
            for (int y = 0; y < b; y++)
            {
                for (int x = l; x < r; x++)
                {
                    if (!VisiblePixel(new Point(x, y), true)) continue;

                    visible = true;
                    break;
                }
                if (!visible) continue;

                t = y;
                break;
            }

            visible = false;
            for (int x = r - 1; x >= l; x--)
            {
                for (int y = 0; y < b; y++)
                {
                    if (!VisiblePixel(new Point(x, y), true)) continue;

                    visible = true;
                    break;
                }

                if (!visible) continue;

                r = x + 1;
                break;
            }

            visible = false;
            for (int y = b - 1; y >= t; y--)
            {
                for (int x = l; x < r; x++)
                {
                    if (!VisiblePixel(new Point(x, y), true)) continue;

                    visible = true;
                    break;
                }
                if (!visible) continue;

                b = y + 1;
                break;
            }

            TrueSize = Rectangle.FromLTRB(l, t, r, b).Size;

            return TrueSize;
        }

        private static byte[] DecompressImage(byte[] image)
        {
            using (GZipStream stream = new GZipStream(new MemoryStream(image), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }
    }

    */
}
