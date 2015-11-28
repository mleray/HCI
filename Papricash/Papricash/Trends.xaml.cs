using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Papricash
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Trends : Page
    {
        public Trends()
        {
            this.InitializeComponent();
            addDataToChart();
        }

        private void return_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void addDataToChart()
        {
            List<Spending> ls = new List<Spending>();
            var query = MainPage.conn.Query<Spending>("Select * from Spending order by Cat DESC");
            foreach (Spending s in query)
            {
                ls.Add(new Spending() { Cat = s.Cat, Amount = s.Amount });
            }
            (chart.Series[0] as PieSeries).ItemsSource = ls;
        }
    }
}
