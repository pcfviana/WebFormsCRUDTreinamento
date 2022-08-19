using Implanta.WebFormsCRUD.Business.Contract;
using Implanta.WebFormsCRUD.Business.Factory;
using Implanta.WebFormsCRUD.Entity.Concret;
using Implanta.WebFormsCRUD.IView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implanta.WebFormsCRUD.Presenter
{
    public class PagamentosPresenter : Base.PresenterBase<IPagamentosBusiness, IPagamentosView, PagamentosGridEntity>
    {
        public PagamentosPresenter(IPagamentosView view) 
            : base(WebFormsCRUDFactory.PagamentosBusiness())
        {
            this.View = view;
            Inicializar();
        }

        private void Inicializar()
        {
            View.Inicia += View_Inicia;
            View.Busca += View_Busca; ;
        }
        private void View_Inicia(object sender, EventArgs e)
        {
            View.ListaResultado = new List<PagamentosGridEntity>();
        }
        private void View_Busca(object sender, Common.EventParam<Entity.Concret.FilterEntity.FilterEntityPagamento> e)
        {
            View.ListaResultado = BusinessFactory.BuscarParaGridView(e.Parametro);
        }

     
    }
}
