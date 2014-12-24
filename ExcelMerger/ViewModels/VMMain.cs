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
        public string BaseExcel {
            get { return GetValue<string>(); }
            set { SetValue(value); } 
        }

        /// <summary>
        /// 要合併的另一個檔案。這個檔案的內容，會合併到BaseExcel裡。
        /// </summary>
        public string MergedExcel {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// 合併的結果，寫到這個指定的檔案來。
        /// </summary>
        public string DestExcel
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public VMMain()
        {
            BaseExcel = null;
            MergedExcel = null;
            DestExcel = null;
        }
    }
}
