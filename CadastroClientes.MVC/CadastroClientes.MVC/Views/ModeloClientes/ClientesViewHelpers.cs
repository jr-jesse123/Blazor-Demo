using CadastroClientes.MVC.Models;

namespace CadastroClientes.MVC.Views.ModeloClientes
{
    //TODO: DELETAR
    public static class ClientesViewHelpers
    {
        public static string ObterClasseSemaforoParaPoderDeDecisao(PoderDeDecisao poderDeDecisao)
        {
            return poderDeDecisao switch
            {
                PoderDeDecisao.Limitado => "limitado",
                PoderDeDecisao.Elevado => "elevado",
                PoderDeDecisao.Total => "total",
                _ => throw new NotImplementedException()
            };
        }
    }
}
