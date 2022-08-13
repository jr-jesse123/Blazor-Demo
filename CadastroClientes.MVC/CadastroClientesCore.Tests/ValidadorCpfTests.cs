using CadastroClientesCore.CPF;
using FluentAssertions;

namespace CadastroClientesCore.Tests
{
    public class ValidadorCpfTests
    {
        [Theory(DisplayName = "EhValido retorna true para cpfs válidos")]
        [InlineData("366.616.780-20")]
        [InlineData("619.597.870-12")]
        [InlineData("242.346.130-53")]
        [InlineData("093.201.100-42")]
        public void Test1(string cpf)
        {
            var sut = new ValidadorCpf();
            sut.EhValido(cpf).Should().Be(true);
        }

        [Theory(DisplayName = "EhValido retorna true para cpfs válidos em quaisquer formatos")]
        [InlineData("366.616.780-20")]
        [InlineData("366.616.78020")]
        [InlineData("36661678020")]

        public void Test2(string cpf)
        {
            var sut = new ValidadorCpf();
            sut.EhValido(cpf).Should().Be(true);
        }


        [Theory(DisplayName = "EhValido retorna false para cpfs Inválidos")]
        [InlineData("366.616.780-21")]
        [InlineData("619.597.870-13")]
        [InlineData("242.346.130-54")]
        [InlineData("123")]
        [InlineData("cpf")]

        public void Test3(string cpf)
        {
            var sut = new ValidadorCpf();
            sut.EhValido(cpf).Should().Be(false);
        }


    }
}