using System;

namespace MirTools
{
    public static class Common
    {
        public static string LocalAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\MirTools\";
        public static string SavedFramesPath = LocalAppDataPath + @"\FrameData\";
        public static string LibraryCachePath = LocalAppDataPath + @"\LibraryCache\";

        public static string MirToolsConfigurationFilePath = LocalAppDataPath + @"\MirTools.config";
        public static string BookmarkFilePath = LocalAppDataPath + @"\Bookmarks.list";
        public static string HistoryFilePath = LocalAppDataPath + @"\History.list";

        public static string OpenFileDialogFilter = "Crystal Mir Library V2|*.Lib|WeMade Mir Image Library|*.Wil|WeMade Texture Library|*.Wtl|Shanda WeMade Zipped Library|*.Wzl|Shanda Mir Image Zip|*.Miz|All Mir Formats|*.Lib;*.Wil;*.Wtl;*.Wzl;*.Miz|All Files|*.*";

        public enum LibraryImageOffsets : int
        {
            CArmour = 808,
            CHumEffect = 808, // Needs changing
            CWeapon = 416
        }

        public enum OpenType
        {
            None,
            Open,
            New,
            Convert
        }

        public enum FolderType
        {
            None,
            AArmour,
            AHair,
            AHelmet,
            AHumEffect,
            AWeapon,
            AWeaponEffect,
            ARArmour,
            ARHair,
            ARHelmet,
            ARHumEffect,
            ARWeapon,
            ARWeaponEffect,
            CArmour,
            CHair,
            CHelmet,
            CHumEffect,
            CShields,
            CWeapon,
            CWeaponEffect,
            Monster,
            Mount,
            NPC,
            Pet,
            Transform,
            TransformEffect,
            Data
        }

        public enum OfficialMirType
        {
            None,
            Armour,
            Weapon
        };

        public enum Gender : byte
        {
            None = 255,
            Male = 0,
            Female = 1,
            Both = 2
        }

        public enum Direction : Byte
        {
            None = 255,
            North = 0,
            Up = 0,
            NorthEast = 1,
            UpRight = 1,
            East = 2,
            Right = 2,
            SouthEast = 3,
            DownRight = 3,
            South = 4,
            Down = 4,
            SouthWest = 5,
            DownLeft = 5,
            West = 6,
            Left = 6,
            NorthWest = 7,
            UpLeft = 7
        }

        public enum ReturnTye
        {
            None,
            Cancel,
            Preview,
            OK,
            Apply
        }

        public enum FileSize
        {
            None,
            Bits,
            Bytes,
            Kilobytes,
            Megabytes,
            Gigabytes
        }

        public enum LibraryType
        {
            None,
            CSharpLibraryV1,
            CSharpLibraryV2,
            WeMadeLibrary,
            WTLLibrary
        }

        public static string GetBytesReadable(long i)
        {
            // Get absolute value
            long absolute_i = (i < 0 ? -i : i);
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (absolute_i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (i >> 50);
            }
            else if (absolute_i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (i >> 40);
            }
            else if (absolute_i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (i >> 30);
            }
            else if (absolute_i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (i >> 20);
            }
            else if (absolute_i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (i >> 10);
            }
            else if (absolute_i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = i;
            }
            else
            {
                return i.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = (readable / 1024);
            // Return formatted number with suffix
            return readable.ToString("0.### ") + suffix;
        }

        public enum MirAction
        {
            Standing,
            Walking,
            Running,
            Pushed,
            DashL,
            DashR,
            DashFail,
            Stance,
            Stance2,
            Attack1,
            Attack2,
            Attack3,
            Attack4,
            Attack5,
            AttackRange1,
            AttackRange2,
            AttackRange3,
            Special,
            Struck,
            Harvest,
            Spell,
            Die,
            Dead,
            Skeleton,
            Show,
            Hide,
            Stoned,
            Appear,
            Revive,
            SitDown,
            Mine,
            Sneek,
            DashAttack,
            Lunge,

            WalkingBow,
            RunningBow,
            Jump,

            MountStanding,
            MountWalking,
            MountRunning,
            MountStruck,
            MountAttack,

            FishingCast,
            FishingWait,
            FishingReel
        }
    }
}