using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using LiteDB;
using ReviewMovie.Infrastructure.Config;

namespace ReviewMovie.Infrastructure.Project
{
    //public class ProjectCtrl
    //{

    //    public static string dbconnection = "Filename={0}\\{1}.db;Password='Toan@123';connection=shared;upgrade=true";
    //    public static string dblog = "{0}\\{1}-log.db";
    //    private static string TableName = "Project";
    //    private static readonly object LockDb = new object();

    //    public static bool InsertInfoProjectList(InfoProject item)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(string.Format(dbconnection, item.ProjectPath, item.ID)))
    //                {
    //                    ILiteCollection<InfoProject> collection = liteDatabase.GetCollection<InfoProject>(TableName);
    //                    collection.EnsureIndex(x => x.ID);

    //                    // Kiểm tra xem bản ghi với ID là 1 có tồn tại không
    //                    var existingItem = collection.FindById(item.ID);
    //                    if (existingItem != null)
    //                    {
    //                        // Nếu tồn tại, cập nhật dữ liệu
    //                        // item.ID = existingItem.ID; // ngu lồn
    //                        collection.Update(item);
    //                    }
    //                    else
    //                    {
    //                        //item.ID = id;
    //                        // Nếu không tồn tại, thêm mới dữ liệu
    //                        collection.Insert(item);
    //                    }
    //                    return true;
    //                }
    //            }
    //        }
    //        catch
    //        {
    //            // Ghi thông báo lỗi vào tệp log mà không xóa nó // 
    //            //File.AppendAllText(string.Format(dblog, item.ProjectPath, item.ID), $"Error inserting InfoProjectList: {ex.Message}");
    //        }
    //        return false;
    //    }

    //    //public static void InsertBulk(List<DeviceInfo> lstwafer)
    //    //{
    //    //    try
    //    //    {
    //    //        lock (LockDb)
    //    //        {
    //    //            using (LiteDatabase liteDatabase = new LiteDatabase(dbconnection))
    //    //            {
    //    //                ILiteCollection<DeviceInfo> collection = liteDatabase.GetCollection<DeviceInfo>(TableName, BsonAutoId.ObjectId);
    //    //                collection.EnsureIndex((DeviceInfo x) => x.ID);
    //    //                collection.DeleteAll();
    //    //                collection.InsertBulk(lstwafer);
    //    //            }
    //    //        }
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        if (File.Exists(dblog))
    //    //            File.Delete(dblog);
    //    //        Console.WriteLine("ERR INS:" + ex.Message);
    //    //    }
    //    //}

    //    public static InfoProject GetProjectDetail(Guid id, string projectPath)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(string.Format(dbconnection, projectPath, id)))
    //                {
    //                    ILiteCollection<InfoProject> collection = liteDatabase.GetCollection<InfoProject>(TableName, BsonAutoId.ObjectId);
    //                    collection.EnsureIndex((InfoProject x) => x.ID);
    //                    InfoProject project = collection.FindOne((InfoProject x) => x.ID == id) ?? new InfoProject();
    //                    if (project.ID != Guid.Empty)
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
    //        return new InfoProject();
    //    }
    //}
}
