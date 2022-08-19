using Implanta.Common;
using Implanta.WebFormsCRUD.Entity.Concret;
using Implanta.WebFormsCRUD.Entity.Concret.FilterEntity;
using Implanta.WebFormsCRUD.IView;
using Implanta.WebFormsCRUD.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Implanta.WebFormsCRUD.View.Web
{
    public partial class pagamentos : Base.WebPageBase<PagamentosPresenter>, IPagamentosView
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!DesignMode)
            {
                Presenter = new PagamentosPresenter(this);
                btnBuscar.Click += BtnBuscar_Click;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Busca(this, new EventParam<FilterEntityPagamento>(Filtro));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Inicia(this, EventArgs.Empty);
            }

            CarregarGridView();
        }

        private void CarregarGridView()
        {
            gridViewResultado.DataSource = ListaResultado;
            gridViewResultado.DataBind();
        }

        public List<PagamentosGridEntity> ListaResultado 
        {
            get
            {
                return Session["lista"] as List<PagamentosGridEntity>;
            }
            set
            {
                Session["lista"] = value;
                CarregarGridView();
            }
        }

        public FilterEntityPagamento Filtro
        {
            get
            {
                var filtro = new FilterEntityPagamento();
                filtro.Favorecido = txtFavorecido.Text;

                if (!string.IsNullOrEmpty(txtNumero.Text))
                    filtro.Numero = int.Parse(txtNumero.Text);

                return filtro;
            }
        }

        public event EventHandler<EventParam<FilterEntityPagamento>> Busca;
        public event EventHandler Inicia;
    }
}