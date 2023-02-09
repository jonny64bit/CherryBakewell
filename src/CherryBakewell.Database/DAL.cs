using CherryBakewell.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CherryBakewell.Database;

public class DAL : DbContext
{
    public DAL(DbContextOptions<DAL> options) : base(options)
    {
    }

    public DAL()
    {
    }

    public virtual DbSet<Calculation> Calculations { get; set; }

    public void AttachModified(object entity)
    {
        Entry(entity).State = EntityState.Modified;
    }

    public void Detach(object entity)
    {
        Entry(entity).State = EntityState.Detached;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Calculation>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).UseIdentityColumn();
            entity.ToTable("Calculations");
        });
    }
}