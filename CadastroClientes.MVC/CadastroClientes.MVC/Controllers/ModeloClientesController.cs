using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using CadastroClientes.MVC.Models;
using CadastroClientesCore.Data;

namespace CadastroClientes.MVC.Controllers
{
    public class ModeloClientesController : Controller
    {
        

        private RepositorioClientes repo { get; }
        
        public ModeloClientesController(RepositorioClientes repo)
        {
            this.repo = repo;
        }

        // GET: ModeloClientes
        public async Task<IActionResult> Index()
        {
            return View(repo.ObterTodos());
        }

        // GET: ModeloClientes/Details/5
        
        public async Task<IActionResult> Details(string id)
        {
            var clienteLocalizado = repo.ObterPorCPF(id);

            if (id == null || clienteLocalizado == null)
            {
                return NotFound();
            }

            return View(clienteLocalizado);
        }

        // GET: ModeloClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(ModeloCliente modeloCliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.Adicionar(modeloCliente);
                }
                catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("UNIQUE constraint failed: clientes.CPF") ?? false) 
                {
                    ModelState.AddModelError($"{nameof(modeloCliente)}.{nameof(modeloCliente.CPF)}", "Desculpe, já existe outro cliente com este cpf."  );
                    return View(modeloCliente);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Não foi possível adicionar o cliente. " + ex.Message);
                    return View(modeloCliente);
                }

            return RedirectToAction(nameof(Index));
            }
            
            return View(modeloCliente);
        }

        // GET: ModeloClientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {

            var clienteLocalizado = repo.ObterPorCPF(id);

            if (id == null || clienteLocalizado == null)
            {
                return NotFound();
            }

            return View(clienteLocalizado);

        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(string id, ModeloCliente modeloCliente)
        {
            if (id != modeloCliente.CPF)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repo.Atualizar(modeloCliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloClienteExists(modeloCliente.CPF))
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
            return View(modeloCliente);
        }

        // GET: ModeloClientes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {

            var clienteLocalizado = repo.ObterPorCPF(id);

            if (id == null || clienteLocalizado == null)
            {
                return NotFound();
            }

            return View(clienteLocalizado);


        }

        // POST: ModeloClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            
            var clienteLocalizado = repo.ObterPorCPF(id);

            if (id == null || clienteLocalizado == null)
            {
                return NotFound();
            }

            repo.Remover(clienteLocalizado);

            return RedirectToAction(nameof(Index));
        }

        private bool ModeloClienteExists(string id)
        {
            return !(repo.ObterPorCPF(id) == null);
        }
    }
}
