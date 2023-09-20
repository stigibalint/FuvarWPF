using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace Dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> adatok = new List<Fuvar>();
        public MainWindow()
        {
            InitializeComponent();

            //<<Orosz Zsombor Olivér
            //>> -

        }

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                File.ReadAllLines("fuvar.csv").Skip(1).ToList().ForEach(x => adatok.Add(new Fuvar(x)));
                lbBetoltottAdatok.ItemsSource = adatok;
                
               

            }
            catch (Exception)
            {

                MessageBox.Show("Hibás fájl!");
            }
            if (adatok.Any())
            {
                File.WriteAllLines("Hibak.txt");
            }
        }

        private void btnSzamol_Click(object sender, RoutedEventArgs e)
        {
            var megszamoltUtazasok = lbBetoltottAdatok.Items.Count;
            MessageBox.Show($"{megszamoltUtazasok} fuvar");
        }

        private void btnAzonosito_Click(object sender, RoutedEventArgs e)
        {
            if (tbBekeres.Text == "6185")
            {
                var mennyiBevetel = adatok.Where(x => x.TaxiAzonosito == tbBekeres.Text).Sum(x => x.VitelDij);
                var hanyFuvar = adatok.Where(x => x.TaxiAzonosito.Equals(tbBekeres.Text)).Distinct().Count();
                MessageBox.Show($"{mennyiBevetel}$ volt a bevétel {hanyFuvar} fuvar alatt");

            }
            else
            {
                MessageBox.Show("Hibás azonosító");
            }

        }

        private void btnFizetesek_Click(object sender, RoutedEventArgs e)
        {
            var fizetesimodok = adatok.Select(x => x.FizetesModja).Distinct();
            var bankkartyasFizetesek = adatok.Where(x => x.FizetesModja == "bankkártya").Count();
            var keszpenzesFizetesek = adatok.Where(x => x.FizetesModja == "készpénz").Count();
            var vitatott = adatok.Where(x => x.FizetesModja == "vitatott").Count();
            var ingyenes = adatok.Where(x => x.FizetesModja == "ingyenes").Count();
            var ismeretlen = adatok.Where(x => x.FizetesModja == "ismeretlen").Count();
            lbBetoltottFizetesek.ItemsSource = fizetesimodok;
           
        }

        private void btnTavolsag_Click(object sender, RoutedEventArgs e)
        {
            var megtettTavolsag = adatok.Sum(x => x.MegtettTavolsag * 1.6);
            MessageBox.Show($"{Math.Round(megtettTavolsag,2)} km");
        }

        private void btnLeghosszabbFuvar_Click(object sender, RoutedEventArgs e)
        {
            var leghosszabbFuvar = adatok.OrderByDescending(x => x.UtazasIdotartam).ToList().Take(1);
            MessageBox.Show($"{leghosszabbFuvar}");
            foreach (var adat in leghosszabbFuvar)
            {
                continue;
            }
          
        }
    }
}