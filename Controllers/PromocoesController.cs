using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Data;
using SuperMarket.Models;
using SuperMarket.ValidacaoDTO;

namespace SuperMarket.Controllers
{
    public class PromocoesController : Controller
    {
        private readonly ApplicationDbContext _database;

        public PromocoesController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult Salvar(PromocaoDTO promocaoDTO)
        {
            if (ModelState.IsValid)
            {
                var promocao = new Promocao();
                promocao.Nome = promocaoDTO.Nome;
                promocao.Produto = _database.Produtos.First(produto => produto.Id == promocaoDTO.ProdutoId);
                promocao.PorcentagemDesconto = promocaoDTO.PorcentagemDesconto;
                promocao.Status = true;

                _database.Promocoes.Add(promocao);
                _database.SaveChanges();

                return RedirectToAction("ListaPromocao", "Gestao");
            }
            else
            {
                ViewBag.ListaProdutos = _database.Produtos.ToList();
                return View("../Gestao/NovaPromocao");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(PromocaoDTO promocaoDTO)
        {
            if (ModelState.IsValid)
            {
                var promocao = _database.Promocoes.First(promocao => promocao.Id == promocaoDTO.Id);

                promocao.Nome = promocaoDTO.Nome;
                promocao.Produto = _database.Produtos.First(produto => produto.Id == promocaoDTO.ProdutoId);
                promocao.PorcentagemDesconto = promocaoDTO.PorcentagemDesconto;

                _database.SaveChanges();

                return RedirectToAction("ListaPromocao", "Gestao");
            }
            else
            {
                return View("../Gestao/NovaPromocao");
            }
        }

         [HttpPost]
        public IActionResult Excluir(int id)
        {
            if (id > 0)
            {
                var promocao = _database.Promocoes.First(promocao => promocao.Id == id);
                promocao.Status = false;

                _database.SaveChanges();
            }

            return RedirectToAction("ListaPromocao", "Gestao");
        }
    }
}