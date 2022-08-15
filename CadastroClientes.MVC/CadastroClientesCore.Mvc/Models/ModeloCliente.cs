using CadastroClientesCore.CPF;
using System.ComponentModel.DataAnnotations;
using System;

namespace CadastroClientes.MVC.Models
{
    public class ModeloCliente
    {
        public static int ObterIdade(DateOnly nascimento, DateOnly hoje)
        {
            return hoje.Year - nascimento.Year + (hoje.DayOfYear > nascimento.DayOfYear ? 1 : 0);
        }

        public static PoderDeDecisao ObterPoderDeDecisaoDeAcordoComAIdade(int idade)
        {
            return
                idade switch
                {
                    < 18 => PoderDeDecisao.Limitado,
                    < 25 => PoderDeDecisao.Elevado,
                    _ => PoderDeDecisao.Total
                };
        }


        [Required(ErrorMessage = "{0} é Obrigatório"), Cpf]
        public string CPF { get; set; }

        public DateOnly DataNascimento { get; set; }

        public int Idade { get => ObterIdade(DataNascimento, DateOnly.FromDateTime(DateTime.Now)); }

        //public int Idade { get; set; }
        [Required(ErrorMessage = "{0} é Obrigatório")]
        public string Nome { get; set; }
        public PoderDeDecisao PoderDeDecisao { get => ObterPoderDeDecisaoDeAcordoComAIdade(Idade); }

    }

    

    public enum PoderDeDecisao
    {
        Limitado,
        Elevado,
        Total
    }
}
