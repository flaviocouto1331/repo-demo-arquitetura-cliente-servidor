using Application.DTOs;
using Application.InterfacesApp;

namespace Presentation.ConfigurationEndpoints
{
    public static class TodoEndpoint
    {
        public static void AddTodoEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/todo", async (ITodoServiceApp _serviceApp) =>
            {
                try
                {
                    var response = await _serviceApp.PegarTodos();
                    if (response.Count == 0) return Results.Ok(new { sts = true, msg = "Nenhum registro encontrado.", Todo = new List<TodoDTO>() });
                    return Results.Ok(new { sts = true, msg = "Registro encontrado.", Todo = response });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { sts = false, msg = $"Erro: {ex.Message}" });
                }

            }).WithTags("Todo");

            app.MapGet("/api/todo/{id:guid}", async (Guid id, ITodoServiceApp _serviceApp) =>
            {
                try
                {
                    var response = await _serviceApp.Pegar(id);
                    if (response is null) return Results.Ok(new { sts = true, msg = "Nenhum registro encontrado.", Todo = (TodoDTO?)null });
                    return Results.Ok(new { sts = true, msg = "Registro encontrado.", Todo = response });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { sts = false, msg = $"Erro: {ex.Message}" });
                }
            }).WithTags("Todo");

            app.MapPost("/api/todo", async (TodoCriarDTO todo, ITodoServiceApp _serviceApp) =>
            {
                try
                {
                    await _serviceApp.Criar(todo);
                    return Results.Ok(new { sts = true, msg = "Criado com sucesso." });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { sts = false, msg = $"Erro: {ex.Message}" });
                }
            }).WithTags("Todo");

            app.MapPost("/api/todo/retorno-id", async (TodoCriarDTO todo, ITodoServiceApp _serviceApp) =>
            {
                try
                {
                    var response = await _serviceApp.CriarRetornoId(todo);
                    return Results.Ok(new { sts = true, msg = "Criado com sucesso.", id = response });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { sts = false, msg = $"Erro: {ex.Message}" });
                }
            }).WithTags("Todo");

            app.MapPut("/api/todo", async (TodoDTO todo, ITodoServiceApp _serviceApp) =>
            {
                try
                {
                    await _serviceApp.Atualizar(todo);
                    return Results.Ok(new { sts = true, msg = "Atualizado com sucesso." });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { sts = false, msg = $"Erro: {ex.Message}" });
                }
            }).WithTags("Todo");

            app.MapDelete("/api/todo/{id:guid}", async (Guid id, ITodoServiceApp _serviceApp) =>
            {
                try
                {
                    await _serviceApp.Deletar(id);
                    return Results.Ok(new { sts = true, msg = "Deletado com sucesso." });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { sts = false, msg = $"Erro: {ex.Message}" });
                }
            }).WithTags("Todo");
        }
    }
}
