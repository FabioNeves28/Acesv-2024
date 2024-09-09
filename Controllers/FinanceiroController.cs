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

        // GET: Financeiro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Financeiro.ToListAsync());
        }

        // GET: Financeiro/Details/5
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

        // GET: Financeiro/Create
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

        // POST: Financeiro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Mes,Saldo_Mes,Arrecadacao_Mensalidade_Atrasada,Arrecadacao_Mensalidade_Antecipadas,Total_Entradas,Vencimento,Contabilidade,Tarifa_Bancaria,Apolice_Seguro,Advogada,Renovacao_Assinatura,Taxas_Bancarias,Taxa_Internet,Total_Gastos,Total_Liquido")] Financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                // Convertendo as colunas de string para double

                _context.Add(financeiro);
                await _context.SaveChangesAsync();





                // Faça algo com pdfStream, como salvá-lo ou enviá-lo para o cliente


            }
            return View(financeiro);
        }


        // GET: Financeiro/Edit/5
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

        // POST: Financeiro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Financeiro/Delete/5
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

        // POST: Financeiro/Delete/5
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
