using Microsoft.EntityFrameworkCore;
using bugTracker.Models;

namespace bugTracker.Data;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<ProjectModel>().HasMany(p => p.Admins).WithMany(m => m.ProjetosAdmin);
    //     modelBuilder.Entity<ProjectModel>().HasMany(p => p.Membros).WithMany(m => m.ProjetosMembro);
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

    }
   

    public DbSet<TicketModel> Tickets {get; set;}
    public DbSet<ProjectModel> Projetos {get; set;}
    public DbSet<UserModel> Usuarios {get; set;}
    public DbSet<HistoryModel> Historico {get; set;}
    public DbSet<CommentModel> Comentarios {get; set;}
    
}