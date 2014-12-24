using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ExcelMerger.Helpers
{
    internal class ExcelMergeHelper
    {
        private string _baseExcel = null;
        private string _mergedExcel = null;
        private string _destExcel = null;

        private List<string> mergedRows = new List<string>();
        private List<string> mergedColumns = new List<string>();

        private Dictionary<string, int> columnMap = new Dictionary<string, int>();

        public ExcelMergeHelper(string baseExcel, string mergedExcel, string destExcel)
        {
            _baseExcel = baseExcel;
            _mergedExcel = mergedExcel;
            _destExcel = destExcel;

            if (File.Exists(_baseExcel) == false || File.Exists(_mergedExcel) == false) {
                throw new ArgumentException("Failed to find the excel files.");
            }

            //! 先複蓋掉destExcel這份檔案。
            File.Copy(_baseExcel, _destExcel, true);
        }

        public void MergeToDest() { 
            
        }

        // 先取得Row/Column的資訊
        private void PrepareRowColumnInfo(ExcelPackage excel) 
        {
            var ws = excel.Workbook.Worksheets.First();
            var query = from cell in ws.Cells["a:a"]
                        where cell.Value is string &&
                        string.IsNullOrEmpty( (String)cell.Value) == false
                        select cell;
        }

        // 依Row, Column, 開始比對資料，並且上色。
        
        
    }
}
