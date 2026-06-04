using Mapster;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mapster
{
    public static class TodoMapper
    {
        // Mapster - Configuração necessária para mapear os objetos usando o construtor da classe quando utilizado { private set; }.
        // TypeAdapterConfig<Origem, Destino>
            // .NewConfig()
            // .MapToConstructor(true);
        static TodoMapper()
        {
            TypeAdapterConfig<TodoDTO, TodoEntity>
                .NewConfig()
                .MapToConstructor(true);
        }

        public static List<TodoEntity> Entity(List<TodoDTO> todo) => todo.Adapt<List<TodoEntity>>();
        public static TodoEntity Entity(TodoDTO todo) => todo.Adapt<TodoEntity>();
        public static List<TodoDTO> DTO(List<TodoEntity> todo) => todo.Adapt<List<TodoDTO>>();
        public static TodoDTO DTO(TodoEntity todo) => todo.Adapt<TodoDTO>();
        public static TodoDTO DTO(TodoCriarDTO todoCriar) => todoCriar.Adapt<TodoDTO>();
    }
}
