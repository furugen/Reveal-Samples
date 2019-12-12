using Infragistics.Sdk;
using System.Collections.Generic;
using System.Windows;

namespace DesktopDemo
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Reveal 初期設定用コード
            RevealSettings revealSettings = new RevealSettings(null);
            revealView.Settings = revealSettings;
            // データソースを設定
            revealView.DataSourcesRequested += RevealView_DataSourcesRequested;
            // データプロバイダを設定
            revealView.DataProvider = new EmbedDataProvider();

        }


        /// <summary>
        /// データソース選択時に動作するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RevealView_DataSourcesRequested(object sender, DataSourcesRequestedEventArgs e)
        {
            // データソースは複数設定することも可能です。
            // 下記は2つのデータソースを設定しています。

            // 社員情報
            var employeesDS = new RVInMemoryDataSourceItem("employees");
            employeesDS.Title = "社員情報";
            employeesDS.Description = "社員用データソース";

            // 製品情報
            var salesDS = new RVInMemoryDataSourceItem("products");
            salesDS.Title = "製品情報";
            salesDS.Description = "製品用データソース";

            e.Callback(new RevealDataSources(
                    null,
                    new List<object>() { employeesDS, salesDS },
                    false));
        }
    }
}
