using EasyClip.Infrastructure.Config;
using EasyClip.Infrastructure.Project;
using ReviewMovie.Infrastructure.Config;
using ReviewMovie.Infrastructure.Project;
using System;
using System.Collections.Generic;
using System.IO;

namespace EasyClip.Services
{
    public class LoadConfigDataServices
    {
        private readonly IConfigDataService _configDataService;
        private readonly IProjectDataService _projectDataService;

        public LoadConfigDataServices(
          IConfigDataService configDataService,
          IProjectDataService projectDataService)
        {
            _configDataService = configDataService;
            _projectDataService = projectDataService;
        }

        public void InitOrUpdateBaseConfig(string apiKey, string fptKey, string vbeeAppId, string vbeeToken)
        {
            var config = _configDataService.GetItem(1);

            if (config.IsEmpty)
            {
                var newConfig = new ConfigModel
                {
                    T2PSoftKey = apiKey,
                    FptAIKey = fptKey,          // txtAppID.Text
                    VbeeAppId = vbeeAppId,      // txtAppID.Text
                    VbeeAppToken = vbeeToken,   // txtToken.Text
                    ProjectNames = new List<ProjectName>()
                };
                _configDataService.Insert(newConfig);
            }
            else
            {
                if (!apiKey.Equals(config.T2PSoftKey))
                    config.T2PSoftKey = apiKey;

                _configDataService.Insert(config);
            }
        }

        public InfoProject CreateNewProject(string path, string voice, string ratio, bool zoom)
        {
            return new InfoProject
            {
                ID = Guid.NewGuid(),
                ProjectPath = path,
                VoiceSelect = voice,
                SpeechRatio = ratio,
                ChkZoomvideo = zoom,
                EffectSettup = new EffectSetting(),
                InforSubtitleFile = new InforSubtitleFile(),
                InfoRenders = new List<InfoRenderVd>()
            };
        }

        public void EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public bool IsDuplicate(string path) => _configDataService.IsProjectPathUnique(path);

        public bool AddProjectToConfig(InfoProject project)
        {
            try
            {
                var config = _configDataService.GetItem(1);
                if (config == null || config.ProjectNames == null)
                    return false;

                if (config.ProjectNames == null)
                    config.ProjectNames.Add(new ProjectName
                {
                    ID = project.ID,
                    ProjectPath = project.ProjectPath,
                    date = DateTime.Now
                });
                _configDataService.Insert(config);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SaveToDatabase(InfoProject project)
        {
            _projectDataService.InsertInfoProjectList(project);
        }
    }
}
