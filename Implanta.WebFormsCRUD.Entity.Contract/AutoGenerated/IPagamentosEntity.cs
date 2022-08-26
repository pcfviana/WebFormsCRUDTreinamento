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
        int IdClassificacao { get; set; }
    }
}
