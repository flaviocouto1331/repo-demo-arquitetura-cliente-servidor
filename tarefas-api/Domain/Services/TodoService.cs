using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;

namespace Domain.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;
        public TodoService(ITodoRepository repository) => _repository = repository;

        public async Task Atualizar(TodoEntity todo)
        {
            todo.AlterarNome(todo.Nome);
            await _repository.Atualizar(todo);
        }

        public async Task Criar(TodoEntity todo)
        {
            todo.AlterarNome(todo.Nome);
            await _repository.Criar(todo);
        }

        public async Task<Guid> CriarRetornoId(TodoEntity todo) 
        { 
            todo.AlterarNome(todo.Nome);
            return await _repository.CriarRetornoId(todo);
        }

        public async Task Deletar(Guid GuidId) => await _repository.Deletar(GuidId);    

        public async Task<TodoEntity> Pegar(Guid GuidId) => await _repository.Pegar(GuidId);

        public async Task<List<TodoEntity>> PegarTodos() => await _repository.PegarTodos();

    }
}
