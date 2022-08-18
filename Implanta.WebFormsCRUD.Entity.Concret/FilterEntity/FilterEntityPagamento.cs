using Implanta.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implanta.WebFormsCRUD.Entity.Concret.FilterEntity
{
    public class FilterEntityPagamento : BaseFilterEntity
    {
        public Guid IdPagamento { get; set; }
        public int Numero { get; set; }
        public string Favorecido { get; set; }
    }
}
