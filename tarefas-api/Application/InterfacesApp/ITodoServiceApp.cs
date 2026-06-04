using Application.DTOs;

namespace Application.InterfacesApp
{
    public interface ITodoServiceApp
    {
        Task<List<TodoDTO>> PegarTodos();
        Task<TodoDTO> Pegar(Guid guidId);
        Task Criar(TodoCriarDTO todoCriar);
        Task<Guid> CriarRetornoId(TodoCriarDTO todoCriar);
        Task Atualizar(TodoDTO todo);
        Task Deletar(Guid guidId);
    }
}
