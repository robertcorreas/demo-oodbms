using System.Windows;
using System.Windows.Controls;

namespace OODBMS
{
    /// <summary>
    ///     Interaction logic for FiltrarPorIdade.xaml
    /// </summary>
    public partial class FiltrarPorIdade : Window
    {
        public FiltrarPorIdade()
        {
            InitializeComponent();
        }

        public int IdadeEscolhida { get; private set; }
        public string FiltroEscolhido { get; private set; }

        private void Filtar_Click(object sender, RoutedEventArgs e)
        {
            IdadeEscolhida = int.Parse(Idade.Text);
            Close();
        }


        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = Filtros.SelectedItem as ComboBoxItem;

            if (item == null) return;

            FiltroEscolhido = item.Content.ToString();
        }
    }
}