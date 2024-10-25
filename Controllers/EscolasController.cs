using Acesv.Models;
using Acesv2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Acesvv.Controllers
{
    public class EscolasController : Controller
    {
        private readonly BD _context;

        public EscolasController(BD context)
        {
            _context = context;
        }

                public async Task<IActionResult> Index()
        {
            return View(await _context.Escolas.ToListAsync());
        }

                public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Escolas == null)
            {
                return NotFound();
            }

            var escola = await _context.Escolas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escola == null)
            {
                return NotFound();
            }

            return View(escola);
        }

                public IActionResult Create()
        {
            return View();
        }

                                [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeEscola")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escola);
        }

                public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Escolas == null)
            {
                return NotFound();
            }

            var escola = await _context.Escolas.FindAsync(id);
            if (escola == null)
            {
                return NotFound();
            }
            return View(escola);
        }

                                [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeEscola")] Escola escola)
        {
            if (id != escola.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolaExists(escola.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(escola);
        }

                public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Escolas == null)
            {
                return NotFound();
            }

            var escola = await _context.Escolas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escola == null)
            {
                return NotFound();
            }

            return View(escola);
        }

                [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Escolas == null)
            {
                return Problem("Entity set 'BD.Escolas'  is null.");
            }
            var escola = await _context.Escolas.FindAsync(id);
            if (escola != null)
            {
                _context.Escolas.Remove(escola);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolaExists(int id)
        {
            return _context.Escolas.Any(e => e.Id == id);
        }
    }
}
