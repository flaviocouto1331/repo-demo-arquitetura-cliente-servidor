using Domain.Entities;

namespace Domain.Interfaces.IRepositories
{
    public interface ITodoRepository
    {
        Task<List<TodoEntity>> PegarTodos();
        Task<TodoEntity> Pegar(Guid guidId);
        Task Criar(TodoEntity todo);
        Task<Guid> CriarRetornoId(TodoEntity todo);
        Task Atualizar(TodoEntity todo);        
        Task Deletar(Guid guidId);
    }
}
