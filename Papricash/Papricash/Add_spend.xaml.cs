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

namespace Papricash
{
    /// <summary>
    /// Page used to add spendings
    /// </summary>
    public sealed partial class Add_spend : Page
    {
        private string currentCat { get; set; }
        public static Spending spend;

        /// <summary>
        /// Initialization of the page, empty constructor
        /// </summary>
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

        /// <summary>
        /// Action when return button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void return_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        /// <summary>
        /// Actions when a category is selected
        /// </summary>
        /// <param name="c">Represents the category</param>
        private void clickCat(string c)
        {
            if (c == "Parties")
            {
                cat1.BorderBrush = new SolidColorBrush(Colors.Black);
                cat2.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat3.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat4.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat5.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat6.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat7.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cat1.BorderThickness = new Thickness(3, 3, 3, 3);
                currentCat = "Parties";
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
        /// <summary>
        /// Category 1 is picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cat1_click(object sender, RoutedEventArgs e)
        {
            clickCat("Parties");
        }

        /// <summary>
        /// Category 2 is picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cat2_click(object sender, RoutedEventArgs e)
        {
            clickCat("Health");
        }
        /// <summary>
        /// Category 3 is picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cat3_click(object sender, RoutedEventArgs e)
        {
            clickCat("Shopping");
        }

        /// <summary>
        /// Category 4 is picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cat4_click(object sender, RoutedEventArgs e)
        {
            clickCat("Grocery");
        }
        /// <summary>
        /// Category 5 is picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cat5_click(object sender, RoutedEventArgs e)
        {
            clickCat("Hobbies");
        }
        /// <summary>
        /// Category 6 is picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cat6_click(object sender, RoutedEventArgs e)
        {
            clickCat("Transport");
        }
        /// <summary>
        /// Category 7 is picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cat7_click(object sender, RoutedEventArgs e)
        {
            clickCat("Travel");
        }
        /// <summary>
        /// Actions when user changes the amount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void amount_changed(object sender, TextChangedEventArgs e)
        {
            add_button.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Actions when add button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_click(object sender, RoutedEventArgs e)
        {
            int a;
            string com; 
            if (amount_textBox.Text == "" && currentCat == "") // if no amount and no category specified
            {
                amount_textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                you_must.Visibility = Visibility.Visible;
                you_must_cat.Visibility = Visibility.Visible;
            }
            else if (amount_textBox.Text == "") // if no amount specified
            {
                amount_textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                you_must.Visibility = Visibility.Visible;
                you_must_cat.Visibility = Visibility.Collapsed;
            }
            else if (currentCat == "") // if no category specified
            {
                you_must_cat.Visibility = Visibility.Visible;
                you_must.Visibility = Visibility.Collapsed;
            }
            else if (comment_textBox.Text == "Optional comment") // if no comment specified
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
            else // if there is a comment
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

        /// <summary>
        /// If focus on comment text box, put value to empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comment_textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (comment_textBox.Text == "Optional comment") comment_textBox.Text = "";
        }
        /// <summary>
        /// If comment text box loses focus without input then put back "optional comment"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comment_textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (comment_textBox.Text == "") comment_textBox.Text = "Optional comment";
        }
        /// <summary>
        /// Keyboard: touch "1"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nb1_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "1";
        }
        /// <summary>
        /// Keyboard: touch "2"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nb2_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "2";
        }
        /// <summary>
        /// Keyboard: touch "7"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nb7_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "7";
        }
        /// <summary>
        /// Keyboard: touch "8"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nb8_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "8";
        }
        /// <summary>
        /// Keyboard: touch "9"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nb9_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "9";
        }
        /// <summary>
        /// Keyboard: touch "4"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nb4_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "4";
        }
        /// <summary>
        /// Keyboard: touch "5"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nb5_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "5";
        }
        /// <summary>
        /// Keyboard: touch "6"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nb6_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "6";
        }
        /// <summary>
        /// Keyboard: touch "3"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nb3_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "3";
        }
        /// <summary>
        /// Keyboard: touch "0"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nb0_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text += "0";
        }
        /// <summary>
        /// Keyboard: touch "Clean"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            amount_textBox.Text = "";
        }
    }
}
