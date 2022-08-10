using System;

namespace Implanta.WebFormsCRUD.Data
{
    public class Pagamentos
    {
        public Guid IdPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public int Numero { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string Favorecido { get; set; }
        public string CPF { get; set; }

    }
}
