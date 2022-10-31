using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using bugTracker.Models;

namespace bugTracker.Data;

public class BancoContext : IdentityDbContext<ApplicationUser>
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);

    }
   

    public DbSet<TicketModel> Tickets {get; set;}
    public DbSet<ProjectModel> Projetos {get; set;}
    public DbSet<HistoryModel> Historico {get; set;}
    public DbSet<CommentModel> Comentarios {get; set;}
    public DbSet<ApplicationUser> ApplicationUser {get; set;}
    
}