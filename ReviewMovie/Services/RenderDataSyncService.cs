using EasyClip.Infrastructure.Project;
using ReviewMovie.Infrastructure.Project;
using System.Collections.Generic;
using System.Linq;

namespace EasyClip.Services
{
    public class RenderDataSyncService
    {
        private readonly IProjectDataService _projectDataService;

        public RenderDataSyncService(IProjectDataService projectDataService)
        {
            _projectDataService = projectDataService;
        }

        public void UpdateProjectRenderList(InfoProject project, List<InfoRenderVd> allCurrent, List<InfoRenderVd> updatedList)
        {
            if (project == null || allCurrent == null || updatedList == null)
                return;

            var updatedIds = updatedList.Select(x => x.NoID).ToHashSet();

            allCurrent.RemoveAll(x => !updatedIds.Contains(x.NoID));

            foreach (var updated in updatedList)
            {
                var existing = allCurrent.FirstOrDefault(x => x.NoID == updated.NoID);
                if (existing != null)
                    UpdateProperties(existing, updated);
                else
                    allCurrent.Add(updated.Clone());
            }

            project.InfoRenders = allCurrent.OrderBy(x => x.NoID).ToList();
            _projectDataService.InsertInfoProjectList(project);
        }

        private void UpdateProperties(InfoRenderVd target, InfoRenderVd source)
        {
            target.MediaPath = source.MediaPath;
            target.Audiotime = source.Audiotime;
            target.CurrentTimeOfMediaPart = source.CurrentTimeOfMediaPart;
            target.TimeOfMediaPart = source.TimeOfMediaPart;
            target.Width = source.Width;
            target.Height = source.Height;
            target.TextInput = source.TextInput;
            target.Textlength = source.Textlength;
            target.AudioLink = source.AudioLink;
            target.AudioStatus = source.AudioStatus;
            target.MediaFilePath = source.MediaFilePath;
            target.LblVdtime = source.LblVdtime;
            target.RenderStatus = source.RenderStatus;
            target.MediaMiss = source.MediaMiss;
        }
    }
}
