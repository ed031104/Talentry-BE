using Application.Abstractions.Persistence;
using Application.Abstractions.Vectorization;
using Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestructure.Persistence.Repositories;

public class UnitOfWork : IUnitofwork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction? _transaction;
    private IEmbeddingRepository  _embedding;
    private IMatchAnalysisRepository _matchAnalysis;
    private IOutboxRepository _outbox;
    private IResumeAnalysisRepository _resumeAnalysis;
    private IResumeRepository _resume;
    private IVacancyRepository _vacancy;

    public UnitOfWork(
        ApplicationDbContext context,
        IEmbeddingRepository embedding,
        IMatchAnalysisRepository matchAnalysis,
        IOutboxRepository outbox,
        IResumeAnalysisRepository resumeAnalysis,
        IResumeRepository resume,
        IVacancyRepository vacancy
        )
    {
        _context = context;
        _embedding = embedding;
        _matchAnalysis = matchAnalysis;
        _outbox = outbox;
        _resumeAnalysis = resumeAnalysis;
        _resume = resume;
        _vacancy = vacancy;
    }
    
    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database
            .BeginTransactionAsync(cancellationToken);

    }

    public async Task CommitTransaction(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);

        if (_transaction is not null)
        {
            await _transaction.CommitAsync(cancellationToken);
        }
    }

    public async Task RollbackTransaction(CancellationToken cancellationToken = default)
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}