using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Data;
using SuperMarket.Models;
using SuperMarket.ValidacaoDTO;

namespace SuperMarket.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _database;

        public ProdutosController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult Salvar(ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto();
                produto.Nome = produtoDTO.Nome;
                produto.Categoria = _database.Categorias.First(categoria => categoria.Id == produtoDTO.CategoriaId);
                produto.Fornecedor = _database.Fornecedores.First(fornecedor => fornecedor.Id == produtoDTO.FornecedorId);
                produto.PrecoDeCusto = produtoDTO.PrecoDeCusto;
                produto.PrecoDeVenda = produtoDTO.PrecoDeVenda;
                produto.UnidadeDeMedida = produtoDTO.UnidadeDeMedida;
                produto.Status = true;

                _database.Produtos.Add(produto);
                _database.SaveChanges();

                return RedirectToAction("ListaProdutos", "Gestao");
            }
            else
            {
                ViewBag.ListaCategorias = _database.Categorias.ToList();
                ViewBag.ListaFornecedores = _database.Fornecedores.ToList();

                return View("../Gestao/NovoProduto");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                var produto = _database.Produtos.First(produto => produto.Id == produtoDTO.Id);
                produto.Nome = produtoDTO.Nome;
                produto.Categoria = _database.Categorias.First(categoria => categoria.Id == produtoDTO.CategoriaId);
                produto.Fornecedor = _database.Fornecedores.First(fornecedor => fornecedor.Id == produtoDTO.FornecedorId);
                produto.PrecoDeCusto = produtoDTO.PrecoDeCusto;
                produto.PrecoDeVenda = produtoDTO.PrecoDeVenda;
                produto.UnidadeDeMedida = produtoDTO.UnidadeDeMedida;
                produto.Status = true;

                _database.SaveChanges();

                return RedirectToAction("ListaProdutos", "Gestao");
            }
            else
            {
                ViewBag.ListaCategorias = _database.Categorias.ToList();
                ViewBag.ListaFornecedores = _database.Fornecedores.ToList();

                return View("../Gestao/NovoProduto");
            }
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            if (id > 0)//Qualquer id maior que zero ja é um id valido.
            {
                var produto = _database.Produtos.First(produto => produto.Id == id);
                produto.Status = false;

                _database.SaveChanges();
            }

            return RedirectToAction("ListaProdutos", "Gestao");
        }

        [HttpPost]
        public IActionResult GetProduto(int id)
        {
            if (id < 1)
            {
                Response.StatusCode = 404;
                return Json(null);
            }

            var produto = _database.Produtos.Where(produto => produto.Status == true).Include(produto => produto.Categoria).Include(produto => produto.Fornecedor).First(produto => produto.Id == id);

            if (produto == null)
            {
                Response.StatusCode = 404;
                return Json(null);
            }

            Response.StatusCode = 200;
            return Json(produto);
        }
    }
}