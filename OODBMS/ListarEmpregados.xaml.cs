using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using VelocityDb.Session;

namespace OODBMS
{
    /// <summary>
    ///     Interaction logic for ListarEmpregados.xaml
    /// </summary>
    public partial class ListarEmpregados : UserControl
    {
        public ListarEmpregados()
        {
            InitializeComponent();
            CarregarEmpregados();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var empregado = Empregados.SelectedItem as Empregado;

            if (empregado == null) return;

            InfoNome.Text = empregado?.Nome;
            InfoIdade.Text = empregado.Idade.ToString();
            InfoMatricula.Text = empregado.Matricula;
        }

        public void CarregarEmpregados()
        {
            using (var session = new SessionNoServer("OODBMS_FOLDER"))
            {
                try
                {
                    session.BeginRead();
                    var empregados = session.AllObjects<Empregado>();

                    Empregados.Items.Clear();
                    foreach (var empregado in empregados)
                        Empregados.Items.Add(empregado);

                    session.Commit();
                }
                catch (Exception e)
                {
                    session.Abort();
                    
                }
            }
        }

        public void FiltrarPorIdade(int idade, string filtro)
        {
            using (var session = new SessionNoServer("OODBMS_FOLDER"))
            {
                session.BeginRead();

                var empregados = session.AllObjects<Empregado>();
                IEnumerable<Empregado> query;

                if (filtro == "<")
                {
                    query = from Empregado empregado in empregados
                        where empregado.Idade < idade
                        select empregado;
                }
                else if (filtro == ">")
                {
                    query = from Empregado empregado in empregados
                        where empregado.Idade > idade
                        select empregado;
                }
                else
                {
                    query = from Empregado empregado in empregados
                        where empregado.Idade == idade
                        select empregado;
                }

                Empregados.Items.Clear();
                foreach (var empregado in query)
                    Empregados.Items.Add(empregado);

                session.Commit();
            }
        }
    }
}