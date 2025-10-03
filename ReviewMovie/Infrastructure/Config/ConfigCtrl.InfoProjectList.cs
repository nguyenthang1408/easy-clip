using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReviewMovie.Infrastructure.Config
{
    //public partial class ConfigCtrl
    //{
    //    public static bool InsertInfoProjectList(int configID, InfoProject newInfoProjectList)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(dbconnection))
    //                {
    //                    ILiteCollection<ConfigModel> collection = liteDatabase.GetCollection<ConfigModel>(TableName);
    //                    ConfigModel config = collection.FindById(configID);

    //                    if (config != null)
    //                    {
    //                        //// Kiểm tra xem danh sách InfoProjectList đã được khởi tạo chưa
    //                        //if (config.InfoProjects == null)
    //                        //{
    //                        //    config.InfoProjects = new List<InfoProject>();
    //                        //}

    //                        // Tìm ID lớn nhất trong danh sách InfoProjectList
    //                        int maxID = 1;
    //                        if (config.InfoProjects.Count >= 1)
    //                        {
    //                            maxID = config.InfoProjects.Max(ip => ip.ID) + 1;
    //                        }

    //                        // Tăng ID lên một đơn vị và gán cho phần tử mới
    //                        newInfoProjectList.ID = maxID;

    //                        // Thêm phần tử mới vào danh sách
    //                        config.InfoProjects.Add(newInfoProjectList);

    //                        // Cập nhật lại dữ liệu vào cơ sở dữ liệu
    //                        collection.Update(config);
    //                        return true;
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // Ghi thông báo lỗi vào tệp log mà không xóa nó
    //            File.AppendAllText(dblog, $"Error inserting InfoProjectList: {ex.Message}");
    //            Console.WriteLine("ERR INSERTING InfoProjectList:" + ex.Message);
    //        }
    //        return false;
    //    }

    //    public static bool UpdateInfoProjectList(int configID, InfoProject updatedInfoProjectList)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(dbconnection))
    //                {
    //                    ILiteCollection<ConfigModel> collection = liteDatabase.GetCollection<ConfigModel>(TableName);
    //                    ConfigModel config = collection.FindById(configID);

    //                    if (config != null)
    //                    {
    //                        // Tìm kiếm phần tử trong danh sách InfoProjectList dựa trên ID hoặc một thuộc tính khác
    //                        InfoProject existingInfoProject = config?.InfoProjects?.Find(ip => ip.ID == updatedInfoProjectList.ID);

    //                        if (existingInfoProject != null)
    //                        {
    //                            // Nếu tìm thấy, cập nhật thông tin của phần tử
    //                            existingInfoProject.ProjectPath = updatedInfoProjectList.ProjectPath;
    //                            existingInfoProject.VoiceSelect = updatedInfoProjectList.VoiceSelect;
    //                            existingInfoProject.date = DateTime.Now;
    //                            existingInfoProject.SpeechRatio = updatedInfoProjectList.SpeechRatio;
    //                            existingInfoProject.ChkZoomvideo = updatedInfoProjectList.ChkZoomvideo;
    //                            existingInfoProject.EffectSettup = updatedInfoProjectList.EffectSettup;
    //                            existingInfoProject.InforSubtitleFile = updatedInfoProjectList.InforSubtitleFile;
    //                            existingInfoProject.InfoRenders = updatedInfoProjectList.InfoRenders;

    //                            collection.Update(config);
    //                        }
    //                        //else   // Không có dữ liệu thì bỏ qua -> sau thêm tính năng gì
    //                        //{
    //                        //    // Nếu không tìm thấy, thêm phần tử mới vào danh sách
    //                        //    config.InfoProjects.Add(updatedInfoProjectList);
    //                        //}

    //                        // Cập nhật lại dữ liệu vào cơ sở dữ liệu
    //                        //collection.Update(config);
    //                        return true;
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // Ghi thông báo lỗi vào tệp log mà không xóa nó
    //            File.AppendAllText(dblog, $"Error updating InfoProjectList: {ex.Message}");
    //            Console.WriteLine("ERR UPDATING InfoProjectList:" + ex.Message);
    //        }
    //        return false;
    //    }

    //    public static bool DeleteInfoProjectList(int configID, int infoProjectID)
    //    {
    //        try
    //        {
    //            lock (LockDb)
    //            {
    //                using (LiteDatabase liteDatabase = new LiteDatabase(dbconnection))
    //                {
    //                    ILiteCollection<ConfigModel> collection = liteDatabase.GetCollection<ConfigModel>(TableName);
    //                    ConfigModel config = collection.FindById(configID);

    //                    if (config != null)
    //                    {
    //                        // Tìm kiếm phần tử trong danh sách InfoProjectList dựa trên ID
    //                        InfoProject infoProjectToRemove = config.InfoProjects.Find(ip => ip.ID == infoProjectID);

    //                        if (infoProjectToRemove != null)
    //                        {
    //                            // Nếu tìm thấy, xóa phần tử khỏi danh sách
    //                            config.InfoProjects.Remove(infoProjectToRemove);
    //                        }

    //                        // Cập nhật lại dữ liệu vào cơ sở dữ liệu
    //                        collection.Update(config);
    //                        return true;
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // Ghi thông báo lỗi vào tệp log mà không xóa nó
    //            File.AppendAllText(dblog, $"Error deleting InfoProjectList: {ex.Message}");
    //            Console.WriteLine("ERR DELETING InfoProjectList:" + ex.Message);
    //        }
    //        return false;
    //    }
    //}
}
