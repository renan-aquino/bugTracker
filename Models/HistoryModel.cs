namespace bugTracker.Models;

public class HistoryModel {
    public int ID {get; set;}
    public string? Status {get; set;}
    public string? Grau {get; set;}
    public string? Tipo {get; set;}
    public DateTime Data {get; set;}

    public int TicketID { get; set; }
    public TicketModel Ticket { get; set; }

    public string AutorNome { get; set; }
    public ApplicationUser Autor { get; set; }
    
    
}