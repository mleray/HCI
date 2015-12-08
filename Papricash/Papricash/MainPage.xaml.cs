using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
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
    /// Main page of Papricash, featuring all functionalities
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string path;
        public static SQLite.Net.SQLiteConnection conn;
        public static int budgetLeft;
        public static int budget;
        public static int threshold;
        public static int currency; // 1 for euros, 0 for forints
        public static Windows.Storage.ApplicationDataContainer localSettings;

        /// <summary>
        /// Initialization of the page, empty constructor
        /// </summary>

        public MainPage()
        {
            this.InitializeComponent();
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings; //creates local settings for the application
            var bl = localSettings.Values["budgetLeft"];
            var b = localSettings.Values["budget"];
            var c = localSettings.Values["currency"];
            var t = localSettings.Values["thresh"];
            if (b != null && bl != null && c != null && t != null) //checks if settings are initialized
            {
                please.Visibility = Visibility.Collapsed;
                you_are_text.Visibility = Visibility.Visible;
                add_button.IsEnabled = true;
                currency = (int)c;
                budget = (int)b;
                budgetLeft = (int)bl;
                threshold = (int)t;

                if (currency == 1) // it means it is in euros
                {
                    euro.Visibility = Visibility.Visible;
                    ft.Visibility = Visibility.Collapsed;
                }
                else // it means it is in forints
                {
                    ft.Visibility = Visibility.Visible;
                    euro.Visibility = Visibility.Collapsed;
                }
                thresh.Text += " " + budgetLeft;
                canvas_left.Visibility = Visibility.Visible;
                if (DateTime.Today.Day == 1) //means that we need to reinitialize the budget
                {
                    budgetLeft = budget;
                    localSettings.Values["budgetLeft"] = budget;
                    thresh.Text = " ";
                    thresh.Text += budgetLeft;
                }
                if (budgetLeft <= threshold) // you are in the red
                {
                    green_text.Visibility = Visibility.Collapsed;
                    red_text.Visibility = Visibility.Visible;
                }
                else // you are in the green
                {
                    red_text.Visibility = Visibility.Collapsed;
                    green_text.Visibility = Visibility.Visible;
                }
            } else // settings must be initialized
            {
                you_are_text.Visibility = Visibility.Collapsed;
                green_text.Visibility = Visibility.Collapsed;
                red_text.Visibility = Visibility.Collapsed;
                canvas_left.Visibility = Visibility.Collapsed;
                please.Visibility = Visibility.Visible;
                add_button.IsEnabled = false;
            }
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed; // no back button
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db_spend"); // create database
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Spending>(); // create table for spendings
        }
        /// <summary>
        /// Action when return"history" button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void history_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(History));
        }
        /// <summary>
        /// Action when "add spending" button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_button_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Add_spend)); 
        }
        /// <summary>
        /// Action when "settings" button is pressed, opens a content dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void settings_button_click(object sender, RoutedEventArgs e)
        {
            var dialog = new ContentDialog()
            {
                Title = "Settings",
                MaxWidth = this.ActualWidth // Required for Mobile
            };

            // Setup Content
            var panel = new StackPanel();

            panel.Children.Add(new TextBlock
            {
                Text = "Select the currency you want to use:",
                TextWrapping = TextWrapping.Wrap,
            });

            var cbEuro = new CheckBox
            {
                Content = "Euros"
            };
            
            var cbFt = new CheckBox
            {
                Content = "Forints"
            };

            var text = new TextBlock
            {
                Text = "Specify a monthly budget:"
            };

            var budget = new TextBox
            {
                Text = ""
            };
            var text2 = new TextBlock
            {
                Text = "Specify an alert threshold:"
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
            
            dialog.PrimaryButtonText = "OK";
            dialog.PrimaryButtonClick += delegate
            {
                MainPage.budgetLeft = Convert.ToInt32(budget.Text);
                MainPage.budget = Convert.ToInt32(budget.Text);
                MainPage.threshold = Convert.ToInt32(threshold.Text);
                localSettings.Values["budget"] = Convert.ToInt32(budget.Text);
                localSettings.Values["budgetLeft"] = Convert.ToInt32(budget.Text);
                localSettings.Values["thresh"] = Convert.ToInt32(threshold.Text);
                if (cbEuro.IsChecked == true) // selected currency is euro
                {
                    MainPage.currency = 1;
                    localSettings.Values["currency"] = 1;
                    euro.Visibility = Visibility.Visible;
                    ft.Visibility = Visibility.Collapsed;
                }
                else // selected currency is forint
                {
                    MainPage.currency = 0;
                    localSettings.Values["currency"] = 0;
                    ft.Visibility = Visibility.Visible;
                    euro.Visibility = Visibility.Collapsed;
                }
                // update main page
                canvas_left.Visibility = Visibility.Visible;
                you_are_text.Visibility = Visibility.Visible;
                green_text.Visibility = Visibility.Visible;
                add_button.IsEnabled = true;
                thresh.Text += " " + budgetLeft;
                please.Visibility = Visibility.Collapsed;
            };

            dialog.SecondaryButtonText = "Cancel";
            dialog.SecondaryButtonClick += delegate { };

            var result = await dialog.ShowAsync();
        }
        /// <summary>
        /// Action when "charts" button is pressed
        /// </summary>
        private void trends_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Trends));
        }
    }
}
