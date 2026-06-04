using Application.DTOs;
using Application.InterfacesApp;
using Application.Mapster;
using Domain.Interfaces.IServices;
using FluentValidation;

namespace Application.ServicesApp
{
    public class TodoServiceApp : ITodoServiceApp
    {
        private readonly ITodoService _service;
        private readonly IValidator<TodoDTO> _validator;
        public TodoServiceApp(
            ITodoService service,
            IValidator<TodoDTO> validator)
        {
            _service = service;
            _validator = validator;
        }

        public async Task Atualizar(TodoDTO todo)
        {
            var response = TodoMapper.Entity(todo);
            var validator = await _validator.ValidateAsync(todo);
            if (!validator.IsValid) throw new ValidationException(validator.Errors);
            await _service.Atualizar(response);
        }

        public async Task Criar(TodoCriarDTO todoCriar)
        {
            var todo = TodoMapper.DTO(todoCriar);            
            var response = TodoMapper.Entity(todo);
            var validator = await _validator.ValidateAsync(todo);
            if (!validator.IsValid) throw new ValidationException(validator.Errors);
            await _service.Criar(response);
        }

        public async Task<Guid> CriarRetornoId(TodoCriarDTO todoCriar)
        {
            var todo = TodoMapper.DTO(todoCriar);
            var response = TodoMapper.Entity(todo);
            var validator = await _validator.ValidateAsync(todo);
            if (!validator.IsValid) throw new ValidationException(validator.Errors);
            return await _service.CriarRetornoId(response);
        }

        public async Task Deletar(Guid guidId) => await _service.Deletar(guidId);

        public async Task<TodoDTO> Pegar(Guid guidId)
        {
            var response = await _service.Pegar(guidId);
            return TodoMapper.DTO(response);
        }

        public async Task<List<TodoDTO>> PegarTodos()
        {
            var response = await _service.PegarTodos();
            return TodoMapper.DTO(response);
        }

    }
}
