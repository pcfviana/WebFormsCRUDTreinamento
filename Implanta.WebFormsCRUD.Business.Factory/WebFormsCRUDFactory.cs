
using Implanta.WebFormsCRUD.Business.Concret;
using Implanta.WebFormsCRUD.Business.Contract;

namespace Implanta.WebFormsCRUD.Business.Factory
{
    public static class WebFormsCRUDFactory
    {
        public static IPagamentosBusiness PagamentosBusiness() 
        {
            return new PagamentosBusiness();
        }
    }
}
