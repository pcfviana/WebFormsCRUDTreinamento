using Implanta.WebFormsCRUD.Entity.Concret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implanta.WebFormsCRUD.Business.Contract
{
    public interface IClassificacoesPagamentosBusiness
    {
        List<ClassificacoesPagamentosEntity> Buscar();
    }
}
