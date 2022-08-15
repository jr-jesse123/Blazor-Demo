using CadastroClientesCore.CPF;
using System.ComponentModel.DataAnnotations;
using System;

namespace CadastroClientes.MVC.Models
{
    public class ModeloCliente
    {
        public static int ObterIdade(DateTime nascimento, DateOnly hoje)
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

        [Required(ErrorMessage = "{0} é Obrigatório")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} é Obrigatório")] //TODO: VALIDAR DATA.
        [Display(Name = "Data de Nascimento")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataNascimento { get; set; }
        

        public int Idade { get => ObterIdade(DataNascimento, DateOnly.FromDateTime(DateTime.Now)); }

        [Display(Name = "Poder de Decisão")]
        public PoderDeDecisao PoderDeDecisao { get => ObterPoderDeDecisaoDeAcordoComAIdade(Idade); }

    }

    

    public enum PoderDeDecisao
    {
        Limitado,
        Elevado,
        Total
    }
}
