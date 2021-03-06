﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirTools.Map
{
    public class CellInfo
    {
        public short BackIndex;
        public int BackImage;
        public short MiddleIndex;
        public int MiddleImage;
        public short FrontIndex;
        public int FrontImage;

        public byte DoorIndex;
        public byte DoorOffset;

        public byte FrontAnimationFrame;
        public byte FrontAnimationTick;

        public byte MiddleAnimationFrame;
        public byte MiddleAnimationTick;

        public short TileAnimationImage;
        public short TileAnimationOffset;
        public byte TileAnimationFrames;

        public byte Light;
        public byte Unknown;

        public bool FishingCell;
    }

    public class MapReader
    {
        public int Width, Height;
        public CellInfo[,] MapCells;
        private string FileName;
        private byte[] Bytes;

        private FileStream _stream;

        public int Count;

        public string MapType;

        public MapReader(string FileName)
        {
            this.FileName = FileName;
            initiate();
        }

        public MapReader(int width, int height)
        {
            Width = width;
            Height = height;
            MapCells = new CellInfo[Width, Height];

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    MapCells[x, y] = new CellInfo();
                    MapCells[x, y].BackIndex = 0;
                    MapCells[x, y].BackImage = 0;
                    MapCells[x, y].MiddleIndex = 0;
                    MapCells[x, y].MiddleImage = 0;
                    MapCells[x, y].FrontIndex = 0;
                    MapCells[x, y].FrontImage = 0;
                    MapCells[x, y].DoorIndex = 0;
                    MapCells[x, y].DoorOffset = 0;
                    MapCells[x, y].FrontAnimationFrame = 0;
                    MapCells[x, y].FrontAnimationTick = 0;
                    MapCells[x, y].MiddleAnimationFrame = 0;
                    MapCells[x, y].MiddleAnimationTick = 0;
                    MapCells[x, y].TileAnimationImage = 0;
                    MapCells[x, y].TileAnimationOffset = 0;
                    MapCells[x, y].TileAnimationFrames = 0;
                    MapCells[x, y].Light = 0;
                }
        }

        private void initiate()
        {
            if (File.Exists(FileName))
            {
                Bytes = File.ReadAllBytes(FileName);
            }
            else
            {
                Width = 1000;
                Height = 1000;
                MapCells = new CellInfo[Width, Height];

                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {
                        MapCells[x, y] = new CellInfo();
                    }
                return;
            }

            //c# custom map format
            if ((Bytes[2] == 0x43) && (Bytes[3] == 0x23))
            {
                LoadMapType100();
                //MessageBox.Show("MapType100");
                MapType = "100";
                return;
            }

            //wemade mir3 maps have no title they just start with blank bytes
            if (Bytes[0] == 0)
            {
                LoadMapType5();
                //MessageBox.Show("MapType5");
                MapType = "5";
                return;
            }
            //shanda mir3 maps start with title: (C) SNDA, MIR3.
            if ((Bytes[0] == 0x0F) && (Bytes[5] == 0x53) && (Bytes[14] == 0x33))
            {
                LoadMapType6();
                //MessageBox.Show("MapType6");
                MapType = "6";
                return;
            }
            //wemades antihack map (laby maps) title start with: Mir2 AntiHack
            if ((Bytes[0] == 0x15) && (Bytes[4] == 0x32) && (Bytes[6] == 0x41) && (Bytes[19] == 0x31))
            {
                LoadMapType4();
                //MessageBox.Show("MapType4");
                MapType = "4";
                return;
            }
            //wemades 2010 map format i guess title starts with: Map 2010 Ver 1.0
            if ((Bytes[0] == 0x10) && (Bytes[2] == 0x61) && (Bytes[7] == 0x31) && (Bytes[14] == 0x31))
            {
                LoadMapType1();
                //MessageBox.Show("MapType1");
                MapType = "1";
                return;
            }

            //shanda's 2012 format and one of shandas(wemades) older formats share same header info, only difference is the filesize
            if ((Bytes[4] == 0x0F) || (Bytes[4] == 0x03) && (Bytes[18] == 0x0D) && (Bytes[19] == 0x0A))
            {
                int W = Bytes[0] + (Bytes[1] << 8);
                int H = Bytes[2] + (Bytes[3] << 8);
                if (Bytes.Length > (52 + (W * H * 14)))
                {
                    LoadMapType3();
                    //MessageBox.Show("MapType3");
                    MapType = "3";
                    return;
                }
                LoadMapType2();
                //MessageBox.Show("MapType2");
                MapType = "2";
                return;
            }

            //Aka:  added to load shanda 0.map & 3~1.map which was loading as MapType0
            //      not sure if any other MapType would be more suitable but this works :)
            if ((Bytes[4] == 0x0D) && (Bytes[5] == 0x4C) && (Bytes[6] == 0x65))
            {
                //load default for now
                LoadMapType8();
                //MessageBox.Show("MapType8");
                MapType = "8";
                return;
            }

            //3/4 heroes map format (myth/lifcos i guess)
            if ((Bytes[0] == 0x0D) && (Bytes[1] == 0x4C) && (Bytes[7] == 0x20) && (Bytes[11] == 0x6D))
            {
                LoadMapType7();
                //MessageBox.Show("MapType7");
                MapType = "7";
                return;
            }
            //if it's none of the above load the default old school format
            LoadMapType0();
            //MessageBox.Show("MapType0");
            MapType = "0";
        }

        private void LoadMapType0()
        {
            try
            {
                int offset = 0;
                Width = BitConverter.ToInt16(Bytes, offset);
                offset += 2;
                Height = BitConverter.ToInt16(Bytes, offset);
                MapCells = new CellInfo[Width, Height];
                offset = 52;
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {//12
                        MapCells[x, y] = new CellInfo();
                        MapCells[x, y].BackIndex = 0;
                        MapCells[x, y].MiddleIndex = 1;
                        MapCells[x, y].BackImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].MiddleImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].FrontImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].DoorIndex = Bytes[offset++];
                        MapCells[x, y].DoorOffset = Bytes[offset++];
                        MapCells[x, y].FrontAnimationFrame = Bytes[offset++];
                        MapCells[x, y].FrontAnimationTick = Bytes[offset++];
                        MapCells[x, y].FrontIndex = (short)(Bytes[offset++] + 2);
                        MapCells[x, y].Light = Bytes[offset++];
                        if ((MapCells[x, y].BackImage & 0x8000) != 0)
                            MapCells[x, y].BackImage = (MapCells[x, y].BackImage & 0x7FFF) | 0x20000000;

                        if (MapCells[x, y].Light == 100 || MapCells[x, y].Light == 101)
                            MapCells[x, y].FishingCell = true;
                    }
            }
            catch (Exception ex)
            {
                //if (Settings.LogErrors) CMain.SaveError(ex.ToString());
            }
        }

        private void LoadMapType1()
        {
            try
            {
                int offSet = 21;

                int w = BitConverter.ToInt16(Bytes, offSet);
                offSet += 2;
                int xor = BitConverter.ToInt16(Bytes, offSet);
                offSet += 2;
                int h = BitConverter.ToInt16(Bytes, offSet);
                Width = w ^ xor;
                Height = h ^ xor;
                MapCells = new CellInfo[Width, Height];

                offSet = 54;

                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {
                        MapCells[x, y] = new CellInfo
                        {
                            BackIndex = 0,
                            BackImage = (int)(BitConverter.ToInt32(Bytes, offSet) ^ 0xAA38AA38),
                            MiddleIndex = 1,
                            MiddleImage = (short)(BitConverter.ToInt16(Bytes, offSet += 4) ^ xor),
                            FrontImage = (short)(BitConverter.ToInt16(Bytes, offSet += 2) ^ xor),
                            DoorIndex = Bytes[offSet += 2],
                            DoorOffset = Bytes[++offSet],
                            FrontAnimationFrame = Bytes[++offSet],
                            FrontAnimationTick = Bytes[++offSet],
                            FrontIndex = (short)(Bytes[++offSet] + 2),
                            Light = Bytes[++offSet],
                            Unknown = Bytes[++offSet]
                        };
                        offSet++;

                        if (MapCells[x, y].Light == 100 || MapCells[x, y].Light == 101)
                            MapCells[x, y].FishingCell = true;
                    }
            }
            catch (Exception ex)
            {
                //if (Settings.LogErrors) CMain.SaveError(ex.ToString());
            }
        }

        private void LoadMapType2()
        {
            try
            {
                int offset = 0;
                Width = BitConverter.ToInt16(Bytes, offset);
                offset += 2;
                Height = BitConverter.ToInt16(Bytes, offset);
                MapCells = new CellInfo[Width, Height];
                offset = 52;
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {//14
                        MapCells[x, y] = new CellInfo();
                        MapCells[x, y].BackImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].MiddleImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].FrontImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].DoorIndex = Bytes[offset++];
                        MapCells[x, y].DoorOffset = Bytes[offset++];
                        MapCells[x, y].FrontAnimationFrame = Bytes[offset++];
                        MapCells[x, y].FrontAnimationTick = Bytes[offset++];
                        MapCells[x, y].FrontIndex = (short)(Bytes[offset++] + 120);
                        MapCells[x, y].Light = Bytes[offset++];
                        MapCells[x, y].BackIndex = (short)(Bytes[offset++] + 100);
                        MapCells[x, y].MiddleIndex = (short)(Bytes[offset++] + 110);
                        if ((MapCells[x, y].BackImage & 0x8000) != 0)
                            MapCells[x, y].BackImage = (MapCells[x, y].BackImage & 0x7FFF) | 0x20000000;

                        if (MapCells[x, y].Light == 100 || MapCells[x, y].Light == 101)
                            MapCells[x, y].FishingCell = true;
                    }
            }
            catch (Exception ex)
            {
                //if (Settings.LogErrors) CMain.SaveError(ex.ToString());
            }
        }

        private void LoadMapType3()
        {
            try
            {
                int offset = 0;
                Width = BitConverter.ToInt16(Bytes, offset);
                offset += 2;
                Height = BitConverter.ToInt16(Bytes, offset);
                MapCells = new CellInfo[Width, Height];
                offset = 52;
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {//36
                        MapCells[x, y] = new CellInfo();
                        MapCells[x, y].BackImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].MiddleImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].FrontImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].DoorIndex = Bytes[offset++];
                        MapCells[x, y].DoorOffset = Bytes[offset++];
                        MapCells[x, y].FrontAnimationFrame = Bytes[offset++];
                        MapCells[x, y].FrontAnimationTick = Bytes[offset++];
                        MapCells[x, y].FrontIndex = (short)(Bytes[offset++] + 120);
                        MapCells[x, y].Light = Bytes[offset++];
                        MapCells[x, y].BackIndex = (short)(Bytes[offset++] + 100);
                        MapCells[x, y].MiddleIndex = (short)(Bytes[offset++] + 110);
                        MapCells[x, y].TileAnimationImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 7;//2bytes from tileanimframe, 2 bytes always blank?, 2bytes potentialy 'backtiles index', 1byte fileindex for the backtiles?
                        MapCells[x, y].TileAnimationFrames = Bytes[offset++];
                        MapCells[x, y].TileAnimationOffset = BitConverter.ToInt16(Bytes, offset);
                        offset += 14; //tons of light, blending, .. related options i hope
                        if ((MapCells[x, y].BackImage & 0x8000) != 0)
                            MapCells[x, y].BackImage = (MapCells[x, y].BackImage & 0x7FFF) | 0x20000000;

                        if (MapCells[x, y].Light == 100 || MapCells[x, y].Light == 101)
                            MapCells[x, y].FishingCell = true;
                    }
            }
            catch (Exception ex)
            {
                //  if (Settings.LogErrors) CMain.SaveError(ex.ToString());
            }
        }

        private void LoadMapType4()
        {
            try
            {
                int offset = 31;
                int w = BitConverter.ToInt16(Bytes, offset);
                offset += 2;
                int xor = BitConverter.ToInt16(Bytes, offset);
                offset += 2;
                int h = BitConverter.ToInt16(Bytes, offset);
                Width = w ^ xor;
                Height = h ^ xor;
                MapCells = new CellInfo[Width, Height];
                offset = 64;
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {//12
                        MapCells[x, y] = new CellInfo();
                        MapCells[x, y].BackIndex = 0;
                        MapCells[x, y].MiddleIndex = 1;
                        MapCells[x, y].BackImage = (short)(BitConverter.ToInt16(Bytes, offset) ^ xor);
                        offset += 2;
                        MapCells[x, y].MiddleImage = (short)(BitConverter.ToInt16(Bytes, offset) ^ xor);
                        offset += 2;
                        MapCells[x, y].FrontImage = (short)(BitConverter.ToInt16(Bytes, offset) ^ xor);
                        offset += 2;
                        MapCells[x, y].DoorIndex = Bytes[offset++];
                        MapCells[x, y].DoorOffset = Bytes[offset++];
                        MapCells[x, y].FrontAnimationFrame = Bytes[offset++];
                        MapCells[x, y].FrontAnimationTick = Bytes[offset++];
                        MapCells[x, y].FrontIndex = (short)(Bytes[offset++] + 2);
                        MapCells[x, y].Light = Bytes[offset++];
                        if ((MapCells[x, y].BackImage & 0x8000) != 0)
                            MapCells[x, y].BackImage = (MapCells[x, y].BackImage & 0x7FFF) | 0x20000000;

                        if (MapCells[x, y].Light == 100 || MapCells[x, y].Light == 101)
                            MapCells[x, y].FishingCell = true;
                    }
            }
            catch (Exception ex)
            {
                // if (Settings.LogErrors) CMain.SaveError(ex.ToString());
            }
        }

        private void LoadMapType5()
        {
            try
            {
                byte flag = 0;
                int offset = 20;
                short Attribute = (short)(BitConverter.ToInt16(Bytes, offset));
                Width = (int)(BitConverter.ToInt16(Bytes, offset += 2));
                Height = (int)(BitConverter.ToInt16(Bytes, offset += 2));
                //ignoring eventfile and fogcolor for now (seems unused in maps i checked)
                offset = 28;
                //initiate all cells
                MapCells = new CellInfo[Width, Height];
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                        MapCells[x, y] = new CellInfo();
                //read all back tiles
                for (int x = 0; x < (Width / 2); x++)
                    for (int y = 0; y < (Height / 2); y++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            MapCells[(x * 2) + (i % 2), (y * 2) + (i / 2)].BackIndex = (short)(Bytes[offset] != 255 ? Bytes[offset] + 200 : -1);
                            MapCells[(x * 2) + (i % 2), (y * 2) + (i / 2)].BackImage = (int)(BitConverter.ToUInt16(Bytes, offset + 1) + 1);
                        }
                        offset += 3;
                    }
                //read rest of data
                offset = 28 + (3 * ((Width / 2) + (Width % 2)) * (Height / 2));
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {
                        flag = Bytes[offset++];
                        MapCells[x, y].MiddleAnimationFrame = Bytes[offset++];

                        MapCells[x, y].FrontAnimationFrame = Bytes[offset] == 255 ? (byte)0 : Bytes[offset];
                        MapCells[x, y].FrontAnimationFrame &= 0x8F;
                        offset++;
                        MapCells[x, y].MiddleAnimationTick = 0;
                        MapCells[x, y].FrontAnimationTick = 0;
                        MapCells[x, y].FrontIndex = (short)(Bytes[offset] != 255 ? Bytes[offset] + 200 : -1);
                        offset++;
                        MapCells[x, y].MiddleIndex = (short)(Bytes[offset] != 255 ? Bytes[offset] + 200 : -1);
                        offset++;
                        MapCells[x, y].MiddleImage = (ushort)(BitConverter.ToUInt16(Bytes, offset) + 1);
                        offset += 2;
                        MapCells[x, y].FrontImage = (ushort)(BitConverter.ToUInt16(Bytes, offset) + 1);
                        if ((MapCells[x, y].FrontImage == 1) && (MapCells[x, y].FrontIndex == 200))
                            MapCells[x, y].FrontIndex = -1;
                        offset += 2;
                        offset += 3;//mir3 maps dont have doors so dont bother reading the info
                        MapCells[x, y].Light = (byte)(Bytes[offset] & 0x0F);
                        offset += 2;
                        if ((flag & 0x01) != 1) MapCells[x, y].BackImage |= 0x20000000;
                        if ((flag & 0x02) != 2) MapCells[x, y].FrontImage = (ushort)((UInt16)MapCells[x, y].FrontImage | 0x8000);

                        if (MapCells[x, y].Light >= 100 && MapCells[x, y].Light <= 119)
                            MapCells[x, y].FishingCell = true;
                        else
                            MapCells[x, y].Light *= 2;//expand general mir3 lighting as default range is small. Might break new colour lights.
                    }
            }
            catch (Exception ex)
            {
                // if (Settings.LogErrors) CMain.SaveError(ex.ToString());
            }
        }

        private void LoadMapType6()
        {
            try
            {
                byte flag = 0;
                int offset = 16;
                Width = BitConverter.ToInt16(Bytes, offset);
                offset += 2;
                Height = BitConverter.ToInt16(Bytes, offset);
                MapCells = new CellInfo[Width, Height];
                offset = 40;
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {
                        MapCells[x, y] = new CellInfo();
                        flag = Bytes[offset++];
                        MapCells[x, y].BackIndex = (short)(Bytes[offset] != 255 ? Bytes[offset] + 300 : -1);
                        offset++;
                        MapCells[x, y].MiddleIndex = (short)(Bytes[offset] != 255 ? Bytes[offset] + 300 : -1);
                        offset++;
                        MapCells[x, y].FrontIndex = (short)(Bytes[offset] != 255 ? Bytes[offset] + 300 : -1);
                        offset++;
                        MapCells[x, y].BackImage = (short)(BitConverter.ToInt16(Bytes, offset) + 1);
                        offset += 2;
                        MapCells[x, y].MiddleImage = (short)(BitConverter.ToInt16(Bytes, offset) + 1);
                        offset += 2;
                        MapCells[x, y].FrontImage = (short)(BitConverter.ToInt16(Bytes, offset) + 1);
                        offset += 2;
                        if ((MapCells[x, y].FrontImage == 1) && (MapCells[x, y].FrontIndex == 200))
                            MapCells[x, y].FrontIndex = -1;
                        MapCells[x, y].MiddleAnimationFrame = Bytes[offset++];
                        MapCells[x, y].FrontAnimationFrame = Bytes[offset] == 255 ? (byte)0 : Bytes[offset];
                        if (MapCells[x, y].FrontAnimationFrame > 0x0F)//assuming shanda used same value not sure
                            MapCells[x, y].FrontAnimationFrame = (byte)(/*0x80 ^*/ (MapCells[x, y].FrontAnimationFrame & 0x0F));
                        offset++;
                        MapCells[x, y].MiddleAnimationTick = 1;
                        MapCells[x, y].FrontAnimationTick = 1;
                        MapCells[x, y].Light = (byte)(Bytes[offset] & 0x0F);
                        MapCells[x, y].Light *= 4;//far wants all light on mir3 maps to be maxed :p
                        offset += 8;
                        if ((flag & 0x01) != 1) MapCells[x, y].BackImage |= 0x20000000;
                        if ((flag & 0x02) != 2) MapCells[x, y].FrontImage = (short)((UInt16)MapCells[x, y].FrontImage | 0x8000);

                        //Aka: fix errors in shanda mir3 1.map and others where a blue water tile will appear on top of everything
                        if (MapCells[x, y].FrontIndex == 300) MapCells[x, y].FrontIndex = -1;
                    }
            }
            catch (Exception ex)
            {
                //if (Settings.LogErrors) CMain.SaveError(ex.ToString());
            }
        }

        private void LoadMapType7()
        {
            try
            {
                int offset = 21;
                Width = BitConverter.ToInt16(Bytes, offset);
                offset += 4;
                Height = BitConverter.ToInt16(Bytes, offset);
                MapCells = new CellInfo[Width, Height];

                offset = 54;

                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {//total 15
                        MapCells[x, y] = new CellInfo
                        {
                            BackIndex = 0,
                            BackImage = BitConverter.ToInt32(Bytes, offset),
                            MiddleIndex = 1,
                            MiddleImage = BitConverter.ToInt16(Bytes, offset += 4),
                            FrontImage = BitConverter.ToInt16(Bytes, offset += 2),
                            DoorIndex = Bytes[offset += 2],
                            DoorOffset = Bytes[++offset],
                            FrontAnimationFrame = Bytes[++offset],
                            FrontAnimationTick = Bytes[++offset],
                            FrontIndex = (short)(Bytes[++offset] + 2),
                            Light = Bytes[++offset],
                            Unknown = Bytes[++offset]
                        };
                        if ((MapCells[x, y].BackImage & 0x8000) != 0)
                            MapCells[x, y].BackImage = (MapCells[x, y].BackImage & 0x7FFF) | 0x20000000;
                        offset++;

                        if (MapCells[x, y].Light == 100 || MapCells[x, y].Light == 101)
                            MapCells[x, y].FishingCell = true;
                    }
            }
            catch (Exception ex)
            {
                // if (Settings.LogErrors) CMain.SaveError(ex.ToString());
            }
        }

        private void LoadMapType8()
        {
            try
            {
                int offset = 0;
                Width = BitConverter.ToInt16(Bytes, offset);
                offset += 2;
                Height = BitConverter.ToInt16(Bytes, offset);
                MapCells = new CellInfo[Width, Height];
                offset = 52;
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {//12
                        MapCells[x, y] = new CellInfo();
                        MapCells[x, y].BackIndex = 100;
                        MapCells[x, y].MiddleIndex = 110;
                        MapCells[x, y].BackImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].MiddleImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].FrontImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].DoorIndex = Bytes[offset++];
                        MapCells[x, y].DoorOffset = Bytes[offset++];
                        MapCells[x, y].FrontAnimationFrame = Bytes[offset++];
                        MapCells[x, y].FrontAnimationTick = Bytes[offset++];
                        MapCells[x, y].FrontIndex = (short)(Bytes[offset++] + 120);
                        MapCells[x, y].Light = Bytes[offset++];
                        if ((MapCells[x, y].BackImage & 0x8000) != 0)
                            MapCells[x, y].BackImage = (MapCells[x, y].BackImage & 0x7FFF) | 0x20000000;

                        if (MapCells[x, y].Light == 100 || MapCells[x, y].Light == 101)
                            MapCells[x, y].FishingCell = true;
                    }
            }
            catch (Exception ex)
            {
                //if (Settings.LogErrors) CMain.SaveError(ex.ToString());
            }
        }

        private void LoadMapType100()
        {
            try
            {
                int offset = 4;
                if ((Bytes[0] != 1) || (Bytes[1] != 0)) return;//only support version 1 atm
                Width = BitConverter.ToInt16(Bytes, offset);
                offset += 2;
                Height = BitConverter.ToInt16(Bytes, offset);
                MapCells = new CellInfo[Width, Height];
                offset = 8;
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {
                        MapCells[x, y] = new CellInfo();
                        MapCells[x, y].BackIndex = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].BackImage = BitConverter.ToInt32(Bytes, offset); //Aka: changed this from short to int
                        offset += 4;
                        MapCells[x, y].MiddleIndex = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].MiddleImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].FrontIndex = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].FrontImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].DoorIndex = Bytes[offset++];
                        MapCells[x, y].DoorOffset = Bytes[offset++];
                        MapCells[x, y].FrontAnimationFrame = Bytes[offset++];
                        MapCells[x, y].FrontAnimationTick = Bytes[offset++];
                        MapCells[x, y].MiddleAnimationFrame = Bytes[offset++];
                        MapCells[x, y].MiddleAnimationTick = Bytes[offset++];
                        MapCells[x, y].TileAnimationImage = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].TileAnimationOffset = BitConverter.ToInt16(Bytes, offset);
                        offset += 2;
                        MapCells[x, y].TileAnimationFrames = Bytes[offset++];
                        MapCells[x, y].Light = Bytes[offset++];

                        if (MapCells[x, y].Light == 100 || MapCells[x, y].Light == 101)
                            MapCells[x, y].FishingCell = true;
                    }
            }
            catch (Exception ex)
            {
                //if (Settings.LogErrors) CMain.SaveError(ex.ToString());
            }
        }

        public void Close()
        {
            if (_stream != null)
                _stream.Dispose();
        }

        public void Save(string mapFileName)
        {
            Close();
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    writer.Write((Int16)MapCells[x, y].BackIndex); //short
                    writer.Write((Int32)MapCells[x, y].BackImage); //int
                    writer.Write((Int16)MapCells[x, y].MiddleIndex); //short
                    writer.Write((Int16)MapCells[x, y].MiddleImage); //short
                    writer.Write((Int16)MapCells[x, y].FrontIndex); //short
                    writer.Write((Int16)MapCells[x, y].FrontImage); //short
                    writer.Write((byte)MapCells[x, y].DoorIndex); //byte
                    writer.Write((byte)MapCells[x, y].DoorOffset); //byte
                    writer.Write((byte)MapCells[x, y].FrontAnimationFrame); //byte
                    writer.Write((byte)MapCells[x, y].FrontAnimationTick); //byte
                    writer.Write((byte)MapCells[x, y].MiddleAnimationFrame); //byte
                    writer.Write((byte)MapCells[x, y].MiddleAnimationTick); //byte
                    writer.Write((Int16)MapCells[x, y].TileAnimationImage); //short
                    writer.Write((Int16)MapCells[x, y].TileAnimationOffset); //short
                    writer.Write((byte)MapCells[x, y].TileAnimationFrames); //byte
                    writer.Write((byte)MapCells[x, y].Light); //byte
                }
            }

            writer.Flush();
            byte[] fBytes = stream.ToArray();

            _stream = File.Create(mapFileName);
            writer = new BinaryWriter(_stream);
            //write header as 10C#
            //writer.Write("10C#"); //but not like this :)
            writer.Write((byte)0x01);
            writer.Write((byte)0x00);
            writer.Write((byte)0x43);//(byte)67 (C)
            writer.Write((byte)0x23);//(byte)35 (#)
            writer.Write((Int16)Width); //short
            writer.Write((Int16)Height); //short

            writer.Write(fBytes);
            writer.Flush();
            writer.Close();
            writer.Dispose();
            Close();
        }
    }
}
