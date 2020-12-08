using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Data;
using SuperMarket.ValidacaoDTO;

namespace SuperMarket.Controllers
{
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext _database;

        public GestaoController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaCategorias()
        {
            var listaDeCategorias = _database.Categorias.Where(categorias => categorias.Status == true).ToList();

            return View(listaDeCategorias);
        }

        public IActionResult NovaCategoria()
        {
            return View();
        }

        public IActionResult EditarCategoria(int id)
        {
            var categoria = _database.Categorias.First(categoria => categoria.Id == id);
            var categoriaDTO = new CategoriaDTO();

            categoriaDTO.Id = categoria.Id;
            categoriaDTO.Nome = categoria.Nome;

            return View(categoriaDTO);
        }

        public IActionResult ListaFornecedores()
        {
            var listaDeFornecedores = _database.Fornecedores.Where(fornecedores => fornecedores.Status == true).ToList();

            return View(listaDeFornecedores);
        }

        public IActionResult NovoFornecedor()
        {
            return View();
        }

        public IActionResult EditarFornecedor(int id)
        {
            var fornecedor = _database.Fornecedores.First(fornecedor => fornecedor.Id == id);
            var fornecedorDTO = new FornecedorDTO();

            fornecedorDTO.Id = fornecedor.Id;
            fornecedorDTO.Nome = fornecedor.Nome;
            fornecedorDTO.Email = fornecedor.Email;
            fornecedorDTO.Telefone = fornecedor.Telefone;

            return View(fornecedorDTO);
        }

        public IActionResult ListaProdutos()
        {
            // Include para noao trazer nulo na consulta dos relacionamentos.
            var listaDeProdutos = _database.Produtos.Include(produto => produto.Categoria).Include(produto => produto.Fornecedor).Where(produtos => produtos.Status == true).ToList();

            return View(listaDeProdutos);
        }

        public IActionResult NovoProduto()
        {
            ViewBag.ListaCategorias = _database.Categorias.ToList();//Qualquer Iaction que apontar pra view(NovoProduto) tem que trazer estas viewbags correspondentes.
            ViewBag.ListaFornecedores = _database.Fornecedores.ToList();

            return View();
        }

        public IActionResult EditarProduto(int id)
        {
            var produto = _database.Produtos.Include(produto => produto.Categoria).Include(produto => produto.Fornecedor).First(produto => produto.Id == id);
            var produtoDTO = new ProdutoDTO();

            produtoDTO.Id = produto.Id;
            produtoDTO.Nome = produto.Nome;
            produtoDTO.CategoriaId = produto.Categoria.Id;
            produtoDTO.FornecedorId = produto.Fornecedor.Id;
            produtoDTO.PrecoDeCusto = produto.PrecoDeCusto;
            produtoDTO.PrecoDeVenda = produto.PrecoDeVenda;
            produtoDTO.UnidadeDeMedida = produto.UnidadeDeMedida;

            ViewBag.ListaCategorias = _database.Categorias.ToList();
            ViewBag.ListaFornecedores = _database.Fornecedores.ToList();

            return View(produtoDTO);
        }

        public IActionResult ListaPromocao()
        {
            var listaPromocoes = _database.Promocoes.Include(promocao => promocao.Produto).Where(promocoes => promocoes.Status == true).ToList();
            return View(listaPromocoes);
        }

        public IActionResult Novapromocao()
        {
            ViewBag.ListaProdutos = _database.Produtos.ToList();

            return View();
        }

        public IActionResult EditarPromocao(int id)
        {
            var promocao = _database.Promocoes.Include(promocao => promocao.Produto).First(promocao => promocao.Id == id);
            var promocaoDTO = new PromocaoDTO();

            promocaoDTO.Id = promocao.Id;
            promocaoDTO.Nome = promocao.Nome;
            promocaoDTO.ProdutoId = promocao.Produto.Id;
            promocaoDTO.PorcentagemDesconto = promocao.PorcentagemDesconto;

            ViewBag.ListaProdutos = _database.Produtos.ToList();

            return View(promocaoDTO);
        }

        public IActionResult ListaEstoque()
        {
            var listaEstoque = _database.Estoques.Include(estoque => estoque.Produto).ToList();

            return View(listaEstoque);
        }

        public IActionResult NovoEstoque()
        {
            ViewBag.ListaProdutos = _database.Produtos.ToList();

            return View();
        }

        public IActionResult EditarEstoque(int id)
        {
            ViewBag.ListaProdutos = _database.Produtos.ToList();
            return View();
        }
    }
}