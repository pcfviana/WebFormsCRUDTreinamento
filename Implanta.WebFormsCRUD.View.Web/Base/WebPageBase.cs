using Implanta.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Implanta.WebFormsCRUD.View.Web.Base
{
    public abstract class WebPageBase<TPresenter> : Common.WebPageBase<TPresenter>
        where TPresenter : IPresenterBase
    {
        public string PaginaRedirect { get; set; }

        public void ExibirMensagem(List<string> mensagens, bool erro)
        {
            if (!erro && !string.IsNullOrEmpty(PaginaRedirect))
            {
                Response.Redirect(PaginaRedirect);
            }
            else
            {
                string cuteAlert = "cuteAlert({type: 'success', title : 'Sucesso!', message : 'Operação realizada com sucesso!'})";

                if (erro)
                {
                    cuteAlert = "cuteAlert({type: 'error', title : 'Erro!', message : '" + mensagens.FirstOrDefault() + "'})";
                }

                ScriptManager.RegisterStartupScript(this.Page, GetType(), "alert_" + Guid.NewGuid(), cuteAlert, true);
            }
        }
    }
}