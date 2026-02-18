namespace Lib
{
    public class inputparamShowwaves
    {
        public int index { get; set; }
        public string mode { get; set; }
        public string size { get; set; }
        public string colors { get; set; }
    }

    public class inputparamAddlogo
    {
        public double index { get; set; }
        public string opacity { get; set; }
        public string size { get; set; }
    }

    public class inputparamzoompan
    {
        public int index { get; set; }
        public string zoomValue { get; set; }
        public string size { get; set; }
        public string delayValue { get; set; }
    }
    public class InputParamZoomV2Request
    {
        public string AppCode { get; set; }
        public string ProductSlug { get; set; }
        public int Index { get; set; }
        public InputZoomFactor ZoomValueInput { get; set; }
        public string ZoomQualityInput { get; set; }
        public decimal DelayValue { get; set; }
        public VideoProperties Size { get; set; } // kích thước đẩy vào để tương thích với size = 1920x1080
        public VideoProperties SizeOutPut { get; set; }
        public ModeTypeSelect ModeType { get; set; }
        public MediaType MediaSelect { get; set; }
        public bool Hflip { get; set; }
        public bool Rotate { get; set; }
        public bool LayerRandomMoveX { get; set; }
        public int Fps { get; set; }
        public decimal? PTS { get; set; } //PTS (presentation timestamp) of the input frames

        public EffectTypeSelect EffectType { get; set; }
    }
    public class InputParamZoomV2
    {
        public object EffectBackGroundSelect { get; set; }
        public object EffectLayerSelect { get; set; }
        public object EffectOverlaySelect { get; set; }
        public int Index { get; set; }
        public InputZoomFactor ZoomValueInput { get; set; }
        public string ZoomQualityInput { get; set; }
        public decimal DelayValue { get; set; }
        public VideoProperties Size { get; set; } // kích thước đẩy vào để tương thích với size = 1920x1080
        public VideoProperties SizeOutPut { get; set; }
        public ModeTypeSelect ModeType { get; set; }
        public MediaType MediaSelect { get; set; }
        public bool Hflip { get; set; }
        public bool Rotate { get; set; }
        public bool LayerRandomMoveX{ get; set; }
        public int Fps { get; set; }
        public decimal? PTS { get; set; } //PTS (presentation timestamp) of the input frames
        public bool? VideoShort { get; set; }

    }
    public class InputZoomFactor
    {
        public bool EffectZoom { get; set; }
        //public decimal ZoomInit { get; set; }
        public decimal ZoomEnd { get; set; }
        public decimal Time { get; set; }
        public int Fps { get; set; }

    }
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
    public class CreateZoomResponse : BaseResponse {}
}
