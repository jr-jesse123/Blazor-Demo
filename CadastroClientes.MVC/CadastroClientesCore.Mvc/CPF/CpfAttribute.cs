using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientesCore.CPF
{
    [AttributeUsage(AttributeTargets.Property |    AttributeTargets.Field, AllowMultiple = false)]
    internal class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cpfValidator = new ValidadorCpf();

            if (value != null && cpfValidator.EhValido(value.ToString()))
            {
                return ValidationResult.Success;
            }
            else if (value == null)
            {
                return new ValidationResult("CPF é obrigatório");
            }
            else
            {
                return new ValidationResult("CPF inválido");
            }
        }
    }
}
