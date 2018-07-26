using System;
using System.Drawing;

namespace MirTools.Functions
{
    public static class ColourFromString
    {
        public static Color Colour(string String)
        {
            try
            {
                var p = String.Split(new char[] { ',', ']' });

                int A = Convert.ToInt32(p[0].Substring(p[0].IndexOf('=') + 1));
                int R = Convert.ToInt32(p[1].Substring(p[1].IndexOf('=') + 1));
                int G = Convert.ToInt32(p[2].Substring(p[2].IndexOf('=') + 1));
                int B = Convert.ToInt32(p[3].Substring(p[3].IndexOf('=') + 1));

                return Color.FromArgb(A, R, G, B);
            }
            catch
            {
                return Color.White;
            }
        }
    }
}