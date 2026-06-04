namespace Domain.Entities
{
    public class BaseEntity
    {
        // Dapper - Contrutor vazio necessário para o Dapper conseguir mapear os dados do banco para o objeto
        public BaseEntity() { }

        public BaseEntity(Guid guidId)
        {
            GuidId = guidId;
        }

        public Guid GuidId { get; private set; }
    }
}
