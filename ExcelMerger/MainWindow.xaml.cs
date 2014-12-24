using ExcelMerger.ViewModels;
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
            // 
        }

        private void OnBtnExit_Clicked(object sender, RoutedEventArgs e)
        {
            //TODO, 離開之前，把資料存一存…。

            Application.Current.Shutdown();
        }
    }
}
