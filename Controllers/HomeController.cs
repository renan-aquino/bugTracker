using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bugTracker.Models;
using bugTracker.Repositories;
using bugTracker.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace bugTracker.Controllers;

public class HomeController : Controller
{
    private readonly IProjectRepository _repository;


    public HomeController(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Projects()
    {
        // ClaimsPrincipal currentUser = this.User;
        // var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

        
        
        var projetos = _repository.GetAllProjects();
        return View(projetos);
    }

    public IActionResult ProjectX(int id)
    {
        var projeto = _repository.GetProject(id);
        return View(projeto);
    }

    public IActionResult CreateProject(int? id)
    {
        if(id == null)
            return View(new ProjectModel());
        else
        {
            var projeto = _repository.GetProject((int) id);
            return View(projeto);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject(ProjectModel projeto)
    {   
        if (projeto.ID > 0)
            _repository.UpdateProject(projeto);
        else
            _repository.AddProject(projeto);

        if(await _repository.SaveChangesAsync())
            return RedirectToAction("Projects");
        else
            return View(projeto);
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        _repository.RemoveProject(id);

        await _repository.SaveChangesAsync();
        return RedirectToAction("Projects");
    }

    public IActionResult CreateTicket(TicketViewModel vm)
    {    
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewTicket(TicketViewModel vm)
    {
        if(!ModelState.IsValid)
            return RedirectToAction("Projects", new { id = vm.ProjetoID });

        var projeto = _repository.GetProject(vm.ProjetoID);

        if(vm.TicketID == 0)
        {
            projeto.Tickets = projeto.Tickets ?? new List<TicketModel>();
            projeto.Tickets.Add(new TicketModel
            { 
                Status = "Aberto",
                Descricao = vm.Descricao,
                Grau = vm.Grau,
                Tipo = vm.Tipo,
                DataCriacao = DateTime.Now
                
            });
    
            _repository.UpdateProject(projeto);

        }

        await _repository.SaveChangesAsync();

        return RedirectToAction("ProjectX", new { id = vm.ProjetoID });
    }

    public IActionResult TicketInfo(int id)
    {
        TicketModel ticket = _repository.GetTicket(id);
        return View(ticket);
    }

    public IActionResult Comment(CommentViewModel vm)
    {
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewComment(CommentViewModel vm)
    {
        if(!ModelState.IsValid)
            return RedirectToAction("TicektInfo", new { id = vm.TicketID });

        var ticket = _repository.GetTicket(vm.TicketID);

        if(vm.CommentID == 0)
        {
            ticket.Comentarios = ticket.Comentarios ?? new List<CommentModel>();
            ticket.Comentarios.Add(new CommentModel { Texto = vm.Texto });
    
            _repository.UpdateTicket(ticket);

        }

        await _repository.SaveChangesAsync();

        return RedirectToAction("TicketInfo", new { id = vm.TicketID });
    }

    // public IActionResult History(HistoryModel vm)
    // {    
    //     return View(vm);
    // }

}
