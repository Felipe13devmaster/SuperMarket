using Microsoft.AspNetCore.Mvc;
using SuperMarket.Data;

namespace SuperMarket.Controllers
{
    public class SaidasController : Controller
    {
        private readonly ApplicationDbContext _database;

        public SaidasController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult Salvar()
        {
            if (ModelState.IsValid)
            {
                // _database.Produtos.Add();
                _database.SaveChanges();

                return RedirectToAction("ListaProdutos", "Gestao");
            }
            else
            {
                return View("../Gestao/NovoProduto");
            }
        }

        [HttpPost]
        public IActionResult Atualizar()
        {
            if (ModelState.IsValid)
            {
                _database.SaveChanges();

                return RedirectToAction("ListaProdutos", "Gestao");
            }
            else
            {
                return View("../Gestao/NovoProduto");
            }
        }

         [HttpPost]
        public IActionResult Excluir(int id)
        {
            if (id > 0)
            {
                _database.SaveChanges();
            }

            return RedirectToAction("ListaProdutos", "Gestao");
        }
    }
}