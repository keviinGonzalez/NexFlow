using FluentValidation;
using NexFlow.Application.Features.Request.Commands.CreateRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Requests.Commands.Create
{
    public sealed class CreateRequestValidator : AbstractValidator<CreateRequestCommand>
    {
        public CreateRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Description)
                .MaximumLength(1000);
        }
    }
}
