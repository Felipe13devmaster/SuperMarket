using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Data;
using SuperMarket.Models;

namespace SuperMarket.Controllers
{
    public class EstoquesController : Controller
    {
        private readonly ApplicationDbContext _database;

        public EstoquesController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpPost]
         public IActionResult Salvar(Estoque estoque)
        {
            _database.Estoques.Add(estoque);
            _database.SaveChanges();

            return RedirectToAction("ListaEstoque", "Gestao");
        }

        [HttpPost]
        public IActionResult Atualizar(Estoque estoqueAtualizado)
        {
            var estoque = _database.Estoques.First(estoque => estoque.Id == estoqueAtualizado.Id);
            estoque.Produto = _database.Produtos.First(produto => produto.Id == estoqueAtualizado.ProdutoId);
            estoque.Quantidade = estoqueAtualizado.Quantidade;
            

            _database.SaveChanges();

            return RedirectToAction("ListaEstoque", "Gestao");
            
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            if (id > 0)
            {
                var estoque = _database.Estoques.First(estoque => estoque.Id == id);

                _database.Estoques.Remove(estoque);
                _database.SaveChanges();
            }

            return RedirectToAction("ListaEstoque", "Gestao");
        }
    }
}