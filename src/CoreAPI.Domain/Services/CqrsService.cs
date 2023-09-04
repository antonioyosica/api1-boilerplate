using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CoreAPI.Domain.Services
{
    public interface ICqrsService
    {
        Task SendAsync<T>(T command) where T : INotification;
        Task<TResponse> SendAsync<TResponse, TCommand>(TCommand command) where TCommand : IRequest<TResponse>;
    }

    public class CqrsService : ICqrsService
    {
        private readonly IMediator _mediator;

        public CqrsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendAsync<T>(T command) where T : INotification
        {
            await _mediator.Publish(command);
        }

        public async Task<TResponse> SendAsync<TResponse, TCommand>(TCommand command) where TCommand : IRequest<TResponse>
        {
            return await _mediator.Send(command);
        }
    }
}