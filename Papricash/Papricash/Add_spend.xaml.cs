using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
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
    public sealed partial class Add_spend : Page
    {

        private Spending spend;

        internal Spending Spend
        {
            get
            {
                return spend;
            }

            set
            {
                spend = value;
            }
        }

        public Add_spend()
        {
            this.InitializeComponent();
            spend = new Spending();
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
            spend.cat = 1;
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
            spend.cat = 2;
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
            spend.cat = 3;
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
            spend.cat = 4;
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
            spend.cat = 5;
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
            spend.cat = 6;
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
            spend.cat = 7;
        }

        private void amount_changed(object sender, TextChangedEventArgs e)
        {
            add_button.Visibility = Visibility.Visible;
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            int a, c;
            string com;
            if (amount_textBox.Text == "")
            {
                amount_textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                you_must.Visibility = Visibility.Visible;
            } else if (spend.cat == 0)
            {
                you_must_cat.Visibility = Visibility.Visible;
            } else if (comment_textBox.Text == "Optional comment")
            {
                a = Convert.ToInt32(amount_textBox.Text);
                c = spend.cat;
                spend = new Spending(c, a);
            }
            else
            {
                a = Convert.ToInt32(amount_textBox.Text);
                c = spend.cat;
                com = comment_textBox.Text;
                spend = new Spending(c, a, com);
            }
        }

        private void comment_textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (comment_textBox.Text == "Optional comment") comment_textBox.Text = "";
        }

        private void comment_textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (comment_textBox.Text == "") comment_textBox.Text = "Optional comment";
        }
    }
}
