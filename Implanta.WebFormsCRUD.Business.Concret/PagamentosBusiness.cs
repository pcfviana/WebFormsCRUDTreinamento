using Implanta.Common;
using Implanta.WebFormsCRUD.Business.Contract;
using Implanta.WebFormsCRUD.Data;
using Implanta.WebFormsCRUD.Entity.Concret;
using Implanta.WebFormsCRUD.Entity.Concret.FilterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implanta.WebFormsCRUD.Business.Concret
{
    public partial class PagamentosBusiness
    {
        const decimal VALOR_LIMITE_DIARIO = 10000M;
        public Operacao<PagamentosEntity> Salvar(Operacao<PagamentosEntity> operacao)
        {
            if (operacao != null && operacao.Entidade == null)
            {
                operacao.AdicionarErro("Entidade nullo");
                return operacao;
            }

            if(operacao.Entidade.Acao != EntityAction.Delete)
                operacao.AdicionarErro(ValidarCampos(operacao.Entidade));

            if (operacao.Erro)
                return operacao;

            try
            {
                if (operacao.Entidade.Acao == EntityAction.New)
                    operacao.Entidade.Numero = GetNumeroPagamento();

                using (var db = new Implanta.WebFormsCRUD.Data.WebFormsCRUDDbContext())
                {
                    operacao.AdicionarErro(Salvar(operacao.Entidade, db, true));
                }

            }
            catch (Exception ex)
            {
                operacao.AdicionarErro(ex.Message);
            }

            if (!operacao.Erro)
                operacao.Entidade.Acao = EntityAction.None;


            return operacao;
        }


        public PagamentosEntity Recuperar(Guid idPagamento)
        {
            PagamentosEntity pagamento = Buscar(
                new FilterEntityPagamento
                {
                    IdPagamento = idPagamento
                })[0];

            return pagamento;
        }

        public List<PagamentosEntity> Buscar(FilterEntityPagamento filtro)
        {
            List<PagamentosEntity> retorno = new List<PagamentosEntity>();

            using (var db = new Implanta.WebFormsCRUD.Data.WebFormsCRUDDbContext())
            {
                var query = from p in db.Pagamentos
                            select p;

                if (filtro.IdPagamento != null && filtro.IdPagamento != Guid.Empty)
                    query = query.Where(o => o.IdPagamento == filtro.IdPagamento);

                if (filtro.Numero > 0)
                    query = query.Where(o => o.Numero == filtro.Numero);

                if (!string.IsNullOrEmpty(filtro.Favorecido))
                    query = query.Where(o => o.Favorecido.StartsWith(filtro.Favorecido));

                query = query.OrderBy(o => o.Numero).ThenBy(o => o.DataPagamento);
                query = query.Skip(filtro.Skip).Take(filtro.Take);

                foreach (var item in query)
                {
                    var entity = new PagamentosEntity();
                    Common.PropertyCopy.Copy(item, entity);
                    retorno.Add(entity);
                }
            }

            return retorno;
        }
        public List<PagamentosGridEntity> BuscarParaGridView(FilterEntityPagamento filtro)
        {
            List<PagamentosGridEntity> listaRetorno = new List<PagamentosGridEntity>();

            using (var dataBase = new WebFormsCRUDDbContext())
            {
                var query = from p in dataBase.Pagamentos
                            select p;

                if (filtro.Numero > 0)
                    query = query.Where(o => o.Numero == filtro.Numero);

                if (!string.IsNullOrEmpty(filtro.Favorecido))
                    query = query.Where(o => o.Favorecido.StartsWith(filtro.Favorecido));

                query = query.OrderBy(o => o.Numero).ThenBy(o => o.DataPagamento);
                query = query.Skip(filtro.Skip).Take(filtro.Take);

                foreach (var itemDb in query)
                {
                    var entity = new PagamentosGridEntity();
                    Common.PropertyCopy.Copy(itemDb, entity);
                    listaRetorno.Add(entity);
                }
            }

            return listaRetorno;
        }

        internal ActionReturn ValidarCampos(PagamentosEntity pagamento)
        {
            ActionReturn retorno = new ActionReturn();


            if (pagamento.CPF.CPFValido())
                retorno.AdicionarErro("CPF inválido");

            ValidarCampoNome(retorno, pagamento);
            ValidarCPF(retorno, pagamento);
            ValidarLimiteDiario(retorno, pagamento);

            return retorno;
        }

        private void ValidarCampoNome(ActionReturn action , PagamentosEntity pagamento)
        {
            if (string.IsNullOrEmpty(pagamento.Favorecido))
                action.AdicionarErro("O favorecido deve ser informado");
            else if(pagamento.Favorecido.Length > 200)
                action.AdicionarErro("O campo favorecido deve ter no máximo 200 caracteres");
        }

        private void ValidarCPF(ActionReturn action, PagamentosEntity pagamento)
        {
        }

        private void ValidarLimiteDiario(ActionReturn action, PagamentosEntity pagamento)
        {
            if(pagamento.Acao != EntityAction.Delete)
            {
                if(pagamento.Valor > VALOR_LIMITE_DIARIO)
                {
                    action.AdicionarErro("O limite diário permitido é de R$ 10.000");
                }
                else
                {
                    using(var db = new WebFormsCRUDDbContext())
                    {
                        var somaPagamentos = db.Pagamentos
                            .Where(p => p.CPF == pagamento.CPF &&
                                        p.DataPagamento == pagamento.DataPagamento &&
                                        p.IdPagamento != pagamento.IdPagamento)
                            .ToList()
                            .Sum(p => p.Valor);

                        if((somaPagamentos + pagamento.Valor) > VALOR_LIMITE_DIARIO)
                        {
                            string msg = string.Format("O limite diário permitido é de R$ 10.000,00. Já existe(m) pagamento(s) que totalizam R$ {0}.", somaPagamentos.ToString("n2"));
                            action.AdicionarErro(msg);
                        }
                    }
                }
            }
        }

        internal int GetNumeroPagamento()
        {
            using (var db = new Implanta.WebFormsCRUD.Data.WebFormsCRUDDbContext())
            {
                var max = db.Pagamentos.Any() ? db.Pagamentos.Max(p => p.Numero) : 0;

                return max + 1;
            }
        }
    }
}
