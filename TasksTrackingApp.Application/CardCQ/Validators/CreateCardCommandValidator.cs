﻿using FluentValidation;
using TasksTrackingApp.Application.CardCQ.Commands;

namespace TasksTrackingApp.Application.CardCQ.Validators
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("O título não pode ser vazio");
            RuleFor(p => p.Description).NotEmpty().WithMessage("A descrição não pode ser vazio");
            RuleFor(p => p.Deadline).NotEmpty().WithMessage("A data de expiração é obrigatória");
            RuleFor(p => p.ListCardId).NotEmpty().WithMessage("O Id da lista não pode ser vazio");
        }
    }
}
