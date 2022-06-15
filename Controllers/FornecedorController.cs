
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prod_.Data;
using Prod_.Models;

namespace Prod_.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly ApplicationDbContext _appContext;
        public FornecedorController(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }

        public IActionResult Index(int Id)
        {
            var allTasks = _appContext.Fornecedores.ToList();
            var allTask = _appContext.Produtos.ToList();

            if (allTasks == null || allTask == null)
            {
                return BadRequest();
            }
            return View(allTasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FornecedorId, Nome, Email, Nivel, Produto_")] Fornecedor fornecedor)
        {
            /*_appContext.Add(fornecedor);
            await _appContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/

            if (ModelState.IsValid)
            {
                _appContext.Add(fornecedor);
                await _appContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? Id)
        {

            if (Id == null)
            {
                return NotFound();
            }

            var fornecedor = await _appContext.Fornecedores.FindAsync(Id);
            var produto = await _appContext.Produtos.FindAsync(Id);

            if (fornecedor == null || produto == null)
            {
                return BadRequest();
            }
            return View(fornecedor);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var fornecedor = await _appContext.Fornecedores.FindAsync(Id);
            var produto = await _appContext.Produtos.FindAsync(Id);

            if (produto == null || fornecedor == null)
            {
                return BadRequest();
            }
            return View(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? Id, Fornecedor fornecedor)
        {
            if (Id == null)
            {
                return NotFound();
            }            
            var dadosAntigos = _appContext.Fornecedores.AsNoTracking().FirstOrDefault(f => f.FornecedorId == Id);
            var dadosAntigo = _appContext.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == Id);

            if (ModelState.IsValid)
            {

                _appContext.Update(fornecedor);
                await _appContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(fornecedor);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var fornecedor = await _appContext.Fornecedores.FindAsync(Id);
            var produto = await _appContext.Produtos.FindAsync(Id);
            if (fornecedor == null || produto == null)
            {
                return BadRequest();
            }
            return View(fornecedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            var fornecedor = await _appContext.Fornecedores.FindAsync(Id);
            _appContext.Fornecedores.Remove(fornecedor);
            await _appContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
