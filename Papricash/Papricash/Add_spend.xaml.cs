using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private string currentCat { get; set; }
        public static Spending spend;

        public Add_spend()
        {
            this.InitializeComponent();
            currentCat = "";
            if (MainPage.currency == 1)
            {
                euro.Visibility = Visibility.Visible;
                forint.Visibility = Visibility.Collapsed;
            } else
            {
                forint.Visibility = Visibility.Visible;
                euro.Visibility = Visibility.Collapsed;
            }
            if (spend != null)
            {
                clickCat(spend.Cat);
                amount_textBox.Text += spend.Amount;
                if (spend.Comment != "")
                {
                    comment_textBox.Text = spend.Comment;
                }
                dp.Date = spend.Date;
                add_button.Visibility = Visibility.Visible;
                spend = null;
            }
        }

        private void return_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void clickCat(string c)
        {
            if (c == "Party")
            {
                cat1.BorderBrush = new SolidColorBrush(Colors.Black);
                cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat1.BorderThickness = new Thickness(3, 3, 3, 3);
                currentCat = "Party";
            } else if (c == "Health")
            {
                cat2.BorderBrush = new SolidColorBrush(Colors.Black);
                cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat2.BorderThickness = new Thickness(3, 3, 3, 3);
                currentCat = "Health";
            }
            else if (c == "Shopping")
            {
                cat3.BorderBrush = new SolidColorBrush(Colors.Black);
                cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat3.BorderThickness = new Thickness(3, 3, 3, 3);
                currentCat = "Shopping";
            } else if (c == "Grocery")
            {
                cat4.BorderBrush = new SolidColorBrush(Colors.Black);
                cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat4.BorderThickness = new Thickness(3, 3, 3, 3);
                currentCat = "Grocery";
            } else if (c == "Hobbies")
            {
                cat5.BorderBrush = new SolidColorBrush(Colors.Black);
                cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat5.BorderThickness = new Thickness(3, 3, 3, 3);
                currentCat = "Hobbies";
            } else if (c == "Transport")
            {
                cat6.BorderBrush = new SolidColorBrush(Colors.Black);
                cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat6.BorderThickness = new Thickness(3, 3, 3, 3);
                currentCat = "Transport";
            } else if (c == "Travel")
            {
                cat1.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat7.BorderBrush = new SolidColorBrush(Colors.Black);
                cat7.BorderThickness = new Thickness(3, 3, 3, 3);
                currentCat = "Travel";
            } else
            {
                Debug.WriteLine("This category does not exist");
            }
        }

        private void cat1_click(object sender, RoutedEventArgs e)
        {
            clickCat("Party");
        }
        private void cat2_click(object sender, RoutedEventArgs e)
        {
            clickCat("Health");
        }
        private void cat3_click(object sender, RoutedEventArgs e)
        {
            clickCat("Shopping");
        }
        private void cat4_click(object sender, RoutedEventArgs e)
        {
            clickCat("Grocery");
        }
        private void cat5_click(object sender, RoutedEventArgs e)
        {
            clickCat("Hobbies");
        }
        private void cat6_click(object sender, RoutedEventArgs e)
        {
            clickCat("Transport");
        }
        private void cat7_click(object sender, RoutedEventArgs e)
        {
            clickCat("Travel");
        }

        private void amount_changed(object sender, TextChangedEventArgs e)
        {
            add_button.Visibility = Visibility.Visible;
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            int a;
            string com; 
            if (amount_textBox.Text == "" && currentCat == "")
            {
                amount_textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                you_must.Visibility = Visibility.Visible;
                you_must_cat.Visibility = Visibility.Visible;
            }
            else if (amount_textBox.Text == "")
            {
                amount_textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                you_must.Visibility = Visibility.Visible;
                you_must_cat.Visibility = Visibility.Collapsed;
            }
            else if (currentCat == "")
            {
                you_must_cat.Visibility = Visibility.Visible;
                you_must.Visibility = Visibility.Collapsed;
            }
            else if (comment_textBox.Text == "Optional comment")
            {
                a = Convert.ToInt32(amount_textBox.Text);
                var add = MainPage.conn.Insert(new Spending() { Comment = String.Empty, Amount = a, Cat = currentCat, Date = dp.Date.Date.ToLocalTime() });
                if (MainPage.budgetLeft != 0)
                {
                    MainPage.budgetLeft -= a;
                    MainPage.localSettings.Values["budgetLeft"] = MainPage.budgetLeft;
                }
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                a = Convert.ToInt32(amount_textBox.Text);
                com = comment_textBox.Text;
                var add = MainPage.conn.Insert(new Spending() { Comment = com, Amount = a, Cat = currentCat, Date = dp.Date.Date.ToLocalTime() });
                if (MainPage.budgetLeft != 0)
                {
                    MainPage.budgetLeft -= a;
                    MainPage.localSettings.Values["budgetLeft"] = MainPage.budgetLeft;
                }
                Frame.Navigate(typeof(MainPage));
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

        private void nb1_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "1";
        }

        private void nb2_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "2";
        }

        private void nb7_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "7";
        }

        private void nb8_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "8";
        }

        private void nb9_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "9";
        }

        private void nb4_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "4";
        }

        private void nb5_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "5";
        }

        private void nb6_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "6";
        }

        private void nb3_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "3";
        }

        private void nb0_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "0";
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text = "";
        }
    }
}
