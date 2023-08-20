using System;

namespace Models
{
    [Serializable]
    public class TrackSettingsVo
    {
        public int LevelLength;
        public float XMultiplier;
        public float YMultiplier;
        public float CurveSmoothness;
        public float NoiseStep;
        public float Bottom;
    }
}