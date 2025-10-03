using Common.Constant;
using EasyClip.Services;
using Lib;
using LiteDB;
using ReviewMovie.Infrastructure.Config;
using ReviewMovie.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyClip.Infrastructure.Config
{
    public interface IConfigDataService
    {
        bool Insert(ConfigModel item);
        bool UpdateConfig(ConfigVoiceDto input);
        bool UpdateProjectNameDate(Guid projectId);
        bool IsProjectPathUnique(string projectPath);
        bool DeleteProjectName(Guid projectId);
        ConfigModel GetItem(int ID);
    }

    public class ConfigDataService : IConfigDataService
    {
        private readonly string DbFolder;
        private readonly string DbPath;
        private readonly string LogPath;

        private readonly string dbconnection;
        private readonly string dblog;
        private readonly string TableName = "Config";
        private readonly object LockDb = new object();

        public ConfigDataService()
        {
            DbFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), LibConst.AppName);
            DbPath = Path.Combine(DbFolder, LibConst.DBName);
            LogPath = Path.Combine(DbFolder, "config-log.db");
            dbconnection = $"Filename={DbPath};Password='Toan@123';connection=shared;upgrade=true";
            dblog = LogPath;

            try
            {
                if (!Directory.Exists(DbFolder))
                    Directory.CreateDirectory(DbFolder);
            }
            catch
            {
                if (File.Exists(dblog))
                    File.Delete(dblog);
            }
        }

        public bool Insert(ConfigModel item)
        {
            try
            {
                lock (LockDb)
                {
                    using (var liteDatabase = new LiteDatabase(dbconnection))
                    {
                        var collection = liteDatabase.GetCollection<ConfigModel>(TableName);
                        collection.EnsureIndex(x => x.ID);

                        var existingItem = collection.FindById(1);
                        item.ID = 1;
                        if (existingItem != null)
                            collection.Update(item);
                        else
                            collection.Insert(item);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(dblog, $"Error inserting data: {ex.Message}\n");
            }
            return false;
        }

        public bool UpdateConfig(ConfigVoiceDto input)
        {
            try
            {
                lock (LockDb)
                {
                    using (var liteDatabase = new LiteDatabase(dbconnection))
                    {
                        var collection = liteDatabase.GetCollection<ConfigModel>(TableName);
                        var config = collection.FindById(1); // Giả sử cấu hình chỉ có một bản ghi với ID là 1

                        if (config != null)
                        {
                            // Update tùy theo ManualSelected
                            if (input.ManualSelected == ManualSelect.FptAI)
                                config.FptAIKey = input.FptAIkey;
                            if (input.ManualSelected == ManualSelect.Google)
                                config.GoogleTTSKey = input.GoogleTTSkey;
                            if (input.ManualSelected == ManualSelect.Elevenlab)
                                config.ElevenlabKey = input.EvelenlabKey;
                            else if (input.ManualSelected == ManualSelect.Vbee)
                            {
                                config.VbeeAppId = input.VbeeId;
                                config.VbeeAppToken = input.VbeeToken;
                            }
                            collection.Update(config);
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(dblog, $"Error updating configuration: {ex.Message}\n");
            }
            return false;
        }

        public bool UpdateProjectNameDate(Guid projectId)
        {
            try
            {
                lock (LockDb)
                {
                    using (var liteDatabase = new LiteDatabase(dbconnection))
                    {
                        var collection = liteDatabase.GetCollection<ConfigModel>(TableName);
                        collection.EnsureIndex(x => x.ID);

                        // Tìm bản ghi với ID là 1
                        var configItem = collection.FindById(1);
                        if (configItem != null)
                        {
                            // Tìm và cập nhật thuộc tính date của ProjectName có ID trùng khớp
                            var projectToUpdate = configItem.ProjectNames?.FirstOrDefault(p => p.ID == projectId);
                            if (projectToUpdate != null)
                            {
                                projectToUpdate.date = DateTime.Now;
                                collection.Update(configItem);
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(dblog, $"Error updating project name date: {ex.Message}\n");
            }
            return false;
        }

        public bool IsProjectPathUnique(string projectPath)
        {
            try
            {
                lock (LockDb)
                {
                    using (var liteDatabase = new LiteDatabase(dbconnection))
                    {
                        var collection = liteDatabase.GetCollection<ConfigModel>(TableName);
                        collection.EnsureIndex(x => x.ID);

                        // Tìm bản ghi với ID là 1
                        var configItem = collection.FindById(1);
                        if (configItem != null)
                        {
                            // Kiểm tra xem ProjectPath đã tồn tại hay chưa
                            var projectPathCount = configItem.ProjectNames?.Count(p => p.ProjectPath.Equals(projectPath, StringComparison.OrdinalIgnoreCase)) ?? 0;
                            return projectPathCount == 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(dblog, $"Error checking project path uniqueness: {ex.Message}\n");
            }
            return false;
        }

        public bool DeleteProjectName(Guid projectId)
        {
            try
            {
                lock (LockDb)
                {
                    using (var liteDatabase = new LiteDatabase(dbconnection))
                    {
                        var collection = liteDatabase.GetCollection<ConfigModel>(TableName);
                        collection.EnsureIndex(x => x.ID);

                        // Tìm bản ghi với ID là 1
                        var configItem = collection.FindById(1);
                        if (configItem != null)
                        {
                            // Tìm và xóa phần tử trong danh sách ProjectNames
                            var projectToRemove = configItem.ProjectNames?.FirstOrDefault(p => p.ID == projectId);
                            if (projectToRemove != null)
                            {
                                configItem.ProjectNames.Remove(projectToRemove);
                                collection.Update(configItem);
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(dblog, $"Error deleting project name: {ex.Message}\n");
            }
            return false;
        }

        public ConfigModel GetItem(int ID)
        {
            try
            {
                lock (LockDb)
                {
                    using (var liteDatabase = new LiteDatabase(dbconnection))
                    {
                        var collection = liteDatabase.GetCollection<ConfigModel>(TableName, BsonAutoId.ObjectId);
                        collection.EnsureIndex((ConfigModel x) => x.ID);
                        var project = collection.FindOne((ConfigModel x) => x.ID == ID) ?? new ConfigModel();
                        if (project.ID > 0)
                            project.IsEmpty = false;
                        return project;
                    }
                }
            }
            catch
            {
                if (File.Exists(dblog))
                    File.Delete(dblog);
            }
            return new ConfigModel();
        }
    }
}
