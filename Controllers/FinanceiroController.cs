using Acesv2.Models;
using Acesvv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Acesvv.Controllers
{
    public class FinanceiroController : Controller
    {
        private readonly BD _context;

        public FinanceiroController(BD context)
        {
            _context = context;
        }

                public async Task<IActionResult> Index()
        {
            return View(await _context.Financeiro.ToListAsync());
        }

                public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Financeiro == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro
                .FirstOrDefaultAsync(m => m.ID == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

                public IActionResult Create()
        {
            var meses = Enum.GetValues(typeof(Mes)).Cast<Mes>().Select(m => new SelectListItem
            {
                Value = m.ToString(),
                Text = m.ToString()
            }).ToList();

            ViewData["Mes"] = meses;
            return View();
        }

                                [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Mes,Saldo_Mes,Arrecadacao_Mensalidade_Atrasada,Arrecadacao_Mensalidade_Antecipadas,Total_Entradas,Vencimento,Contabilidade,Tarifa_Bancaria,Apolice_Seguro,Advogada,Renovacao_Assinatura,Taxas_Bancarias,Taxa_Internet,Total_Gastos,Total_Liquido")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(financeiro);
                await _context.SaveChangesAsync();





                

            }
            return View(financeiro);
        }


                public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Financeiro == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro.FindAsync(id);
            if (financeiro == null)
            {
                return NotFound();
            }
            return View(financeiro);
        }

                                [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Saldo_Mes,Arrecadacao_Mensalidade_Atrasada,Arrecadacao_Mensalidade_Antecipadas,Total_Entradas,Vencimento,Contabilidade,Tarifa_Bancaria,Apolice_Seguro,Advogada,Renovacao_Assinatura,Taxas_Bancarias,Taxa_Internet,Total_Gastos,Total_Liquido")] Financeiro financeiro)
        {
            if (id != financeiro.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceiroExists(financeiro.ID))
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
            return View(financeiro);
        }

                public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Financeiro == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro
                .FirstOrDefaultAsync(m => m.ID == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

                [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Financeiro == null)
            {
                return Problem("Entity set 'BD.Financeiro'  is null.");
            }
            var financeiro = await _context.Financeiro.FindAsync(id);
            if (financeiro != null)
            {
                _context.Financeiro.Remove(financeiro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceiroExists(int id)
        {
            return _context.Financeiro.Any(e => e.ID == id);
        }
    }
}
