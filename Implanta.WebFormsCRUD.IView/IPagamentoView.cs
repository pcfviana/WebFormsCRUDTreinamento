using Implanta.WebFormsCRUD.Entity.Concret;
using Implanta.WebFormsCRUD.Entity.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implanta.WebFormsCRUD.IView
{
    public interface IPagamentoView : IPagamentosEntity, Base.IViewEdicaoSimple
    {
        List<ClassificacoesPagamentosEntity> ListaClassificacoes { set; }
        bool BloquearExclusao { set; }
        bool BloquearCamposFavorecidoCPF { set; }
        bool Erro { get; set; }
    }
}
