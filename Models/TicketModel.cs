using System.ComponentModel.DataAnnotations.Schema;

namespace bugTracker.Models;

public class TicketModel {
    public int ID {get; set;}
    public string? Status {get; set;}
    public string? Grau {get; set;}
    public string? Tipo {get; set;}
    public string? Descricao {get; set;}
    public DateTime? DataCriacao {get; set;}
    public DateTime? DataAlteracao {get; set;}

    public int ProjetoID {get; set;}
    public ProjectModel Projeto { get; set; }
    public UserModel? Criador { get; set; }

    public ICollection<HistoryModel>? Historico { get; set; }
    public ICollection<CommentModel>? Comentarios { get; set; }
    
    }
