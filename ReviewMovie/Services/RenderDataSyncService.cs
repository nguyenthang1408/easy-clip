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

            // Sao chép danh sách để tránh lỗi khi duyệt và sửa
            var currentCopy = allCurrent.ToList();
            var updatedIds = updatedList.Select(x => x.NoID).ToHashSet();

            currentCopy.RemoveAll(x => !updatedIds.Contains(x.NoID));

            var itemsToAdd = new List<InfoRenderVd>();

            foreach (var updated in updatedList)
            {
                var existing = currentCopy.FirstOrDefault(x => x.NoID == updated.NoID);
                if (existing != null)
                    UpdateProperties(existing, updated);
                else
                    itemsToAdd.Add(updated.Clone());
            }

            currentCopy.AddRange(itemsToAdd);

            project.InfoRenders = currentCopy.OrderBy(x => x.NoID).ToList();

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
