using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bugTracker.Models;
using bugTracker.Repositories;
using bugTracker.ViewModels;

namespace bugTracker.Controllers;

public class HomeController : Controller
{
    private readonly IProjectRepository _repository;

    public HomeController(IProjectRepository repository)
    {
        _repository = repository;

    }

    public IActionResult Projects()
    {
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
        // if(id == null)
            return View(vm);
        // else
        // {
        //     var ticket = _repository.GetProject((int) id);
        //     return View(ticket);
        // }
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
            projeto.Tickets.Add(new TicketModel { Descricao = vm.Descricao });
    
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
}
