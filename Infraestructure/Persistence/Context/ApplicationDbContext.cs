using System.Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
    ) : base(options)
    {
    }

    public DbSet<EmbeddingDocument> EmbeddingDocuments { get; set; }
    public DbSet<MatchAnalysis> MatchAnalyses { get; set; }
    public DbSet<ResumeAnalysis> ResumeAnalyses { get; set; }
    public DbSet<ResumeDocument> ResumeDocuments { get; set; }
    public DbSet<VacancyDocument> VacancyDocuments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}