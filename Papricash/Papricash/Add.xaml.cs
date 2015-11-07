using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Papricash
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Add : Page
    {
        public Add()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (s, e) =>
            {
                this.Frame.Navigate(typeof(MainPage));
            };
        }

        private void cat1_click(object sender, RoutedEventArgs e)
        {
            cat1.BorderBrush = new SolidColorBrush(Colors.Black);
            cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }
        private void cat2_click(object sender, RoutedEventArgs e)
        {
            cat2.BorderBrush = new SolidColorBrush(Colors.Black);
            cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }
        private void cat3_click(object sender, RoutedEventArgs e)
        {
            cat3.BorderBrush = new SolidColorBrush(Colors.Black);
            cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }
        private void cat4_click(object sender, RoutedEventArgs e)
        {
            cat4.BorderBrush = new SolidColorBrush(Colors.Black);
            cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }
        private void cat5_click(object sender, RoutedEventArgs e)
        {
            cat5.BorderBrush = new SolidColorBrush(Colors.Black);
            cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }
        private void cat6_click(object sender, RoutedEventArgs e)
        {
            cat6.BorderBrush = new SolidColorBrush(Colors.Black);
            cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }
        private void cat7_click(object sender, RoutedEventArgs e)
        {
            cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cat7.BorderBrush = new SolidColorBrush(Colors.Black);
        }
    }
}
