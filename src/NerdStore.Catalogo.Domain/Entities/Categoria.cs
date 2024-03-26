using NerdStore.Core.DomainObjects;
using NerdStore.Core.Validations;

namespace NerdStore.Catalogo.Domain.Entities
{
    public class Categoria : Entity
    {
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public Categoria()
        {

        }

        public string Nome { get; private set; }
        public int Codigo { get; private set; }
        public List<Produto> Produtos { get; private set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }
    }
}
