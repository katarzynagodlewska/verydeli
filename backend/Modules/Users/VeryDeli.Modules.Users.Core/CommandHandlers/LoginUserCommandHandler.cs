using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeryDeli.Modules.Users.Core.Commands;

namespace VeryDeli.Modules.Users.Core.CommandHandlers
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Guid>
    {
        public Task<Guid> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
