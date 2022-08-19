using Implanta.WebFormsCRUD.Business.Contract;
using Implanta.WebFormsCRUD.Business.Factory;
using Implanta.WebFormsCRUD.Entity.Concret;
using Implanta.WebFormsCRUD.IView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implanta.WebFormsCRUD.Presenter
{
    public  class PagamentoPresenter : Base.PresenterBase<IPagamentosBusiness, IPagamentoView, PagamentosEntity >
    {
        public PagamentoPresenter(IPagamentoView view) 
            : base(WebFormsCRUDFactory.PagamentosBusiness())
        {
            this.View = view;
            Inicializar();
        }

        private void Inicializar()
        {
            View.Inicia += View_Inicia;
            View.Novo += View_Novo;
            View.Salvar += View_Salvar;
            View.Abrir += View_Abrir;
        }

        private void View_Inicia(object sender, EventArgs e)
        {
            
        }

        private void View_Novo(object sender, EventArgs e)
        {
            var novoPagamento = new PagamentosEntity 
            {
                Acao = Common.EntityAction.New,
                IdPagamento = Guid.NewGuid(),
                DataPagamento = DateTime.Now,
                Numero = 0
            };

            SetView(novoPagamento);
        }

        private void View_Salvar(object sender, EventArgs e)
        {
            if (View.Acao == Common.EntityAction.None)
                View.Acao = Common.EntityAction.Update;

            NovaOperacao();

            Operacao.Entidade = GetView();
            Operacao = BusinessFactory.Salvar(Operacao);

            if (!Operacao.Erro && View.Acao != Common.EntityAction.Delete)
                SetView(Operacao.Entidade);

            View.Erro = Operacao.Erro;
            View.Mensagens = Operacao.Mensagens;
        }
        private void View_Abrir(object sender, Common.EventParam<Guid> e)
        {
            PagamentosEntity pagamento = BusinessFactory.Recuperar(e.Parametro);
            SetView(pagamento);
        }

        private void SetView(PagamentosEntity pagamento)
        {
            View.Acao = pagamento.Acao;
            View.IdPagamento = pagamento.IdPagamento;
            View.Numero = pagamento.Numero;
            View.DataPagamento = pagamento.DataPagamento;
            View.Descricao = pagamento.Descricao;
            View.Favorecido = pagamento.Favorecido;
            View.CPF = pagamento.CPF;
            View.Valor = pagamento.Valor;
            View.BloquearExclusao = pagamento.Numero == 0;
        }

        private PagamentosEntity GetView()
        {
            var pagamento = new PagamentosEntity 
            {
                Acao = View.Acao,
                IdPagamento = View.IdPagamento,
                DataPagamento = View.DataPagamento,
                Numero = View.Numero,
                Descricao = View.Descricao,
                Favorecido = View.Favorecido,
                CPF = View.CPF,
                Valor = View.Valor
            };

            return pagamento;
        }
    }
}
