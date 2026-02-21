using Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ReviewMovie.Infrastructure.Config
{
    public class ConfigModel
    {
        public int ID { get; set; }
        public string T2PSoftKey { get; set; }
        public string FptAIKey { get; set; }
        public string GoogleTTSKey { get; set; }
        public string ElevenlabKey { get; set; }
        public string VbeeAppId { get; set; }
        public string VbeeAppToken { get; set; }
        //public List<InfoProject> InfoProjects { get; set; }

        public List<ProjectName> ProjectNames { get; set; }
        public string Language { get; set; } = "vi";
        public bool IsEmpty { get; set; } = true;
    }
    public class ProjectName
    {
        public Guid ID { get; set; }
        public string ProjectPath { get; set; }
        public DateTime date { get; set; }
    }

 //   public class InfoProject
 //   {
 //       public int ID { get; set; }
 //       public string ProjectPath { get; set; }
 //       public string VoiceSelect { get; set; }
 //       public DateTime date { get; set; }
 //       public string SpeechRatio { get; set; }
 //       public bool ChkZoomvideo { get; set; }
 //       public EffectSetting EffectSettup { get; set; }
 //       public InforSubtitleFile InforSubtitleFile { get; set; }
 //       public List<InfoRenderVd> InfoRenders { get; set; }
 //   }

 //   public class EffectSetting
 //   {
 //       public bool Active { get; set; }
 //       public string SzoomRatio { get; set; }
 //       public string SzoomQuality { get; set; }
 //       public decimal VolumnOrigin { get; set; }
 //       public int Sfps {  get; set; }
 //       public int Sthread { get; set; }
 //       public string SvideoQuality { get; set; }
 //       public string Smode { get; set; }
 //       public string SeffectType { get; set; }
 //       public bool SckZoom { get; set; }
 //       public bool SckRotate { get; set; }
 //       public bool SckHflip { get; set; }
 //       public bool SckHflipRandom { get; set; }
 //       public string SspeechRatio { get; set; }
 //       public bool SckNotUseAudio { get; set; }
 //       public string SspeechType { get; set; }
 //   }

 //   public class InforSubtitleFile
 //   {
 //       public string SubtitleFile { get; set; }
 //       public string FolderSubtileMediaFile { get; set; }
 //   }

 //   public class InfoRenderVd
	//{
 //       public int NoID { get; set; }
 //       public string MediaPath { get; set; }
 //       public decimal? Audiotime { get; set; }
 //       public decimal? CurrentTimeOfMediaPart { get; set; }
 //       public decimal? TimeOfMediaPart { get; set; }
 //       public int Width { get; set; }
 //       public int Height { get; set; }
 //       public string TextInput { get; set; }
 //       public string Textlength { get; set; }
 //       public string AudioLink { get; set; }
 //       public string AudioStatus { get; set; }
 //       public string MediaFilePath { get; set; }
 //       public string LblVdtime { get; set; }
 //       public string RenderStatus { get; set; }
 //       public bool MediaMiss { get; set; }
	//}

 //   public class InfoMainView
 //   {
 //       public int check { get; set; }
 //       public int id { get; set; }
 //       public string idxnumber { get; set; }
 //       public string textlength { get; set; }
 //       public string audiolink { get; set; }
 //       public string audiotime { get; set; }
 //       public string audiostatus { get; set; }
 //       public string filemediapath { get; set; }
 //       public string timevideo { get; set; }
 //       public string renderstatus { get; set; }
 //       public string inputtext { get; set; }
 //   }
 }
