using System.Collections.Generic;

namespace MirTools.FileStructures
{
    public class FrameSet
    {
        public Dictionary<Common.MirAction, Frame> Frames = new Dictionary<Common.MirAction, Frame>();

        public void SaveFrameSet(string FileName)
        {
            // TODO: Add save code
        }

        public List<Frame> LoadFrames(string FileName)
        {
            List<Frame> Output = new List<Frame>();

            // TODO: Add load code

            return Output;
        }
    }

    public class Frame
    {
        public int Start, Count, Skip, EffectStart, EffectCount, EffectSkip;
        public int Interval, EffectInterval;
        public bool Reverse, Blend, UseFrame;
        
        public Frame(int start, int count, int skip, int interval, int effectstart = 0, int effectcount = 0, int effectskip = 0, int effectinterval = 0, bool reverse = false, bool bled = false, bool useframe = false)
        {
            Start = start;
            Count = count;
            Skip = skip;
            Interval = interval;
            EffectStart = effectstart;
            EffectCount = effectcount;
            EffectSkip = effectskip;
            EffectInterval = effectinterval;
            Reverse = reverse;
            Blend = bled;
            UseFrame = useframe;
        }
    }
}