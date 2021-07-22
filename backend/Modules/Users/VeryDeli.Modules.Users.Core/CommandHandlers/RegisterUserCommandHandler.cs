using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeryDeli.Modules.Users.Core.Commands;

namespace VeryDeli.Modules.Users.Core.CommandHandlers
{
    internal class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        public Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
