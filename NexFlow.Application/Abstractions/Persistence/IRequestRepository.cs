using NexFlow.Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Application.Abstractions.Persistence
{
    public interface IRequestRepository
    {
        Task<Request?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ExistsByTitleAsync(string title, CancellationToken cancellationToken);
        Task AddAsync(Request request, CancellationToken cancellationToken);
        Task UpdateAsync(Request request, CancellationToken cancellationToken);
    }
}
