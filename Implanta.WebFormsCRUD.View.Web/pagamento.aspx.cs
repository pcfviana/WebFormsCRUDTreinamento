using Implanta.Common;
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
    public partial class pagamento : Base.WebPageBase<PagamentoPresenter>, IPagamentoView
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if(!DesignMode)
            {
                Presenter = new PagamentoPresenter(this);
                btnSalvar.Click += BtnSalvar_Click;
                btnExcluir.Click += BtnExcluir_Click;
                btnCancelar.Click += BtnCancelar_Click;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Inicia(this, EventArgs.Empty);

                if (Request.QueryString["cod"] != null)
                {
                    Guid idPagamento = Guid.Parse(Request.QueryString["cod"].ToString());
                    Abrir(this, new EventParam<Guid>(idPagamento));
                }
                else
                    Novo(this, EventArgs.Empty);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            PaginaRedirect = "pagamentos.aspx";

            Acao = EntityAction.Delete;
            Salvar(this, EventArgs.Empty);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            Salvar(this, EventArgs.Empty);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("pagamentos.aspx");
        }

        [SaveInViewState]
        public bool Erro { get; set; }

        [SaveInViewState]
        public EntityAction Acao { get; set; }

        [SaveInViewState]
        public Guid IdPagamento { get; set; }
        public DateTime DataPagamento
        {
            get
            {
                return DateTime.Parse(txtData.Text);
            }
            set
            {
                txtData.Text = value.ToString("yyyy-MM-dd");
            }
        }
        public int Numero
        {
            get
            {
                return int.Parse(txtNumero.Text);
            }
            set
            {
                txtNumero.Text = value.ToString();
            }
        }
        public decimal Valor
        {
            get
            {
                return decimal.Parse(txtValor.Text);
            }
            set
            {
                txtValor.Text = value.ToString();
            }
        }
        public string Descricao
        {
            get
            {
                return txtDescricao.Text;
            }
            set
            {
                txtDescricao.Text = value;
            }
        }
        public string Favorecido
        {
            get
            {
                return txtFavorecido.Text;
            }
            set
            {
                txtFavorecido.Text = value;
            }
        }
        public string CPF
        {
            get
            {
                return txtCPF.Text;
            }
            set
            {
                txtCPF.Text = value;
            }
        }
        public List<string> Mensagens 
        { 
            set 
            {
                ExibirMensagem(value, Erro);
            }  
        }

        public bool BloquearExclusao 
        {
            set 
            {
                if (value)
                {
                    btnExcluir.Enabled = false;
                }
                else
                    btnExcluir.Enabled = true;
            }
         }

        public event EventHandler Salvar;
        public event EventHandler Novo;
        public event EventHandler Inicia;
        public event EventHandler<EventParam<Guid>> Abrir;
    }
}