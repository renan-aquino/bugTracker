namespace bugTracker.Models;

public class ProjectModel {
    public int ID {get; set;}
    public string? Nome {get; set;}
    
    public ICollection<TicketModel>? Tickets { get; set; }

}