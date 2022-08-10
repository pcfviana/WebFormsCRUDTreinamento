using Implanta.Common;

namespace Implanta.WebFormsCRUD.Presenter.Base
{
    public class PresenterBase<B, V, E> : Common.PresenterBase<B, V>
        where E : class
        where V : IView.Base.IViewImplanta
    {
        public PresenterBase(B BusinessFactory)
            : base(BusinessFactory)
        {

        }
        protected Operacao<E> Operacao { get; set; }


        protected void NovaOperacao()
        {
            Operacao = new Operacao<E>() { };
        }
    }
}
