using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Service.Commands;

namespace CQRS.Service.CommandHandlers
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider serviceProvider;

        public CommandBus(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public void Send<T>(T command) where T : ICommand
        {
            var handler = GetHandler<T>();
            if (handler == null)
            {
                throw new Exception("未找到对应的处理器");
            }

            handler.Execute(command);
        }

        public ICommandHandler<T> GetHandler<T>() where T : ICommand
        {
            var types = GetHandlerTypes<T>();
            if (!types.Any())
            {
                return null;
            }

            var handler = this.serviceProvider.GetService(types.FirstOrDefault()) as ICommandHandler<T>;
            return handler;
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : ICommand
        {
            var handlers = typeof(ICommandHandler<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }
    }
}
