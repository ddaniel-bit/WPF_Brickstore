using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Microsoft.Win32;

namespace WPF_Brickstore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string kivalasztottFajl = "";
        List<LegoClass> legoItems = new List<LegoClass>();
        public MainWindow()
        {
            InitializeComponent();
            fajlValasztas();
        }

        private void btnSzukit_Click(object sender, RoutedEventArgs e)
        {
            Szures();
        }
        private void fajlValasztas()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "BSX files (*.bsx)|*.bsx";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                XDocument xaml = XDocument.Load(selectedFilePath);
                foreach (var elem in xaml.Descendants("Item"))
                {
                    string id = elem.Element("ItemID").Value;
                    string nev = elem.Element("ItemName").Value;
                    string kategoria = elem.Element("CategoryName").Value;
                    string szin = elem.Element("ColorName").Value;
                    int qty = Convert.ToInt32(elem.Element("Qty").Value);

                    legoItems.Add(new LegoClass(id, nev, kategoria, szin, qty));
                }
                dgElemek.ItemsSource = legoItems;
            }
            else
            {
                fajlValasztas();
            }
        }
        private void Szures()
        {
            string keresettNev = txtNev.Text.ToLower();
            string keresettAzon = txtAzon.Text.ToLower();

            var szurtLista = legoItems.Where(item =>
                (string.IsNullOrEmpty(keresettNev) || item.ItemName.ToLower().StartsWith(keresettNev)) &&
                (string.IsNullOrEmpty(keresettAzon) || item.ItemID.ToString().ToLower().StartsWith(keresettAzon))
            ).ToList();

            dgElemek.ItemsSource = szurtLista;
        }

    }
}