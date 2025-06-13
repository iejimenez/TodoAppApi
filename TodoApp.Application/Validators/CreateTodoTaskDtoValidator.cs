using FluentValidation;
using TodoApp.Application.DTOs;

namespace TodoApp.Application.Validators
{
    public class CreateTodoTaskDtoValidator : AbstractValidator<CreateTodoTaskDto>
    {
        public CreateTodoTaskDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("El título es requerido")
                .MaximumLength(200).WithMessage("El título no puede tener más de 200 caracteres");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es requerida")
                .MaximumLength(1000).WithMessage("La descripción no puede tener más de 1000 caracteres");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("El estado es requerido")
                .Must(status => status == "Pendiente" || status == "Completada")
                .WithMessage("El estado debe ser 'Pendiente' o 'Completada'");

            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("La fecha de expiración es requerida")
                .Must(date => date > DateTime.UtcNow)
                .WithMessage("La fecha de expiración debe ser posterior a la fecha actual");
        }
    }
} 