using Application.DTOs;
using FluentValidation;

namespace Application.FluentValidation
{
    public class TodoValidator : AbstractValidator<TodoDTO>
    {
        public TodoValidator() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome obrigatório.")
                .MaximumLength(100).WithMessage("Nome máximo caracteres 100.");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero.");
        }
    }
}
