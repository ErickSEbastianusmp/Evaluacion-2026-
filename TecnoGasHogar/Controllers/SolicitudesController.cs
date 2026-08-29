using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoGasHogar.Data;
using TecnoGasHogar.Models;

namespace TecnoGasHogar.Controllers;

public class SolicitudesController : Controller
{
    private readonly ApplicationDbContext _context;

    public SolicitudesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Solicitudes
    public async Task<IActionResult> Index()
    {
        var solicitudes = await _context.Solicitudes.ToListAsync();
        return View(solicitudes);
    }

    // GET: Solicitudes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Solicitudes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SolicitudServicio solicitud)
    {
        if (ModelState.IsValid)
        {
            solicitud.FechaRegistro = DateTime.Now;
            _context.Add(solicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(solicitud);
    }
}