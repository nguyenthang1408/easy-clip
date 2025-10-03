using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MediaInfoLib;

namespace ReviewMovie
{
    public class RVFuncion
    {
        public static decimal GetMediaTime(string mediapath)
        {
            using (var mediaInfo = new MediaInfo())
            {
                // Mở file video để đọc thông tin
                mediaInfo.Open(mediapath);

                // Lấy thời lượng video
                var durationMilliseconds = mediaInfo.Get(StreamKind.Video, 0, "Duration", InfoKind.Text);
                return string.IsNullOrEmpty(durationMilliseconds) ? 0 : Convert.ToDecimal(durationMilliseconds);
            }
        }
        public static IEnumerable<List<T>> Partition<T>(List<T> source, int batchSize)
        {
            for (int i = 0; i < source.Count; i += batchSize)
            {
                yield return source.GetRange(i, Math.Min(batchSize, source.Count - i));
            }
        }
        public static List<int> GenerateList(int n)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
    public class FuncDataGridView
    {
        public static void UpdateDataGridViewCell(DataGridView dtGridView,int rowIndex, string columnName, object newData , Color? backcolor)
        {
            if (dtGridView.InvokeRequired)
            {
                // Nếu không ở trong UI thread, gọi lại phương thức trong UI thread
                dtGridView.Invoke(new MethodInvoker(() => UpdateDataGridViewCell(dtGridView,rowIndex, columnName, newData, backcolor)));
            }
            else
            {
                // Kiểm tra chỉ số dòng và tên cột có hợp lệ không
                if (rowIndex < 0 || rowIndex >= dtGridView.Rows.Count)
                    return;

                if (!dtGridView.Columns.Contains(columnName))
                    return;

                // Cập nhật nội dung của ô cụ thể
                DataGridViewCell cell = dtGridView.Rows[rowIndex].Cells[columnName];

                if (cell != null)
                {
                    cell.Value = newData;

                    if (backcolor.HasValue)
                        cell.Style.BackColor = backcolor.Value;
                }
            }
        }

        public static void UpdateColorDataGridView(DataGridView dtGridView, int rowIndex, string columnName, string newData, Color backcolor)
        {
            if (dtGridView.InvokeRequired)
            {
                // Nếu không ở trong UI thread, gọi lại phương thức trong UI thread
                dtGridView.Invoke(new MethodInvoker(() => UpdateColorDataGridView(dtGridView, rowIndex, columnName, newData, backcolor)));
            }
            else
            {
                // Cập nhật nội dung và màu nền của ô cụ thể
                DataGridViewRow row = dtGridView.Rows[rowIndex];
                DataGridViewCell cell = row.Cells[columnName];
                cell.Value = newData;
                cell.Style.BackColor = backcolor;
            }
        }
    }
}
