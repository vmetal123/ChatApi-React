using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Contracts.v1.Requests.Validators
{
    public class SendMessageRequestValidator: AbstractValidator<SendMessageRequest>
    {
        public SendMessageRequestValidator()
        {
            RuleFor(x => x.Text).NotNull().NotEmpty();
            RuleFor(x => x.To).NotNull().NotEmpty();
        }
    }
}
