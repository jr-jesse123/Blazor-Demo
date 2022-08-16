using CadastroClientes.MVC.Models;
using CadastroClientesCore.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadastroClientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloClienteController : ControllerBase
    {
        private readonly RepositorioClientes repositorio;
        private readonly IHttpContextAccessor contextAccessor;

        public ModeloClienteController(RepositorioClientes repositorio, IHttpContextAccessor  contextAccessor)
        {
            
            this.repositorio = repositorio;
            this.contextAccessor = contextAccessor;
            contextAccessor.HttpContext.Response.Headers
                .Add("Access-Control-Allow-Credential", "true");
            contextAccessor.HttpContext.Response.Headers
                .Add("Access-Control-Allow-Origin", "*");
            contextAccessor.HttpContext.Response.Headers
                .Add("Access-Control-Allow-Methods", "GET,OPTIONS,PATCH,DELETE,POST,PUT");
            contextAccessor.HttpContext.Response.Headers
                .Add("Access-Control-Allow-HEADERS", "X-CSRF-Token, X-Requested-With, Accept, Accept-Language, Content-Language, Content-Type");

        }

        // GET: api/<ModeloClienteController>
        [HttpGet]
        public IEnumerable<ModeloCliente> Get()
        {
            return repositorio.ObterTodos();
        }

        // GET api/<ModeloClienteController>/5
        [HttpGet("{id}")]
        public ModeloCliente Get(string cpf)
        {
            return repositorio.ObterPorCPF(cpf);
        }

        // POST api/<ModeloClienteController>
        [HttpPost]
        public void Post([FromBody] ModeloCliente cliente)
        {
            repositorio.Adicionar(cliente);
        }

        // PUT api/<ModeloClienteController>/5
        [HttpPut("{id}")]
        public void Put(string cpf, [FromBody] ModeloCliente cliente)
        {
            var clienteAtual = repositorio.ObterPorCPF(cliente.CPF);
            
            repositorio.Atualizar(clienteAtual);
        }

        // DELETE api/<ModeloClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(string cpf)
        {
            var cliente = repositorio.ObterPorCPF(cpf);
            repositorio.Remover(cliente);
        }
    }
}
