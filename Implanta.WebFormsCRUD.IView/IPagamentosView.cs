using Implanta.WebFormsCRUD.Entity.Concret;
using Implanta.WebFormsCRUD.Entity.Concret.FilterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implanta.WebFormsCRUD.IView
{
    public interface IPagamentosView : Base.IViewBusca<PagamentosGridEntity, FilterEntityPagamento>
    {
        FilterEntityPagamento Filtro {get;}
    }
}
