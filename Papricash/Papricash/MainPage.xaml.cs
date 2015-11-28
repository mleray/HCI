using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        public static int budget;
        public static int threshold;
        public static int currency;

        public MainPage()
        {
            this.InitializeComponent();
            if (budget != 0)
            {
                if (currency == 1)
                {
                    euro.Visibility = Visibility.Visible;
                    ft.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ft.Visibility = Visibility.Visible;
                    euro.Visibility = Visibility.Collapsed;
                }
                thresh.Text += " " + budget;
                you_still.Visibility = Visibility.Visible;
                if (budget <= threshold)
                {
                    green_text.Visibility = Visibility.Collapsed;
                    red_text.Visibility = Visibility.Visible;
                } else
                {
                    red_text.Visibility = Visibility.Collapsed;
                    green_text.Visibility = Visibility.Visible;
                }
                }
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

        private async void settings_button_click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var dialog = new ContentDialog()
            {
                Title = "Settings",
                MaxWidth = this.ActualWidth // Required for Mobile!
            };

            // Setup Content
            var panel = new StackPanel();

            panel.Children.Add(new TextBlock
            {
                Text = "Please choose your settings for Papricash:",
                TextWrapping = TextWrapping.Wrap,
            });

            var cbEuro = new CheckBox
            {
                Content = "Euros",
                IsChecked = true
            };

            var cbFt = new CheckBox
            {
                Content = "Forints"
            };

            var text = new TextBlock
            {
                Text = "Budget:"
            };

            var budget = new TextBox
            {
                Text = ""
            };
            var text2 = new TextBlock
            {
                Text = "Threshold:"
            };

            var threshold = new TextBox
            {
                Text = ""
            };

            panel.Children.Add(cbEuro);
            panel.Children.Add(cbFt);
            panel.Children.Add(text);
            panel.Children.Add(budget);
            panel.Children.Add(text2);
            panel.Children.Add(threshold);
            dialog.Content = panel;

            // Add Buttons
            dialog.PrimaryButtonText = "OK";
            dialog.PrimaryButtonClick += delegate
            {
                btn.Content = "Result: OK";
                MainPage.budget = Convert.ToInt32(budget.Text);
                MainPage.threshold = Convert.ToInt32(threshold.Text);
                if (cbEuro.IsChecked == true)
                {
                    MainPage.currency = 1;
                    euro.Visibility = Visibility.Visible;
                    ft.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MainPage.currency = 0;
                    ft.Visibility = Visibility.Visible;
                    euro.Visibility = Visibility.Collapsed;
                }
                you_still.Visibility = Visibility.Visible;
                thresh.Text += " " + budget.Text;
            };

            dialog.SecondaryButtonText = "Cancel";
            dialog.SecondaryButtonClick += delegate
            {
                btn.Content = "Result: Cancel";
            };

            // Show Dialog
            var result = await dialog.ShowAsync();
        }

        private void trends_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Trends));
        }
    }
}
