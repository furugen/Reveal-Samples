using Infragistics.Sdk;
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

        }
    }
}
