using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implanta.WebFormsCRUD.Entity.Concret
{
    public class PagamentosGridEntity
    {
        public Guid IdPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public int Numero { get; set; }
        public decimal Valor { get; set; }
        public string Favorecido { get; set; }
    }
}
