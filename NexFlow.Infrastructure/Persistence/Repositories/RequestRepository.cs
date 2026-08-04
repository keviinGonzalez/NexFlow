using Microsoft.EntityFrameworkCore;
using NexFlow.Application.Abstractions.Persistence;
using NexFlow.Domain.Entities.Requests;
using NexFlow.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexFlow.Infrastructure.Persistence.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _context;
        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Request request, CancellationToken cancellationToken)
        {
            await _context.Requests.AddAsync(request, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Request?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Requests.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<bool> ExistsByTitleAsync(string title, CancellationToken cancellationToken)
        {
            return await _context.Requests.AnyAsync(x => x.Title == title, cancellationToken);
        }

        public async Task UpdateAsync(Request request, CancellationToken cancellationToken)
        {
            _context.Requests.Update(request);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
