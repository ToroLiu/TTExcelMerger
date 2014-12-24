using ExcelMerger.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExcelMerger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VMMain _viewModel;

        public MainWindow()
        {
            // 取得ViewModel
            _viewModel = new VMMain();

            this.DataContext = _viewModel;
            InitializeComponent();
        }

        private void OnBtnOK_Clicked(object sender, RoutedEventArgs e)
        {
            //TODO, 執行檔案合併的動作。
        }

        private void OnBtnExit_Clicked(object sender, RoutedEventArgs e)
        {
            //TODO, 離開之前，把資料存一存…。

            Application.Current.Shutdown();
        }

        private const string _fileExt = "xlsx";
        private string ShowOpenFileDialog(string initialPath) {
            // 顯示OpenFileDialog，取得檔案路徑。
            string selFileName = null;

            bool isEmpty = string.IsNullOrEmpty(initialPath);
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = string.Format("Excel File (*.{0})|*.{0}", _fileExt);
            dlg.InitialDirectory = isEmpty ? 
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : 
                System.IO.Path.GetDirectoryName(initialPath);

            if (isEmpty == false)
                dlg.FileName = System.IO.Path.GetFileName(initialPath);

            if (dlg.ShowDialog() == true) {
                selFileName = dlg.FileName;
            }
            return selFileName;
        }
        private string ShowSaveFileDialog(string initialPath) {
            // 取得要存的檔案名稱
            string selFileName = null;

            bool isEmpty = string.IsNullOrEmpty(initialPath);

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = string.Format("Excel File (*.{0})|*.{0}", _fileExt);
            dlg.InitialDirectory = isEmpty ?
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) :
                System.IO.Path.GetDirectoryName(initialPath);

            dlg.FileName = isEmpty ? 
                "output" : 
                System.IO.Path.GetFileNameWithoutExtension(initialPath) ;

            if (dlg.ShowDialog() == true) {
                selFileName = dlg.FileName;
            }

            return selFileName;
        }

        private void OnBtnBaseExcel_Clicked(object sender, RoutedEventArgs e)
        {
            string fileName = ShowOpenFileDialog(_viewModel.BaseExcel);
            if (string.IsNullOrEmpty(fileName))
                return;

            _viewModel.BaseExcel = fileName;
        }

        private void OnBtnMergedExcel_Clicked(object sender, RoutedEventArgs e)
        {
            string fileName = ShowOpenFileDialog(_viewModel.MergedExcel);
            if (string.IsNullOrEmpty(fileName))
                return;

            _viewModel.MergedExcel = fileName;
        }

        private void OnBtnDestExcel_Clicked(object sender, RoutedEventArgs e)
        {
            string fileName = ShowSaveFileDialog(_viewModel.DestExcel);
            if (string.IsNullOrEmpty(fileName))
                return;

            _viewModel.DestExcel = fileName;
        }
    }
}
