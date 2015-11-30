using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            List<Spending> lsPie = new List<Spending>();
            string[] tabCat = { "Party", "Health", "Shopping", "Grocery", "Hobbies", "Transport", "Travel" };
            int[] tabAmount = { 0, 0, 0, 0, 0, 0, 0 };
            var query = MainPage.conn.Query<Spending>("SELECT Cat, Date, Amount FROM Spending");
            foreach (Spending s in query)
            {
                if (s.Date.Month == DateTime.Today.Month && s.Date.Year == DateTime.Today.Year)
                {
                    switch (s.Cat)
                    {
                        case "Party":
                            tabAmount[0] += s.Amount;
                            break;
                        case "Health":
                            tabAmount[1] += s.Amount;
                            break;
                        case "Shopping":
                            tabAmount[2] += s.Amount;
                            break;
                        case "Grocery":
                            tabAmount[3] += s.Amount;
                            break;
                        case "Hobbies":
                            tabAmount[4] += s.Amount;
                            break;
                        case "Transport":
                            tabAmount[5] += s.Amount;
                            break;
                        case "Travel":
                            tabAmount[6] += s.Amount;
                            break;
                        default:
                            Debug.WriteLine("Default case");
                            break;
                    }
                }
            }
            for (int i=0; i < 7; i++)
            {
                lsPie.Add(new Spending { Cat = tabCat[i], Amount = tabAmount[i] });
            }
            (pie.Series[0] as PieSeries).ItemsSource = lsPie;
        }
    }
}
