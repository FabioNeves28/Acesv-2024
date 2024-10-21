using Acesv.Models;
using Acesv2.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Acesvv.Controllers
{
    public class DadosController : Controller
    {
        private readonly BD _context;
        private readonly ChaveADMRequirement _chaveADMRequirement;

        public DadosController(BD dadosContext, ChaveADMRequirement chaveADMRequirement)
        {
            _context = dadosContext;
            _chaveADMRequirement = chaveADMRequirement;
        }

        public ActionResult DownloadRelatorio()
        {
            using (var db = new BD())
            {
                var dados = db.Dados.Include(d => d.Escola).ToList();

                Document doc = new Document();
                MemoryStream ms = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                doc.Open();

                var mapeamentoCampos = new Dictionary<string, string>
                {
                    { "Escolas", "EscolaId" },
                    { "Nome Completo", "NomeCompleto" },
                    { "Telefone", "Telefone" },
                    { "Placa", "Placa" },
                    { "Apelido", "Apelido" },
                    { "CPF", "Cpf" },
                    { "Data de Nascimento", "Data_Nascimento" },
                    { "Prefixo", "Prefixo" },
                    { "Bairros", "Bairros" },
                    { "Veículo", "Veiculo" },
                    { "Ano", "Ano" },
                    { "CNH", "Cnh" },
                    { "Categoria", "CategoriaSelecionada" },
                    { "Validade", "Validade" },
                    { "Endereço", "Endereco" },
                    { "Bairro", "Bairro" },
                    { "CEP", "Cep" },
                    { "Número", "Número" },
                    { "Complemento", "Complemento" },
                };

                var headerFont = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, BaseColor.WHITE);
                var cellFont = new Font(Font.FontFamily.HELVETICA, 12, Font.NORMAL, BaseColor.BLACK);
                var headerBackgroundColor = new BaseColor(0, 156, 220);

                foreach (var dado in dados)
                {
                    PdfPTable table = new PdfPTable(2);
                    float[] columnWidths = new float[] { 2f, 4f };
                    table.SetWidths(columnWidths);

                    foreach (var colunaPersonalizada in mapeamentoCampos)
                    {
                        var nomeColuna = colunaPersonalizada.Key;
                        var nomePropriedade = colunaPersonalizada.Value;

                        string valor = nomePropriedade == "EscolaId" ? GetEscolasSelecionadas(dado.EscolaId) : GetValorCampo(dado, nomePropriedade);

                        PdfPCell headerCell = new PdfPCell(new Phrase(nomeColuna, headerFont));
                        headerCell.BackgroundColor = headerBackgroundColor;
                        table.AddCell(headerCell);

                        PdfPCell cell = new PdfPCell(new Phrase(valor, cellFont));
                        table.AddCell(cell);
                    }

                    doc.Add(table);
                    doc.NewPage();
                }

                doc.Close();

                byte[] pdfData = ms.ToArray();

                return File(pdfData, "application/pdf", "Dados.pdf");
            }
        }

        string GetValorCampo(object obj, string fieldName)
        {
            var propInfo = obj.GetType().GetProperty(fieldName);
            if (propInfo != null)
            {
                var value = propInfo.GetValue(obj, null);
                if (value != null)
                {
                    return value.ToString();
                }
            }
            return string.Empty;
        }

        string GetEscolasSelecionadas(List<int> escolaIds)
        {
            if (escolaIds == null)
            {
                return "Nenhuma escola encontrada";
            }

            var escolasSelecionadas = new List<string>();
            foreach (var escolaId in escolaIds)
            {
                var escola = _context.Escolas.Find(escolaId);
                if (escola != null)
                {
                    escolasSelecionadas.Add(escola.NomeEscola);
                }
            }
            return string.Join(", ", escolasSelecionadas);
        }

        public async Task<IActionResult> Index()
        {
            ChaveADMRequirement chaveAdm = new ChaveADMRequirement();
            if (!User.Identity.IsAuthenticated)
            {
                string returnUrl = "/Identity/Account/AccessDeniedLogin";
                return Redirect(returnUrl);
            }
            var userEmail = User.Identity.Name;
            string chaveADM = chaveAdm.Chama_ChaveADM(userEmail);
            if (chaveADM != "1")
            {
                string returnUrl = "/Identity/Account/AccessDenied?ReturnUrl=%2FDados";
                return Redirect(returnUrl);
            }

            var dados = await _context.Dados.Include(d => d.Escola).ToListAsync();

            foreach (var dado in dados)
            {
                if (dado.EscolaId != null && dado.EscolaId.Count > 0)
                {
                    var escolasSelecionadas = new List<string>();

                    foreach (var escolaId in dado.EscolaId)
                    {
                        var escola = await _context.Escolas.FindAsync(escolaId);
                        if (escola != null)
                        {
                            escolasSelecionadas.Add(escola.NomeEscola);
                        }
                    }

                    dado.EscolasSelecionadas = string.Join(", ", escolasSelecionadas);
                }
            }
            return View(dados);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dados == null)
            {
                return NotFound();
            }

            var dados = await _context.Dados
                .Include(d => d.Escola)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        public IActionResult Create()
        {
            var categorias = Enum.GetValues(typeof(Categoria))
                     .Cast<Categoria>()
                     .Select(c => new SelectListItem
                     {
                         Value = c.ToString(),
                         Text = c.ToString()
                     })
                     .ToList();

            ViewData["Categorias"] = categorias;
            ViewBag.Escolas = new MultiSelectList(_context.Escolas, "Id", "NomeEscola");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EscolaId,NomeCompleto,Telefone,Placa,Apelido,Cpf,Data_Nascimento,Prefixo,Bairros,Veiculo,Ano,Cnh,Categoria,CategoriaSelecionada,Validade,Endereco,Bairro,Cep,Número,Complemento")] Dados dados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Escolas = new SelectList(_context.Escolas, "Id", "NomeEscola");

            return View(dados);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "Nenhum registro foi encontrado.";
                return View("Error");
            }

            var dados = await _context.Dados.FindAsync(id);
            if (dados == null) { }

            var escolas = _context.Escolas.ToList();
            ViewBag.Escolas = escolas.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.NomeEscola,
                Selected = dados.EscolasSelecionadas != null && dados.EscolasSelecionadas.Contains(e.Id.ToString())
            }).ToList();

            var categorias = Enum.GetValues(typeof(Categoria))
                  .Cast<Categoria>()
                  .Select(c => new SelectListItem
                  {
                      Value = c.ToString(),
                      Text = c.ToString()
                  })
                  .ToList();

            ViewData["Categorias"] = categorias;
            return View(dados);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EscolaId,EscolasSelecionadas,NomeCompleto,Telefone,Placa,Apelido,Cpf,Data_Nascimento,Prefixo,Bairros,Veiculo,Ano,Cnh,CategoriaSelecionada,Validade,Endereco,Bairro,Cep,Número,Complemento")] Dados dados)
        {
            if (id != dados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var escolasSelecionadas = dados.EscolaId ?? new List<int>();
                    dados.EscolasSelecionadas = string.Join(",", escolasSelecionadas);

                    _context.Update(dados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosExists(dados.Id))
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

            var todasEscolas = await _context.Escolas.ToListAsync();
            var escolasSelecionaveis = todasEscolas.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.NomeEscola,
                Selected = dados.EscolasSelecionadas.Contains(e.NomeEscola)
            }).ToList();

            ViewData["EscolaId"] = escolasSelecionaveis;

            return View(dados);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dados == null)
            {
                ViewBag.ErrorMessage = "Nenhum ID de usuário foi fornecido para edição.";
                return NotFound();
            }

            var dados = await _context.Dados
                .Include(d => d.Escola)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dados == null)
            {
                return Problem("Entity set 'BD.Dados'  is null.");
            }
            var dados = await _context.Dados.FindAsync(id);
            if (dados != null)
            {
                _context.Dados.Remove(dados);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosExists(int id)
        {
            return _context.Dados.Any(e => e.Id == id);
        }
    }
}
