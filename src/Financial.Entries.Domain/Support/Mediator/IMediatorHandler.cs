﻿using Financial.Entries.Domain.Support.Messages;
using FluentValidation.Results;

namespace Financial.Entries.Domain.Support.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command, CancellationToken cancellationToken) where T : Command;
    }
}
