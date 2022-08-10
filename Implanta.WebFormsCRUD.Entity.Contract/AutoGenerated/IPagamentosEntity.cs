using Implanta.Common;
using System;

namespace Implanta.WebFormsCRUD.Entity.Contract
{
    public partial interface IPagamentosEntity
    {
        EntityAction Acao { get; set; }
        Guid IdPagamento { get; set; }
        DateTime DataPagamento { get; set; }
        int Numero { get; set; }
        decimal Valor { get; set; }
        string Descricao { get; set; }
        string Favorecido { get; set; }
        string CPF { get; set; }
    }
}
