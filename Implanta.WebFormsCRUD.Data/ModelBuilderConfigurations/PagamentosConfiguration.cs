using System.Data.Entity.ModelConfiguration;

namespace Implanta.WebFormsCRUD.Data.ModelBuilderConfigurations
{
    public class PagamentosConfiguration : EntityTypeConfiguration<Pagamentos>
    {
        public PagamentosConfiguration()
        {
            ToTable("Pagamentos", "WebFormsCRUD");
            HasKey(c => c.IdPagamento);

            Property(c => c.IdPagamento).HasColumnName("IdPagamento").HasColumnType("UNIQUEIDENTIFIER").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(c => c.Numero).HasColumnName("Numero").HasColumnType("int").IsRequired();
            Property(c => c.DataPagamento).HasColumnName(@"DataPagamento").HasColumnType("DATETIME2").IsRequired();
            Property(c => c.Valor).HasColumnName("Valor").HasColumnType("numeric").IsRequired();
            Property(c => c.Descricao).HasColumnName("Descricao").HasColumnType("VARCHAR").IsRequired();
            Property(x => x.Favorecido).HasColumnName("Favorecido").HasColumnType("VARCHAR").IsRequired();
            Property(x => x.CPF).HasColumnName("CPF").HasColumnType("VARCHAR").IsRequired();
        }
    }
}
