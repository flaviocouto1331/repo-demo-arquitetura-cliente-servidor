using Dapper;
using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infra.Dapper;
using System.Data;
using System.Text;

namespace Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DapperContext _context;
        public TodoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task Atualizar(TodoEntity todo)
        {
            StringBuilder query = new();
            query.AppendLine(@"
            update Todo
            set 
            StatusCadastro = @StatusCadastro,
            Nome = @Nome,
            Valor = @Valor
            where GuidId = @GuidId
            ");
            using var connection = _context.DapperConnection();
            var response = await connection.ExecuteAsync(
                query.ToString(),
                todo,
                commandType: CommandType.Text
                );
            if (response == 0) throw new ArgumentException("Identificador inválido.");
        }

        public async Task Criar(TodoEntity todo)
        {
            StringBuilder query = new();
            query.AppendLine(@"
            insert into Todo
            (
            Nome,
            Valor
            )
            values
            (
            @Nome,
            @Valor
            )
            ");
            using var connection = _context.DapperConnection();
            await connection.ExecuteAsync(
                query.ToString(),
                todo,
                commandType: CommandType.Text
                );
        }

        public async Task<Guid> CriarRetornoId(TodoEntity todo)
        {
            StringBuilder query = new();
            query.AppendLine(@"
            insert into Todo
            (
            Nome,
            Valor
            )
            output inserted.GuidId
            values            
            (
            @Nome,
            @Valor
            )
            ");
            using var connnection = _context.DapperConnection();
            var response = await connnection.ExecuteScalarAsync<Guid>(
                query.ToString(),
                todo,
                commandType: CommandType.Text
                );
            return response;
        }

        public async Task Deletar(Guid guidId)
        {
            StringBuilder query = new();
            query.AppendLine("delete from Todo where GuidId = @GuidId");
            using var connection = _context.DapperConnection();
            var response = await connection.ExecuteAsync(
                query.ToString(),
                new { GuidId = guidId },
                commandType: CommandType.Text
                );
            if (response == 0) throw new ArgumentException("Identificador inválido.");
        }

        public async Task<TodoEntity> Pegar(Guid guidId)
        {
            StringBuilder query = new();
            query.AppendLine(@"
            select 
            GuidId,
            DataCadastro,
            StatusCadastro,
            Nome,
            Valor
            from Todo
            where GuidId = @GuidId
            ");
            using var connection = _context.DapperConnection();
            var response = await connection.QuerySingleOrDefaultAsync<TodoEntity>(
                query.ToString(),
                new { GuidId = guidId },
                commandType: CommandType.Text
                );
            return response is not null ? response : throw new ArgumentException("Identificador inválido.");
        }

        public async Task<List<TodoEntity>> PegarTodos()
        {
            StringBuilder query = new();
            query.AppendLine(@"
            select 
            GuidId,
            DataCadastro,
            StatusCadastro,
            Nome,
            Valor
            from Todo
            order by DataCadastro desc
            ");
            using var connection = _context.DapperConnection();
            var response = await connection.QueryAsync<TodoEntity>(
                query.ToString(),
                commandType: CommandType.Text);
            return [.. response];
        }
    }
}
