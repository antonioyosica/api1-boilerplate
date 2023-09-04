using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Domain.Extensions;
using MediatR;

namespace CoreAPI.Domain.Commands.Account
{
    public class CreateAccountCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Response>
    {
        public async Task<Response> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
        {
            var response = new Response
            {
                Message = $"Olá {command.Name}!"
            };

            return await Task.FromResult(response);
        }
    }
}