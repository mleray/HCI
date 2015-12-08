using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Papricash
{
    /// <summary>
    /// Page used to display the history of spendings, and modify/delete some if needed
    /// </summary>
    public sealed partial class History : Page
    {
        List<Spending> ls;
        /// <summary>
        /// Initialization of the page, empty constructor
        /// </summary>
        public History()
        {
            this.InitializeComponent();
            addDataToList();
        }
        /// <summary>
        /// Fills the list with the spendings
        /// </summary>
        private void addDataToList()
        {
            ls = new List<Spending>();
            var query = MainPage.conn.Query<Spending>("Select * from Spending order by Date DESC");
            foreach (Spending s in query)
            {
                ls.Add(s);
            }
            listSpend.ItemsSource = ls;
        }
        /// <summary>
        /// Makes buttons "modify" and "delete" visible if a spending is selected in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listSpend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            delete_button.Visibility = Visibility.Visible;
            modify_button.Visibility = Visibility.Visible;
            modify.Visibility = Visibility.Visible;
            delete.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Action when "delete" button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            Object o = listSpend.SelectedValue;
            Spending s = (Spending)o;
            var query = MainPage.conn.Query<Spending>("Delete from Spending where Id = ?", s.Id);
            MainPage.budgetLeft += s.Amount;
            MainPage.localSettings.Values["budgetLeft"] = MainPage.budgetLeft;
            addDataToList();
        }
        /// <summary>
        /// Action when "modify" button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modify_button_Click(object sender, RoutedEventArgs e)
        {
            Object o = listSpend.SelectedValue;
            Spending s = (Spending)o;
            var query = MainPage.conn.Query<Spending>("Delete from Spending where Id = ?", s.Id);
            MainPage.budgetLeft += s.Amount;
            MainPage.localSettings.Values["budgetLeft"] = MainPage.budgetLeft;
            this.Frame.Navigate(typeof(Add_spend), Add_spend.spend = s);
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
    }
}
