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
using Implanta.WebFormsCRUD.Entity.Concret;
using System;

namespace Implanta.WebFormsCRUD.Business.Contract
{
    public partial interface IPagamentosBusiness
    {
        Operacao<PagamentosEntity> Salvar(Operacao<PagamentosEntity> operacao);

        bool PodeExcluir(Guid idadiantamento);
    }
}
