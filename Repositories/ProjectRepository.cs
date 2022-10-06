using bugTracker.Models;
using bugTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace bugTracker.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly BancoContext _context;

    public ProjectRepository(BancoContext bancoContext)
    {
        this._context = bancoContext;
    }

   

    public void AddProject(ProjectModel projeto)
    {
        _context.Projetos.Add(projeto);
    }

    public List<ProjectModel> GetAllProjects()
    {
        return _context.Projetos.ToList();
    }

    public ProjectModel GetProject(int id)
    {
       return _context.Projetos.Include(p => p.Tickets).FirstOrDefault(p => p.ID == id);
    }

    public void RemoveProject(int id)
    {
        _context.Projetos.Remove(GetProject(id));
    }

    public void UpdateProject(ProjectModel projeto)
    {
        _context.Projetos.Update(projeto);
    }

    public async Task<bool> SaveChangesAsync()
    {
        if(await _context.SaveChangesAsync() > 0)
        {
            return true;
        }
        return false;
    }

    public TicketModel GetTicket(int id)
    {
       return _context.Tickets.FirstOrDefault(t => t.ID == id);
    }

}
