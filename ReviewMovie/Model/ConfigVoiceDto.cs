using Lib;
using System;

namespace ReviewMovie.Model
{
    public class ConfigVoiceDto
    {
        public string FptAIkey { get; set; }
        public string VbeeId { get; set; }
        public string VbeeToken { get; set; }
        public string EvelenlabKey { get; set; }
        public string GoogleTTSkey { get; set; }
        public ManualSelect ManualSelected { get; set; }
    } 
}
