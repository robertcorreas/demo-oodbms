namespace OODBMS.Models
{
    public class Empregado : Pessoa
    {
        public Empregado(string nome, int idade, string matricula) : base(nome, idade)
        {
            Matricula = matricula;
        }

        public string Matricula { get; }
    }
}