namespace bugTracker.Models;

public class HistoryModel {
    public int ID {get; set;}
    public string? Status {get; set;}
    public DateTime? Data {get; set;}

    public int TicketID { get; set; }
    public UserModel Autor { get; set; }
    
    
}