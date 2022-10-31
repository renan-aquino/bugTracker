using System.ComponentModel.DataAnnotations;

namespace bugTracker.Models;

public class TicketModel {
    public int ID {get; set;}
    [Required]
    public string Status {get; set;}
    [Required]
    public string Grau {get; set;}
    [Required]
    public string Tipo {get; set;}
    [Required]
    public string Descricao {get; set;}
    [Required]
    public DateTime DataCriacao {get; set;}
    public DateTime? DataAlteracao {get; set;}

    public int ProjetoID {get; set;}
    public ProjectModel Projeto { get; set; }
    // public UserModel? Criador { get; set; }

    // public ICollection<HistoryModel>? Historico { get; set; }
    public ICollection<CommentModel>? Comentarios { get; set; }
    
    }
