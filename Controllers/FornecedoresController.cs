using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Data;
using SuperMarket.Models;
using SuperMarket.ValidacaoDTO;

namespace SuperMarket.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly ApplicationDbContext _database;

        public FornecedoresController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult Salvar(FornecedorDTO fornecedorDTO)
        {
            if (ModelState.IsValid)
            {
                var fornecedor = new Fornecedor();
                fornecedor.Nome = fornecedorDTO.Nome;
                fornecedor.Email = fornecedorDTO.Email;
                fornecedor.Telefone = fornecedorDTO.Telefone;
                fornecedor.Status = true;

                _database.Fornecedores.Add(fornecedor);
                _database.SaveChanges();

                return RedirectToAction("ListaFornecedores", "Gestao");
            }
            else
            {
                return View("../Gestao/NovoFornecedor");
            } 
        }

        [HttpPost]
        public IActionResult Atualizar(FornecedorDTO fornecedorDTO)
        {
            if (ModelState.IsValid)
            {
                var fornecedor = _database.Fornecedores.First(fornecedor => fornecedor.Id == fornecedorDTO.Id);
                fornecedor.Nome = fornecedorDTO.Nome;
                fornecedor.Email = fornecedorDTO.Email;
                fornecedor.Telefone = fornecedorDTO.Telefone;
            
                _database.SaveChanges();

                return RedirectToAction("ListaFornecedores", "Gestao");
            }
            else
            {
                return View("../Gestao/NovoFornecedor");
            } 
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            if (id > 0)//Qualquer id maior que zero ja é um id valido.
            {
                var fornecedor = _database.Fornecedores.First(fornecedor => fornecedor.Id == id);
                fornecedor.Status = false;

                _database.SaveChanges();
            }

            return RedirectToAction("ListaFornecedores", "Gestao");
        }
    }
}