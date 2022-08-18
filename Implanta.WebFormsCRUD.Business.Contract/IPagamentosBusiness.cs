using Implanta.WebFormsCRUD.Entity.Concret;
using Implanta.WebFormsCRUD.Entity.Concret.FilterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implanta.WebFormsCRUD.Business.Contract
{
    public partial interface IPagamentosBusiness
    {
        PagamentosEntity Recuperar(Guid idPagamento);
        List<PagamentosEntity> Buscar(FilterEntityPagamento filtro);
        List<PagamentosGridEntity> BuscarParaGridView(FilterEntityPagamento filtro);
    }
}
