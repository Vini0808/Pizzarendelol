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

namespace Pizzarendelol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> pizzaList = new List<string>() { "Margherita", "Sonkás", "Hawaii", "Gombás", "Négy Sajtos", "Magyaros" };
        List<string> pizzaMeretek = new List<string>() { "kicsi", "kozepes", "nagy" };

        string selectedMeret;
        string selectedPizza; 
        public MainWindow()
        {
            InitializeComponent();
            PizzaListBox.ItemsSource = pizzaList;
            list_Meretek.ItemsSource = pizzaMeretek;
        }

        private void Kivalasztas(object sender, SelectionChangedEventArgs e)
        {
            string kivalasztott = "" + PizzaListBox.SelectedItem;
            TextBoxPizza.Text = "A választott pizza: " + kivalasztott;
        }

        private void btn_torles_Click(object sender, RoutedEventArgs e)
        {
            string kivalasztott = "" + PizzaListBox.SelectedItem;
            if (kivalasztott != null)
            {
                if (MessageBox.Show($"Biztosan kívánja törölni a {kivalasztott} elemet?", "Figyelmeztetés", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    pizzaList.Remove(kivalasztott);
                    PizzaListBox.ItemsSource = pizzaList;
                    PizzaListBox.Items.Refresh();
                }
            }
        }

        private void btn_HozzaAdas_Click(object sender, RoutedEventArgs e)
        {
            string ujPizza = txtbox_HozzaAdas.Text;
            if (string.IsNullOrWhiteSpace(ujPizza) || pizzaList.Contains(ujPizza))
            {
                MessageBox.Show("A pizza neve nem lehet üres vagy léteik ilyen pizza", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                pizzaList.Add(ujPizza);
                PizzaListBox.Items.Refresh();
                txtbox_HozzaAdas.Clear();
            }
        }

        private void btn_Rendeles_Click(object sender, RoutedEventArgs e)
        {
            txtblock_Rendelesek.Text = "Rendelés: ";
            txtblock_Rendelesek.Text += "Pizza: " + selectedPizza + " - " + "Méret " + selectedMeret;

        }

        private void btn_Meret_Click(object sender, RoutedEventArgs e)
        {
            string kivalasztottMeret = "" + list_Meretek.SelectedItem;
            if (kivalasztottMeret != null)
            {
                txtblock_Rendeles.Text += " Méret: " + kivalasztottMeret;
            }
        }

        private void KivalasztasMeretek(object sender, SelectionChangedEventArgs e)
        {
            //if (list_Meretek.SelectedItem != null)
            //{
            //    txtblock_Rendeles.Text = $"Rendelés: {list_Meretek.SelectedItem}";
            //}
            //else
            //{
            //    txtblock_Rendeles.Text = "Rendelés:";
            //}
        }
        private void btn_HozzaadMeret_Click(object sender, RoutedEventArgs e)
        {
            selectedMeret = ""+list_Meretek.SelectedItem;
            selectedPizza = ""+PizzaListBox.SelectedItem;

            var sb = new StringBuilder();
            sb.Append("Rendelés:");
            if (selectedPizza != null)
                sb.Append(" Pizza: ").Append(selectedPizza.ToString());
            if (selectedMeret != null)
                sb.Append(" Méret: ").Append(selectedMeret.ToString());

            txtblock_Rendeles.Text = sb.ToString();
        }
    }
}