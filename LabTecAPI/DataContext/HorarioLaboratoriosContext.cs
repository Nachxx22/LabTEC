
namespace LabTecAPI.DataContext;
using LabTecAPI.Models;
using Microsoft.EntityFrameworkCore;

public class HorariosLaboratoriosContext : DbContext
{
    public HorariosLaboratoriosContext(DbContextOptions<HorariosLaboratoriosContext> options) : base(options)
    {
    }

    public DbSet<HorarioLaboratorio> HorariosLaboratorios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<HorarioLaboratorio>().HasIndex(c => c.HorarioID).IsUnique();
    }
}