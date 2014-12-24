using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelMerger.ViewModels
{
    internal class VMMain : VMBase
    {
        /// <summary>
        /// 基底的檔案。合併時會以這個檔案為主，將另一個檔案，合併到這個檔案來。
        /// </summary>
        public string BaseExcel { get; set; }

        /// <summary>
        /// 要合併的另一個檔案。這個檔案的內容，會合併到BaseExcel裡。
        /// </summary>
        public string MergedExcel { get; set; }

        public VMMain()
        {
            BaseExcel = "base";
            MergedExcel = "merged";
        }
    }
}
