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
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class History : Page
    {
        List<Spending> ls;

        public History()
        {
            this.InitializeComponent();
            addDataToList();
        }

        private void Show_click(object sender, RoutedEventArgs e)
        {
            var show = MainPage.conn.Table<Spending>();
            string result = String.Empty;
            foreach (var item in show)
                {
                    result = item.ToString();
                    Debug.WriteLine(result);
                }; 
        }

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

        private void listSpend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            delete_button.Visibility = Visibility.Visible;
            modify_button.Visibility = Visibility.Visible;
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            Object o = listSpend.SelectedValue;
            Spending s = (Spending)o;
            var query = MainPage.conn.Query<Spending>("Delete from Spending where Id = ?", s.Id);
            Debug.WriteLine("Item successfully deleted");
            addDataToList();
        }

        private void modify_button_Click(object sender, RoutedEventArgs e)
        {
            Object o = listSpend.SelectedValue;
            Spending s = (Spending)o;
            var query = MainPage.conn.Query<Spending>("Delete from Spending where Id = ?", s.Id);
            Debug.WriteLine("Item successfully deleted");
            this.Frame.Navigate(typeof(Add_spend), Add_spend.spend = s);
        }

        private void return_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
