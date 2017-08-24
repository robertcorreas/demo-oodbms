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
using System.Windows.Shapes;
using VelocityDb.Session;

namespace OODBMS
{
    /// <summary>
    /// Interaction logic for CadastroEmpregados.xaml
    /// </summary>
    public partial class CadastroEmpregados : Window
    {
        public CadastroEmpregados()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var nome = this.Nome.Text;
            var idade = int.Parse(this.Idade.Text);

            using (SessionNoServer session = new SessionNoServer("OODBMS_FOLDER"))
            {
                try
                {
                    session.BeginUpdate();
                    var empregado = new Empregado(nome, idade, Guid.NewGuid().ToString());
                    session.Persist(empregado);
                    session.Commit();
                }
                catch (Exception ex)
                {
                    session.Abort();
                    return;
                }
            }

            this.Close();
        }
    }
}
