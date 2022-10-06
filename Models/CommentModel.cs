namespace bugTracker.Models;

public class CommentModel {
    public int ID {get; set;}
    public DateTime? Data {get; set;}
    public string? Texto {get; set;}

    public int TicketID { get; set; }
    public UserModel Autor { get; set; }

    
}
