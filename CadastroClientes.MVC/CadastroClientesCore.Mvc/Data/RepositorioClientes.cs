using CadastroClientes.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientesCore.Data
{
    public class RepositorioClientes : IDisposable
    {
        public RepositorioClientes(CadastroClientesContext context)
        {
            Context = context;
        }

        private CadastroClientesContext Context { get; }
        
        public IEnumerable<ModeloCliente> ObterTodos()
        {
            return Context.clientes.ToList();
        }

        public ModeloCliente ObterPorCPF(string cpf)
        {
            return Context.clientes.FirstOrDefault(c => c.CPF == cpf);
        }

        public void Adicionar(ModeloCliente modeloCliente)
        {
            Context.clientes.Add(modeloCliente);
            Context.SaveChanges();
        }

        public void Atualizar(ModeloCliente modeloCliente)
        {
            Context.Entry(modeloCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        public void Remover(ModeloCliente modeloCliente)
        {
            Context.clientes.Remove(modeloCliente);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

    }
}
