using System.Windows;

namespace OODBMS
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CadastrarEmpregados_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new CadastroEmpregados();
            window.ShowDialog();

            ListaEmpregadosView.CarregarEmpregados();
        }

        private void FiltrarIdade_Click(object sender, RoutedEventArgs e)
        {
            var window = new FiltrarPorIdade();
            window.ShowDialog();

            ListaEmpregadosView.FiltrarPorIdade(window.IdadeEscolhida, window.FiltroEscolhido);
        }

        private void CarregarEmpregados_Click(object sender, RoutedEventArgs e)
        {
            ListaEmpregadosView.CarregarEmpregados();
        }
    }
}