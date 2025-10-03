using LiteDB;
using ReviewMovie.Infrastructure.Project;
using System;
using System.IO;
using static EasyClip.Infrastructure.Project.ProjectDataService;

namespace EasyClip.Infrastructure.Project
{
    public interface IProjectDataService
    {
        bool InsertInfoProjectList(InfoProject item);
        InfoProject GetProjectDetail(Guid id, string projectPath);
    }

    public class ProjectDataService : IProjectDataService
    {
        // Giữ config ở đây
        private readonly string dbconnection = "Filename={0}\\{1}.db;Password='Toan@123';connection=shared;upgrade=true";
        private readonly string dblog = "{0}\\{1}-log.db";
        private readonly string TableName = "Project";
        private readonly object LockDb = new object();

        public bool InsertInfoProjectList(InfoProject item)
        {
            try
            {
                lock (LockDb)
                {
                    using (LiteDatabase liteDatabase = new LiteDatabase(string.Format(dbconnection, item.ProjectPath, item.ID)))
                    {
                        var collection = liteDatabase.GetCollection<InfoProject>(TableName);
                        collection.EnsureIndex(x => x.ID);

                        var existingItem = collection.FindById(item.ID);
                        if (existingItem != null)
                            collection.Update(item);
                        else
                            collection.Insert(item);

                        return true;
                    }
                }
            }
            catch
            {
                // File.AppendAllText(string.Format(dblog, item.ProjectPath, item.ID), $"Error SaveProject: {ex.Message}\r\n");
                return false;
            }
        }

        public InfoProject GetProjectDetail(Guid id, string projectPath)
        {
            try
            {
                lock (LockDb)
                {
                    using (LiteDatabase liteDatabase = new LiteDatabase(string.Format(dbconnection, projectPath, id)))
                    {
                        var collection = liteDatabase.GetCollection<InfoProject>(TableName, BsonAutoId.ObjectId);
                        collection.EnsureIndex((InfoProject x) => x.ID);
                        var project = collection.FindOne((InfoProject x) => x.ID == id) ?? new InfoProject();
                        if (project.ID != Guid.Empty)
                            project.IsEmpty = false;
                        return project;
                    }
                }
            }
            catch
            {
                // File.AppendAllText(string.Format(dblog, projectPath, id), $"Error LoadProject: {ex.Message}\r\n");
                return new InfoProject();
            }
        }
    }
}
