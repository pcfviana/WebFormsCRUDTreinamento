/*******************************************************************************
*                          ATENÇÃO												
* O codigo deste arquivo foi gerado de forma automatica!						
* Toda e qualquer alteração feito neste arquivo será descartada quando o mesmo	
* for regerado!																	
*																				
* Caso precise adicionar uma propriedade, metodo, etc, crie uma nova 			
* classe/interface com o mesmo nome e namespace e marque-a como 'partial'	    
* 																				
*******************************************************************************/

using Implanta.Common;
using Implanta.WebFormsCRUD.Entity.Contract;
using System;

namespace Implanta.WebFormsCRUD.Entity.Concret
{
    public partial class PagamentosEntity : BaseEntity, IPagamentosEntity
    {
        public override Guid Id 
        {
            get
            {
                return IdPagamento;
            }
            set 
            {
                IdPagamento = value;
            }
        }
        public Guid IdPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public int Numero { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string Favorecido { get; set; }
        public string CPF { get; set; }
        public int IdClassificacao { get; set; }
    }
}
