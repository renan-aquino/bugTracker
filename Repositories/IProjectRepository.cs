using bugTracker.Models;

namespace bugTracker.Repositories;

public interface IProjectRepository
{
    ProjectModel GetProject(int id);
    List<ProjectModel> GetAllProjects();
    void AddProject(ProjectModel projeto);
    void UpdateProject(ProjectModel projeto);
    void RemoveProject(int id);

    public TicketModel GetTicket(int id);
    void UpdateTicket(TicketModel ticket);

    Task<bool> SaveChangesAsync();
}
