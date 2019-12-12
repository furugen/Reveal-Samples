using Infragistics.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace DesktopDemo
{
    public class ShowRevealBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();


            if(this.AssociatedObject.ContextMenu == null)
            {
                this.AssociatedObject.ContextMenu = new ContextMenu();
            }

            MenuItem menuItem = new MenuItem();
            menuItem.Header = "Revealを開く";
            menuItem.Click += MenuItem_Click;
            this.AssociatedObject.ContextMenu.Items.Add(menuItem);
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            RegisterRevealMenu(menuItem);
        }

        private void RegisterRevealMenu(FrameworkElement sender)
        {
            MenuItem menuItem = sender as MenuItem;
            DataGrid dg = ((ContextMenu)menuItem.Parent).PlacementTarget as DataGrid;


            RevealDialogWindow revealWindow = new RevealDialogWindow();


            // グリッドの１件目のレコードから型情報を取得する。
            Type recordType;
            object recordFirst;
            foreach (var record in dg.ItemsSource)
            {
                recordType = record.GetType();
                recordFirst = record;
                break;
            }
            //this.dataGrid.ItemsSource
            DataGridDataProvider dataGridDataProvider = new DataGridDataProvider(
                (IEnumerable<object>)dg.ItemsSource,
                dg.Columns);


            // データグリッドのアイテムリソースを設定
            //dataGridDataProvider.Data = (IEnumerable<object>)this.dataGrid.ItemsSource;

            // Reveal 初期設定用コード
            RevealSettings revealSettings = new RevealSettings(null);
            revealWindow.revealView.Settings = revealSettings;

            // データソースの設定
            revealWindow.revealView.DataSourcesRequested += RevealView_DataSourcesRequested;

            // グリッドのデータを提供するプロバイダ
            revealWindow.revealView.DataProvider = dataGridDataProvider;
            revealWindow.ShowDialog();

            // (メモリリーク対策)イベントを開放するため、画面を閉じた際にイベントを開放。
            revealWindow.Closed += RevealWindow_Closed;
        }


        private void RevealWindow_Closed(object sender, System.EventArgs e)
        {
            //this.revealWindow.Closed -= RevealWindow_Closed;
            //this.revealWindow.revealView.DataSourcesRequested -= RevealView_DataSourcesRequested;
        }

        private void RevealView_DataSourcesRequested(object sender, DataSourcesRequestedEventArgs e)
        {
            // グリッドのデータソースを設定
            var dataGridDS = new RVInMemoryDataSourceItem("dataGrid");
            dataGridDS.Title = "データグリッド";
            dataGridDS.Description = "データグリッドのデータソース";

            e.Callback(new RevealDataSources(
                    null,
                    new List<object>() { dataGridDS },
                    false));
        }


        protected override void OnDetaching()
        {
            base.OnDetaching();
            
        }
    }
}
