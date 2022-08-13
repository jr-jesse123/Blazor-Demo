using CadastroClientesCore.CPF;
using System.ComponentModel.DataAnnotations;

namespace CadastroClientes.MVC.Models
{
    public class ModeloCliente
    {
        [Required, Cpf]
        public string CPF { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string Nome { get; set; }
        
    }
}
