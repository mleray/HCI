using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Papricash
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string path;
        public static SQLite.Net.SQLiteConnection conn;

        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db_spend");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Spending>();
        }

        private void history_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(History));
        }

        private void add_button_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Add_spend));
        }

        private void settings_button_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }
    }
}
