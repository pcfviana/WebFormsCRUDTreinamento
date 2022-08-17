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
using Implanta.WebFormsCRUD.Business.Contract;
using Implanta.WebFormsCRUD.Data;
using Implanta.WebFormsCRUD.Entity.Concret;
using Implanta.WebFormsCRUD.Entity.Contract;
using System;
using System.Collections.Generic;

namespace Implanta.WebFormsCRUD.Business.Concret
{
	public partial class PagamentosBusiness : IPagamentosBusiness
	{
		#region Converte
		private Pagamentos converte(IPagamentosEntity pagamentosEntity)
		{
			return new Pagamentos
			{
				IdPagamento = pagamentosEntity.IdPagamento,
				CPF = pagamentosEntity.CPF,
				DataPagamento = pagamentosEntity.DataPagamento,
				Descricao = pagamentosEntity.Descricao,
				Favorecido = pagamentosEntity.Favorecido,
				Numero = pagamentosEntity.Numero,
				Valor = pagamentosEntity.Valor
			};
		}

		private PagamentosEntity converte(Pagamentos pagamentos)
		{
			return new PagamentosEntity
			{
				IdPagamento = pagamentos.IdPagamento,
				CPF = pagamentos.CPF,
				DataPagamento = pagamentos.DataPagamento,
				Descricao = pagamentos.Descricao,
				Favorecido = pagamentos.Favorecido,
				Numero = pagamentos.Numero,
				Valor = pagamentos.Valor,
				Acao = EntityAction.None
			};
		}
		#endregion

		#region Salvar

		#region Protected

		internal ActionReturn SalvarEntidade(Operacao<PagamentosEntity> operacao)
		{
			using (var db = new WebFormsCRUDDbContext())
			{
				return Salvar(operacao.Entidade, db, true);
			}
		}


		internal ActionReturn SalvarEntidade(Operacao<List<PagamentosEntity>> operacao)
		{
			using (var db = new WebFormsCRUDDbContext())
			{
				return Salvar(operacao.Entidade, db, true);
			}
		}

		internal ActionReturn Salvar(PagamentosEntity pagamentosEntity, WebFormsCRUDDbContext context, bool save)
		{
			ActionReturn retorno = new ActionReturn();

			try
			{
				switch (pagamentosEntity.Acao)
				{
					case EntityAction.New:
						retorno = inserir(context, pagamentosEntity);
						break;
					case EntityAction.Update:
						retorno = atualizar(context, pagamentosEntity);
						break;
					case EntityAction.Delete:
						retorno = deletar(context, pagamentosEntity);
						break;
					case EntityAction.None:
					default:
						break;
				}

				if (retorno.Erro)
					return retorno;

				if (save)
					context.SaveChanges();

				return retorno;
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				if (ex.Number == 547)
				{
					System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"table\S*(?:\s\S+)");

					string childTable = string.Empty;

					var match = regex.Match(ex.Message);

					if (match.Success)
					{
						childTable = match.Value.Replace("table", "").Replace(",", "").Replace("'", "");
					}

					retorno.AdicionarErro(ex.Message);
				}
				else
				{
					retorno.AdicionarErro(ex.Message);
				}

				return retorno;
			}
			catch (TimeoutException ex)
			{
				retorno.AdicionarErro(ex.Message);
				return retorno;
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null && ex.InnerException is System.Data.SqlClient.SqlException && (ex.InnerException as System.Data.SqlClient.SqlException).Number == 547)
				{
					System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"table\S*(?:\s\S+)");

					string childTable = string.Empty;

					var match = regex.Match(ex.InnerException.Message);

					if (match.Success)
					{
						childTable = match.Value.Replace("table", "").Replace(",", "").Replace("'", "");
					}

					retorno.AdicionarErro(ex.Message);
				}
				else
				{
					retorno.AdicionarErro(ex.Message);
				}
				return retorno;
			}
		}

		internal ActionReturn Salvar(List<PagamentosEntity> listPagamentosEntity, WebFormsCRUDDbContext context, bool save)
		{
			ActionReturn retorno = new ActionReturn();

			try
			{
				listPagamentosEntity.ForEach(ent =>
				{
					switch (ent.Acao)
					{
						case EntityAction.New:
							retorno = inserir(context, ent);
							break;
						case EntityAction.Update:
							retorno = atualizar(context, ent);
							break;
						case EntityAction.Delete:
							retorno = deletar(context, ent);
							break;
						case EntityAction.None:
						default:
							break;
					};
				});

				if (retorno.Erro)
					return retorno;

				if (save)
					context.SaveChanges();

				return retorno;
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				retorno.AdicionarErro(ex.Message);
				return retorno;
			}
			catch (TimeoutException ex)
			{
				retorno.AdicionarErro(ex.Message);
				return retorno;
			}
			catch (Exception ex)
			{
				retorno.AdicionarErro(ex.Message);
				return retorno;
			}
		}




		private ActionReturn deletar(WebFormsCRUDDbContext db, PagamentosEntity pagamentosEntity)
		{
			ActionReturn retorno = new ActionReturn();

			try
			{
				var toDelete = new Data.Pagamentos
				{
					IdPagamento = pagamentosEntity.IdPagamento
				};

				db.Entry(toDelete).State = System.Data.Entity.EntityState.Deleted;
			}
			catch (Exception ex)
			{
				retorno.AdicionarErro(ex.Message);
			}
			return retorno;
		}

		private ActionReturn inserir(WebFormsCRUDDbContext db, PagamentosEntity pagamentosEntity)
		{
			ActionReturn retorno = new ActionReturn();

			try
			{
				TratarEntidadeMonitoravel(db, pagamentosEntity);

				Pagamentos PagamentosData = converte(pagamentosEntity);

				db.Set<Pagamentos>().Add(PagamentosData);
			}
			catch (Exception ex)
			{
				retorno.AdicionarErro(ex.Message);
			}

			return retorno;

		}

		private void TratarEntidadeMonitoravel(WebFormsCRUDDbContext db, PagamentosEntity entidade) { }

		private ActionReturn atualizar(WebFormsCRUDDbContext db, PagamentosEntity pagamentosEntity)
		{
			ActionReturn retorno = new ActionReturn();

			try
			{
				TratarEntidadeMonitoravel(db, pagamentosEntity);

				Pagamentos pagamentosData = converte(pagamentosEntity);

				db.Entry(pagamentosData).State = System.Data.Entity.EntityState.Modified;
			}
			catch (Exception Ex)
			{
				retorno.AdicionarErro(Ex.Message);
			}

			return retorno;
		}

		#endregion

		#endregion

		public bool PodeExcluir(Guid idPagamento)
		{
			return true;
		}
	}
}