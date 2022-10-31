using System.ComponentModel.DataAnnotations;

namespace bugTracker.ViewModels;

public class RegisterViewModel 
{   
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.EmailAddress)]
    [Compare("Email")]
    public string ConfirmarEmail { get; set; }

    [DataType(DataType.Password)]
    public string Senha { get; set; }
    [DataType(DataType.Password)]
    [Compare("Senha")]
    public string ConfirmarSenha { get; set; }

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Cargo { get; set; }
}