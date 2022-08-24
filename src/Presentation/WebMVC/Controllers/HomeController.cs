using System.Diagnostics;
using Application.Models;
using Application.Services.Catalog.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITemplateService _templateService;
    private IResumeService _resumeService;

    public HomeController(ILogger<HomeController> logger, ITemplateService templateService, IResumeService resumeService)
    {
        _logger = logger;
        _templateService = templateService;
        _resumeService = resumeService;
    }

    public async Task<IActionResult> Index()
    {
        return View();
        
    }  
     
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
