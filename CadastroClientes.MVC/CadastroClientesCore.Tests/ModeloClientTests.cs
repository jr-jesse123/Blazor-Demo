using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using CadastroClientes.MVC.Models;
using FluentAssertions;

namespace CadastroClientesCore.Tests
{
    public class ModeloClientTests
    {
        [Theory(DisplayName = "Idades são corretamente resolvidas de acordo com a data de nascimento")]
        [InlineData(2000, 12, 24, 2001, 10, 25, 1)]
        [InlineData(2000, 12, 24, 2001, 10, 24, 1)]
        [InlineData(2000, 01, 01, 2001, 01, 01, 1)]
        [InlineData(1980, 12, 24, 2020, 10, 25, 40)]

        public void Test1(
            int anoNasc, int mesNasc, int diaNasc,
            int anoAtual, int MesAtual, int diatual, int idadeEsperada)
        {   
            var nascimento = new DateOnly(anoNasc, mesNasc, diaNasc);
            var hoje = new DateOnly(anoAtual, MesAtual, diatual);

            ModeloCliente.ObterIdade(nascimento, hoje).Should().Be(idadeEsperada);
        }

        

        [Fact(DisplayName = "Poder de decisão para idade menor do que 18 sempre resulta em Limitado")]
        public void Test2()
        {
            var idades = obterIdades(0, 17);
            
            idades
                .Select(idade => ModeloCliente.ObterPoderDeDecisaoDeAcordoComAIdade(idade))
                .Should().AllBeEquivalentTo(PoderDeDecisao.Limitado);
                
        }

        [Fact(DisplayName = "Poder de decisão para idade maior do que 17 e menor que 25 sempre resulta em Elevado")]
        public void Test3()
        {
            var idades = obterIdades(18, 25);
            
            idades
                .Select(idade => ModeloCliente.ObterPoderDeDecisaoDeAcordoComAIdade(idade))
                .Should().AllBeEquivalentTo(PoderDeDecisao.Elevado);
        }

        [Fact(DisplayName = "Poder de decisão para idade maior do que 24 sempre resulta em Total")]
        public void Test4()
        {
            var idades = obterIdades(25, 1000);
            
            idades
                .Select(idade => ModeloCliente.ObterPoderDeDecisaoDeAcordoComAIdade(idade))
                .Should().AllBeEquivalentTo(PoderDeDecisao.Total);
        }

        private int[] obterIdades(int idadeMinima, int IdadeMaxima)
        {
            return Enumerable.Range(idadeMinima, IdadeMaxima - idadeMinima).ToArray();
        }
    }
}
