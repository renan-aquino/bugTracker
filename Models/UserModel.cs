using System.ComponentModel.DataAnnotations.Schema;

namespace bugTracker.Models;

public class UserModel {
    public int ID {get; set;}
    public string? Nome {get; set;}
    public string? Cargo {get; set;}
    public string? Senha {get; set;}
    public string? Email {get; set;}
    public ICollection<TicketModel>? Tickets { get; set; }
    public ICollection<CommentModel>? Comentarios { get; set; }
    public ICollection<HistoryModel>? Atualizacoes { get; set; }

    
}