using VelocityDb;

namespace OODBMS.Models
{
    public abstract class Pessoa : OptimizedPersistable
    {
        private int _idade;
        private string _nome;

        protected Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public string Nome
        {
            get => _nome;
            set
            {
                Update();
                _nome = value;
            }
        }

        public int Idade
        {
            get => _idade;
            set
            {
                Update();
                _idade = value;
            }
        }
    }
}