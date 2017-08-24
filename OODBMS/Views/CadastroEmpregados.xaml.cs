using System;
using System.Windows;
using OODBMS.Models;
using VelocityDb.Session;

namespace OODBMS.Views
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
