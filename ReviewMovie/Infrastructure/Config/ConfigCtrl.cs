using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using LiteDB;
using Lib;
using System.Linq;
using ReviewMovie.Infrastructure.Project;
using ReviewMovie.Model;
using System.Xml.Linq;
using Common.Constant;

namespace ReviewMovie.Infrastructure.Config
{
    //public partial class ConfigCtrl
    //{
    //    // Xác định thư mục database trong AppData
    //    private static readonly string DbFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), LibConst.AppName);
    //    private static readonly string DbPath = Path.Combine(DbFolder, LibConst.DBName);
    //    private static readonly string LogPath = Path.Combine(DbFolder, "config-log.db");

    //    // Kết nối database
    //    public static readonly string dbconnection = $"Filename={DbPath};Password='Toan@123';connection=shared;upgrade=true";
    //    public static readonly string dblog = LogPath;

    //    private static string TableName = "Config";
    //    private static readonly object LockDb = new object();

    //    static ConfigCtrl()
    //    {
    //        try
    //        {
    //            if (!Directory.Exists(DbFolder))
    //            {
    //                Directory.CreateDirectory(DbFolder);
    //            }
    //        }
    //        catch
    //        {
    //            if (File.Exists(dblog))
    //                File.Delete(dblog);
    //        }
    //    }

    //    public static bool Insert(ConfigModel item)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(dbconnection))
    //                {
    //                    ILiteCollection<ConfigModel> collection = liteDatabase.GetCollection<ConfigModel>(TableName);
    //                    collection.EnsureIndex(x => x.ID);

    //                    // Kiểm tra xem bản ghi với ID là 1 có tồn tại không
    //                    var existingItem = collection.FindById(1);
    //                    if (existingItem != null)
    //                    {
    //                        // Nếu tồn tại, cập nhật dữ liệu
    //                        item.ID = 1;
    //                        collection.Update(item);
    //                    }
    //                    else
    //                    {
    //                        // Nếu không tồn tại, thêm mới dữ liệu
    //                        item.ID = 1;
    //                        collection.Insert(item);
    //                    }
    //                    return true;
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // Ghi thông báo lỗi vào tệp log mà không xóa nó
    //            File.AppendAllText(dblog, $"Error inserting data: {ex.Message}");
    //        }
    //        return false;
    //    }

    //    public static bool UpdateConfig(ConfigVoiceDto input)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(dbconnection))
    //                {
    //                    ILiteCollection<ConfigModel> collection = liteDatabase.GetCollection<ConfigModel>(TableName);
    //                    ConfigModel config = collection.FindById(1); // Giả sử cấu hình chỉ có một bản ghi với ID là 1

    //                    if (config != null)
    //                    {
    //                        // Kiểm tra và cập nhật dựa trên giá trị của manualSelected được truyền vào
    //                        if (input.ManualSelected == ManualSelect.FptAI)
    //                        {
    //                            config.FptAIKey = input.FptAIkey;
    //                        }
    //                        if (input.ManualSelected == ManualSelect.Google)
    //                        {
    //                            config.GoogleTTSKey = input.GoogleTTSkey;
    //                        }
    //                        if (input.ManualSelected == ManualSelect.Elevenlab)
    //                        {
    //                            config.ElevenlabKey = input.EvelenlabKey;
    //                        }
    //                        else if (input.ManualSelected == ManualSelect.Vbee)
    //                        {
    //                            config.VbeeAppId = input.VbeeId;
    //                            config.VbeeAppToken = input.VbeeToken;
    //                        }

    //                        // Cập nhật lại cấu hình vào cơ sở dữ liệu
    //                        collection.Update(config);
    //                        return true;
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            File.AppendAllText(dblog, $"Error updating configuration: {ex.Message}");
    //        }
    //        return false;
    //    }

    //    public static bool UpdateProjectNameDate(Guid projectId)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(dbconnection))
    //                {
    //                    ILiteCollection<ConfigModel> collection = liteDatabase.GetCollection<ConfigModel>(TableName);
    //                    collection.EnsureIndex(x => x.ID);

    //                    // Tìm bản ghi với ID là 1
    //                    var configItem = collection.FindById(1);
    //                    if (configItem != null)
    //                    {
    //                        // Tìm và cập nhật thuộc tính date của ProjectName có ID trùng khớp
    //                        var projectToUpdate = configItem.ProjectNames.FirstOrDefault(p => p.ID == projectId);
    //                        if (projectToUpdate != null)
    //                        {
    //                            projectToUpdate.date = DateTime.Now;
    //                            collection.Update(configItem);
    //                            return true;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            File.AppendAllText(dblog, $"Error updating project name date: {ex.Message}");
    //        }
    //        return false;
    //    }

    //    public static bool IsProjectPathUnique(string projectPath)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(dbconnection))
    //                {
    //                    ILiteCollection<ConfigModel> collection = liteDatabase.GetCollection<ConfigModel>(TableName);
    //                    collection.EnsureIndex(x => x.ID);

    //                    // Tìm bản ghi với ID là 1
    //                    var configItem = collection.FindById(1);
    //                    if (configItem != null)
    //                    {
    //                        // Kiểm tra xem ProjectPath đã tồn tại hay chưa
    //                        var projectPathCount = configItem.ProjectNames.Count(p => p.ProjectPath.Equals(projectPath, StringComparison.OrdinalIgnoreCase));
    //                        return projectPathCount == 1;
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            File.AppendAllText(dblog, $"Error checking project path uniqueness: {ex.Message}");
    //        }
    //        return false;
    //    }


    //    public static bool DeleteProjectName(Guid projectId)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(dbconnection))
    //                {
    //                    ILiteCollection<ConfigModel> collection = liteDatabase.GetCollection<ConfigModel>(TableName);
    //                    collection.EnsureIndex(x => x.ID);

    //                    // Tìm bản ghi với ID là 1
    //                    var configItem = collection.FindById(1);
    //                    if (configItem != null)
    //                    {
    //                        // Tìm và xóa phần tử trong danh sách ProjectNames
    //                        var projectToRemove = configItem.ProjectNames.FirstOrDefault(p => p.ID == projectId);
    //                        if (projectToRemove != null)
    //                        {
    //                            configItem.ProjectNames.Remove(projectToRemove);
    //                            collection.Update(configItem);
    //                            return true;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            File.AppendAllText(dblog, $"Error deleting project name: {ex.Message}");
    //        }
    //        return false;
    //    }


    //    public static ConfigModel GetItem(int ID)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(dbconnection))
    //                {
    //                    ILiteCollection<ConfigModel> collection = liteDatabase.GetCollection<ConfigModel>(TableName, BsonAutoId.ObjectId);
    //                    collection.EnsureIndex((ConfigModel x) => x.ID);
    //                    ConfigModel project = collection.FindOne((ConfigModel x) => x.ID == ID) ?? new ConfigModel();
    //                    if (project.ID > 0) // Ngu loz
    //                    {
    //                        project.IsEmpty = false;
    //                    }
    //                    return project;
    //                }
    //            }
    //        }
    //        catch
    //        {
    //            if (File.Exists(dblog))
    //                File.Delete(dblog);
    //        }
    //        return new ConfigModel();
    //    }
    //}
}
