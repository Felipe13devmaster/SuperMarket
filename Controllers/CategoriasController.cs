using Microsoft.AspNetCore.Mvc;
using SuperMarket.Data;
using SuperMarket.Models;
using SuperMarket.ValidacaoDTO;
using System;
using System.Linq;

namespace SuperMarket.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _database;

        public CategoriasController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult Salvar(CategoriaDTO categoriaDTO)
        {
            if (ModelState.IsValid)//Se todas as regras de validação da CategoriaDTO forem atendidas
            {
                var categoria = new Categoria();
                categoria.Nome = categoriaDTO.Nome;
                categoria.Status = true;
                _database.Categorias.Add(categoria);
                _database.SaveChanges();

                return RedirectToAction("ListaCategorias","Gestao");
            }
            else
            {
                return View("../Gestao/NovaCategoria");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(CategoriaDTO categoriaDTO)
        {
            if (ModelState.IsValid)//Se todas as regras de validação da CategoriaDTO forem atendidas
            {
                var categoria = _database.Categorias.First(categoria => categoria.Id == categoriaDTO.Id);
                categoria.Nome = categoriaDTO.Nome;
                
                _database.SaveChanges();

                return RedirectToAction("ListaCategorias","Gestao");
            }
            else
            {
                return View("../Gestao/EditarCategoria");
            }
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            if (id > 0)//Qualquer id maior que zero ja é um id valido.
            {
                var categoria = _database.Categorias.First(categoria => categoria.Id == id);
                categoria.Status = false;

                _database.SaveChanges();
            }

            return RedirectToAction("ListaCategorias", "Gestao");
        }
    }
}