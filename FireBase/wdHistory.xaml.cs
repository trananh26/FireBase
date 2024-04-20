using Aspose.Cells;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FireBase
{
    /// <summary>
    /// Interaction logic for wdHistory.xaml
    /// </summary>
    public partial class wdHistory : Window
    {
        BLDatabase oBL= new BLDatabase();
        DataTable dt = new DataTable();
        public wdHistory()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string TemplateFileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "/Report/ReportTemplate.xlsx";
            TemplateFileName = TemplateFileName.Substring(6, TemplateFileName.Length - 6);
            ArrayList strSheetName = new ArrayList();
            string filePath = filePath = "D:\\Report\\Export\\Weekly Report_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }
            if (File.Exists(TemplateFileName))
            {
                try
                {
                    if (dt.Rows.Count <= 0)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    DataSet ds = new DataSet();
                    ds = dt.DataSet;
                    strSheetName.Add("Lịch sử gửi xe");

                    Workbook wbMapping = new Workbook(TemplateFileName);
                    Worksheet wbSheetHistory = wbMapping.Worksheets[0];
                    int x = wbSheetHistory.Cells.ImportDataTable(dt, true, 1, 0);
                    wbMapping.Save(filePath);
                    File.Open(filePath, FileMode.Open);
                    MessageBox.Show("Xuất khẩu báo cáo thành công. Vui lòng tuy cập vào " + filePath + " để xem báo cáo!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Có lỗi khi lưu file!");
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void grdHistory_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetHistory();
        }

        private void GetHistory()
        {
            List<SensorData> lst= new List<SensorData> ();
            lst = oBL.GetHistory();
            grdHistory.ItemsSource = ToDataTable(lst).DefaultView;
        }

        private DataTable ToDataTable<SensorData>(List<SensorData> lst)
        {
            DataTable dataTable = new DataTable(typeof(SensorData).Name);

            // Lấy ra danh sách các thuộc tính của kiểu dữ liệu T
            var props = typeof(SensorData).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Thêm các cột vào DataTable dựa trên các thuộc tính của đối tượng
            foreach (var prop in props)
            {
                dataTable.Columns.Add(prop.Name, prop.PropertyType);
            }

            // Thêm các hàng vào DataTable dựa trên giá trị của từng đối tượng
            foreach (var item in lst)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    // Lấy giá trị của từng thuộc tính của đối tượng
                    values[i] = props[i].GetValue(item);
                }
                // Thêm hàng mới vào DataTable
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

    }
}
