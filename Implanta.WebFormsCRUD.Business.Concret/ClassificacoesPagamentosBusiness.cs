using Implanta.WebFormsCRUD.Business.Contract;
using Implanta.WebFormsCRUD.Entity.Concret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implanta.WebFormsCRUD.Business.Concret
{
    public class ClassificacoesPagamentosBusiness : IClassificacoesPagamentosBusiness
    {
        public List<ClassificacoesPagamentosEntity> Buscar()
        {
            List<ClassificacoesPagamentosEntity> retorno = new List<ClassificacoesPagamentosEntity> 
            {
                 new ClassificacoesPagamentosEntity { IdClassificacaoPagamento = 1, Descricao = "Semanal" },
                 new ClassificacoesPagamentosEntity { IdClassificacaoPagamento = 2, Descricao = "Quinzenal" },
                 new ClassificacoesPagamentosEntity { IdClassificacaoPagamento = 3, Descricao = "Mensal" }
            };

            return retorno;
        }
    }
}
