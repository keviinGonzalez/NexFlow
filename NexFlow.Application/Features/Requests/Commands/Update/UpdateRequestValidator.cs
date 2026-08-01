using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Features.Requests.Commands.Update
{
    public sealed class UpdateRequestValidator : AbstractValidator<UpdateRequestCommand>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(150);
            RuleFor(x => x.Description)
                .MaximumLength(1000);
        }
    }
}
