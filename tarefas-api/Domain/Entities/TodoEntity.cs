namespace Domain.Entities
{
    public class TodoEntity : BaseEntity
    {
        // Dapper - Contrutor vazio necessário para o Dapper conseguir mapear os dados do banco para o objeto
        public TodoEntity() { }

        public TodoEntity(
            Guid guidId,
            DateTime dataCadastro,
            bool statusCadastro,
            string? nome,
            decimal valor) 
        : base(guidId)
        { 
            DataCadastro = dataCadastro;
            StatusCadastro = statusCadastro;
            Nome = nome;
            Valor = valor;
        }

        public DateTime DataCadastro { get; private set; }

        public bool StatusCadastro { get; private set; }

        public string? Nome { get; private set; }

        public void AlterarNome(string? nome)
        {
            Nome = nome?.ToUpperInvariant();
        }

        public decimal Valor { get; private set; }
    }
}
