using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientesCore.CPF
{
    public class ValidadorCpf
    {

        public bool EhValido(string cpf)
        {
            return new CPFValidator(false).IsValid(cpf);   
        }
    }

    
}
