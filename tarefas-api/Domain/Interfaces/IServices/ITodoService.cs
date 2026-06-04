using Domain.Entities;

namespace Domain.Interfaces.IServices
{
    public interface ITodoService
    {
        Task<List<TodoEntity>> PegarTodos();
        Task<TodoEntity> Pegar(Guid GuidId);
        Task Criar(TodoEntity todo);
        Task<Guid> CriarRetornoId(TodoEntity todo);
        Task Atualizar(TodoEntity todo);
        Task Deletar(Guid GuidId);
    }
}
