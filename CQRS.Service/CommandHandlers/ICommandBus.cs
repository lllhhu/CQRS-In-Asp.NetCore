using CQRS.Service.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Service.CommandHandlers
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : ICommand;
    }
}
