using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.VoiceServices.ElevenLabs.V1.Model
{
    public class TextToSpeechResponse
    {
        public byte[] AudioContent { get; set; } // Tệp âm thanh dưới dạng mảng byte
        public string RequestId { get; set; }
        public string HistoryItemId { get; set; }
        public int CharacterCost { get; set; }
        public int TtsLatencyMs { get; set; }
        public string ContentType { get; set; }
    }
}
