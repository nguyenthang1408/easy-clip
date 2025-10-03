using System;
using Lib;

namespace ReviewMovie
{
    public class RenderInfoDto
    {
        public string AppCode { get; set; }
        public int Index { get; set; }
        public decimal TimeOfPart { get; set; }
        public decimal AtempoValue { get; set; }
        public decimal PTSvalue { get; set; } //PTS (presentation timestamp) of the input frames
        public string AudioFile { get; set; }
        public string MediaFile { get; set; }
        public string SaveFile { get; set; }
        public bool Muted { get; set; }
        public bool CkZoom { get; set; }
        public decimal ZoomRatio { get; set; }
        public string ZoomQuality { get; set; }
        public int Fps { get; set; }
        public string VolumnOrigin { get; set; }
        public bool CkRotate { get; set; }
        public bool CkHflip { get; set; }
        public bool CkLayerRandomMoveX { get; set; }
        public string VdSizeOutput { get; set; }
        public VideoProperties VdSizeInput { get; set; }
        public EffectTypeSelect EffectType { get; set; }
        public ModeTypeSelect ModeType { get; set; }
    }
}
