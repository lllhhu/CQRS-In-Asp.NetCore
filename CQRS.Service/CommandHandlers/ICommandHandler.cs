using CQRS.Service.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Service.CommandHandlers
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
