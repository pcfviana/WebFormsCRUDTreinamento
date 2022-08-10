using Implanta.Common;
using System;
using System.Collections.Generic;

namespace Implanta.WebFormsCRUD.IView.Base
{
    public interface IViewBusca<T, F> : IViewImplanta
    {
        List<T> ListaResultado { get; set; }

        event EventHandler<EventParam<F>> Busca;
        event EventHandler Inicia;
    }
}
